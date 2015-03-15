﻿using System;
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
        bool close = false;
        
        private DateTime wholeTime;
        private bool analyzeStarted = false;
        private DateTime timeToday;
        private int counter = 0;

        private Capture capture;
        
        public Main()
        {
            string AID = ConfigHelper.GetValue(ConfigHelper.ConfigKey.AID.ToString());
            if (AID == null || AID == "")
            {
                using (AIDsettings aidWindow = new AIDsettings())
                {
                    aidWindow.ShowDialog();
                    if (aidWindow.DialogResult != DialogResult.OK)
                        close = true;
                }
            }

            // run netsh.exe as admin and add: netsh http add urlacl url=http://+:8799/ user=Everyone
            NancyHost host;
            
            InitializeComponent();
            string URL = "http://localhost:8799";
            host = new NancyHost(new Uri(URL));
            host.Start();

            Statistics.Initialize();
            Statistics.Instance.FaceDetected = false;
            Statistics.Instance.EyesDetected = false;
            Statistics.Instance.FirstDetectionOfFace = true;
            Statistics.Instance.FirstDetectionOfEyes = true;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (close)
                this.Close();
            string previousTime = ConfigHelper.GetValue(ConfigHelper.ConfigKey.WholeTime.ToString());
            if (previousTime != "")
                previousTime += " s";
            else
                previousTime = "0 s";
            this.wholeStatisticsTextBox.Text = previousTime;
            this.statisticTextBox.Text = "0 s";
            return;
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
            analyzeStarted = true;
            timeToday = DateTime.Now;
            wholeTime = DateTime.Now;
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
                {
                    frameProcessing = true;
                    counter++;
                    if (counter % 10 == 0)
                    {
                        TimeSpan tmp = DateTime.Now - timeToday;
                        double time = tmp.TotalMilliseconds / 1000.0;
                        this.statisticTextBox.Text = time.ToString() + " s";

                        double previousTime = 0;
                        string text = this.wholeStatisticsTextBox.Text;
                        string[] partsText = text.Split(' ');
                        previousTime = double.Parse(partsText[0]);
                        previousTime += time;
                        this.wholeStatisticsTextBox.Text = previousTime.ToString() + " s";
                        counter = 0;
                    }
                }
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
            Statistics.Instance.AnalyzeDetectedFaceAndEyes(faces, eyes);
                
            return; 
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (tmr != null)
                tmr.Stop();
            if (analyzeStarted)
            {
                TimeSpan tmp = DateTime.Now - wholeTime;
                double time = 0;
                time += tmp.TotalMilliseconds / 1000.0;

                string previousTime = (ConfigHelper.GetValue(ConfigHelper.ConfigKey.WholeTime.ToString()));
                if (previousTime != "")
                    time += double.Parse(previousTime);
                ConfigHelper.ChangeValue(ConfigHelper.ConfigKey.WholeTime.ToString(), time.ToString());
            }
            Cursor.Current = Cursors.WaitCursor;
            for (; ; )
            {
                if (!frameProcessing)
                    break;
            }
            ReleaseData();
            //ak vypne program a chybaju tabData, tak to treba osetrit, ze sa to nestrati, ale ulozi sa to...
            //Statistics.Instance.WriteToFileData();
            this.Close();
            Application.Exit();
        }

        private void startAnalyzeButton_Click(object sender, EventArgs e)
        {
            cameraSettingsButton.Enabled = false;
            StartAnalyze();
        }

        private void cameraSettingsButton_Click(object sender, EventArgs e)
        {
            using (CameraSettingsForm csw = new CameraSettingsForm())
            {
                csw.ShowDialog();
            }
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
