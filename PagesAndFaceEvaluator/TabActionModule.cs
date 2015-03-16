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
                    bool result = RecorderHelper.MakeRecord(data.Data, "r");

                    if (result == true)
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
