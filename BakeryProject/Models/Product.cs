﻿using System;

namespace BakeryProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ImageName { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
