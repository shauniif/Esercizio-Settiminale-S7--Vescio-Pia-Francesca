﻿using Microsoft.EntityFrameworkCore;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;
namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Context
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Ingredient> Ingredients { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Order> Orders { get; set; } 
        
        public DataContext(DbContextOptions<DataContext> opt) : base(opt) { }


    }
}
