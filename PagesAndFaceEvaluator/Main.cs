using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
using Nancy;
using Nancy.Hosting.Self;
using System.Net.Sockets;
using System.Timers;
using Timer = System.Timers.Timer;

namespace PagesAndFaceEvaluator
{
    public partial class Main : Form
    {
        private Timer tmr;
        private object processFrameMutex;
        private bool frameProcessing = false;
        private Capture capture;
        private bool captureInProgress;
        private Stopwatch watchFace;
        private Stopwatch watchEyes;
        private bool faceDetected;
        private bool eyesDetected;
        private bool firstDetectionOfFace;
        private bool firstDetectionOfEyes;
        private Stopwatch wholeTime;

        public Main()
        {
            // run netsh.exe as admin and add: netsh http add urlacl url=http://+:8799/ user=Everyone
            NancyHost host;
            InitializeComponent();
            string URL = "http://localhost:8799";
            host = new NancyHost(new Uri(URL));
            host.Start();
            faceDetected = false;
            eyesDetected = false;
            firstDetectionOfFace = true;
            firstDetectionOfEyes = true;
            StartAnalyze();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void ProcessFrame()
        {
            DetectFaceInImageFrame(capture.QueryFrame());
        }

        private void ReleaseData()
        {
            if (capture != null)
                capture.Dispose();
        }

        private void StartAnalyze()
        {
            wholeTime = Stopwatch.StartNew();
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
                processFrameMutex = new object();
                frameProcessing = false;

                tmr = new Timer();
                tmr.Interval = 1000;
                tmr.Elapsed += TimerElapsed;
                tmr.Start();
            }
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
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

        private void DetectFaceInImageFrame(Image<Bgr, Byte> image)
        {
                List<Rectangle> faces = new List<Rectangle>();
                List<Rectangle> eyes = new List<Rectangle>();
                DetectFace.Detect(image, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml", faces, eyes);

                if (faces.Count == 0 && faceDetected == true)
                {
                    watchFace.Stop();
                    faceDetected = false;
                }
                else if (faces.Count != 0 && faceDetected == false)
                {
                    if (firstDetectionOfFace)
                    {
                        watchFace = Stopwatch.StartNew();
                        firstDetectionOfFace = false;
                    }
                    else
                        watchFace.Start();
                    faceDetected = true;
                }

                if (eyes.Count == 0 && eyesDetected == true)
                {
                    watchEyes.Stop();
                    eyesDetected = false;
                }
                else if (eyes.Count != 0 && eyesDetected == false)
                {
                    if (firstDetectionOfEyes)
                    {
                        watchEyes = Stopwatch.StartNew();
                        firstDetectionOfEyes = false;
                    }
                    else
                        watchEyes.Start();
                    eyesDetected = true;
                }

                //foreach (Rectangle face in faces)
                //    image.Draw(face, new Bgr(Color.Red), 2);

                //foreach (Rectangle eye in eyes)
                //    image.Draw(eye, new Bgr(Color.Blue), 2);
                
               return; 
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            ReleaseData();

            watchFace.Stop();
            watchEyes.Stop();
            wholeTime.Stop();

            string path = @"D:\Programming\Visual Studio 2013\Projects\PagesAndFaceEvaluator\PagesAndFaceEvaluator\statistics\times.txt";
            string rowToWrite = "Face: " + watchFace.ElapsedMilliseconds.ToString() + " ms; Eyes: " + watchEyes.ElapsedMilliseconds.ToString() + " ms; Whole Time: " + wholeTime.ElapsedMilliseconds.ToString() + " ms;";
            using (StreamWriter w = File.AppendText(path))
            {
                w.WriteLine(rowToWrite);
                w.Flush();
            }
            this.Close();
            Application.Exit();
        }
    }

    public class MainMod: NancyModule
    {
        public MainMod()
        {
            Get["/"] = x =>
            {
                return "Server is running...";
            };

        }
    }
}
