using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniProject.Models
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
      
        public DbSet<Information> informations { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Intermediate> intermediates { get; set; }

    }
}
