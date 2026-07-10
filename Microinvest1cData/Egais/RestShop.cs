using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microinvest1cData.Egais
{
    public class RestShop
    {

        private double qtty;
        public Producer Producer { get; set; } = new Producer();
        public Producer Importer { get; set; } = new Producer();
        public String ClientRefid { get; set; } = "";
        public Product Product { get; set; } = new Product();
        

        public double Qtty { get => qtty; set => qtty = value; }
      
    }
}
