using Domain.Enums;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Drawing
    {
        public Drawing()
        {
            this.DrawingObjects = new HashSet<DrawingObject>();
        }

        public int DrawingID { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public virtual ICollection<DrawingObject> DrawingObjects { get; set; }

    }
}
