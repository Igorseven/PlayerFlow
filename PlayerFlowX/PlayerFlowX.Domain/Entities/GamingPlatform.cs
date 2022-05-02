using System.Collections.Generic;

namespace PlayerFlowX.Domain.Entities
{
    public class GamingPlatform : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Game> Games { get; set; } 
    }
}
