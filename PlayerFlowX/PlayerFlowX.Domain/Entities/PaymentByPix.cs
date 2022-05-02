using System;

namespace PlayerFlowX.Domain.Entities
{
    public class PaymentByPix : Payment
    {
        public Guid PixNumber { get; set; }

        public PaymentByPix(decimal value, string clientName, string cpf)
            : base(value, clientName, cpf)
        {
            this.PixNumber = new Guid();
        }

        public override string GenerateData(bool confirm)
        {
            if (confirm)
            {
                this.ConfirmPurchase = true;
                return $"Confirmação de pagamento, Cliente : {this.ClientName}, Pix Code {this.PixNumber}";
            }
            else
            {
                return $"Boleto {this.PixNumber}   Nome do Cliente : {this.ClientName}, Documento: {this.Cpf} valor {this.Value} " +
                $"Processamento do pagamento leva até 1h.";
            }
        }
    }
}
