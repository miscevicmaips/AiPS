using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

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
    }
}
