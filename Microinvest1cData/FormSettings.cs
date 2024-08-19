using Microinvest1cData.MSSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Microinvest1cData
{
    public partial class FormSettings : Form
    {
        private Settings settings;
        public FormSettings(Settings setting)
        {
            InitializeComponent();
            settings = setting;
            textBoxServer.Text = settings.Server;
            textBoxBase.Text = settings.Base;
            textBoxLogin.Text = settings.Login;
            textBoxPasswords.Text = settings.Passwords;
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            Setsettings();
            var daoServer = new DAOServer(settings);
            daoServer.Test();
            if (daoServer.IsConnect)
            {
                MessageBox.Show("Соединение установлено");
            }
            else
            {
                MessageBox.Show("Нет Подключения");
            }
        }
        private void Setsettings()
        {
            settings.Base = textBoxBase.Text;
            settings.Server = textBoxServer.Text;
            settings.Login = textBoxLogin.Text;
            settings.Passwords = textBoxPasswords.Text;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Setsettings();
            var doc = new XDocument();
            var root = new XElement("Settigs");
            root.Add(new XElement("Set", 
                new XAttribute("server", settings.Server), 
                new XAttribute("Base", settings.Base),new XAttribute("login",settings.Login),
                new XAttribute("Passwords",settings.Passwords)));
            doc.Add(root);
            doc.Save("settings.xml");
        }
    }
}
