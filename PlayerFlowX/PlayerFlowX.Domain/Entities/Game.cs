using System;
using System.Collections.Generic;

namespace PlayerFlowX.Domain.Entities
{
    public class Game : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public bool Favorite { get; set; }

        public List<GamingPlatform> GamingPlatform { get; set; }

        public int ProducerId { get; set; }
        public Producer Producer { get; set; }

    }
}
