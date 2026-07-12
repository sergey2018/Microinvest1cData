using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microinvest1cData.Egais
{
    public class Form2
    {
        public String FormB { get; set; }
        public Producer Shipper { get; set; }
        public Producer Consignee { get; set; }
        public Product Product { get; set; }
        public String TTNNumber { get; set; }
        public DateTime TTNDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public double Quantity { get; set; }

        public Form2()
        {
            Shipper = new Producer();
            Consignee = new Producer();
            Product = new Product();
        }
    }
}
