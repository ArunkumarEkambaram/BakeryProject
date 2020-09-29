using System;
using System.Collections.Generic;
using System.Text;
using BakeryProject.Data.Configurations;
using BakeryProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BakeryProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration()).Seed();

            base.OnModelCreating(builder);//To Create tables for ASP.NET Core Identity, since we are overriding OnModelCreating we have call on our own
        }
    }
}
