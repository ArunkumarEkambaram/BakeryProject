using System.IO;
using BakeryProject.Controllers;
using BakeryProject.Models;
using BakeryProject.Repositories;
using BakeryProject.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BakeryProjectTest
{
    public class ProductControllerTests
    {
        private Mock<IProductRepository> _mockRepo;
        private Mock<IWebHostEnvironment> _mockWebHost;

        public ProductControllerTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _mockWebHost = new Mock<IWebHostEnvironment>();
        }

        [Fact]
        public void Create_AddProductReturnsBadRequest_GivenInvalidModel()
        {
            var controller = new ProductsController(_mockRepo.Object, _mockWebHost.Object);

            var result = controller.Create(null);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        //AddProduct
        private AddProductViewModel GetMockProduct()
        {
            var fileMock = new Mock<IFormFile>();
            var physicalPath = new FileInfo(@"C:\DXC\ASPNETCore\BakeryProject\BakeryProject\wwwroot\images\Donut2.jpg");
            var fileName = physicalPath.Name;

            fileMock.Setup(a => a.FileName).Returns(fileName);

            return new AddProductViewModel
            {
                Name = "Donut",
                Description = "Made of belgium chocolate with very tasty donut",
                Price = 125.50f,
                ImageName = fileMock.Object
            };
        }

        [Fact]
        public void Create_AddProductRedirectToAction_WhenModelStateIsValid()
        {
            //Arrange              
            _mockRepo.Setup(r => r.AddNewProduct(It.IsAny<Product>())).Verifiable();
            var controller = new ProductsController(_mockRepo.Object, _mockWebHost.Object);
            var newProduct = GetMockProduct();

            //Act
            var result = controller.Create(newProduct);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.NotNull(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            _mockRepo.Verify();
        }
    }
}
