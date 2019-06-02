using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Please enter your username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your e-mail address.")]
        public string EmailAddress { get; set; }
    }
}