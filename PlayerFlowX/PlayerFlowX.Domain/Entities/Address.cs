namespace PlayerFlowX.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string HouseNumber { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
