
using Microinvest1cData.Egais;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Microinvest1cData.Query
{
    public class QueryParametr : QveryAbstract
    {

        private readonly XNamespace rst = "http://fsrar.ru/WEGAIS/ReplyRests_v3";
        private String R1Dicer = "R1";
        
        private DateTime date;
        private String tiketComment;
   
        public QueryParametr()
        {
            this.path = "QueryParameters_v3.xml";
            this.AddAtribut(new XAttribute(XNamespace.Xmlns + "qp", "http://fsrar.ru/WEGAIS/QueryParameters"));
            this.Url = "QueryRests_v3";
            CreateDirect(R1Dicer);
        }

        public string TiketComment { get => tiketComment; set => tiketComment = value; }
        public DateTime Date { get => date; set => date = value; }

        public String Create()
        {
   
            this.element = new XElement(this.ns + "QueryRests_v3");
            this.CreateQuery();
            return this.QueryEgais();
        }
        public List<StoreSklad> GetProduct(String url)
        {
            //this.FileName = this.GetDirect(R1Dicer) + "/" + this.GenerateFileName();
            LoadFile(url, "ReplyRests.xml");
            return Parser("ReplyRests.xml");
        }
        public String GetFile()
        {
            return this.ApsolutPath(this.FileName);
        }
        public List<StoreSklad> Parser(String path)
        {
            List<StoreSklad> list = new List<StoreSklad>();
            XDocument doc = XDocument.Load(path);
            XElement document = doc.Root.Element(this.ns+"Document");
            if (document.Element(this.ns + "Ticket") != null)
            {
                tiketComment = document.Element(this.ns + "Ticket").Element(this.tc+"Result").Element(this.tc+ "Comments").Value;
                return null;
            }
            XElement ReplyRests = document.Element(this.ns+ "ReplyRests_v3");
            XElement Producs = ReplyRests.Element(rst + "Products");
            date = DateTime.Now;
            foreach (XElement StokPosition in Producs.Elements(rst+ "StockPosition"))
            {
                StoreSklad stk = new StoreSklad
                {
                    FormA = StokPosition.Element(rst + "InformF1RegId").Value,
                    FormB = StokPosition.Element(rst + "InformF2RegId").Value,
                    Qtty = double.Parse(StokPosition.Element(rst + "Quantity").Value),
                    Product = new Product
                    {
                        Name = StokPosition.Element(rst + "Product").Element(this.pref + "FullName").Value,
                        AlcCode = StokPosition.Element(rst + "Product").Element(this.pref + "AlcCode").Value,
                        UnitType = StokPosition.Element(rst + "Product").Element(this.pref + "UnitType").Value
                    }
                };
                if (StokPosition.Element(rst + "Product").Element(this.pref + "Capacity") != null)
                {
                    stk.Product.Capacity = double.Parse(StokPosition.Element(rst + "Product").Element(this.pref + "Capacity").Value);
                }
                else
                {
                    stk.Product.Capacity = 10;
                }

                stk.Product.AlcVolume = double.Parse(StokPosition.Element(rst + "Product").Element(this.pref + "AlcVolume").Value);
                stk.Product.ProductVCode = int.Parse(StokPosition.Element(rst + "Product").Element(this.pref + "ProductVCode").Value);
                Producer producer = new Producer();
                XElement prod = StokPosition.Element(rst + "Product").Element(this.pref + "Producer");
                XElement child = prod.Descendants().First();
               
                    producer.ClientRegid = child.Element(this.oref + "ClientRegId").Value;
                    producer.FullName = child.Element(this.oref + "FullName").Value;
                    producer.ShortName = child.Element(this.oref + "ShortName").Value;
                     if (child.Element(this.oref + "INN")!=null)
                      {
                             producer.Inn = child.Element(this.oref + "INN").Value;
                             producer.Kpp = child.Element(this.oref + "KPP").Value;
                             producer.Address.RegionCode = child.Element(this.oref + "address").Element(this.oref + "RegionCode").Value;
                }
                    producer.Address.Country = child.Element(this.oref + "address").Element(this.oref + "Country").Value;
                   
                    producer.Address.Description = child.Element(this.oref + "address").Element(this.oref + "description").Value;
             
                stk.Producer = producer;
                stk.Product.ClientRegidP = producer.ClientRegid;
                list.Add(stk);
            }
            File.Delete("ReplyRests.xml");
            return list;
        }
    }
}
