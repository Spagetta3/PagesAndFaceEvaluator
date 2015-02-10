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
                    DateTime timeOfRequest = DateTime.Now;
                    // ToDO tu stopnut cas a zastavit cas merania pritomnosti tvare
                    string[] wholeString = data.Data.Split('=');
                    string urlWithAction = null;
                    for (int i = 1; i <= wholeString.Length - 1; i++ )
                        urlWithAction = wholeString[i];

                    wholeString = urlWithAction.Split(' ');
                    string url = wholeString[0];
                    string action = wholeString[1];
                    //string[] filePaths = Directory.GetFiles(@"D:\Programming\Visual Studio 2013\Projects\PagesAndFaceEvaluator\PagesAndFaceEvaluator\Statistics");
                    string currentPath = url + ".txt";
                    if (currentPath.StartsWith("http://"))
                        currentPath = currentPath.Replace("http://","");
                    else if (currentPath.StartsWith("https://"))
                        currentPath = currentPath.Replace("https://", "");
                    currentPath = currentPath.Replace("/", ".");
                    currentPath = currentPath.Replace("..", ".");
                    currentPath = currentPath.Replace(":", "");
 
                    string path = @"D:\Programming\Visual Studio 2013\Projects\PagesAndFaceEvaluator\PagesAndFaceEvaluator\statistics\" + currentPath;

                    string rowToWrite = "url: " + url + " action: " + action + " dateOfRequest:" + timeOfRequest;
                    using (StreamWriter w = File.AppendText(path))
                    {
                        w.WriteLine(rowToWrite);
                        w.Flush();
                    }

                    string lastPath = ConfigHelper.GetValue(ConfigHelper.ConfigKey.LastPath.ToString());
                    // ToDo Tu ulozit cas a hodnoty namerane pre poslednu url
                    if (lastPath != "")
                    {
                        lastPath = "";
                    }

                    if (ConfigHelper.ChangeValue(ConfigHelper.ConfigKey.LastPath.ToString(), path))
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
