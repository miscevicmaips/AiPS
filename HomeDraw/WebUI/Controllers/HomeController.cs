using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Dashboard()
        {
            return View();
        }
        
        public ActionResult PublicRooms()
        {
            return View();
        }

        public ActionResult SavedDrawings()
        {
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }
    }
}