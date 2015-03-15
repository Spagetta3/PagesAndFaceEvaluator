using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.GPU;
using Emgu.CV.CvEnum;
using System.Timers;
using Timer = System.Timers.Timer;

namespace PagesAndFaceEvaluator
{
    public partial class CameraSettingsForm : Form
    {
        private Timer tmr;
        private object processFrameMutex;
        private bool frameProcessing = false;
        private Capture capture;
        private bool close = false;

        public CameraSettingsForm()
        {
            InitializeComponent();
            StartAnalyze();
        }

        public void StartAnalyze()
        {
            if (capture == null)
            {
                try
                {
                    capture = new Capture();
                }
                catch { }
            }

            if (capture != null)
            {
                processFrameMutex = new object();
                frameProcessing = false;

                tmr = new Timer();
                tmr.Interval = 1500;
                tmr.Elapsed += TimerElapsed;
                tmr.Start();
            }
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (!close)
            {
                lock (processFrameMutex)
                {
                    if (!frameProcessing)
                        frameProcessing = true;
                    else
                        return;
                }

                ProcessFrame();

                lock (processFrameMutex)
                {
                    frameProcessing = false;
                }
            }
        }

        private void ProcessFrame()
        {
            if (!close)
            {
                Image<Bgr, byte> resultImage = DetectFaceInImageFrame(capture.QueryFrame());
                ShowImage(resultImage);
            }
        }

        private void ShowImage(Image<Bgr, byte> resultImage)
        {
            camImageBox.Image = resultImage;
        }

        private Image<Bgr, byte> DetectFaceInImageFrame(Image<Bgr, Byte> image)
        {
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();
            DetectFace.Detect(image, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml", faces, eyes);

            foreach (Rectangle face in faces)
                image.Draw(face, new Bgr(Color.Red), 2);

            foreach (Rectangle eye in eyes)
                image.Draw(eye, new Bgr(Color.Blue), 2);

            return image;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            close = true;

            if (tmr != null)
                tmr.Stop();

            Cursor.Current = Cursors.WaitCursor;

            for (; ; )
            {
                if (!frameProcessing)
                    break;
            }

            if (capture != null)
                capture.Dispose();

            this.Close();
        }
    }
}
