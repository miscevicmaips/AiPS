using DAL.Concrete;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            HomeDrawDbContext context = HomeDrawDbContext.Create();
            List<TestEntity> testEntities = context.TestEntities.Count();

            return View();
        }
    }
}