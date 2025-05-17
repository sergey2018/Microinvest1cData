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
    public partial class FormBadBarcodes : Form
    {
        private Sqlitecontroller controller;
        private List<Barcodes3> barcodes3s;
        public FormBadBarcodes(Sqlitecontroller sqlitecontroller)
        {
            InitializeComponent();
            controller = new Sqlitecontroller();
            barcodes3s = new List<Barcodes3>();
           
            UpdateBarcodes();
        }


        private void UpdateBarcodes()
        {
            barcodes3s = controller.GetBarcodes();
            dataGridViewBarocdes.Rows.Clear();
            foreach(Barcodes3 bar in barcodes3s)
            {
                var rows = dataGridViewBarocdes.Rows.Add();
                dataGridViewBarocdes.Rows[rows].Cells[0].Value = bar.Barcode;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы хотите удалить", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                var rows = dataGridViewBarocdes.CurrentCell.RowIndex;
                controller.DeleteBarcodes(barcodes3s[rows].ID);
                UpdateBarcodes();
            }
        }

        private void buttonOutRКоде_Click(object sender, EventArgs e)
        {
            foreach(Barcodes3 bar in barcodes3s)
            {
                if (bar.Barcode.Length <= 13)
                {
                    controller.SetBarcode(bar.MID, bar.Barcode, 0);
                    controller.DeleteBarcodes(bar.ID);
                }
            }
            UpdateBarcodes();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            var rows = dataGridViewBarocdes.CurrentCell.RowIndex;
            var form = new FormUpdateBarocdes(barcodes3s[rows], controller);
            form.ShowDialog();
            UpdateBarcodes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rows = dataGridViewBarocdes.CurrentCell.RowIndex;
            String[] barcod = barcodes3s[rows].Barcode.Split(',');
            foreach(String str in barcod)
            {
                controller.SetBarcode(barcodes3s[rows].MID, str.Trim(), 0);
            }
            controller.DeleteBarcodes(barcodes3s[rows].ID);
            UpdateBarcodes();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void разпознатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rows = dataGridViewBarocdes.CurrentCell.RowIndex;
            String[] barcod = barcodes3s[rows].Barcode.Split(',');
            MessageBox.Show("Разпознано " + barcod.Length + " Штрихкодов");
        }

        private void dataGridViewBarocdes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonUpdate_Click(sender, e);
        }
    }
}
