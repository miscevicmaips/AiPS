﻿using Domain.Enums;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Drawing
    {
        public Drawing()
        {
            this.ParticipatingUsers = new HashSet<IdentityUser>();

            this.DrawingObjects = new HashSet<DrawingObject>();
        }

        public int DrawingID { get; set; }

        public string DrawingName { get; set; }

        public string DrawingPassword { get; set; }

        public DrawingTypeEnum DrawingType { get; set; }

        public string CreatorID { get; set; }

        public ICollection<IdentityUser> ParticipatingUsers { get; set; }

        public ICollection<DrawingObject> DrawingObjects { get; set; }
    }
}
