namespace PlayerFlowX.Domain.Entities
{
    public abstract class CardPayment : BaseEntity
    {
        public string ClientName { get;  set; }
        public string CardNumber { get;  set; }
        public string CardCode { get;  set; }
        public string ValidDate { get;  set; }
        public bool ConfirmPurchase { get; set; }
        

        protected abstract string Pay(bool valid);

    }
}
