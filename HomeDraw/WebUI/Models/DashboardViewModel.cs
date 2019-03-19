using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebUI.Models
{
    public class DashboardViewModel
    {
        // Join drawing model
        public string JoinDrawingID { get; set; }
        public string JoinDrawingPassword { get; set; }

        // Create drawing model
        public string CreateDrawingName { get; set; }
        public string CreateDrawingPassword { get; set; }

    }
}