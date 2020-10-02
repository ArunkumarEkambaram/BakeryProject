using System;
using System.Collections.Generic;
using BakeryProject.Controllers;
using BakeryProject.Models;
using BakeryProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BakeryProjectTest
{
    public class HomeControllerTests
    {
        private readonly Mock<IProductRepository> mockRepo;

        public HomeControllerTests()
        {
            mockRepo = new Mock<IProductRepository>();
        }

        private IEnumerable<Product> GetMockProdcts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Donut", Description = "Made of belgium chocolate with very tasty donut", Price = 125.50f, ImageName = "Choco_Donut.jpg", AddedDate = DateTime.Now },
                new Product { Id = 2, Name = "Chocolate Cup Cake", Description = "A delicious cup cake with hot cholocate and choco chips", Price = 50, ImageName = "Choco_CupCake.jpg", AddedDate = DateTime.Now },
                new Product { Id = 3, Name = "Cookies", Description = "Fresh baked choco cip cookies", Price = 15.50f, ImageName = "Cookies.jpg", AddedDate = DateTime.Now }
            };
        }

        [Fact]
        public void Index_WithAListOfProducts_ReturnsAViewResult()
        {
            //Arrange            
            mockRepo.Setup(rep => rep.GetProducts()).Returns(GetMockProdcts);
            var controller = new HomeController(mockRepo.Object);

            //Act
            var result = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Product>>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Count);
        }
    }
}
