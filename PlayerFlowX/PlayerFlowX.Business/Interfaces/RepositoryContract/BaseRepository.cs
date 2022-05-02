using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlayerFlowX.Business.Interfaces.RepositoryContract
{
    public interface BaseRepository<TEntity, TKey> : IDisposable where TEntity : class
    {
        Task<bool> SaveAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task DeleteAsync(TKey id);
        bool HasObject(Expression<Func<TEntity, bool>> where);
    }
}
