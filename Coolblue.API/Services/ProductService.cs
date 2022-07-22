using Coolblue.API.Models;
using Coolblue.API.Repository;
using System.Linq;

namespace Coolblue.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRespository _productRespository;
        public ProductService( IProductRespository productRespository)
        {
            _productRespository = productRespository;
        }

        public Product GetProductById(int id)
        {
            var products = _productRespository.GetProducts();
            
            if (products == null)
                return null;
             
            var product = products.FirstOrDefault(x => x.Id == id); //filter the list to match with product id 
            if (product != null)
            {
                var productTypes = _productRespository.GetProductTypes(); //If there are Products then get ProductTypes to include
                if (productTypes != null)
                {
                    product.ProductType = productTypes.FirstOrDefault(x => x.Id == product.ProductTypeId);
                    return product;
                }
                return product;
            }
            return null;
        }
        public int CalculcateInsurance(int id)
        {
            int insuranceCost = 0;

            var products = _productRespository.GetProducts();
            if (products == null)
                return insuranceCost;
            var product = products.FirstOrDefault(x => x.Id == id); //filter the list to match with product id 

            if (product != null)
            {
                var productTypes = _productRespository.GetProductTypes();
                if (productTypes == null)
                    return insuranceCost;

                var productType = productTypes.FirstOrDefault(x => x.Id == product.ProductTypeId);
                if (productType != null && productType.CanBeInsured)
                {
                    if (product.SalesPrice < 500)
                    {
                        insuranceCost = 0;
                    }
                    else if (product.SalesPrice >= 500 && product.SalesPrice < 2000)
                    {
                        insuranceCost = 1000;
                    }
                    else if (product.SalesPrice >= 2000)
                    {
                        insuranceCost = 2000;
                    }

                    if (productType.Name.ToLower() == "smartphones" || productType.Name.ToLower() == "laptops")
                        insuranceCost += 500;
                }
                return insuranceCost;
            }
            return insuranceCost;
        }  
    }
}
