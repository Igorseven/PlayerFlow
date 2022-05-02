﻿namespace PlayerFlowX.Domain.Entities
{
    public class DebitCard : CardPayment
    {
        public decimal Value { get; set; }

        public DebitCard(string clientName, string cardNumber, string cardCode, string validDate)
            : base(clientName, cardNumber, cardCode, validDate)
        {

        }

        protected override string Pay(bool valid)
        {
            if (valid)
            {
                return $"Pagamento Realizado com Sucesso, Valor da Compra : R$ {this.Value}";
            }
            else
            {
                return $"Cartão inválido, a compra não pode ser efetivada!";
            }
        }
    }
}
