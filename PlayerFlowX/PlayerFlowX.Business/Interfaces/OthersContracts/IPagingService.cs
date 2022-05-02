using PlayerFlowX.Infra.EFCore.PaginationHandler;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerFlowX.Business.Interfaces.OthersContracts
{
    public interface IPagingService<TEntity> where TEntity : class
    {
        Task<PageList<TEntity>> CreatePaginationAsync(IQueryable<TEntity> source, int pageNumber, int pageSize);
    }
}
