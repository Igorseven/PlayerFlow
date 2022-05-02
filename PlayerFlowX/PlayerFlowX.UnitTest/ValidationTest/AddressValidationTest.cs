using PlayerFlowX.Business.Handlers.ValidationHandlers;
using PlayerFlowX.Domain.Entities;
using PlayerFlowX.UnitTest.Builders;
using System.Threading.Tasks;
using Xunit;

namespace PlayerFlowX.UnitTest.ValidationTest
{
    public class AddressValidationTest
    {
        private ValidationHandler<Address> _validation;

        public AddressValidationTest()
        {
            this._validation = new ValidationHandler<Address>();
        }

        [Fact]
        [Trait("Properties validation", "Return sucess")]
        public async Task AddressValidation_WithPropertiesValids_ReturnIsValidTrue()
        {
            var address = AddressBuilder.NewObject()
                .DomainBuild();

            var validationResponse = await _validation.ValidateAsync(address);
            Assert.True(validationResponse.IsValid == true);
        }


        [Theory]
        [Trait("Property Street length invalid", "Return invalid")]
        [InlineData("iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii")]
        [InlineData("X")]
        [InlineData("")]
        public async Task AddressValidation_WithStreetInvalid_ReturnIsValidFalse(string street)
        {
            var address = AddressBuilder.NewObject()
                .WithStreet(street)
                .DomainBuild();

            var validationResponse = await _validation.ValidateAsync(address);
            Assert.False(validationResponse.IsValid == false);
        }

        [Theory]
        [Trait("Property District length invalid", "Return invalid")]
        [InlineData("iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii")]
        [InlineData("X")]
        [InlineData("")]
        public async Task AddressValidation_WithDistrictInvalid_ReturnIsValidFalse(string district)
        {
            var address = AddressBuilder.NewObject()
                .WithDistrict(district)
                .DomainBuild();

            var validationResponse = await _validation.ValidateAsync(address);
            Assert.False(validationResponse.IsValid == false);
        }

        [Theory]
        [Trait("Property State length invalid", "Return invalid")]
        [InlineData("iii")]
        [InlineData("X")]
        [InlineData("")]
        public async Task AddressValidation_WithStateInvalid_ReturnIsValidFalse(string state)
        {
            var address = AddressBuilder.NewObject()
                .WithState(state)
                .DomainBuild();

            var validationResponse = await _validation.ValidateAsync(address);
            Assert.False(validationResponse.IsValid == false);
        }

        [Theory]
        [Trait("Property City length invalid", "Return invalid")]
        [InlineData("iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii")]
        [InlineData("X")]
        [InlineData("")]
        public async Task AddressValidation_WithCityInvalid_ReturnIsValidFalse(string city)
        {
            var address = AddressBuilder.NewObject()
                .WithCity(city)
                .DomainBuild();

            var validationResponse = await _validation.ValidateAsync(address);
            Assert.False(validationResponse.IsValid == false);
        }

        [Theory]
        [Trait("Property ZipCode length invalid", "Return invalid")]
        [InlineData("123456789")]
        [InlineData("1234567")]
        [InlineData("123456")]
        [InlineData("12345")]
        [InlineData("1234")]
        [InlineData("1")]
        [InlineData("")]
        public async Task AddressValidation_WithZipCodeInvalid_ReturnIsValidFalse(string zipCode)
        {
            var address = AddressBuilder.NewObject()
                .WithZipCode(zipCode)
                .DomainBuild();

            var validationResponse = await _validation.ValidateAsync(address);
            Assert.False(validationResponse.IsValid == false);
        }

        [Theory]
        [Trait("Property houseNumber length invalid", "Return invalid")]
        [InlineData("123456789 123")]
        [InlineData("1")]
        [InlineData("")]
        public async Task AddressValidation_WithhouseNumberInvalid_ReturnIsValidFalse(string number)
        {
            var address = AddressBuilder.NewObject()
                .WithHouseNumber(number)
                .DomainBuild();

            var validationResponse = await _validation.ValidateAsync(address);
            Assert.False(validationResponse.IsValid == false);
        }
    }

}
