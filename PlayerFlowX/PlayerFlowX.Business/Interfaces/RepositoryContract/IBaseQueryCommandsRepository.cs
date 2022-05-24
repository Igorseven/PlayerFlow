using PlayerFlowX.Infra.EFCore.PaginationHandler;
using System.Threading.Tasks;

namespace PlayerFlowX.Business.Interfaces.RepositoryContract
{
    public interface IBaseQueryCommandsRepository<Tkey, TEntity> where TEntity : class
    {
        Task<PageList<TEntity>> FindAllWithPaginationAsync();
        Task<TEntity> FindByAsync(Tkey id);
    }
}
