using Microinvest1cData.Egais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Microinvest1cData
{
    public class ReadXML
    {
        private Sqlitecontroller controller;

        public ReadXML(Sqlitecontroller controller)
        {
            this.controller = controller;
        }

        public void ReadXMLFile(String path)
        {
            var document = XDocument.Load(path);
            var root = document.Root.Element("Products");
            foreach (XElement elem in root.Elements("Product"))
            {
                var product = new Product();
                var producer1 = new Producer();
                product.UUID = Guid.NewGuid().ToString();
                product.Name = elem.Element("name").Value;
                product.AlcCode = elem.Element("AlcCode").Value;
                product.AlcVolume = double.Parse(elem.Element("AlcVolume").Value);
                product.UnitType = elem.Element("UnitType").Value;
                product.Capacity = double.Parse(elem.Element("Capacity").Value);
                product.ProductVCode = int.Parse(elem.Element("ProductVCode").Value);
                var producer = elem.Element("Producer");
                product.UUID = Guid.NewGuid().ToString();
                if (producer.Element("INN") != null)
                {
                    producer1.Inn = producer.Element("INN").Value;
                }
                if (producer.Element("Kpp") != null)
                {
                    producer1.Kpp = producer.Element("Kpp").Value;
                }
                producer1.FullName = producer.Element("FullName").Value;
                producer1.ShortName = producer.Element("ShortName").Value;
                producer1.Country = producer.Element("Country").Value;
                producer1.Description = producer.Element("Description").Value;
                producer1.ClientRegid = producer.Element("clientRegid").Value;
                product.ClientRegid = producer.Element("clientRegid").Value;
                producer1.UUID = Guid.NewGuid().ToString();
                controller.SetProduct(product);
                controller.SetProducer(producer1);
                var formAB = elem.Element("Forms");
                 foreach (XElement formAd in formAB.Elements("Form"))
                 {
                     var forms = new FormAB();
                     forms.FormA = formAd.Element("FormA").Value;
                     forms.FormB = formAd.Element("FormB").Value;
                     forms.AlkCode = elem.Element("AlcCode").Value;
                     forms.UUID = Guid.NewGuid().ToString();
                    controller.SetFormAB(forms);
                     /*var marks = formAd.Element("Mark");
                     foreach (XElement am in marks.Elements("am"))
                     {
                         forms.Marks.Add(am.Value);
                     }
                     markkode.FormaB.Add(forms);*/


                 }

              


            }
        }


    }
}
