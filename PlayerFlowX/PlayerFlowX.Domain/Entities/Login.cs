using System;

namespace PlayerFlowX.Domain.Entities
{
    public class Login 
    {
        public Guid Id { get; set; }
        public string Password { get; set; }   

        public int EmailId { get; set; }
        public Email Email { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }


        public Login()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
