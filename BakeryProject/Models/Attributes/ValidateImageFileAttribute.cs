using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BakeryProject.Models.Attributes
{
    public class ValidateImageFileAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
             var file = value as IFormFile;
           // var file = (IFormFile)validationContext.ObjectInstance;
            var extn = Path.GetExtension(file.FileName);
            var allowedExtn = new[] { ".jpg", ".jpeg", ".png" };

            if (file == null)
            {
                return new ValidationResult("Please upload a image");
            }

            if (!allowedExtn.Contains(extn.ToLower()))
            {
                return new ValidationResult("Image should be '.jpg' or '.png'");
            }

           return ValidationResult.Success;
        }
    }
}
