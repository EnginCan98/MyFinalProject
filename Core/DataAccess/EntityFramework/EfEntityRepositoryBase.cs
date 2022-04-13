using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity>  //aynı klasörde olduğundan IEntityrepository using yapmadan görür.
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)          //bunu EfProductDal'dan aldık ve product ı TEntity ile NorthwindContext'i TContext le değiştirdik.Amacımız tekrar yazmamak.Kod generic hale gelmiş oldu.
        {
            //IDisposible pattern implementation of C#
            using (TContext context = new TContext())     //burda kullanılan şeyler yapması gereken iş bittiği gibi bellekten atılır.Daha performanslı olur.
            {
                var addedEntity = context.Entry(entity);      //Referansı yakala
                addedEntity.State = EntityState.Added;        //Ekle
                context.SaveChanges();                        //İşleme 
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);      //Referansı yakala
                deletedEntity.State = EntityState.Deleted;      //Sil
                context.SaveChanges();                          //İşleme 
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)       //tek data getirecek
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //Filtre null mı?       //Evet                            //Hayır
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();    //filtre verilmemiş ise bütün veriyi tablo yap ve eğer verildiyse(:) filtredeki veriyi liste olarak getir
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);      //Referansı yakala
                updatedEntity.State = EntityState.Modified;     //Güncelle
                context.SaveChanges();                          //İşleme 
            }
        }
    }
}
