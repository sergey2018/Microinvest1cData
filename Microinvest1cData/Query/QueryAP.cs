using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using Microinvest1cData.Egais;

namespace Microinvest1cData.Query
{
    public class QueryAP : QveryAbstract
    {
        private XNamespace qp = "http://fsrar.ru/WEGAIS/QueryParameters";
        private XNamespace rap = "http://fsrar.ru/WEGAIS/ReplyAP";
        private XNamespace pref = "http://fsrar.ru/WEGAIS/ProductRef";
        private XNamespace oref = "http://fsrar.ru/WEGAIS/ClientRef";
        public QueryAP()
        {
            this.path = "QueryAP.xml";
            this.AddAtribut(new XAttribute(XNamespace.Xmlns + "qp", "http://fsrar.ru/WEGAIS/QueryParameters"));
            this.Url = "QueryAP";
        }

        public String Create(String alcokod)
        {
            this.element = new XElement(this.ns + "QueryAP",new XElement(qp+ "Parameters",new XElement(qp+ "Parameter",new XElement(qp+ "Name","Код"),new XElement(qp+ "Value",alcokod))));
            this.CreateQuery();
            return this.QueryEgais();
        }
        public RestShop getProduct(String url)
        {
            LoadFile(url, "ReplyAP.xml");
            return Parser("ReplyAP.xml");
        }
        public RestShop Parser(String path)
        {
            var doc = XDocument.Load(path);
            var shop = new RestShop();
            var document = doc.Root.Element(this.ns + "Document");
            var ReplyAP = document.Element(this.ns+ "ReplyAP");
            var Product = ReplyAP.Element(rap + "Products").Element(rap+ "Product");
            Console.WriteLine(Product.ToString());
           shop.Product.Name = Product.Element(pref + "FullName").Value;
            shop.Product.AlcCode = Product.Element(pref + "AlcCode").Value;
            shop.Product.Capacity = double.Parse(Product.Element(pref + "Capacity").Value);
           // shop.UnitType = Product.Element(pref + "UnitType").Value;
            shop.Product.AlcVolume = double.Parse(Product.Element(pref + "AlcVolume").Value);
            shop.Product.ProductVCode = int.Parse(Product.Element(pref + "ProductVCode").Value);
            var Producer = Product.Element(pref + "Producer");
           // var child = Producer.Descendants().First();
            var producer = new Producer();
            producer.ClientRegid = Producer.Element(oref + "ClientRegId").Value;
            producer.FullName = Producer.Element(oref + "FullName").Value;
            producer.ShortName = Producer.Element(oref + "ShortName").Value;
            if (Producer.Element(oref + "INN") != null)
            {
                producer.Inn = Producer.Element(oref + "INN").Value;
                producer.Kpp = Producer.Element(oref + "KPP").Value;
                producer.Address.RegionCode = Producer.Element(oref + "address").Element(oref + "RegionCode").Value;
            }
            producer.Address.Country = Producer.Element(oref + "address").Element(oref + "Country").Value;

            producer.Address.Description = Producer.Element(oref + "address").Element(oref + "description").Value;
            shop.Producer = producer;
            if(Product.Element(pref+ "Importer") != null)
            {
                var Importer = Product.Element(pref + "Importer");
                var importer = new Producer();
                importer.ClientRegid = Importer.Element(oref + "ClientRegId").Value;
                importer.FullName = Importer.Element(oref + "FullName").Value;
                importer.ShortName = Importer.Element(oref + "ShortName").Value;
                if (Importer.Element(oref + "INN") != null)
                {
                    importer.Inn = Importer.Element(oref + "INN").Value;
                    importer.Kpp = Importer.Element(oref + "KPP").Value;
                    //importer.Region = Importer.Element(oref + "address").Element(oref + "RegionCode").Value;
                }
                importer.Address.Country = Importer.Element(oref + "address").Element(oref + "Country").Value;

                importer.Address.Description = Importer.Element(oref + "address").Element(oref + "description").Value;
                shop.Importer = importer;
            }
          
            return shop;
        }
    }
}
