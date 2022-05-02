using FluentValidation;
using PlayerFlowX.Business.Extentions;
using PlayerFlowX.Domain.Entities;
using PlayerFlowX.Domain.Enums;
using System;

namespace PlayerFlowX.Business.Handlers.ValidationHandlers.EntitiesValidation
{
    public class ClientValidation : ValidationHandler<Client>
    {

        public ClientValidation()
        {
            GetRules();
        }

        private void GetRules()
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage(EMessage.Required
                .Description().FormatTo("Nome"));
            RuleFor(c => c.FirstName).Length(3, 80).WithMessage(EMessage.MoreExpected
               .Description().FormatTo("Nome", "3 a 80"));

            RuleFor(c => c.LastName).NotEmpty().WithMessage(EMessage.Required
                .Description().FormatTo("Sobrenome"));
            RuleFor(c => c.LastName).Length(3, 80).WithMessage(EMessage.Required
                .Description().FormatTo("Sobrenome", "3, 80"));

            RuleFor(c => c.Phone).NotEmpty().WithMessage(EMessage.Required
                .Description().FormatTo("Telefone/Celular"));
            RuleFor(c => c.Phone).Length(11).WithMessage(EMessage.Required
                .Description().FormatTo("Celular", "11"));

            RuleFor(c => c.BirthDate).NotEmpty().WithMessage(EMessage.Required
                .Description().FormatTo("Data de nascimento"));
            RuleFor(c => c.BirthDate).InclusiveBetween(new DateTime(1900, 1, 1), DateTime.Today.AddYears(-18))
            .WithMessage(EMessage.InvalidFormat.Description().FormatTo("Data de nascimento"));
        }
    }
}
