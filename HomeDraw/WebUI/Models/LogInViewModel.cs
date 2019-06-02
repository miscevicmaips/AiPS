using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class LogInViewModel
    {
        // login details
        public string Username { get; set; }
        public string Password { get; set; }

        // registration details
        public string RegistrationUsername { get; set; }
        public string RegistrationPassword { get; set; }
    }
}