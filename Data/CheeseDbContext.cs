using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Models;

namespace csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Data
{
    public class CheeseDbContext : DbContext
    {
        public DbSet<Cheese> Cheeses { get; set; }
        public DbSet<CheeseCategory> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<CheeseMenu> CheeseMenus { get; set; }

        // constructor
        public CheeseDbContext(DbContextOptions<CheeseDbContext> options)
            : base(options)
        {
        }

        // This method will set the primary key of the CheeseMenu class and table to be a composite key, consisting of both CheeseID and MenuID.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheeseMenu>()
                .HasKey(c => new { c.CheeseID, c.MenuID });
        }
    }
}
