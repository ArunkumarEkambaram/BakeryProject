using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeryProject.Data
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder Seed(this ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Donut", Description = "Made of belgium chocolate with very tasty donut", Price = 125.50f, ImageName = "~/images/Choco_Donut.jfif", AddedDate = DateTime.Now },
                new Product { Id = 2, Name = "Chocolate Cup Cake", Description = "A delicious cup cake with hot cholocate and choco chips", Price = 50, ImageName = "~/images/Choco_CupCake.jfif", AddedDate = DateTime.Now },
                new Product { Id = 3, Name = "Cookies", Description = "Fresh baked choco cip cookies", Price = 15.50f, ImageName = "~/images/Cookies.jfif", AddedDate = DateTime.Now }
                );

            return builder;
        }
    }
}
