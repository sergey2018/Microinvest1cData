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
    public partial class FormMeasure : Form
    {
        private Sqlitecontroller controller;
        private List<String> measure = new List<String>();
        public FormMeasure(Sqlitecontroller sqlitecontroller)
        {
            InitializeComponent();
            controller = sqlitecontroller;
            update();

        }

        private void update()
        {
            listBoxMeasure.Items.Clear();
            measure = controller.GetMeasure();
            foreach(String st in measure)
            {
                listBoxMeasure.Items.Add(st);
            }
        }


    }
}
