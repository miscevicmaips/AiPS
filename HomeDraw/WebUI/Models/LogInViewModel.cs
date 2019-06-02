using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class LogInViewModel
    {
        [DisplayName("Username:")]
        [Required(ErrorMessage = "Please enter your username.")]
        public string Username { get; set; }

        [DisplayName("Password:")]
        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }
    }
}