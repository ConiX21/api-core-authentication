using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApiPizza.Models.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly DbContext Ctx;

        public Repository(DbContext context )
        {
            Ctx = context;
        }

        public void Create(TEntity entity)
        {
            Ctx.Set<TEntity>().Add(entity);
            Ctx.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Ctx.Set<TEntity>().Remove(entity);
            Ctx.SaveChanges();
        }

        public TEntity Read(short id)
        {
            return Ctx.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Read()
        {
            return Ctx.Set<TEntity>();
        }

        public IEnumerable<TEntity> Read(Expression<Func<TEntity, bool>> predicate)
        {
            return Ctx.Set<TEntity>().Where(predicate);
        }

        public void Update(TEntity entity)
        {
            Ctx.Set<TEntity>().Update(entity);
            Ctx.SaveChanges();
        }
    }
}
