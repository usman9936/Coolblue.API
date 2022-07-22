using Coolblue.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coolblue.API.Repository
{
    public interface IProductRespository
    {
        List<Product> GetProducts();
        List<ProductType> GetProductTypes();
    }
}
