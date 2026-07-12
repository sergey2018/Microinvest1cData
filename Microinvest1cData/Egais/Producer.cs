using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microinvest1cData.Egais
{
   public class Producer //Производители алкоголя
    {
        private int Id;
        private String clientRegid; // fsrar
        private String fullName; // Полное имя
        private String shortName; //краткое имя
        private String inn=""; //инн
        private String kpp=""; //кпп
        public AddressInfo Address { get; set; }
        public Producer()
        {
            Address = new AddressInfo();
        }

        public String UUID { get; set; }

        public string ClientRegid { get => clientRegid; set => clientRegid = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string ShortName { get => shortName; set => shortName = value; }
        public string Inn { get => inn; set => inn = value; }
        public string Kpp { get => kpp; set => kpp = value; }
        public int ID { get => Id; set => Id = value; }

    }
}
