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
        private IDrawingObjectRepository drawingObjectRepository;
        private IDrawingRepository drawingRepository;

        public DrawingController(IDrawingObjectRepository drawingObjectRepo, IDrawingRepository drawingRepo)
        {
            drawingObjectRepository = drawingObjectRepo;
            drawingRepository = drawingRepo;
        }

        public ActionResult CreateDrawing(DashboardViewModel vm)
        {
            Drawing newDrawing = new Drawing();

            newDrawing.Name = vm.DrawingName;
            newDrawing.Password = vm.DrawingPassword;

            drawingRepository.CreateDrawing(newDrawing);

            return RedirectToAction("PublicDrawings", "Home");
        }

        public ActionResult OpenDrawing(int drawingId, string drawingPassword)
        {
            Drawing drawingToOpen = drawingRepository.ReadDrawing(drawingId);

            OpenDrawingViewModel vm = new OpenDrawingViewModel();

            vm.Drawing = drawingToOpen;

            return View("Drawing", vm);
        }

        public ActionResult DeleteDrawing(int drawingId)
        {
            drawingRepository.DeleteDrawing(drawingId);

            return RedirectToAction("PublicDrawings", "Home");
        }
    }
}