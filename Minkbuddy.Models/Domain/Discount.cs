using Minkbuddy.Objects.Enum;

namespace Minkbuddy.Models.Domain
{
    public class Discount
    {
        public DiscountType Type { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string DiscountMasterId { get; set; }

    }
}
