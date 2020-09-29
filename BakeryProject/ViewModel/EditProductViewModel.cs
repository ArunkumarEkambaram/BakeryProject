using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BakeryProject.Models.Attributes;
using Microsoft.AspNetCore.Http;

namespace BakeryProject.ViewModel
{
    public class EditProductViewModel : AddProductViewModel
    {
        public int Id { get; set; }

        public string ExistingImageName { get; set; }
    }
}
