using PlayerFlowX.Domain.Entities;

namespace PlayerFlowX.UnitTest.Builders
{
    public class AddressBuilder
    {
        private string _street = "Rua Dos Testes";
        private string _district = "Centro da testabilidade";
        private string _city = "Teste Sul";
        private string _houseNumber = "777";
        private string _state = "TS";
        private string _zipCode = "12345678";

        public static AddressBuilder NewObject()
        {
            return new AddressBuilder();
        }
        public Address DomainBuild()
        {
            return new Address
            {
                Street = this._street,
                District = this._district,
                City = this._city,
                HouseNumber = this._houseNumber,
                State = this._state,
                ZipCode = this._zipCode
            };
        }

        public AddressBuilder WithStreet(string street)
        {
            this._street = street;
            return this;
        }

        public AddressBuilder WithDistrict(string district)
        {
            this._district = district;
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            this._city = city;
            return this;
        }

        public AddressBuilder WithHouseNumber(string number)
        {
            this._houseNumber = number;
            return this;
        }

        public AddressBuilder WithState(string state)
        {
            this._state = state;
            return this;
        }

        public AddressBuilder WithZipCode(string zipCode)
        {
            this._zipCode = zipCode;
            return this;
        }
    }
}
