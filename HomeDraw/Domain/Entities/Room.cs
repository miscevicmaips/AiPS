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

        public string RoomCreatorID { get; set; }
        
        public string Name { get; set; }

        public string Password { get; set; }

        public Drawing ContainedDrawing { get; set; }
    }
}
