using System.Collections.Generic;

namespace PlayerFlowX.Domain.Entities
{
    public class Shopping : BaseEntity
    {
        public List<Game> Games { get; set; }
        public decimal TotalValue { get; set; }
        public bool FinalizePurchase { get; set; }


        public void GetTotalValue()
        {
            foreach (var game in Games)
            {
                this.TotalValue =+ game.Price;
            }
        }
    }
}
