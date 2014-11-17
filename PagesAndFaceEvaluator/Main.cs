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
using System.IO;

namespace PagesAndFaceEvaluator
{
    public partial class Main : Form
    {
        private Capture capture;
        private bool captureInProgress; 

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void GenerateSamplesButton_Click(object sender, EventArgs e)
        {
            Capture cap = new Capture(0);
            int counter = 162;
            string path = null;
            for (; ; )
            {
                bool positive = false;

                using (Image<Bgr, byte> nextFrame = cap.QueryFrame())
                {
                    if (nextFrame != null)
                    {
                        Image<Bgr, Byte> image = cap.QueryFrame(); //Read the files as an 8-bit Bgr image  
                        long detectionTime;
                        List<Rectangle> faces = new List<Rectangle>();
                        List<Rectangle> eyes = new List<Rectangle>();
                        DetectFace.Detect(image, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml", faces, eyes, out detectionTime);
                        path = @"D:\Programming\Visual Studio 2013\Projects\PagesAndFaceEvaluator\PagesAndFaceEvaluator\BasicSamples\" + counter.ToString() + ".png";
                        image.Save(path);

                        foreach (Rectangle face in faces)
                        {
                            positive = true;
                            image.Draw(face, new Bgr(Color.Red), 2);

                        }
                        foreach (Rectangle eye in eyes)
                            image.Draw(eye, new Bgr(Color.Blue), 2);

                        if (positive)
                        {
                            path = @"D:\Programming\Visual Studio 2013\Projects\PagesAndFaceEvaluator\PagesAndFaceEvaluator\PositiveSamples\" + counter.ToString() + ".png";
                            image.Save(path);
                        }
                        else
                        {
                            path = @"D:\Programming\Visual Studio 2013\Projects\PagesAndFaceEvaluator\PagesAndFaceEvaluator\NegativeSamples\" + counter.ToString() + ".png";
                            image.Save(path);
                        }
                        counter++;
                    }
                }
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            Image<Bgr, Byte> imageFrame = DetectFaceInImageFrame(capture.QueryFrame());
            camImageBox.Image = imageFrame;        
        }

        private void ReleaseData()
        {
            if (capture != null)
                capture.Dispose();
        }

        private void StartAnalyzeButton_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                try
                {
                    capture = new Capture();
                }
                catch {}
            }

            if (capture != null)
            {
                if (captureInProgress)
                    Application.Idle -= ProcessFrame;
                else  
                    Application.Idle += ProcessFrame;

                captureInProgress = !captureInProgress;
            }
        }

        private Image<Bgr, Byte> DetectFaceInImageFrame(Image<Bgr, Byte> image)
        {
                long detectionTime;
                List<Rectangle> faces = new List<Rectangle>();
                List<Rectangle> eyes = new List<Rectangle>();
                DetectFace.Detect(image, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml", faces, eyes, out detectionTime);

                foreach (Rectangle face in faces)
                    image.Draw(face, new Bgr(Color.Red), 2);

                //foreach (Rectangle eye in eyes)
                //    image.Draw(eye, new Bgr(Color.Blue), 2);
                
               return image; 
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            ReleaseData();
            this.Close();
            Application.Exit();
        }
    }
}
