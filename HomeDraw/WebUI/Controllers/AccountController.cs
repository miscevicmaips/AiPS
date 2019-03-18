﻿using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUI.Infrastructure;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LogIn(LogInViewModel vm)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindAsync(vm.Username, vm.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                    ViewBag.AuthenticationError = "Invalid uername or password.";

                }

                else
                {
                    ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);


                    return RedirectToAction("UserProfile", "Home");
                }
            }

            return View("~/Views/Account/Login.cshtml", vm);
        }

        public ActionResult LogOut()
        {
            AuthManager.SignOut();
            return RedirectToAction("LogIn", "Account");
        }
    }
}