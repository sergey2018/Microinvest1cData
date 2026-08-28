using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microinvest1cData.Egais
{
   public class StoreSklad //Остатки склада
    {

        private String formA;
        private String formB;
        private double qtty;

        public Product Product{ get; set; }
        public Producer Producer { get; set; }
        public StoreSklad()
        {
            Product = new Product();
        }
        public StoreSklad(Product pr)
        {
            Product = pr;
        }
        public StoreSklad(StoreSkladMini mini)
        {
            Product = new Product();
            formA = mini.FormA;
            formB = mini.FormB;
            qtty = mini.Quantity;
            Product.AlcCode = mini.AlcCode;
        }
        public string FormA { get => formA; set => formA = value; }
        public string FormB { get => formB; set => formB = value; }
        public double Qtty { get => qtty; set => qtty = value; }
    }
}
