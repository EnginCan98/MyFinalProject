using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger
            //dependency chain
            //IProductService prodcutService = new ProductManager(new EfProductDal());
            var result = _categoryService.GetAll();      //field'ları _ ile veririz.
            if (result.Succes)
            {
                return Ok(result);         //burası tamamen bize bağlı sistei ona göre kurduk.
            }
            return BadRequest(result);
        }
    }
}
