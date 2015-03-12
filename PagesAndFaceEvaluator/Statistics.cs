using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagesAndFaceEvaluator
{
    class Statistics
    {
        private static Statistics instance;

        private bool faceDetected;
        private bool eyesDetected;
        private bool firstDetectionOfFace;
        private bool firstDetectionOfEyes;
        private DateTime faceDateTime;
        private DateTime eyesDateTime;
        private DateTime wholeDateTime;
        private double wholeTime = 0;
        private double faceTime = 0;
        private double eyesTime = 0;
        private double actualWholeTime = 0;
        private double actualFaceTime = 0;
        private double actualEyesTime = 0;

        private readonly string statisticsPath = "Statistics";
        private readonly string timesFileName = "times.txt";

        private Statistics()
        {
        }

        public static void Initialize()
        {
            instance = new Statistics();
        }

        public void AnalyzeDetectedFaceAndEyes(List<Rectangle> faces, List<Rectangle> eyes)
        {
            if (faces.Count == 0 && faceDetected == true)
            {
                TimeSpan tmp = DateTime.Now - faceDateTime;
                faceTime += tmp.TotalMilliseconds / 1000.0;
                faceDetected = false;
            }
            else if (faces.Count != 0 && faceDetected == false)
            {
                if (firstDetectionOfFace)
                {
                    wholeDateTime = DateTime.Now;
                    faceDateTime = DateTime.Now;
                    firstDetectionOfFace = false;
                }
                else
                    faceDateTime = DateTime.Now;
                faceDetected = true;
            }

            if (eyes.Count == 0 && eyesDetected == true)
            {
                TimeSpan tmp = DateTime.Now - eyesDateTime;
                eyesTime += tmp.TotalMilliseconds / 1000.0;
                eyesDetected = false;
            }
            else if (eyes.Count != 0 && eyesDetected == false)
            {
                if (firstDetectionOfEyes)
                {
                    eyesDateTime = DateTime.Now;
                    firstDetectionOfEyes = false;
                }
                else
                    eyesDateTime = DateTime.Now;
                eyesDetected = true;
            }

            return;
        }

        public void GetActualData()
        {
            TimeSpan tmp;

            if (faceDetected)
            {
                tmp = DateTime.Now - faceDateTime;
                faceTime += tmp.TotalMilliseconds / 1000.0;
                actualFaceTime = faceTime;
                faceTime = 0;
            }

            if (eyesDetected)
            {
                tmp = DateTime.Now - eyesDateTime;
                eyesTime += tmp.TotalMilliseconds / 1000.0;
                actualEyesTime = eyesTime;
                eyesTime = 0;
            }

            if (!firstDetectionOfFace)
            {
                tmp = DateTime.Now - wholeDateTime;
                wholeTime += tmp.TotalMilliseconds / 1000.0;
                actualWholeTime = wholeTime;
                wholeTime = 0;
            }

            faceDetected = false;
            eyesDetected = false;
            firstDetectionOfFace = true;
            firstDetectionOfEyes = true;

            return;
        }

        //public void WriteToFileData()
        //{
        //    TimeSpan tmp;

        //    if (faceDetected)
        //    {
        //        tmp = DateTime.Now - faceDateTime;
        //        faceTime += tmp.TotalMilliseconds / 1000.0;
        //    }

        //    if (eyesDetected)
        //    {
        //        tmp = DateTime.Now - eyesDateTime;
        //        eyesTime += tmp.TotalMilliseconds / 1000.0;
        //    }

        //    if (!firstDetectionOfFace)
        //    {
        //        tmp = DateTime.Now - wholeDateTime;
        //        wholeTime += tmp.TotalMilliseconds / 1000.0;
        //    }

        //    if (!Directory.Exists(statisticsPath))
        //        Directory.CreateDirectory(statisticsPath);

        //    string rowToWrite = "Face: " + faceTime.ToString() + " s; Eyes: " + eyesTime.ToString() + " s; Whole Time: " + wholeTime.ToString() +" s;";
        //    using (StreamWriter w = File.AppendText(Path.Combine(statisticsPath, timesFileName)))
        //    {
        //        w.WriteLine(rowToWrite);
        //        w.Flush();
        //    }
        //}

        public static Statistics Instance { get { return instance; } }

        public bool FaceDetected { get { return faceDetected; } set { faceDetected = value; } }
        public bool EyesDetected { get { return eyesDetected; } set { eyesDetected = value; } }
        public bool FirstDetectionOfFace { get { return firstDetectionOfFace; } set { firstDetectionOfFace = value; } }
        public bool FirstDetectionOfEyes { get { return firstDetectionOfEyes; } set { firstDetectionOfEyes = value; } }
        public DateTime FaceDateTime { get { return faceDateTime; } set { faceDateTime = value; } }
        public DateTime EyesDateTime { get { return eyesDateTime; } set { eyesDateTime = value; } }
        public DateTime WholeDateTime { get { return wholeDateTime; } set { wholeDateTime = value; } }
        public double WholeTime { get { return wholeTime; } set { wholeTime = value; } }
        public double FaceTime { get { return faceTime; } set { faceTime = value; } }
        public double EyesTime { get { return eyesTime; } set { eyesTime = value; } }
        public double ActualWholeTime { get { return actualWholeTime; } set { actualWholeTime = value; } }
        public double ActualFaceTime { get { return actualFaceTime; } set { actualFaceTime = value; } }
        public double ActualEyesTime { get { return actualEyesTime; } set { actualEyesTime = value; } }
    }
}
