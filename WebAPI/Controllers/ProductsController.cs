using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //loseely coupled : Bağımlılık var ama soyuta bağımlılık.
        //naming convention
        //IoC Container -- Inversion of control
        //11-1.35 de startup.cs  Autofac, Ninject, CastleWindsor, StructureMap, LightInject, DryInject --> IoC Container.AOP = bir metodun önünde, sonunda ve hata verdiğinde çalışan kod parçacıkları.
        IProductService _productService;  //constructorda service e erişim yoktur.bu yüzen field yaptık.Field yapınca erişebiliyoruz.

        public ProductsController(IProductService productService)    //IProductService injection.Burda manager ver dedik referansından.
        {                                                            //Resolve = çözümlemek oda new'lemek demek.
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger
            //dependency chain
            //IProductService prodcutService = new ProductManager(new EfProductDal());
            var result = _productService.GetAll();      //field'ları _ ile veririz.
            if (result.Succes)
            {
                return Ok(result);         //burası tamamen bize bağlı sistei ona göre kurduk.
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]  
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]                           //Gönderi datayı biz veririz.11-2.32 postman
        public IActionResult Add(Product product)   //Controller'ın bildiği yer burası o yüzden parametre buraya yazılır.
        {                                           
            var result = _productService.Add(product);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
