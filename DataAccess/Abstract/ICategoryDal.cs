using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>   //aşağıdakileri tek tek yazmak yerine entity repository de hepsini alabilen bir değişkene(T) atadık.Böylece her yerde ayrı ayrı yazmadan hepsini ordan çekebiliriz.
    {
        //List<Category> GetAll();
        //void Add(Category category);
        //void Update(Category category);
        //void Delete(Category category);
        //List<Category> GetAllByCateegory(int categoryID);
    }
}
