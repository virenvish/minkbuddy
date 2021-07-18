using System;

namespace Minkbuddy.Models.Domain
{
    public class DiscountMaster
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Discount Discount { get; set; }
        public DiscountCoupon Coupon { get; set; }
        public int Priority { get; set; }
        public int ProductId { get; set; }
    }
}
