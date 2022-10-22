using System;
using System.Collections.Generic;

namespace Client.Models
{
    public partial class Material
    {
        public int MaterialId { get; set; }
        public string? MaterialName { get; set; }
        public double? MaterialPrice { get; set; }
        public int? OfferId { get; set; }

        public virtual Offer? Offer { get; set; }
    }
}
