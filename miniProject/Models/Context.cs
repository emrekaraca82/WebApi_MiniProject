using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniProject.Models
{
    public class Context : DbContext
    {

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.;Database=miniProject;Trusted_Connection=true;");
        //}

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
      
        public DbSet<Information> informations { get; set; }
        public DbSet<Company> companies { get; set; }

    }
}
