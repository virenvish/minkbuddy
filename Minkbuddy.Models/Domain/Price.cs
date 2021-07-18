using Minkbuddy.Objects.Enum;
using System;

namespace Minkbuddy.Models.Domain
{
    public class Price
    {
        public PriceType Type { get; set; }
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public Array Denominations { get; set; }
        public int ProductId { get; set; }
    }
}
