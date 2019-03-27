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
        private IRoomRepository roomRepository;

        public HomeController(IRoomRepository roomRepo)
        {
            roomRepository = roomRepo;
        }

        public ActionResult Dashboard()
        {
            return View();
        }
        
        public ActionResult PublicRooms()
        {
            PublicRoomsViewModel vm = new PublicRoomsViewModel();

            vm.PublicRoomsList = roomRepository.GetAllRooms();

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