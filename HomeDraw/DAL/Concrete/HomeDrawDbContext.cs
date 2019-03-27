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
    public class HomeDrawDbContext : IdentityDbContext<AppUser>
    {
        public HomeDrawDbContext() : base("HomeDrawDatabase") { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Drawing> Drawings { get; set; }
        public DbSet<DrawingObject> DrawingObjects { get; set; }
        public DbSet<TestEntity> TestEntities { get; set; }

        public static HomeDrawDbContext Create()
        {
            return new HomeDrawDbContext();
        }

        public class HomeDrawDbInit : DropCreateDatabaseIfModelChanges<HomeDrawDbContext>
        {
            protected override void Seed(HomeDrawDbContext context)
            {
                var passwordHasher = new PasswordHasher();
                var user = new AppUser("Administrator");
                user.PasswordHash = passwordHasher.HashPassword("Administrator!");
                user.SecurityStamp = Guid.NewGuid().ToString();

                context.Users.Add(user);



                TestEntity testEntity = new TestEntity();
                testEntity.Name = "Some Test Entity";

                context.TestEntities.Add(testEntity);

                base.Seed(context);
            }
        }
    }
}
