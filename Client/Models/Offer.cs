using System;
using System.Collections.Generic;

namespace Client.Models
{
    public partial class Offer
    {
        public Offer()
        {
            Status = false;
            Materials = new HashSet<Material>();
        }

        public int OfferId { get; set; }
        public decimal? Price { get; set; }
        public int? Time { get; set; }
        public bool? Status { get; set; }
        public int? Quantity { get; set; }
        public string? MaterialName { get; set; }

        public virtual ICollection<Material> Materials { get; set; }
    }
}
