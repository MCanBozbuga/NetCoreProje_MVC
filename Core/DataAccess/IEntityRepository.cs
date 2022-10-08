using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    /// <summary>
    // class : referans tip
    // IEntity : IEntity olabilir veya IEntity implement eden bir nesne olabilir.
    // new() = new'lenebilir olmalı.
    // (Expression<Func<T, bool>> filter = null); => x=>x.Id filtreleme işlemi yapabilirsin.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityRepository<T> where T : BaseEntity
    {
        #region EF
        //List<T> GetAll(Expression<Func<T, bool>> filter = null); 
        //T Get(Expression<Func<T, bool>> filter);
        //void Add(T entity);
        //void Update(T entity);
        //void Delete(T entity); 
        #endregion
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(int id);
        void SaveChanges();
    }
}
