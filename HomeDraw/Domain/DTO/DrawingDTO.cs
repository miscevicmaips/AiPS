using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class DrawingDTO
    {
        public int DrawingID { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string MasterID { get; set; }

        public List<DrawingObjectDTO> DrawingObjects { get; set; }
    }
}
