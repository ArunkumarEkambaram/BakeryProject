using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BakeryProject.ViewModel
{
    public class AddProductViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        //[Required]
        //[ValidateImageFile]
        public IFormFile ImageName { get; set; }
    }
}
