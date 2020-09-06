using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebDemo.Entities;

namespace WebDemo.Repositories
{
    public abstract class BaseRepository : IDisposable
    {
        protected AspNetWebDemoDbEntities _context;
        public DbContext Context
        {
            get { return _context; }
        }
        public BaseRepository() : this(new AspNetWebDemoDbEntities()) { }
        public BaseRepository(AspNetWebDemoDbEntities context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("DB Context is null.");
            }
            _context = context;
        }
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
        public DbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
    public abstract class BaseRepository<TObj> : IDisposable
        where TObj : class
    {
        protected AspNetWebDemoDbEntities _context;
        public DbContext Context
        {
            get { return _context; }
        }
        public BaseRepository() : this(new AspNetWebDemoDbEntities()) { }
        public BaseRepository(AspNetWebDemoDbEntities context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("DB Context is null.");
            }
            _context = context;
        }
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
        public DbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
        #region Create
        public TObj Create(TObj obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Create data is null.");
            }
            else
            {
                _context.Set<TObj>().Add(obj);
                _context.SaveChanges();
                return obj;
            }
        }
        public async Task<TObj> CreateAsync(TObj obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Create data is null.");
            }
            else
            {
                _context.Set<TObj>().Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
        }
        #endregion
        #region Read
        public virtual TObj Get(Expression<Func<TObj, bool>> predicate)
        {
            return _context.Set<TObj>().FirstOrDefault(predicate);
        }
        public virtual async Task<TObj> GetAsync(Expression<Func<TObj, bool>> predicate)
        {
            return await _context.Set<TObj>().FirstOrDefaultAsync(predicate);
        }
        public virtual IQueryable<TObj> GetAll()
        {
            return _context.Set<TObj>().AsQueryable();
        }
        #endregion
        #region Update
        public TObj Update(TObj obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Update data is null.");
            }
            else
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
                return obj;
            }
        }

        public async Task<TObj> UpdateAsync(TObj obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Update data is null.");
            }
            else
            {
                _context.Entry(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return obj;
            }
        }
        #endregion
        #region Delete
        public void Delete(Expression<Func<TObj, bool>> predicate)
        {
            var obj = Get(predicate);
            Delete(obj);
        }

        public void Delete(TObj obj)
        {
            if (obj != null)
            {
                _context.Entry(obj).State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public async Task DeleteAsync(Expression<Func<TObj, bool>> predicate)
        {
            var obj = await GetAsync(predicate);
            await DeleteAsync(obj);
        }

        public async Task DeleteAsync(TObj obj)
        {
            if (obj != null)
            {
                _context.Entry(obj).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
