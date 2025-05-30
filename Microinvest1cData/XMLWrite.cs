using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Microinvest1cData
{
   public class XMLWrite
    {
        private Sqlitecontroller controller;
        public XMLWrite(Sqlitecontroller cont)
        {
            controller = cont;
        }

        public void CreateDocument(String path)
        {
            var document = new XDocument();
            var root = new XElement("Документ");
            document.Add(root);
            document.Save(path);
        }

        private XElement GetGoods()
        {
            var element = new XElement("Группы");
            
            return element;

        }


    }
}
