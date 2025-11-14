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
            root.Add(GetGoods());
            root.Add(GetBarcode());
            document.Add(root);
            document.Save(path);
        }

        private XElement GetGroups()
        {
            var element = new XElement("Группы");
            var list = controller.GetGroups();
            var cod = controller.GetMaxCode() + 1; 
            foreach(Groups g in list)
            {
                var egroup = new XElement("Группа");
                var eUUid = new XElement("Ссылка", g.UUid);
                var name = new XElement("Наименование", g.Name);
                var code = new XElement("Код", cod);
                var eParent = new XElement("Родитель", g.PaerntUUid);
                egroup.Add(eUUid, name, eParent,code);
                element.Add(egroup);
                cod++;
            }
              
            return element;

        }
        private XElement GetGoods()
        {
            var element = new XElement("Товары");
            var list = controller.GetGoods();
            foreach (Goods g in list)
            {
                var good = new XElement("Товар");
                var name = new XElement("Название", g.Name);
                var name2 = new XElement("ПолноеНазвание", g.Name2);
                var type = new XElement("Тип", g.Type);
                var uuid = new XElement("Cсылка", g.UUid);
                var art = new XElement("Артикул", g.Catalog);
                var code = new XElement("Код", g.Code);
                var measure = new XElement("ЕдИзм", g.Measure.Replace(".",""));
                var grouUUId = new XElement("ГруппаССылка",controller.getGroupUUID(g.Groupid));
                good.Add(name, name2, type, uuid, art,code, measure, grouUUId);
                element.Add(good);
            }

            return element;
        }

        private XElement GetBarcode()
        {
            var element = new XElement("Штрихкоды");
            var list = controller.GetBarcodes();
            foreach (Barcodes3 bar in list)
            {
                var barcod = new XElement("Штрихкод");
                var good = new XElement("ТоварССылка", bar.UUId);
                var val = new XElement("Штрих", bar.Barcode);
                barcod.Add(good, val);
                element.Add(barcod);
            }
            return element;
            
        }


    }
}
