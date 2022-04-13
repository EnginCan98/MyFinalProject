using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //core katmanı diğer katmanları referans almaz.Alırsa o katmana bağımlılık oluşur.
    //generic constraint
    //class:Referans tip
    //IEntity:IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new():new'lenebilir olmalı
    public interface IEntityRepository<T> where T: class,IEntity    //generic constraint T'nin neler olabileceğini kısıtlıyoruz.Burda T referans tip olabilir demiş olduk.Class:referans tip.Sonrada bunu IEntity den bir şey olabilir demiş olduk.Yani bu nesne IEntity olabilir yada onu implament eden bir nesne olabilir.Ama burdada alt classlarda IEntity verebiliyoruz ama IEntity soyut bir nesne olduğu için işimizi görmüyor bu yüzden new ekledik.Böylece IEntity newlenememesinden yararlandık.
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);   //expression filtreleme yapmamızı sağlar
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //List<T> GetAllByCateegory(int categoryID);
    }
}
