using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
                   //T
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);    //bir sitede min şu kadar maks şu kadar dediğimiz yer.
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);                   //Burada product data'nın kendisi.Ürün Id si verince bize bir data resulf of product verecek.
        IResult Add(Product product);              //bunda data yoktu o yüzden void IResult oldu kalanı data tutuyor.
        IResult Update(Product product);

        //IResult AddTransactionalTest(Product product);      //uygulamalarda tutarlılığı korumak için yapılır.mesela para transferinde gönderen hesabı update olduktan sonra receiver da hata olursa gönderende iade olması gerekir.

        //RESTFUL --> HTTP -->
    }
}                                   
