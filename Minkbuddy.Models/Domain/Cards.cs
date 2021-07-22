//Ajay Sharma - 20-07-2021
//All fields must be stored encrypted in local db
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Minkbuddy.Models.Domain
{
    public class Cards
    {
        public string SKU { get; set; }
        public string CardNumber { get; set; }
        public string CardPin { get; set; }
        public string ActivationCode { get; set; }
        public string ActivationUrl { get; set; }
        public string Amount { get; set; }
        public string Validity { get; set; }
    }
}
