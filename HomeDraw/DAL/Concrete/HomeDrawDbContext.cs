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
        
        public DbSet<Drawing> Drawings { get; set; }
        public DbSet<DrawingObject> DrawingObjects { get; set; }

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

                var user2 = new AppUser("User");
                user2.PasswordHash = passwordHasher.HashPassword("User!");
                user2.SecurityStamp = Guid.NewGuid().ToString();

                context.Users.Add(user2);

                var user3 = new AppUser("User2");
                user3.PasswordHash = passwordHasher.HashPassword("User!");
                user3.SecurityStamp = Guid.NewGuid().ToString();

                context.Users.Add(user3);

                var user4 = new AppUser("User3");
                user4.PasswordHash = passwordHasher.HashPassword("User!");
                user3.SecurityStamp = Guid.NewGuid().ToString();

                context.Users.Add(user4);

                base.Seed(context);
            }
        }
    }
}
