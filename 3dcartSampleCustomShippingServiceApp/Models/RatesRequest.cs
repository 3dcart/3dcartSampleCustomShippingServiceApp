using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3dcartSampleCustomShippingServiceApp.Models
{
    public class RatesRequest
    {
        public int orderid { get; set; }
        public string weightunit { get; set; }
        public string measurementunit { get; set; }
        public int totalitems { get; set; }
        public int totalweight { get; set; }
        public double orderamount { get; set; }
        public Shippingfrom shippingfrom { get; set; }
        public Shippingto shippingto { get; set; }
        public List<Item> items { get; set; }
    }
}