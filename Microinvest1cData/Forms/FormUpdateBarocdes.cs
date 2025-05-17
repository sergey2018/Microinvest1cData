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
    public partial class FormUpdateBarocdes : Form
    {
        private Barcodes3 barcode;
        private Sqlitecontroller Sqlitecontroller;
        public FormUpdateBarocdes(Barcodes3 bar,Sqlitecontroller sqlitecontroller)
        {
            InitializeComponent();
            barcode = bar;
            textBox1.Text = barcode.Barcode;
            Sqlitecontroller = sqlitecontroller;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            barcode.Barcode = textBox1.Text;
            Sqlitecontroller.UIpdateBarcodes(barcode);
            Close();
        }
    }
}
