//Ajay Sharma - 20-07-2021
//To detect and Log failure message.
//Through the api message is received as below

using System;
using System.Collections.Generic;
using System.Text;

namespace Minkbuddy.Models.Domain
{
    public class Failure
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string[] Messages { get; set; }
    }
}
