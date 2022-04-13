using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        
        //encryption geri dönüşü olan veri
        //Salting : Kullanıcının girdiği paraloya bir şeyler eklemek.
        //Claim
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductServiceGet")]
        public IResult Add(Product product)                      //*
        {
            //validation
            //if(product.UnitPrice <= 0)         validation'da yapıldı
            //{
            //    return new ErrorResult(Messages.UnitPriceInvalid);
            //}

            //if (product.ProductName.Length < 2)
            //{
            //    //magic strings : burda her noktaya string yazmakdır.Daha sonra problem çıkartabilir.
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}
            //--------------------  12-2     

            //ValidationTool.Validate(new ProductValidator(), product);
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
                CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);             //*

            //if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Succes)
            //{
            //    if (CheckIfProductNameExists(product.ProductName).Succes)
            //    {
                    
            //    }
                
            //}
            //return new ErrorResult();

        }

        [CacheAspect]       //key, value.Maniplasyon yapan metodları cache aspect le yönetilir.elle veri eklendiğinde sıkıntı çıkarmaz.
        public IDataResult<List<Product>> GetAll()            //interface imzasından dolayı IDataResult
        {
            //İş kodları.   //bir iş sınıfı başka sınıfları new'lemez.
            //Kurallar kontrol edilir geçerse return'e geçer.

            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);   //Buralarda Data döndürmemiz gerekli
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll( p => p.CategoryId == id ));    //expression dediği lambda.Her p için p'nin category id si benim gönderdiğiminkine eşitse onları filtrele.
        }                               //calıştığımız tip                //parantez içi data'mız.constructor içine bunu gönderiyoruz
                                        //SuccesDataResult içinde product listesi var.

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductID == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)           //SuccessDataResult*
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll( p => p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()                                   //SuccessDataResult*              
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductServiceGet")]           //bellekte içerisinde get olan bütün key'leri iptal et.Başına interface i eklediğimizde IProduct Service deki bütün get'leri siler.
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //Select count(*) from products where categoryId=1
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            //Select count(*) from products where categoryId=1
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result == true)                //any yokken result!=null yapılabilir.
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()    //Category manager'a yazılırsa tek başına bir servis olmuş olur.
        {                                              //Bu tamamen kategori servisini kullanan bir ürünün nasıl ele aldığı.  
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }

            return new SuccessResult();
        }
       
    }
}
