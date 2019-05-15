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
            this.JoinedUsers = new HashSet<AppUser>();
        }

        public int DrawingID { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string MasterID { get; set; }

        public virtual ICollection<DrawingObject> DrawingObjects { get; set; }

        public virtual ICollection<AppUser> JoinedUsers { get; set; }

    }
}
