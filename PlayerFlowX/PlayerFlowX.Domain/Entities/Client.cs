using System;
using System.Collections.Generic;

namespace PlayerFlowX.Domain.Entities
{
    public class Client : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }


        public List<Game> Games { get; set; }

        public int ShoppingId { get; set; }
        public Shopping Shopping { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public string LoginId { get; set; }
        public Login Login { get; set; }
    }
}
