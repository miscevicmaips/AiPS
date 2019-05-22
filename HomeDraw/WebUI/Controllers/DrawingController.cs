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
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    [Authorize]
    public class DrawingController : Controller
    {
        private IDrawingObjectRepository drawingObjectRepository;
        private IDrawingRepository drawingRepository;
        private IAppUserRepository userRepository;

        public DrawingController(IDrawingObjectRepository drawingObjectRepo, IDrawingRepository drawingRepo, IAppUserRepository userRepo)
        {
            drawingObjectRepository = drawingObjectRepo;
            drawingRepository = drawingRepo;
            userRepository = userRepo;
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

        [HttpGet]
        public JsonResult GetDrawingObjects(int drawingId)
        {
            List<DrawingObject> newObjects = new List<DrawingObject>();

            Drawing drawing = drawingRepository.ReadDrawing(drawingId);

            var drawingObjects = drawing.DrawingObjects;

            foreach(var drawingObject in drawingObjects)
            {
                DrawingObject newObject = new DrawingObject();
                newObject.DrawingObjectID = drawingObject.DrawingObjectID;
                newObject.DrawingObjectType = drawingObject.DrawingObjectType;
                newObject.PositionTop = drawingObject.PositionTop;
                newObject.PositionLeft = drawingObject.PositionLeft;
                newObjects.Add(newObject);
            }

            return Json(newObjects, JsonRequestBehavior.AllowGet);
        }
    }
}