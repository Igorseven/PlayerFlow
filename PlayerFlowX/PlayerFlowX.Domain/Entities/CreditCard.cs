namespace PlayerFlowX.Domain.Entities
{
    public class CreditCard : CardPayment
    {
        public int NumberOfPayment { get; set; }
        public decimal TotalValue { get; set; }
        public decimal ValuePerPayment { get; set; }

        public CreditCard(string clientName, string cardNumber, string cardCode, string validDate)
            : base(clientName, cardNumber, cardCode, validDate)
        {

        }

        protected override string Pay(bool valid)
        {
            if (valid)
            {
                return $"Pagamento Realizado com Sucesso, Valor da parcela : R$ {this.ValuePerPayment}";
            }
            else
            {
                return $"Cartão inválido, a compra não pode ser efetivada!";
            }
        }
    }
}
