using PlayerFlowX.Business.Handlers.ValidationHandlers;
using System.Threading.Tasks;

namespace PlayerFlowX.Business.Interfaces.OthersContracts
{
    public interface IValidationHandler<TEntity> where TEntity : class
    {
        ValidationResponse Validation(TEntity entity);
        Task<ValidationResponse> ValidationAsync(TEntity entity);
    }
}
