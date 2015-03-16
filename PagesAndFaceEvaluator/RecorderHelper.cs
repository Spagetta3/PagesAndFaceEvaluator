using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagesAndFaceEvaluator
{
    public static class RecorderHelper
    {
        private static string requestSavePath = "Statistics";

        public static bool MakeRecord(string data, string option)
        {
            string path = requestSavePath;

            DateTime timeOfRequest = DateTime.Now;

            string aid = ConfigHelper.GetValue(ConfigHelper.ConfigKey.AID.ToString());
            {
                if (aid != "")
                    path += "/" + aid + "/";
            }

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            DateTime dateNow = DateTime.Now;
            string currentPath = path + dateNow.ToString("yyyy_MM_dd") + ".txt";

            string lastPath = ConfigHelper.GetValue(ConfigHelper.ConfigKey.LastPath.ToString());

            if (option == "r" || option == "e")
            {
                string url = "";
                string action = "";

                if (option == "r")
                {
                    string[] wholeString = data.Split('=');
                    string urlWithAction = null;

                    if (wholeString.Length == 1)
                        urlWithAction = wholeString[0];
                    else
                        for (int i = 1; i <= wholeString.Length - 1; i++)
                            urlWithAction = wholeString[i];

                    wholeString = urlWithAction.Split(' ');
                    url = wholeString[0];
                    action = wholeString[1];

                    string controlRequestUrl = url + ";" + action;

                    if (lastPath != "" && lastPath == controlRequestUrl)
                        return true;

                    if (url == "menu" && action == "updated")
                        return true;
                }

                if (Statistics.Instance != null)
                    Statistics.Instance.GetActualData();

                if (lastPath != "")
                {
                    string rowToWrite = lastPath + ";" + timeOfRequest + ";" + Statistics.Instance.ActualWholeTime + ";" + Statistics.Instance.ActualFaceTime + ";" + Statistics.Instance.ActualEyesTime + ";" + option;
                    using (StreamWriter w = File.AppendText(currentPath))
                    {
                        w.WriteLine(rowToWrite);
                        w.Flush();
                    }
                }

                if (url != "" && action != "")
                {
                    string lastPathWithAction = url + ";" + action;
                    if (ConfigHelper.ChangeValue(ConfigHelper.ConfigKey.LastPath.ToString(), lastPathWithAction))
                        return true;
                    else
                        return false;
                }
                return true;
            }
            else
            {
                if (lastPath != "")
                {
                    string rowToWrite;

                    if (option == "o")
                        rowToWrite = lastPath + ";" + timeOfRequest + ";" + "0;" + "0;" + "0;" + option;
                    else
                        rowToWrite = lastPath + ";" + timeOfRequest + ";" + "0;" + "0;" + "0;" + option;

                    using (StreamWriter w = File.AppendText(currentPath))
                    {
                        w.WriteLine(rowToWrite);
                        w.Flush();
                    }
                }
                return true;
            }
        }
    }
}
