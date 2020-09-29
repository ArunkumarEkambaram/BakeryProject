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

        public ProductsController(IProductRepository repository, IWebHostEnvironment webHost)
        {
            _productRepos = repository;
            _webHost = webHost;
        }
        public IActionResult Index()
        {
            var products = _productRepos.GetProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddProductViewModel viewModel = new AddProductViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(AddProductViewModel productView)
        {
            if (!ModelState.IsValid)
            {
                return View(productView);
            }

            Product product = new Product
            {
                Name = productView.Name,
                Description = productView.Description,
                Price = productView.Price,
                ImageName = productView.ImageName.FileName
            };

            int result = _productRepos.AddNewProduct(product);

            if (result > 0)
            {
                this.UploadImageToFolder(productView.ImageName);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("Products/Edit/{id?}")]
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var product = _productRepos.GetProductById(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            EditProductViewModel editProduct = new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ExistingImageName = product.ImageName
            };

            return View(editProduct);
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditProduct(EditProductViewModel editProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(editProduct);
            }

            var product = _productRepos.GetProductById(editProduct.Id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = editProduct.Name;
            product.Description = editProduct.Description;
            product.Price = editProduct.Price;
            if (editProduct.ImageName != null)
            {
                product.ImageName = editProduct.ImageName.FileName;
            }
            else
            {
                product.ImageName = editProduct.ExistingImageName;
            }

            var result = _productRepos.EditProduct(product.Id, product);
            if (result > 0)
            {
                if (editProduct.ImageName != null)
                {
                    string imgFilePath = Path.Combine(_webHost.WebRootPath, "images", editProduct.ExistingImageName);
                    System.IO.File.Delete(imgFilePath);
                    this.UploadImageToFolder(editProduct.ImageName);
                }

            }

            return RedirectToAction("Index", "Home");
        }

        private void UploadImageToFolder(IFormFile productImage)
        {
            string imgFolder = Path.Combine(_webHost.WebRootPath, "images");
            string imgFullPath = Path.Combine(imgFolder, productImage.FileName);
            productImage.CopyTo(new FileStream(imgFullPath, FileMode.Create));
        }
    }
}
