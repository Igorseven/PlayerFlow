using FluentValidation;
using PlayerFlowX.Business.Extentions;
using PlayerFlowX.Domain.Entities;
using PlayerFlowX.Domain.Enums;

namespace PlayerFlowX.Business.Handlers.ValidationHandlers.EntitiesValidation
{
    public class AddressValidation : ValidationHandler<Address>
    {
        public AddressValidation()
        {
            GetRules();
        }

        private void GetRules()
        {
            RuleFor(c => c.Street).NotEmpty().WithMessage(EMessage.Required
                .Description().FormatTo("Lougradoro"));
            RuleFor(c => c.Street).Length(2, 100).WithMessage(EMessage.MoreExpected
               .Description().FormatTo("Lougradoro", "3 a 100"));

            RuleFor(c => c.District).NotEmpty().WithMessage(EMessage.Required
                .Description().FormatTo("Bairro"));
            RuleFor(c => c.District).Length(3, 100).WithMessage(EMessage.MoreExpected
               .Description().FormatTo("Bairro", "3 a 100"));

            RuleFor(c => c.City).NotEmpty().WithMessage(EMessage.Required
                .Description().FormatTo("Cidade"));
            RuleFor(c => c.City).Length(3, 100).WithMessage(EMessage.MoreExpected
               .Description().FormatTo("Cidade", "3 a 100"));

            RuleFor(c => c.State).NotEmpty().WithMessage(EMessage.Required
                .Description().FormatTo("UF"));
            RuleFor(c => c.State).Length(2).WithMessage(EMessage.MoreExpected
               .Description().FormatTo("UF", "2"));

            RuleFor(c => c.HouseNumber).NotEmpty().WithMessage(EMessage.Required
                .Description().FormatTo("Número"));
            RuleFor(c => c.HouseNumber).Length(1, 12).WithMessage(EMessage.MoreExpected
               .Description().FormatTo("Número", "1 a 12"));

            RuleFor(c => c.ZipCode).NotEmpty().WithMessage(EMessage.Required
                .Description().FormatTo("CEP"));
            RuleFor(c => c.ZipCode).Length(8).WithMessage(EMessage.MoreExpected
               .Description().FormatTo("CEP", "8"));
        }
    }
}
