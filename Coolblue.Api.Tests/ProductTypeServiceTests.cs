using Coolblue.API.Models;
using Coolblue.API.Repository;
using Coolblue.API.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Coolblue.Api.Tests
{
    public class ProductTypeServiceTests
    {
        private readonly Mock<IProductRespository> _productRespositoryMock = new Mock<IProductRespository>();

        private readonly IProductTypeService _productTypeService;
        public ProductTypeServiceTests()
        {
            _productTypeService = new ProductTypeService(_productRespositoryMock.Object);
        }

        [Theory]
        [InlineData(124)]
        public void Get_WhenCalled_Get_WhenCalled_ReturnsCorrect_ProductType(int id)
        {
            //Arrange
            int expected = 124;
            _productRespositoryMock.Setup(x => x.GetProductTypes()).Returns(new List<ProductType>()
            {
                 new ProductType
                 {
                    Id = 124,
                    Name = "Washing machines",
                    CanBeInsured = true
                 },
                new ProductType
                {
                    Id = 35,
                    Name = "SLR cameras",
                    CanBeInsured = false
                }
            });

            // Act
            var actual = _productTypeService.GetProductTypeById(id).Id;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            //Arrange
            _productRespositoryMock.Setup(x => x.GetProductTypes()).Returns(new List<ProductType>()
            {
                 new ProductType
                 {
                    Id = 124,
                    Name = "Washing machines",
                    CanBeInsured = true

                 },
                new ProductType
                {
                    Id = 35,
                    Name = "SLR cameras",
                    CanBeInsured = false
                }
            });

            // Act
            var notFoundResult = _productTypeService.GetProductTypeById(0);

            // Assert
            Assert.Null(notFoundResult);
        }
    }
}
