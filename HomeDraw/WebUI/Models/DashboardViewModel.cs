using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class DashboardViewModel
    {
        [Required]
        public string DrawingName { get; set; }

        [Required]   
        public string DrawingPassword { get; set; }

    }
}