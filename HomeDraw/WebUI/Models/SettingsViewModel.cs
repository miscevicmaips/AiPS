using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class SettingsViewModel
    {
        [Required(ErrorMessage = "Please enter your old password.")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Please enter your new password.")]
        public string NewPassword { get; set; }
    }
}