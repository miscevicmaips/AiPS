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

        public ActionResult Dashboard()
        {
            return View();
        }
        
        public ActionResult PublicDrawings()
        {
            PublicDrawingsViewModel vm = new PublicDrawingsViewModel();

            vm.PublicDrawings = drawingRepository.GetAllDrawings();

            return View(vm);
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