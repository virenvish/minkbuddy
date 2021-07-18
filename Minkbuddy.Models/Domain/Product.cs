using System;
using System.Collections.Generic;

namespace Minkbuddy.Models.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Price Price { get; set; }
        public string Type { get; set; } 
        public int Currency { get; set; }
        public Images Images { get; set; }
        public TnC Tnc { get; set; }
        public Array Category { get; set; }
        public Themes Themes { get; set; }
        public bool ReloadCardNumber { get; set; }
        public DateTime Expiry { get; set; }
        public string FromatExpiry { get; set; }
        public IEnumerable<DiscountMaster> Discounts { get; set; }
        public string StoreLocatorUrl { get; set; }

    }
}
