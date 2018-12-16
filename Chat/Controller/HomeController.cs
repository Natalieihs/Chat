using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1;

namespace Chat.Controller
{
    public class HomeController : System.Web.Mvc.Controller
    {
        // GET: Home
        public ActionResult Index()
        {
           var hubContext= GlobalHost.ConnectionManager.GetHubContext<PersonHub>();
           
            return View();
        }
    }
}