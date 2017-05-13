using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise.Models
{
    public class Address
    {
        public string City { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
    }
}