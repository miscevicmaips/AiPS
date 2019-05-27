using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class DashboardViewModel
    {
        public string createDrawingName { get; set; }
        public string createDrawingPassword { get; set; }

        public string joinDrawingName { get; set; }
        public string joinDrawingPassword { get; set; }
    }
}