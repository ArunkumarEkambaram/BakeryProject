using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BakeryProject.Models.Attributes;
using Microsoft.AspNetCore.Http;

namespace BakeryProject.ViewModel
{
    public class ProductViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        //[ValidateImageFile]
        public IFormFile ImageName { get; set; }
    }
}
