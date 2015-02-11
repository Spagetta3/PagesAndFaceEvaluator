﻿using System;
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
using Nancy;
using Nancy.Hosting.Self;
using System.Net.Sockets;

namespace PagesAndFaceEvaluator
{
    public partial class Main : Form
    {
        private Capture capture;
        private bool captureInProgress; 

        public Main()
        {
            // run netsh.exe as admin and add: netsh http add urlacl url=http://+:8799/ user=Everyone
            NancyHost host;
            InitializeComponent();
            string URL = "http://localhost:8799";
            host = new NancyHost(new Uri(URL));
            host.Start();
        }

        private void Main_Load(object sender, EventArgs e)
        {

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
                List<Rectangle> faces = new List<Rectangle>();
                List<Rectangle> eyes = new List<Rectangle>();
                DetectFace.Detect(image, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml", faces, eyes);

                foreach (Rectangle face in faces)
                    image.Draw(face, new Bgr(Color.Red), 2);

                foreach (Rectangle eye in eyes)
                    image.Draw(eye, new Bgr(Color.Blue), 2);
                
               return image; 
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            ReleaseData();
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
