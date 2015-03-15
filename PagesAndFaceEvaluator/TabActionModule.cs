using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Nancy;
using Nancy.Hosting.Self;
using Nancy.ModelBinding;
using System.Net.Sockets;

namespace PagesAndFaceEvaluator
{
    public class TabActionModule : NancyModule
    {
        private string requestSavePath = "Statistics";

        public class ReceivedData
        {
            public string Data { get; set; }
        }

        public TabActionModule()
        {
            Post["/processTabData"] = _ =>
            {
                ReceivedData data = this.Bind<ReceivedData>();
                if (data.Data != null)
                {
                    if (Statistics.Instance != null)
                        Statistics.Instance.GetActualData();

                    DateTime timeOfRequest = DateTime.Now;
                    string[] wholeString = data.Data.Split('=');
                    string urlWithAction = null;
                    for (int i = 1; i <= wholeString.Length - 1; i++ )
                        urlWithAction = wholeString[i];

                    wholeString = urlWithAction.Split(' ');
                    string url = wholeString[0];
                    string action = wholeString[1];

                    string aid = ConfigHelper.GetValue(ConfigHelper.ConfigKey.AID.ToString());
                    {
                        if (aid != "")
                            requestSavePath += "/" + aid + "/";
                    }

                    if (!Directory.Exists(requestSavePath))
                        Directory.CreateDirectory(requestSavePath);

                    DateTime dateNow = DateTime.Now;
                    string currentPath = requestSavePath + dateNow.ToString("yyyy_MM_dd") + ".txt";

                    string lastPath = ConfigHelper.GetValue(ConfigHelper.ConfigKey.LastPath.ToString());
                    
                    if (lastPath != "")
                    {
                        string rowToWrite = lastPath + ";" + timeOfRequest + ";" + Statistics.Instance.ActualWholeTime + ";" + Statistics.Instance.ActualFaceTime + ";" + Statistics.Instance.ActualEyesTime;
                        using (StreamWriter w = File.AppendText(currentPath))
                        {
                            w.WriteLine(rowToWrite);
                            w.Flush();
                        }
                    }

                    string lastPathWithAction = url + ";" + action;
                    if (ConfigHelper.ChangeValue(ConfigHelper.ConfigKey.LastPath.ToString(), lastPathWithAction))
                        return HttpStatusCode.OK;
                    else
                        return HttpStatusCode.InternalServerError;
                }
                else
                    return HttpStatusCode.InternalServerError;
            };
        }
    }
}
