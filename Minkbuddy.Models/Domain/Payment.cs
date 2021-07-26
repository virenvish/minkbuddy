//Ajay
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Minkbuddy.Models.Domain
{
    public class Payment
    {
        [Required]
        public string Code { get; set; } = "svc";

        [Required]
        public Decimal Amount { get; set; }

        public decimal Balance { get; set; }
    }
}
