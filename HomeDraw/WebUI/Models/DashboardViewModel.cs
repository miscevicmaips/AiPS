using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class DashboardViewModel
    {
        public string CreateDrawingName { get; set; }

        public string CreateDrawingPassword { get; set; }

        public string JoinDrawingName { get; set; }

        public string JoinDrawingPassword { get; set; }

    }
}