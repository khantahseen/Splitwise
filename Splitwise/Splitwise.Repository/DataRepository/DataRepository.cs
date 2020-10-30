using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Splitwise.DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.DataRepository
{
    public class DataRepository : IDataRepository
    {
        #region Private Members
        private SplitwiseDbContext _context;
        //private readonly IDbConnection _dbConnection;
        #endregion

        #region Constructor
        public DataRepository(SplitwiseDbContext context)
        {
            _context = context;
            
        }
        #endregion

        #region Public Methods
        public EntityEntry<T> Add<T>(T entity) where T : class
        {
            var dbSet = CreateDbSet<T>();
            return dbSet.Add(entity);
            //throw new NotImplementedException();
        }

       

        public async Task<EntityEntry<T>> AddAsync<T>(T entity) where T : class
        {
            var dbSet = CreateDbSet<T>();
            return await dbSet.AddAsync(entity);
            //throw new NotImplementedException();
        }



        public T Find<T>(int id) where T : class
        {
            var dbSet = CreateDbSet<T>();
            return dbSet.Find(id);
            //throw new NotImplementedException();
        }

        public async Task<T> FindAsync<T>(int id) where T : class
        {
            var dbSet = CreateDbSet<T>();
            return await dbSet.FindAsync(id);
            //throw new NotImplementedException();
        }

        public T First<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var dbSet = CreateDbSet<T>();
            return dbSet.First(predicate);
            //throw new NotImplementedException();
        }

        public async Task<T> FirstAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var dbSet = CreateDbSet<T>();
            return await dbSet.FirstAsync(predicate);
            //throw new NotImplementedException();
        }

        public T FirstOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var dbSet = CreateDbSet<T>();
            return dbSet.FirstOrDefault(predicate);
            //throw new NotImplementedException();
        }

        public async Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var dbSet = CreateDbSet<T>();
            return await dbSet.FirstOrDefaultAsync(predicate);
            //throw new NotImplementedException();
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            var dbSet = CreateDbSet<T>();
            return dbSet.AsQueryable();
            //throw new NotImplementedException();
        }

        public EntityEntry<T> Remove<T>(T entity) where T : class
        {
            var dbSet = CreateDbSet<T>();
            return dbSet.Remove(entity);
            //throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public EntityEntry<T> Update<T>(T entity) where T : class
        {
            var dbSet = CreateDbSet<T>();
            return dbSet.Update(entity);
            //throw new NotImplementedException();
        }

        public IQueryable<T> Where<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var dbSet = CreateDbSet<T>();
            return dbSet.Where(predicate);
            //throw new NotImplementedException();
        }
        #endregion

        private DbSet<T> CreateDbSet<T>() where T : class
        {
            return _context.Set<T>();
            //throw new NotImplementedException();
        }
    }
}
