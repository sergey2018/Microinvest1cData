using Microinvest1cData.Data;
using Microinvest1cData.Egais;
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
            root.Add(GetAlkoProducer());
            root.Add(GetALkoProduct());
            root.Add(GETLinkEgais());
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
        private XElement GetALkoProduct()
        {
            var list = controller.GetProducers();
            var element = new XElement("КонтрагентыЕгаис");
            foreach(Producer pr in list)
            {
                var kont = new XElement("КонтрагентЕ");
                kont.Add(new XElement("ПолноеНаименование", pr.FullName),new XElement("КраткоеНаименование",pr.ShortName),new XElement("ИНН",pr.Inn),
                    new XElement("КПП",pr.Kpp),new XElement("ССылка",pr.UUID), new XElement("Адрес",pr.Description),new XElement("Страна",pr.Country));
                element.Add(kont);
            }
            return element;
        }
        private XElement GETLinkEgais()
        {
            var list = controller.GetEgais();
            var element = new XElement("СвязьЕгаис");
            foreach (LinkEgais egais in list)
            {
                var eg = new XElement("ЕгаисС");
                eg.Add(new XElement("ССылкаЕгаис", egais.PUUD), new XElement("ССылкаНоменклатура",egais.GUUID));
                element.Add(eg);
            }
            return element;
        }

        private XElement GetAlkoProducer()
        {

            var list = controller.GetProduct();
            var element = new XElement("НоменклатураЕгаис");
            foreach(Product p in list)
            {
                var product = new XElement("ТоварЕгаис");
                var name = new XElement("Наименование", p.Name);
                var code = new XElement("КодЕгаис", p.AlcCode);
                var uuid = new XElement("ССылка", p.UUID);
                var capasity = new XElement("Емкость", p.Capacity);
                var alkVolemu = new XElement("Спирт", p.AlcVolume);
                var ProductVCode = new XElement("КодПродукции", p.ProductVCode);
                var Client = new XElement("Производитель", controller.GetUUidProducer(p.ClientRegid));
                product.Add(uuid, name, code, capasity, alkVolemu, ProductVCode, Client);
                element.Add(product);
            }
            return element;
        }
        private XElement GetGoods()
        {
            var cod = controller.GetMaxCode() + 1;
            controller.UpdateCodeFirst(cod);
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
