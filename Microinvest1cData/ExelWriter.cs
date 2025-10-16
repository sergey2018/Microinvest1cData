using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microinvest1cData.Data;
using Microsoft.Office.Interop.Excel;

namespace Microinvest1cData
{
    public class ExelWriter
    {
        private Sqlitecontroller Sqlitecontroller;
        public ExelWriter(Sqlitecontroller sqlitecontroller)
        {
            Sqlitecontroller = sqlitecontroller;
        }


        public void CreateFile()
        {
            var groups = Sqlitecontroller.GetGroups();
            foreach(Groups g in groups)
            {
                var Goods = Sqlitecontroller.GetExelNSIs(g.Name);

                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.Application.Workbooks.Add(System.Reflection.Missing.Value);
                app.Columns.ColumnWidth = 15;
                //app.Range
                app.Cells[2, 1] = "Артикул";
                app.Cells[2, 2] = "Группа/Родитель";
                app.Cells[2, 3] = "Наименование";
                app.Cells[2, 4] = "Базовая единица по классификатору";
                app.Cells[2, 5] = "Единица измерения срока реализации";
                app.Cells[2, 6] = "Тип номенклатуры";
                app.Cells[2, 7] = "Штрих-код";
                for (int i = 0; i < Goods.Count; i++)
                {
                    app.Cells[i + 3, 1] = Goods[i].Code;
                    app.Cells[i + 3, 2] = Goods[i].Group;
                    app.Cells[i + 3, 3] = Goods[i].Name;
                    app.Cells[i + 3, 4] = Goods[i].Measure.Replace('.', '\0');
                    app.Cells[i + 3, 6] = "Товар";
                    app.Cells[i + 3, 7] = Goods[i].Barcode;
                }
                // app.Visible = true;
               var path =  Directory.GetCurrentDirectory();
                app.ActiveWorkbook.SaveAs(path+"\\"+g.Name+".xlsx");
                app.Workbooks.Close();
                app.Quit();
                app = null;
            }

        }
        public void CreateFilePrice()
        {
            var prices = Sqlitecontroller.aktPrices();
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Application.Workbooks.Add(System.Reflection.Missing.Value);
            app.Columns.ColumnWidth = 15;
            app.Cells[1, 1] = "Наименование номенклатуры";
            app.Cells[1, 2] = "Артикул";
            app.Cells[1, 3] = "Новая розничная цена";
            for(int i = 0; i<prices.Count; i++)
            {
                app.Cells[i + 2, 1] = prices[i].Name;
                app.Cells[i + 2, 2] = prices[i].Code;
                app.Cells[i + 2, 3] = prices[i].Price;
            }
            var path = Directory.GetCurrentDirectory();
            app.ActiveWorkbook.SaveAs(path + "\\Цены.xlsx");
            app.Workbooks.Close();
            app.Quit();
            app = null;
        }
        public void CreateFileStore()
        {
            var store = Sqlitecontroller.aktStore();
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Application.Workbooks.Add(System.Reflection.Missing.Value);
            app.Columns.ColumnWidth = 15;
            app.Cells[1, 1] = "Наименование номенклатуры";
            app.Cells[1, 2] = "Артикул";
            app.Cells[1, 3] = "Количество";
            app.Cells[1, 4] = "Приходная цена";
            app.Cells[1, 5] = "Приходная сумма";
            app.Cells[1, 6] = "Розничная цена";
            app.Cells[1, 7] = "Розничная сумма";
            for (int i = 0; i < store.Count; i++)
            {
                app.Cells[i + 2, 1] = store[i].Name;
                app.Cells[i + 2, 2] = store[i].Code;
                app.Cells[i + 2, 3] = store[i].Qtty;
                app.Cells[i + 2, 4] = store[i].PriceIn;
                app.Cells[i + 2, 5] = store[i].PriceInSum;
                app.Cells[i + 2, 6] = store[i].PriceOut;
                app.Cells[i + 2, 7] = store[i].PriceOutSum;
            }
            var path = Directory.GetCurrentDirectory();
            app.ActiveWorkbook.SaveAs(path + "\\Остатки.xlsx");
            app.Workbooks.Close();
            app.Quit();
            app = null;
        }

    }
}
