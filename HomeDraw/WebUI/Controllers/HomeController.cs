using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IDrawingRepository drawingRepository;

        public HomeController(IDrawingRepository drawingRepo)
        {
            drawingRepository = drawingRepo;
        }

        [HttpGet]
        public ActionResult Dashboard()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult SavedDrawings()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Settings()
        {
            return View();
        }
    }
}