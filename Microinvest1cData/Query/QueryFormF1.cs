using Microinvest1cData.Egais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Microinvest1cData.Query
{
    public class QueryFormF1: QveryAbstract
    {
        //private String Form1 = "";
        private XNamespace qf = "http://fsrar.ru/WEGAIS/QueryFormF1F2";
        private XNamespace rfa = "http://fsrar.ru/WEGAIS/ReplyForm1";

        public QueryFormF1()
        {
            this.path = "QueryFormF1.xml";
            this.AddAtribut(new XAttribute(XNamespace.Xmlns + "qf", "http://fsrar.ru/WEGAIS/QueryFormF1F2"));
            this.Url = "QueryFormF1";
            this.xmlGet = new XmlGetValue();
        }

        public String Create(String Form1)
        {
            this.element = new XElement(this.ns + "QueryFormF1", new XElement(qf + "FormRegId", Form1));
            this.CreateQuery();
            return this.QueryEgais();
        }

        public Form1 GetForm1(String url)
        {
            LoadFile(Url, "ReplyFormA.xml");
            return Parser("ReplyFormA.xml");
        }

        private Form1 Parser(string path)
        {
            




            throw new NotImplementedException();
        }

        private Producer ParseClientInfo(XElement element, XNamespace oref)
        {
            var s = this.xmlGet.GetElementValue(element, oref + "ClientRegId");
            return new Producer
            {
                ClientRegid = this.xmlGet.GetElementValue(element, oref + "ClientRegId"),
                Inn = this.xmlGet.GetElementValue(element, oref + "INN"),
                Kpp = this.xmlGet.GetElementValue(element, oref + "KPP"),
                FullName = this.xmlGet.GetElementValue(element, oref + "FullName"),
                ShortName = this.xmlGet.GetElementValue(element, oref + "ShortName"),
                Address = ParseAddress(element.Element(oref + "address"), oref)
            };
        }
        private AddressInfo ParseAddress(XElement element, XNamespace oref)
        {
            if (element == null) return null;

            return new AddressInfo
            {
                Country = this.xmlGet.GetElementValue(element, oref + "Country"),
                RegionCode = this.xmlGet.GetElementValue(element, oref + "RegionCode"),
                Description = this.xmlGet.GetElementValue(element, oref + "description")
            };
        }
        private Product ParseProductInfo(XElement element, XNamespace pref, XNamespace oref)
        {
            var product = new Product
            {
                Name = this.xmlGet.GetElementValue(element, pref + "FullName"),
                AlcCode = this.xmlGet.GetElementValue(element, pref + "AlcCode"),
                Capacity = this.xmlGet.ParseDecimal(element, pref + "Capacity"),
                UnitType = this.xmlGet.GetElementValue(element, pref + "UnitType"),
                AlcVolume = this.xmlGet.ParseDecimal(element, pref + "AlcVolume"),
                ProductVCode = int.Parse(this.xmlGet.GetElementValue(element, pref + "ProductVCode"))
            };

            var producerElement = element.Element(pref + "Producer").Element(oref + "UL");
            if (producerElement != null)
                product.producer = ParseClientInfo(producerElement, oref);

            return product;
        }
    }
}
