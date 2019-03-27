using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Room
    {
        public int RoomID { get; set; }
        
        public string Name { get; set; }

        public string Password { get; set; }

        public int DrawingID { get; set; }
        public Drawing Drawing { get; set; }
    }
}
