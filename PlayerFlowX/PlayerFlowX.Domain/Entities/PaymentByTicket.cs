using System;

namespace PlayerFlowX.Domain.Entities
{
    public class PaymentByTicket : Payment
    {

        public Guid NumberTicket { get; set; }

        public PaymentByTicket(decimal value, string clientName, string cpf)
            : base(value, clientName, cpf)
        {
            this.NumberTicket = new Guid();
        }

        public override string GenerateData(bool confirm)
        {
            if (confirm)
            {
                this.ConfirmPurchase = true;
                return $"Confirmação de pagamento, Cliente : {this.ClientName}, Boleto {this.NumberTicket}";
            }
            else
            {
                return $"Boleto {this.NumberTicket}   Nome do Cliente : {this.ClientName}, Documento: {this.Cpf} valor {this.Value} " +
                $"Processamento do pagamento leva até 3 dias.";
            }
        }
    }
}
