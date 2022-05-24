using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlayerFlowX.Business.Interfaces.RepositoryContract
{
    public interface IBaseCommandsRepository<TEntity, TKey> : IDisposable where TEntity : class
    {
        Task<bool> SaveAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TKey id);
        bool HaveObjectInDb(Expression<Func<TEntity, bool>> where);
    }
}
