using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _entities;
        public EfEntityRepositoryBase(TContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            if (entity != null)
            {
                _entities.Add(entity);
                SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                _entities.Remove(entity);
                SaveChanges();
            }
            //todo: silme tarihi
        }

        public TEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public void SaveChanges()
        {

            _context.SaveChanges();

        }

        public void Update(TEntity entity)
        {
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
                SaveChanges();
                //todo: veri güncelleme işleminde de savechanges() bize "veri kaydedildi" değerini döndürecek. isterseniz bu metodu değiştirebilirsiniz.
                //todo: güncelleme tarihi
            }
        }
    }
}
