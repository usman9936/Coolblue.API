using Coolblue.API.Models;

namespace Coolblue.API.Services
{
    public interface IProductService
    {
        Product GetProductById(int id);
        int CalculcateInsurance(int id);
    }
}
