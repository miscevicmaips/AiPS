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
using WebUI.StrategyService;
using System.IO;
using Domain.DTO;

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

        [HttpPost]
        public ActionResult CreateDrawing(DashboardViewModel vm)
        {
            if (vm.CreateDrawingName != null && vm.CreateDrawingPassword != null)
            {
                DrawingDTO newDrawing = new DrawingDTO();

                newDrawing.Name = vm.CreateDrawingName;
                newDrawing.Password = vm.CreateDrawingPassword;

                drawingRepository.CreateDrawing(newDrawing);

                vm.JoinDrawingName = newDrawing.Name;
                vm.JoinDrawingPassword = newDrawing.Password;

                return RedirectToAction("JoinDrawing", vm);
            }

            else
            {
                ModelState.AddModelError("MissingParameters", "Please enter the room name and password,");

                return View("~/Views/Home/Dashboard.cshtml", vm);
            }

        }

        [HttpGet]
        public ActionResult OpenDrawing(int drawingId, string drawingPassword)
        {
            DrawingDTO drawingToOpen = drawingRepository.ReadDrawing(drawingId);

            OpenDrawingViewModel vm = new OpenDrawingViewModel();

            vm.Drawing = drawingToOpen;

            return View("Drawing", vm);
        }

        [HttpGet]
        public ActionResult JoinDrawing(DashboardViewModel dashboardViewModel)
        {
            if(dashboardViewModel.JoinDrawingName != null && dashboardViewModel.JoinDrawingPassword != null)
            {
                DrawingDTO drawingToJoin = drawingRepository.ReadDrawingByName(dashboardViewModel.JoinDrawingName);

                if (drawingToJoin != null)
                {
                    if (drawingToJoin.Password == dashboardViewModel.JoinDrawingPassword)
                    {
                        OpenDrawingViewModel vm = new OpenDrawingViewModel();
                        vm.Drawing = drawingToJoin;
                        return View("Drawing", vm);
                    }
                    else
                    {
                        ModelState.AddModelError("RoomPasswordInvalid", "Wrong password!");
                        return View("~/Views/Home/Dashboard.cshtml", dashboardViewModel);
                    }
                }
                else
                {
                    ModelState.AddModelError("RoomMissing", "Room with name " + "'" + dashboardViewModel.JoinDrawingName + "'" + " doesn't exist!");
                    return View("~/Views/Home/Dashboard.cshtml", dashboardViewModel);
                }
            }
            else
            {
                ModelState.AddModelError("MissingParameters", "Please enter the room name and password,");
                return View("~/Views/Home/Dashboard.cshtml", dashboardViewModel);
            }
        }

        [HttpPost]
        public ActionResult DeleteDrawing(int drawingId)
        {
            drawingRepository.DeleteDrawing(drawingId);

            return RedirectToAction("Dashboard", "Home");
        }

        [HttpGet]
        public JsonResult GetDrawingObjects(int drawingId)
        {
            List<DrawingObject> newObjects = new List<DrawingObject>();

            DrawingDTO drawing = drawingRepository.ReadDrawing(drawingId);

            var drawingObjects = drawing.DrawingObjects;

            foreach (var drawingObject in drawingObjects)
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

        [ValidateInput(false)]
        public JsonResult ExportDrawingToPDF(string fileExtension, string htmlString)
        {
            Context strategyContext;

            Byte[] file = null;
            string fileName = "";

            if (fileExtension == ".pdf")
            {
                strategyContext = new Context(new ConcreteStrategyPDF());
                file = strategyContext.ContextInterface(htmlString);
                fileName = "HomeDrawExportPDF.pdf";
            }

            if (fileExtension == ".png")
            {
                strategyContext = new Context(new ConcreteStrategyPNG());
                file = strategyContext.ContextInterface(htmlString);
                fileName = "HomeDrawExportPNG.png";
            }

            string fileHandle = Guid.NewGuid().ToString();

            TempData[fileHandle] = file;

            JsonResult jsonFileResult = new JsonResult();

            return new JsonResult()
            {
                Data = new { FileGuid = fileHandle, FileName = fileName }
            };
        }

    }
}