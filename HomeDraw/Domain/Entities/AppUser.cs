using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser() : base()
        {
            this.SavedDrawings = new HashSet<Drawing>();
        }

        public AppUser(string username) : base(username) { }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Drawing> SavedDrawings { get; set; }
    }
}
