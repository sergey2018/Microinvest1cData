using Microinvest1cData.Egais;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Microinvest1cData.Query
{
   public abstract class QveryAbstract
    {
        protected SettingsUtm set; //Настройки егаис
        protected String path; //Имя файла
        protected String Url; // адрес отправления
                              //Наименования файла
                              // Запрос в Егаис
        protected XNamespace ns = "http://fsrar.ru/WEGAIS/WB_DOC_SINGLE_01";
        protected XNamespace oref = "http://fsrar.ru/WEGAIS/ClientRef_v2";
        protected XNamespace pref = "http://fsrar.ru/WEGAIS/ProductRef_v2";
        protected XNamespace tc = "http://fsrar.ru/WEGAIS/Ticket";
        protected XElement element;
        protected String FileName;
        protected XmlGetValue xmlGet;
        private String Director="Direct";
        protected List<XAttribute> atributs = new List<XAttribute>();

        protected void AddAtribut(XAttribute attribute)
        {
            atributs.Add(attribute);
        }
        private void CreateDirect()
        {
           
            if (!Directory.Exists(Director))
            {
                Directory.CreateDirectory(Director);
            }
        }
        protected void CreateDirect(String path)
        {

            if (!Directory.Exists(Director))
            {
                Directory.CreateDirectory(Director+"/"+path);
            }
        }
        protected void CreateQuery() // Класс для формирования запроса в виде XML
        {

            CreateDirect();
            /* XDocument doc = new XDocument(

              new XElement(ns + "Documents",
                                new XAttribute("Version", "1.0"),
                                new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                                new XAttribute(XNamespace.Xmlns + "ns", "http://fsrar.ru/WEGAIS/WB_DOC_SINGLE_01"),

                                new XElement(ns + "Owner", new XElement(ns + "FSRAR_ID", set.Fsrar),
                                new XElement(ns + "Document", element)
   ))); //Создаем документ*/


            XDocument doc = new XDocument();
            XElement documents = new XElement(ns + "Documents", new XAttribute("Version", "1.0"),
                                new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                                new XAttribute(XNamespace.Xmlns + "ns", "http://fsrar.ru/WEGAIS/WB_DOC_SINGLE_01"));

            foreach(XAttribute atr in atributs)
            {
                documents.Add(atr);
            }
            documents.Add(new XElement(ns + "Owner", new XElement(ns + "FSRAR_ID", set.Fsrar)));
            documents.Add(new XElement(ns + "Document", element));
            doc.Add(documents);// Создаем документ 
             doc.Save(path); //Сохраняем документ
        }
        protected void LoadFile(String url,String file)
        {
            var xmlCuery = new XNetQuery();
            var xml = xmlCuery.xmlQvery(url);
            if (xml == "") return;
            if (xml.IndexOf("Ticket") != -1)
            {
                xml = xml.Substring(xml.IndexOf(Environment.NewLine));
            }
            var document = new XmlDocument();
            document.LoadXml(xml);
            document.Save(file);
        }
        protected String GetDirect(String path)
        {
            return Director + "/" + path;
        }
        public String QueryEgais() //Отправка запроса в ЕГАИС
        {
            XNetQuery query = new XNetQuery();
            query.netQuery(path, "http://" + set.Url + ":" + set.Port + "/opt/in/" + Url);
            return query.getUrl();
        }
        protected String ApsolutPath(String path)
        {
            return Directory.GetCurrentDirectory() + "/" + path;
        }
        public void DeleteDocument(String url)
        {
            XNetQuery qu = new XNetQuery();
            qu.deleteDocument(url);
        }
        public void SetSettings(SettingsUtm utm)
        {
            set = utm;
        }

        private void DeleteDocumentXml(String path)
        {
            File.Delete(path);
        }
        public String QueryEgaisSend(String refid)
        {
            XNetQuery query = new XNetQuery();
             query.outQuery("http://"+set.Url + ":" + set.Port + "/opt/out");
            String otvet = query.getOtvet();
            if (otvet == null) return "";
            XDocument doc = XDocument.Parse(otvet);
           // XElement element = doc.Root.Element("A");
            foreach (XElement e in doc.Root.Elements("url"))
            {
                if (e.Attribute("replyId") != null)
                {
                    if (e.Attribute("replyId").Value.Equals(refid))
                    {
                        return e.Value;
                    }
                }
            }
            Thread.Sleep(500);
            return "";
        }
       
    }
}
