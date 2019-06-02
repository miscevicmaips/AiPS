using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class SettingsViewModel
    {
        [DisplayName("Old Password:")]
        [Required(ErrorMessage = "Please enter your old password.")]
        public string OldPassword { get; set; }

        [DisplayName("New Password:")]
        [Required(ErrorMessage = "Please enter your new password.")]
        public string NewPassword { get; set; }
    }
}