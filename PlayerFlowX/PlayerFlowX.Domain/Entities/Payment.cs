namespace PlayerFlowX.Domain.Entities
{
    public abstract class Payment : BaseEntity
    {
        public string ClientName { get; set; }
        public string Cpf { get; set; }
        public decimal Value { get; set; }
        public bool ConfirmPurchase { get; set; }

        public Payment(decimal value, string clientName, string cpf)
        {
            this.Value = value;
            this.ClientName = clientName;
            this.Cpf = cpf;
        }

        public abstract string GenerateData(bool confirm);
    }
}
