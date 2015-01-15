using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Hosting.Self;
using System.Net.Sockets;

namespace PagesAndFaceEvaluator
{
    public class TabActionModule : NancyModule
    {
        public TabActionModule()
        {
            Get["/tabChanged"] = _ =>
        {
            /*zavolat funkciu na parsovanie, ulozenie a vratit ok....*/
            return "Ide to";
        };

        Get["/tabNew"] = _ =>
        {
            return HttpStatusCode.OK;
        };

        Get["/tabClosed"] = _ =>
        {
            return HttpStatusCode.OK;
        };
        }
    }
}
