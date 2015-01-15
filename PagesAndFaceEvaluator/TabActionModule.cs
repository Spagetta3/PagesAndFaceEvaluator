using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                /*zavolat funkc\iu na parsovanie, ulozenie a vratit ok....*/
                ReceivedData data = this.Bind<ReceivedData>();
                if (data.Data != null)
                {
                    return HttpStatusCode.OK;
                }
                else
                    return HttpStatusCode.InternalServerError;
            };
        }
    }
}
