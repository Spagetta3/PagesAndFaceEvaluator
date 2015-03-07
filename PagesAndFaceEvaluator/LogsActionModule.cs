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
    public class LogsActionModule : NancyModule
    {
        public class ReceivedData
        {
            public string Data { get; set; }
        }

        public LogsActionModule()
        {
            Post["/processCoordData"] = _ =>
            {
                ReceivedData data = this.Bind<ReceivedData>();
                if (data.Data != null)
                {
                    data.Data = data.Data;
                }

                return HttpStatusCode.OK;
            };
        }
    }
}
