using AbdielClub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AbdielClub.Context
{
    public class AbdielClubDbContext : DbContext
    {
        public AbdielClubDbContext()
             : base("DatabaseContext")
        {

        }

        public DbSet<Socio> Socios { get; set; }

        public DbSet<Login> Login { get; set; }
    }
}
