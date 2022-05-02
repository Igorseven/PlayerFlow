using FluentValidation;
using FluentValidation.Results;
using PlayerFlowX.Business.Interfaces.OthersContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayerFlowX.Business.Handlers.ValidationHandlers
{
    public class ValidationHandler<TEntity> :AbstractValidator<TEntity>, IValidationHandler<TEntity> where TEntity : class
    {
        private ValidationResult ValidationResult { get; set; }


        private void CreateResult(TEntity entity) => this.ValidationResult = base.Validate(entity);
        private async Task CreateResultAsync(TEntity entity) => this.ValidationResult = await ValidateAsync(entity);
        private Dictionary<string, string> GetErrors()
        {
            var errors = new Dictionary<string, string>();

            foreach (var error in this.ValidationResult.Errors)
            {
                errors.Add(error.PropertyName, error.ErrorMessage);
            }

            return errors;
        }


        public async Task<ValidationResponse> ValidationAsync(TEntity entity)
        {
            await CreateResultAsync(entity);
            return ValidationResponse.CreateValidation(GetErrors());
        }

        ValidationResponse IValidationHandler<TEntity>.Validation(TEntity entity)
        {
            CreateResult(entity);
            return ValidationResponse.CreateValidation(GetErrors());
        }
    }
}
