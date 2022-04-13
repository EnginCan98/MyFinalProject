using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Burda IproductDal'da ne yazarsak onu implemente edeceğiz.
    //NuGet
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal  //Ef in içinde IProductDal a lazım olan operasyonlar olduğu için hata bitmiş oldu.
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = (from p in context.Products
                              join c in context.Categories on p.CategoryId equals c.CategoryID
                              select new ProductDetailDto()
                              { ProductID = p.ProductID, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock, CategoryId = c.CategoryID });    //ödevde var izle.
                                                                                                                                                                                              //var result = context.Categories.ToList();

                return result.ToList();         //To list çünkü dönen sonuç bir IQueryable dır
            }
        }
        //public void Add(Product entity)   //EfEntityRepositoryBase e taşındı çünkü her şey için tekrar yazmak istemiyoruz
        //{
        //    //IDisposible pattern implementation of C#
        //    using (NorthwindContext context = new NorthwindContext())     //burda kullanılan şeyler yapması gereken iş bittiği gibi bellekten atılır.Daha performanslı olur.
        //    {
        //        var addedEntity = context.Entry(entity);      //Referansı yakala
        //        addedEntity.State = EntityState.Added;        //Ekle
        //        context.SaveChanges();                        //İşleme 
        //    }
        //}

        //public void Delete(Product entity)
        //{
        //    using (NorthwindContext context = new NorthwindContext())     
        //    {
        //        var deletedEntity = context.Entry(entity);      //Referansı yakala
        //        deletedEntity.State = EntityState.Deleted;      //Sil
        //        context.SaveChanges();                          //İşleme 
        //    }
        //}

        //public Product Get(Expression<Func<Product, bool>> filter) //tek data getirecek
        //{
        //    using (NorthwindContext context = new NorthwindContext())
        //    {
        //        return context.Set<Product>().SingleOrDefault(filter);
        //    }
        //}

        //public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        //{
        //    using (NorthwindContext context = new NorthwindContext())
        //    {
        //        //Filtre null mı?       //Evet                            //Hayır
        //        return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();    //filtre verilmemiş ise bütün veriyi tablo yap ve eğer verildiyse(:) filtredeki veriyi liste olarak getir
        //    }
        //}

        //public void Update(Product entity)
        //{
        //    using (NorthwindContext context = new NorthwindContext())
        //    {
        //        var updatedEntity = context.Entry(entity);      //Referansı yakala
        //        updatedEntity.State = EntityState.Modified;     //Güncelle
        //        context.SaveChanges();                          //İşleme 
        //    }
        //}

    }
}
