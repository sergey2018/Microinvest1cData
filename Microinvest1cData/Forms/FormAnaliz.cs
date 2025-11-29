using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microinvest1cData.Data
{
    public partial class FormAnaliz : Form
    {
        private Sqlitecontroller controller;
        public FormAnaliz(Sqlitecontroller sqlitecontroller)
        {
            InitializeComponent();
            controller = sqlitecontroller;
        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            listBoxReports.Items.Clear();
            listBoxReports.Items.Add("Количество нераспознанных штрихкодов: " + controller.CounProblemBarkode() + " шт.");
            listBoxReports.Items.Add("Количество нечисловых кодов: " + controller.CountIsnumerik() + " шт.");
            listBoxReports.Items.Add("Количество дублируюших  кодов: " + controller.CountDoubleCode() + " шт.");
            listBoxReports.Items.Add("Количество длинных кодов: " + controller.ReportsBigLengCode() + " шт.");


        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
