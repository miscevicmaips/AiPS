using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Domain.Entities;

namespace DAL.Concrete
{
    public class HomeDrawDbContext : IdentityDbContext<IdentityUser>
    {
        public HomeDrawDbContext() : base("HomeDrawDatabase") { }

        public DbSet<Drawing> Drawings { get; set; }
        public DbSet<DrawingObject> DrawingObjects { get; set; }
        public DbSet<TestEntity> TestEntities { get; set; }

        public static HomeDrawDbContext Create()
        {
            return new HomeDrawDbContext();
        }

        public class HomeDrawDbInit : DropCreateDatabaseAlways<HomeDrawDbContext>
        {
            protected override void Seed(HomeDrawDbContext context)
            {
                var passwordHasher = new PasswordHasher();
                var user = new IdentityUser("AdminAIPS");
                user.PasswordHash = passwordHasher.HashPassword("Admin");
                user.SecurityStamp = Guid.NewGuid().ToString();

                var roleToChoose = new IdentityRole("AdministratorAIPS");
                context.Roles.Add(roleToChoose);

                var role = new IdentityUserRole();
                role.RoleId = roleToChoose.Id;
                role.UserId = user.Id;

                user.Roles.Add(role);
                context.Users.Add(user);

                TestEntity testEntity = new TestEntity();
                testEntity.Name = "Some Test Entity";

                context.TestEntities.Add(testEntity);

                base.Seed(context);
            }
        }
    }
}
