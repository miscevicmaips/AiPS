using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace DAL.Abstract
{
    public interface IAppUserRepository
    {
        AppUser ReadUser(string userId);
        AppUser ReadUserByLastConnectionId(string connectionId);
        void UpdateUser(AppUser user);
    }
}
