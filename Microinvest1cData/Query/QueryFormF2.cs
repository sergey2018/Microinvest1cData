using Microinvest1cData.Egais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Microinvest1cData.Query
{
    public class QueryFormF2 : QveryAbstract
    {
        private String Form2 = "";
        private XNamespace qf= "http://fsrar.ru/WEGAIS/QueryFormF1F2";
        private XNamespace rfb = "http://fsrar.ru/WEGAIS/ReplyForm2";


        public QueryFormF2()
        {
            this.path = "QueryFormF2.xml";
            this.AddAtribut(new XAttribute(XNamespace.Xmlns +"qf", "http://fsrar.ru/WEGAIS/QueryFormF1F2"));
            this.Url = "QueryFormF2";
            this.xmlGet = new XmlGetValue();
        }

        public String GetForm2()
        {
            return Form2;
        }

        public String Create(String Form2)
        {
            this.element = new XElement(this.ns + "QueryFormF2", new XElement(qf + "FormRegId", Form2));
            this.CreateQuery();
            return this.QueryEgais();
        }

        public Form2 GetForm2(String Url)
        {
            LoadFile(Url, "ReplyFormB.xml");
            return Parser("ReplyFormB.xml");
        }

        private Form2 Parser(String path)
        {
            var doc = XDocument.Load(path);
            var form2 = new Form2();
            var document = doc.Root.Element(this.ns + "Document");
            var ReplyForm2 = document.Element(this.ns + "ReplyForm2");
            Form2 = ReplyForm2.Element(rfb + "InformF2RegId").Value;
            form2.FormB = Form2;
            form2.TTNNumber = ReplyForm2.Element(rfb + "TTNNumber").Value;
            form2.TTNDate = DateTime.Parse(ReplyForm2.Element(rfb + "TTNDate").Value);
            form2.Quantity = double.Parse(ReplyForm2.Element(rfb + "Quantity").Value);
            form2.ShippingDate = this.xmlGet.ParseDate(ReplyForm2, rfb + "ShippingDate");

            var shipperElement = ReplyForm2.Element(rfb + "Shipper");
            if (shipperElement != null)
                form2.Shipper = ParseClientInfo(shipperElement, this.oref);

            var consigneeElement = ReplyForm2.Element(rfb + "Consignee");
            if (consigneeElement != null)
                form2.Consignee = ParseClientInfo(consigneeElement, this.oref);

            // Продукт
            var productElement = ReplyForm2.Element(rfb + "Product");
            if (productElement != null)
                form2.Product = ParseProductInfo(productElement, this.pref, this.oref);
            return form2;
        }


        private Producer ParseClientInfo(XElement element, XNamespace oref)
        {
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

            var producerElement = element.Element(pref + "Producer")?.Element(oref + "UL");
            if (producerElement != null)
                product.producer = ParseClientInfo(producerElement, oref);

            return product;
        }

    }
}
