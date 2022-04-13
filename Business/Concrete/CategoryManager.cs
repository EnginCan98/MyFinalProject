using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;            //Bağımlılığı constructor injection ile yapıyoruz.

        public CategoryManager(ICategoryDal categoryDal)   //Bu veri erişim katmanına bağlı ama zayıf bağımlılık.Interface referans üzerinden bağımlı.Kurallarına uyduğumuz sürece herşeyi yapabiliriz.
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            //iş kodları
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        //Select * from Categories where categoryId = 3
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get( c=> c.CategoryID == categoryId ));  
        }

    }
}
