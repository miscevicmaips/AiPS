using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class PublicDrawingsViewModel
    {
        public IEnumerable<Drawing> PublicDrawings { get; set; }

        public string DrawingPassword { get; set; }
    }
}