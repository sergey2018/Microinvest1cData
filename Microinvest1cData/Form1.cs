using Microinvest1cData.MSSQL;
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

namespace Microinvest1cData
{
    public partial class Form1 : Form
    {
        private DaoController controller;
        private Settings settings;
        public Form1()
        {
            InitializeComponent();
            if (File.Exists("settings.xml"))
            {
                InitSettings();
            }
            else
            {
                settings = new Settings
                {
                    Base = "",
                    Login = "",
                    Server = "",
                    Passwords = ""
                };
            }
        }
        private void InitSettings()
        {
            var document = XDocument.Load("settings.xml");
            var root = document.Root.Element("Set");
            settings = new Settings
            {
                Base = root.Attribute("Base").Value,
                Server = root.Attribute("server").Value,
                Login = root.Attribute("login").Value,
                Passwords = root.Attribute("Passwords").Value
            };
            controller = new DaoController(settings);
        }
    }
}
