using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatTrackr.Data.Interfaces;
using StatTrackr.Model.Data;
using StatTrackr.Model.Base;
using System.Data.Entity;

namespace StatTrackr.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected DbContext _context;
        protected readonly IDbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable<T>();
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _dbSet.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual T Add(T entity)
        {
            return _dbSet.Add(entity);
        }
        //TODO:NOt sure if this is the best way to return true
        public virtual bool Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        public virtual void Edit(T entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
