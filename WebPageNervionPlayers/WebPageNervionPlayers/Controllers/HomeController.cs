using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPageNervionPlayers.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }
        public ActionResult Principal()
        {
            return View();
        }
    }
}