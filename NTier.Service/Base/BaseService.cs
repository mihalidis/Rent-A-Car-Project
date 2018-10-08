using NTier.Core.Entity;
using NTier.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using NTier.Model.Context;
using NTier.Core.Entity.Enum;
using System.Data.Entity.Infrastructure;

namespace NTier.Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        private static ProjectContext _context;

        public ProjectContext context
        {
            get
            {
                if (_context == null)
                {
                    _context = new ProjectContext();
                    return _context;
                }
                return _context;
            }
            set { _context = value; }
        }

        public void Add(T item)
        {
            context.Set<T>().Add(item);
            Save();
        }

        public void Add(List<T> items)
        {
            context.Set<T>().AddRange(items);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp) => context.Set<T>().Any(exp);

        public List<T> GetActive() => context.Set<T>().Where(x => x.Durumu == Status.Active).ToList();

        public List<T> GetAll() => context.Set<T>().ToList();

        public T GetByDefault(Expression<Func<T, bool>> exp) => context.Set<T>().Where(exp).FirstOrDefault();

        public T GetById(Guid id) => context.Set<T>().Find(id);

        public List<T> GetDefault(Expression<Func<T, bool>> exp) => context.Set<T>().Where(exp).ToList();

        public int Save() => context.SaveChanges();

        public void Remove(T item)
        {
            item.Durumu = Status.Deleted;
            Update(item);
        }

        public void Remove(Guid id)
        {
            T item = GetById(id);
            item.Durumu = Status.Deleted;
            Update(item);
        }
     
        public void Update(T item)
        {
            T updated = GetById(item.Id);
            DbEntityEntry entry = context.Entry(updated);
            entry.CurrentValues.SetValues(item);
            Save();
        }

        public void DetachEntity(T item)
        {
            context.Entry<T>(item).State = System.Data.Entity.EntityState.Detached;
        }
    }
}
