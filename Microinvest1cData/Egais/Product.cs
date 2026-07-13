using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microinvest1cData.Egais
{
   public class Product
    {
        public Product()
        {
            this.producer = new Producer();
        }

        public int ID { get; set; }
        public String Name { get; set; } = "";
        public String AlcCode { get; set; }
        public String UnitType { get; set; } = "";
        public double AlcVolume { get; set; } = 0;
        public int ProductVCode { get; set; } = 0;
        public double Capacity { get; set; } = 0;
        public String ClientRegid { get; set; }
        public String UUID { get; set; } = "";
        public String ClientRegidP { get; set; }
        public Producer  producer { get; set; }

        public void Setproduct()
        {
            ClientRegid = producer.ClientRegid;
        }
    }
}
