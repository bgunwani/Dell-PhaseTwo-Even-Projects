using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApproachApplication.Models
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-EI4423A;Database=DellDB;Integrated Security=true;");
            // optionsBuilder.UseSqlServer("Server=DESKTOP-EI4423A;Database=DellDB;User Id=sa;Password=sa@123456;");
        }
    }
}
