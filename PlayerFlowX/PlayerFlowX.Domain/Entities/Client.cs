using PlayerFlowX.Domain.Identity;
using System;
using System.Collections.Generic;

namespace PlayerFlowX.Domain.Entities
{
    public class Client : User
    {
        public DateTime BirthDate { get; set; }


        public List<Game> Games { get; set; }
        public Shopping Shopping { get; set; }
        public Address Address { get; set; }

    }
}
