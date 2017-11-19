
using Modal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsersContext : DbContext
    {
        public UsersContext() : base("UserContext")
        {

        }
        public DbSet<User> Users { get; set; }

        
     
    }
}
