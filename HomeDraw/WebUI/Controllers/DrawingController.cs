using DAL.Abstract;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Infrastructure;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize]
    public class DrawingController : Controller
    {
        private IDrawingRepository drawingRepository;

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

        public DrawingController(IDrawingRepository repo)
        {
            drawingRepository = repo;
        }

        public ActionResult DrawingBoard()
        {
            return View();
        }

        public ActionResult MyDrawings()
        {
            MyDrawingsViewModel vm = new MyDrawingsViewModel();

            vm.MyDrawings = drawingRepository.GetMyDrawings(User.Identity.GetUserId());

            return View(vm);
        }

        public ActionResult CreateDrawing(DashboardViewModel vm)
        {
            if(ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();

                Drawing drawing = new Drawing();

                drawing.DrawingName = vm.CreateDrawingName;
                drawing.DrawingPassword = vm.CreateDrawingPassword;
                drawing.CreatorID = currentUserId;

                drawingRepository.CreateDrawing(drawing);

                return RedirectToAction("DrawingBoard", drawing);
            }

            return RedirectToAction("Index", "Test");

        }
    }
}