using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;            //Global değişken
        public InMemoryProductDal()
        {
            //Oracle,Sql,Server
            _products = new List<Product>
            {
            new Product { ProductID = 1, CategoryId=  1, ProductName = "Bardak",  UnitPrice = 15,   UnitsInStock= 15  },
            new Product { ProductID = 2, CategoryId = 1, ProductName = "Kamera",  UnitPrice = 500,  UnitsInStock = 3  },
            new Product { ProductID = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2  },
            new Product { ProductID = 4, CategoryId = 2, ProductName = "Klavye",  UnitPrice = 150,  UnitsInStock = 65 },
            new Product { ProductID = 5, CategoryId = 2, ProductName = "Fare",    UnitPrice = 85,   UnitsInStock = 1  },
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Langue Intagrated Query
            
            Product productToDelete = _products.SingleOrDefault(p => p.ProductID == p.ProductID);   //linq kullanıldı. => işareti lambda.SingleOrDefault foreach'i yapar.Kuramıda parentez içerisine yazarız.           
//            foreach (var p in _products)              //Yerine linq kullanıldı
//            {                                              //bunu yerine linq kullanmak daha sağlıklı
//                if (product.ProductID == p.ProductID)
//               {
//                   productToDelete = p;
//               }
//            }

            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCateegory(int categoryID)
        {
            return _products.Where(p => p.CategoryId == categoryID).ToList();    //where içindeki şarta uyan bütün elemanları yeni bir liste yapar ve onu döndürür.yeni koşul eklemek içimn &&(ve) kullanılır.
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == p.ProductID);
            productToUpdate.ProductName  = product.ProductName ;
            productToUpdate.CategoryId   = product.CategoryId  ;    
            productToUpdate.UnitPrice    = product.UnitPrice   ;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
