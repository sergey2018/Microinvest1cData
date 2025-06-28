using Microinvest1cData.Data;
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
            root.Add(GetGroups());
            document.Add(root);
            document.Save(path);
        }

        private XElement GetGroups()
        {
            var element = new XElement("Группы");
            var list = controller.GetGroups();
            foreach(Groups g in list)
            {
                var egroup = new XElement("Группа");
                var eUUid = new XElement("Ссылка", g.UUid);
                var name = new XElement("Наименование", g.Name);
                var eParent = new XElement("Родитель", g.PaerntUUid);
                egroup.Add(eUUid, name, eParent);
                element.Add(egroup);
            }
              
            return element;

        }
        private XElement GetGoods()
        {
            var element = new XElement("Название");
            return element;
        }


    }
}
