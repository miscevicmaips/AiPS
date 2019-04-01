using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using Domain.Entities;
using DAL.Abstract;
using Domain.Enums;
using WebUI.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace WebUI.Controllers
{
    public class RoomController : Controller
    {
        // CreateRoom
        // DeleteRoom
        // OpenRoom

        private IRoomRepository roomRepository;

        public RoomController(IRoomRepository roomRepo)
        {
            roomRepository = roomRepo;
        }

        public ActionResult CreateRoom(DashboardViewModel vm)
        {
            Room newRoom = new Room();
            Drawing containedDrawing = new Drawing();

            newRoom.Name = vm.RoomName;
            newRoom.Password = vm.RoomPassword;
            newRoom.RoomCreatorID = User.Identity.GetUserId();

            containedDrawing.DrawingName = newRoom.Name;
            containedDrawing.DrawingOwner = DrawingTypeEnum.RoomDrawing;

            newRoom.ContainedDrawing = containedDrawing;

            roomRepository.Create(newRoom);

            return RedirectToAction("Dashboard", "Home");
        }

        public ActionResult DeleteRoom(int roomId)
        {
            roomRepository.Delete(roomId);

            return RedirectToAction("PublicRooms", "Home");
        }

        public ActionResult OpenRoom(int roomId, string roomPassword)
        {
            Room roomToOpen = new Room();
            roomToOpen = roomRepository.GetRoomById(roomId);

            if(roomToOpen.Password == roomPassword)
            {
                return View("Room", roomToOpen);
            }
            else
            {
                return RedirectToAction("PublicRooms", "Home");
            }

        }
    }
}