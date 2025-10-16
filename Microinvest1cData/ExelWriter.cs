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
                app.ActiveWorkbook.SaveAs(path+"\\"+g.Name+".xls");
                app.Workbooks.Close();
                app.Quit();
                app = null;
            }

        }
    }
}
