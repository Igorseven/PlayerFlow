namespace PlayerFlowX.Domain.Entities
{
    public abstract class CardPayment : BaseEntity
    {
        public string ClientName { get;  set; }
        public string CardNumber { get;  set; }
        public string CardCode { get;  set; }
        public string ValidDate { get;  set; }
        public bool ConfirmPurchase { get; set; }
        

        public CardPayment(string clientName, string cardNumber, string cardCode, string validDate)
        {
            this.ClientName = clientName;
            this.CardNumber = cardNumber;
            this.CardCode = cardCode;
            this.ValidDate = validDate;
        }

        protected abstract string Pay(bool valid);

    }
}
