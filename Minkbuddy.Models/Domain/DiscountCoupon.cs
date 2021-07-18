using System;
using System.Collections.Generic;
using System.Text;

namespace Minkbuddy.Models.Domain
{
    public class DiscountCoupon
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int DiscountMasterId { get; set; }
    }
}
