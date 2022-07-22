using Coolblue.API.Models;

namespace Coolblue.API.Services
{
   public interface IProductTypeService
    {
        ProductType GetProductTypeById(int id);
    }
}
