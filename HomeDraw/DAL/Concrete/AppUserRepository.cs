using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Data.Entity;

namespace DAL.Concrete
{
    public class AppUserRepository : IAppUserRepository
    {
        public AppUser ReadUser(string userId)
        {
            using (var context = new HomeDrawDbContext())
            {
                return context.Users.Find(userId);
            }
        }

        public AppUser ReadUserByLastConnectionId(string connectionId)
        {
            using (var context = new HomeDrawDbContext())
            {
                var user = context.Users.Where(u => u.LastConnectionIdentification == connectionId).SingleOrDefault();

                return user;
            }
        }

        public void UpdateUser(AppUser user)
        {
            using (var context = new HomeDrawDbContext())
            {
                context.Entry(user).State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}
