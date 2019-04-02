using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DrawingObject
    {
        public int DrawingObjectID { get; set; }

        public double PositionTop { get; set; }

        public double PositionLeft { get; set; }

        public DrawingObjectTypeEnum DrawingObjectType { get;set; }

        public int DrawingID { get; set; }
    }
}
