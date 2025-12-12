using Microinvest1cData.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microinvest1cData.Forms
{
    public partial class FormDoubCode : Form
    {
        private Sqlitecontroller controller;
        private List<Goods> goods;
        public FormDoubCode(Sqlitecontroller sqlitecontroller)
        {
            InitializeComponent();
            controller = new Sqlitecontroller();
            goods = new List<Goods>();
            UpdateGoods();
        }

        private void UpdateGoods()
        {
            goods = controller.GetDoubleCode();
            dataGridViewGoods.Rows.Clear();
            foreach (Goods g in goods)
            {
                var rows = dataGridViewGoods.Rows.Add();
                dataGridViewGoods.Rows[rows].Cells[0].Value = g.Code;
                dataGridViewGoods.Rows[rows].Cells[1].Value = g.Name;
                //dataGridViewGoods.Rows[rows].Cells[2].Value = g.Measure;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewGoods.CurrentCell.RowIndex != -1)
            {
                var good = goods[dataGridViewGoods.CurrentCell.RowIndex];
                var cod = controller.GetMaxCode() + 1;
                controller.UpdateCode(cod.ToString(), good.ID);
                UpdateGoods();
            }

        }
    }
}
