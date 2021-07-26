//Ajay Sharma - 20-07-2021

using System;
using System.Collections.Generic;
using System.Text;

namespace Minkbuddy.Models.Domain
{
    public class Shipments
    {
        public IList<Tracks> Tracks { get; set; }
    }

    public class Tracks
    {
        public string Label { get; set; }
        public string Awb { get; set; }
        public string Url { get; set; }
    }
}
