using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BakeryProject.Models;
using BakeryProject.Repositories;
using BakeryProject.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BakeryProject.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository _productRepos;
        private readonly IWebHostEnvironment _webHost;

        public ProductsController(IProductRepository repository,IWebHostEnvironment webHost)
        {
            _productRepos = repository;
            _webHost = webHost;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ProductViewModel viewModel = new ProductViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel productView)
        {
            if (!ModelState.IsValid)
            {
                return View(productView);
            }

            string imgFolder = Path.Combine(_webHost.WebRootPath, "images");
            string imgFullPath = Path.Combine(imgFolder, productView.ImageName.FileName);
            productView.ImageName.CopyTo(new FileStream(imgFullPath, FileMode.Create));

            Product product = new Product
            {
                Name = productView.Name,
                Description = productView.Description,
                Price = productView.Price,
                ImageName = productView.ImageName.FileName
            };

            _productRepos.AddNewProduct(product);

            return RedirectToAction("Index", "Home");
        }
    }
}
