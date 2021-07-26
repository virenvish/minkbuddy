//Ajay Sharma - 20-07-2021

using Minkbuddy.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Minkbuddy.Models.Domain
{
    public class Orders
    {
        public IList<Address> Addresses { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Minimum 2 characters required")]
        [MaxLength(55, ErrorMessage = "Maximum 100 characters allowed")]
        public string RefNo { get; set; } = Convert.ToString(new Guid("minkbuddy" + DateTime.UtcNow.ToString()));

        public bool SyncOnly { get; set; }
        public string CouponCode { get; set; }
        public DeliveryMode DeliveryMode { get; set; } = DeliveryMode.API;
        public IList<Product> Products { get; set; }
        public IList<Payment> Payments { get; set; }

        //For Response
        //Could be removed as move further
        public IList<Cards> Cards { get; set; }
    }

    public class OrderDetails
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public string StatusLabel { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Date { get; set; }
        public Decimal GrandTotal { get; set; }
        public Decimal SubTotal { get; set; }

        //To be ignored
        //public Decimal Discount { get; set; }

        public CorporateDiscount CorporateDiscount { get; set; }
        public int TotalQty { get; set; }

        public IList<Product> Products { get; set; }
        public Currency Currency { get; set; }

        //Could be removed as we move further
        public Address Address { get; set; }
        public string EtaMessage { get; set; }
        public Shipments Shipments { get; set; }

        //Required payments here. To be discussed
        public bool Cancel { get; set; } //Order can be cancelled flag
    }
}
