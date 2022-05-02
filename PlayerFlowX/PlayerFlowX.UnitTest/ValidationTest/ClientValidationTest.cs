using PlayerFlowX.Business.Handlers.ValidationHandlers;
using PlayerFlowX.Domain.Entities;
using PlayerFlowX.UnitTest.Builders;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PlayerFlowX.UnitTest.ValidationTest
{
    public class ClientValidationTest
    {
        private ValidationHandler<Client> _validation;

        public ClientValidationTest()
        {
            this._validation = new ValidationHandler<Client>();
        }

        [Fact]
        [Trait("Properties validations", "Return Sucess")]
        public async Task ClientValidation_WithPropertiesValids_ReturnIsValidTrue()
        {
            var client = ClientBuilder.NewObject()
                .DomainBuild();

            var validationResponse = await this._validation.ValidationAsync(client);

            Assert.True(validationResponse.Valid);
        }

        [Theory]
        [Trait("Property FirstName length invalid", "Return Invalid")]
        [InlineData("Viiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii")]
        [InlineData("Vi")]
        [InlineData("V")]
        [InlineData("")]

        public async Task ClientValidation_WithFirstNameInvalid_ReturnIsValidFalse(string firstName)
        {
            var client = ClientBuilder.NewObject()
                .WithFirstName(firstName)
                .DomainBuild();

            var validationResponse = await this._validation.ValidationAsync(client);

            Assert.False(validationResponse.Valid != true);
        }


        [Theory]
        [Trait("Property LastName length invalid", "Return Invalid")]
        [InlineData("Viiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii")]
        [InlineData("Vi")]
        [InlineData("V")]
        [InlineData("")]
        public async Task ClientValidation_WithLastNameInvalid_ReturnIsValidFalse(string lastName)
        {
            var client = ClientBuilder.NewObject()
                .WithLastName(lastName)
                .DomainBuild();

            var validationResponse = await this._validation.ValidationAsync(client);

            Assert.False(validationResponse.Valid != true);
        }

        [Theory]
        [Trait("Property Phone length invalid", "Return Invalid")]
        [InlineData("991234567891")]
        [InlineData("9912345678")]
        [InlineData("")]
        public async Task ClientValidation_WithPhoneInvalid_ReturnIsValidFalse(string phone)
        {
            var client = ClientBuilder.NewObject()
                .WithPhone(phone)
                .DomainBuild();

            var validationResponse = await this._validation.ValidationAsync(client);

            Assert.False(validationResponse.Valid != true);
        }

        [Fact]
        [Trait("Property BirthDate invalid", "Return Invalid")]
        public async Task ClientValidation_WithBirthDateInvalid_ReturnIsValidFalse()
        {
            var client = ClientBuilder.NewObject()
                .WithBirthDate(new DateTime(2020, 01, 20))
                .DomainBuild();

            var validationResponse = await this._validation.ValidationAsync(client);

            Assert.False(validationResponse.Valid != true);
        }

    }
}
