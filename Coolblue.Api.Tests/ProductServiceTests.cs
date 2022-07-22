using Coolblue.API.Models;
using Coolblue.API.Repository;
using Coolblue.API.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Coolblue.Api.Tests
{
    public class ProductServiceTests
    {

        private readonly Mock<IProductRespository> _productRespositoryMock = new Mock<IProductRespository>();

        private readonly IProductService _productService;
        public ProductServiceTests()
        {
            _productService = new ProductService(_productRespositoryMock.Object);
        }

        [Theory]
        [InlineData(735246)]
        public void GetById_Returns_CorrectProduct(int id)
        {
            //Arrange
            int expected = 735246;
            _productRespositoryMock.Setup(x => x.GetProducts()).Returns(new List<Product>()
            {
                 new Product
                 {
                     Id = 735246,
                     Name = "AEG L8FB86ES",
                     SalesPrice = 699,
                     ProductTypeId = 124
                 },
                new Product
                {
                    Id = 735296,
                    Name = "Canon EOS 5D Mark IV Body",
                    SalesPrice = 2699,
                    ProductTypeId = 35
                }
            });
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

            var actual = _productService.GetProductById(id).Id;

            // Assert

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetById_When_UnknownIdPassed_ReturnsNotFoundResult()
        {
            //Arrange
            _productRespositoryMock.Setup(x => x.GetProducts()).Returns(new List<Product>()
            {
                 new Product
                 {
                     Id = 735246,
                     Name = "AEG L8FB86ES",
                     SalesPrice = 699,
                     ProductTypeId = 124
                 },
                new Product
                {
                    Id = 735296,
                    Name = "Canon EOS 5D Mark IV Body",
                    SalesPrice = 2699,
                    ProductTypeId = 35
                }
            });
            // Act
            var notFoundResult = _productService.GetProductById(1);
            // Assert
            Assert.Null(notFoundResult);
        }

        [Theory]
        [InlineData(11)]
        public void Get_WhenCalled_Returns_Zero_WhenCanbeInsured_False(int id)
        {
            //Arrange
            int expected = 0;
            _productRespositoryMock.Setup(x => x.GetProducts()).Returns(new List<Product>()
            {
                 new Product
                 {
                     Id = 11,
                     Name = "AEG L8FB86ES",
                     SalesPrice = 899,
                     ProductTypeId = 21
                 },
                new Product
                {
                    Id = 12,
                    Name = "Canon EOS 5D Mark IV Body",
                    SalesPrice = 800,
                    ProductTypeId = 35
                }
            });
            //Arrange
            _productRespositoryMock.Setup(x => x.GetProductTypes()).Returns(new List<ProductType>()
            {
                 new ProductType
                 {
                    Id = 21,
                    Name = "Washing machines",
                    CanBeInsured = false

                 },
                new ProductType
                {
                    Id = 22,
                    Name = "SLR cameras",
                    CanBeInsured = false
                }
            });

            // Act
            var actual = _productService.CalculcateInsurance(id);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(11)]
        public void Get_WhenCalled_Returns_Zero_WhenProductSalesPrice_LessThan500(int id)
        {
            //Arrange
            int expected = 0;
            _productRespositoryMock.Setup(x => x.GetProducts()).Returns(new List<Product>()
            {
                 new Product
                 {
                     Id = 11,
                     Name = "AEG L8FB86ES",
                     SalesPrice = 499,
                     ProductTypeId = 21
                 },
                new Product
                {
                    Id = 12,
                    Name = "Canon EOS 5D Mark IV Body",
                    SalesPrice = 200,
                    ProductTypeId = 35
                }
            });
            //Arrange
            _productRespositoryMock.Setup(x => x.GetProductTypes()).Returns(new List<ProductType>()
            {
                 new ProductType
                 {
                    Id = 21,
                    Name = "Washing machines",
                    CanBeInsured = true

                 },
                new ProductType
                {
                    Id = 22,
                    Name = "SLR cameras",
                    CanBeInsured = true
                }
            });
            // Act

            var actual = _productService.CalculcateInsurance(id);

            // Assert

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(11)]
        public void Get_WhenCalled_Returns_1000_WhenProductSalesPrice_Between_500And2000(int id)
        {
            //Arrange
            int expected = 1000;
            _productRespositoryMock.Setup(x => x.GetProducts()).Returns(new List<Product>()
            {
                 new Product
                 {
                     Id = 11,
                     Name = "AEG L8FB86ES",
                     SalesPrice = 1500,
                     ProductTypeId = 21
                 },
                new Product
                {
                    Id = 12,
                    Name = "Canon EOS 5D Mark IV Body",
                    SalesPrice = 2000,
                    ProductTypeId = 35,
                }
            });
            //Arrange
            _productRespositoryMock.Setup(x => x.GetProductTypes()).Returns(new List<ProductType>()
            {
                 new ProductType
                 {
                    Id = 21,
                    Name = "Washing machines",
                    CanBeInsured = true

                 },
                new ProductType
                {
                    Id = 22,
                    Name = "SLR cameras",
                    CanBeInsured = true
                }
            });
            // Act

            var actual = _productService.CalculcateInsurance(id);

            // Assert

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(11)]
        public void Get_WhenCalled_Returns_2000_WhenProductSalesPrice_GreaterThan_2000(int id)
        {
            //Arrange
            int expected = 2000;
            _productRespositoryMock.Setup(x => x.GetProducts()).Returns(new List<Product>()
            {
                 new Product
                 {
                     Id = 11,
                     Name = "AEG L8FB86ES",
                     SalesPrice = 2000,
                     ProductTypeId = 21
                 },
                new Product
                {
                    Id = 12,
                    Name = "Canon EOS 5D Mark IV Body",
                    SalesPrice = 2500,
                    ProductTypeId = 35,
                }
            });
            //Arrange
            _productRespositoryMock.Setup(x => x.GetProductTypes()).Returns(new List<ProductType>()
            {
                 new ProductType
                 {
                    Id = 21,
                    Name = "Washing machines",
                    CanBeInsured = true

                 },
                new ProductType
                {
                    Id = 22,
                    Name = "SLR cameras",
                    CanBeInsured = true
                }
            });
            // Act

            var actual = _productService.CalculcateInsurance(id);

            // Assert

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(11)]
        public void Get_WhenCalled_Returns_InsuranceCost_WithAdditionalCost_When_ProductType_Laptop_Smartphone(int id)
        {
            //Arrange
            int expected = 2500;
            _productRespositoryMock.Setup(x => x.GetProducts()).Returns(new List<Product>()
            {
                 new Product
                 {
                     Id = 11,
                     Name = "Iphone 13",
                     SalesPrice = 2000,
                     ProductTypeId = 21
                 },
                new Product
                {
                    Id = 12,
                    Name = "Macbook Pro",
                    SalesPrice = 2500,
                    ProductTypeId = 22
                }
            });
            //Arrange
            _productRespositoryMock.Setup(x => x.GetProductTypes()).Returns(new List<ProductType>()
            {
                 new ProductType
                 {
                    Id = 21,
                    Name = "smartphones",
                    CanBeInsured = true

                 },
                new ProductType
                {
                    Id = 22,
                    Name = "laptops",
                    CanBeInsured = true
                }
            });
            // Act

            var actual = _productService.CalculcateInsurance(id);

            // Assert

            Assert.Equal(expected, actual);
        }
    }

}
