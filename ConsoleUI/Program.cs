// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {

        static void Main(string[] args)
        {
            //DTO = Data Transformation Object.Bunu ürünnü yanında başka şeyleride yazmak için kullanırız(join).
            //ProductTest();
            //IoC
            //CategoryTest();
    //    }

    //    private static void CategoryTest()
    //    {
    //        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
    //        foreach (var category in categoryManager.GetAll().Data)  
    //        {
    //            Console.WriteLine(category.CategoryName);
    //        }
    //    }

    //    private static void ProductTest()                                   //bunu sağ click yaparak metod haline getirdik.
    //    {
    //        //ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(EfCategoryDal()));

    //        var result = productManager.GetAll().Data;

    //        if (result.Succes == true)
    //        {
    //            foreach (var product in result.Data)
    //            {
    //                Console.WriteLine(product.ProductName + "/" + product.CategoryName);
    //            }
    //        }
    //        else
    //        {
    //            Console.WriteLine(result.Message);
    //        }

    //        foreach (var product in productManager.GetProductDetails().Data)
    //        {
    //            Console.WriteLine(product.ProductName + "/" + product.CategoryName);
    //        }
        }
    }
}
