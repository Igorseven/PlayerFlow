using PlayerFlowX.Domain.Entities;
using System;

namespace PlayerFlowX.UnitTest.Builders
{
    public class ClientBuilder
    {
        private string _firstName = "Igor Teste";
        private string _lastName = "Teste Teste";
        private DateTime _birthDate = DateTime.Now;
        private string _phone = "99107773461";

        public static ClientBuilder NewObject()
        {
            return new ClientBuilder();
        }

        public Client DomainBuild()
        {
            return new Client
            {
                FirstName = this._firstName,
                LastName = this._lastName,
                BirthDate = this._birthDate,
                Phone = this._phone
            };
        }

        public ClientBuilder WithFirstName(string firstName)
        {
            this._firstName = firstName;
            return this;
        }

        public ClientBuilder WithLastName(string lastName)
        {
            this._lastName = lastName;
            return this;
        }

        public ClientBuilder WithBirthDate(DateTime birthDate)
        {
            this._birthDate = birthDate;
            return this;
        }

        public ClientBuilder WithPhone(string phone)
        {
            this._phone = phone;
            return this;
        }
    }

}
