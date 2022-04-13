using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //IProcutDal'ı kullandığım veri tabanı değişse bile sistemin çalışması için ihtiyacımız var.
    //Buraya ürüne ait özel operasyonlar koyulur.Örnek olarak ürünün detaylarını getirmek, ürün kategori tablolarına join atmak.
    public interface IProductDal:IEntityRepository<Product>          //interface in operasyonları public dir.kendisi değil.circular dependancy
    {
        List<ProductDetailDto> GetProductDetails();
        //List<Product> GetAll();
        //void Add(Product product);
        //void Update(Product product);
        //void Delete(Product product);
        //List<Product> GetAllByCateegory(int categoryID);
    }
}

//code refactoring : kodun iyileştirilmesi