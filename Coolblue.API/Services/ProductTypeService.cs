using Coolblue.API.Models;
using Coolblue.API.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Coolblue.API.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductRespository _productRespository;

        public ProductTypeService(IProductRespository productRespository)
        {
            _productRespository = productRespository;
        }
        public ProductType GetProductTypeById(int id)
        {
            var productTypes = _productRespository.GetProductTypes();
            if (productTypes != null)
            {
                var productType = productTypes.FirstOrDefault(x => x.Id == id); //filter the list to match with productTypeId 
                return productType;
            }
            return null;
        }
    }
}
