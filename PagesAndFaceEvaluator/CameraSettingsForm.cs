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
        private Capture capture;
        private bool first = true;
        private bool paused = false;

        public CameraSettingsForm()
        {
            InitializeComponent();
            StartAnalyze();
        }

        public void StartAnalyze()
        {
            if (capture == null && first)
            {
                try
                {
                    capture = new Capture();
                }
                catch
                {
                    MessageBox.Show("Nepodarilo sa spustiť kameru", "Chyba");
                }
                first = false;
            }

            ProcessFrame();
        }

        private void ProcessFrame()
        {
            if (paused)
                capture.Start();
            Image<Bgr, byte> resultImage = DetectFaceInImageFrame(capture.QueryFrame());
            capture.Pause();
            paused = true;
            ShowImage(resultImage);
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

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;
            StartAnalyze();
            this.Enabled = true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;

            capture.Stop();

            if (capture != null)
                capture.Dispose();

            this.Close();
        }
    }
}
