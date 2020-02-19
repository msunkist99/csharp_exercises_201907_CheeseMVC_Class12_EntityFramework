﻿using Microsoft.EntityFrameworkCore;
using MK_CheeseMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Data
{
    public class CheeseDbContext : DbContext
    {
        public DbSet<Cheese> Cheeses { get; set; }

        // constructor
        public CheeseDbContext(DbContextOptions<CheeseDbContext> options)
            : base(options)
        {
        }
    }
}