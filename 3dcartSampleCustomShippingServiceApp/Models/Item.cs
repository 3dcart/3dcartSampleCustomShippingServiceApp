namespace _3dcartSampleCustomShippingServiceApp.Models
{
    public class Item
    {
        public string sku { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public double unitprice { get; set; }
        public int unitweight { get; set; }
        public int unitlength { get; set; }
        public int unitwidth { get; set; }
        public int unitheight { get; set; }
    }
}