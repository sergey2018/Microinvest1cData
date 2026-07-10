using Microinvest1cData.Egais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Microinvest1cData.Forms
{
    public partial class SettingsUtmForm : Form
    {
        private Sqlitecontroller controller;
       
        public SettingsUtmForm(Sqlitecontroller con)
        {
            InitializeComponent();
            controller = con;
            controller.initSettigs();
            //utm = con.SettingsUtm();
            textBoxUrl.Text = controller.SettingsUtm().Url;
            textBoxPort.Text = controller.SettingsUtm().Port;
            textFsrar.Text = controller.SettingsUtm().Fsrar;
        }

        private void textBoxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void textFsrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var utm = new SettingsUtm();
            utm.Id = 1;
            utm.Url = textBoxUrl.Text;
            utm.Port = textBoxPort.Text;
            utm.Fsrar = textFsrar.Text;
            controller.UpdateSettings(utm);
            Close();
            /*
            XDocument doc = new XDocument();
            XElement element = new XElement("set");
            element.Add(utm.GetElement());
            doc.Add(element);
            doc.Save("set.xml");
            */
            
        }
    }
}
