using Coolblue.API.Models;
using Coolblue.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Coolblue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _ProductTypeService;
        public ProductTypeController(IProductTypeService productTypeService)
        {
            _ProductTypeService = productTypeService;
        }
        /// <summary>
        /// Return product type info for given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductType>> GetByProductTypeId(int id)
        {
            var productType = _ProductTypeService.GetProductTypeById(id);
            if (productType == null)
            {
                return NotFound();
            }
            return await Task.FromResult(Ok(productType));
        }
    }
}
