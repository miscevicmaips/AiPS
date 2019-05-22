using DAL.Concrete;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Hubs;
using WebUI.Infrastructure;

namespace WebUI.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {

            app.CreatePerOwinContext<HomeDrawDbContext>(HomeDrawDbContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/LogIn"),
            });

            GlobalHost.DependencyResolver.Register(
                typeof(SignalRHub),
                () => new SignalRHub(new DrawingObjectRepository(), new DrawingRepository(), new AppUserRepository()));

            app.MapSignalR();
        }
    }
}