using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microinvest1cData.Egais
{
    public class Form1
    {
        public String InformF1RegId { get; set; }
        public Producer OriginalClient { get; set; }
        public String OriginalDocNumber { get; set; }
        public DateTime OriginalDocDate { get; set; }

        public Product Product { get; set; }
        public DateTime BottlingDate{get;set; }
        public double Quantity { get; set; }
        public String EGAISNumber { get; set; }
        public DateTime EGAISDate { get; set; }
    }
}
