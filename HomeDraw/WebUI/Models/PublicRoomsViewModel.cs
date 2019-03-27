using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class PublicRoomsViewModel
    {
        public IEnumerable<Room> PublicRoomsList { get; set; }

        public string RoomPassword { get; set; }
    }
}