namespace PlayerFlowX.Domain.Entities
{
    public abstract class Payment : BaseEntity
    {
        public string ClientName { get; set; }
        public string Cpf { get; set; }
        public decimal Value { get; set; }
        public bool ConfirmPurchase { get; set; }


        public abstract string GenerateData(bool confirm);
    }
}
