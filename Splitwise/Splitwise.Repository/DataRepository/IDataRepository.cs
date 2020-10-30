using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.DataRepository
{
    public interface IDataRepository
    {
        Task<T> FirstAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<T> Where<T>(Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<T> GetAll<T>() where T : class;
        T First<T>(Expression<Func<T, bool>> predicate) where T : class;
        T FirstOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<EntityEntry<T>> AddAsync<T>(T entity) where T : class;
        EntityEntry<T> Add<T>(T entity) where T : class;
        EntityEntry<T> Update<T>(T entity) where T : class;
        EntityEntry<T> Remove<T>(T entity) where T : class;
        Task<T> FindAsync<T>(int id) where T : class;
        T Find<T>(int id) where T : class;
        Task SaveChangesAsync();




    }
}
