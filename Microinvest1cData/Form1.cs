using Microinvest1cData.Forms;
using Microinvest1cData.MSSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            labelUpdate.Text = "";
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

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormSettings(settings);
            form.ShowDialog();
            InitSettings();
        }

        private void buttonGoods_Click(object sender, EventArgs e)
        {

            controller.GetLengthZCountG();
            var thread1 = new Thread(LoadData);
            var thread2 = new Thread(UpdateLabel);
            thread1.Start();
            thread2.Start();

        }
        private void UpdateLabel()
        {
            var lengt = controller.GetLength();
            while (controller.GetUpdateFlag())
            {
               
                var count = controller.GetCount();
                this.Invoke((MethodInvoker)delegate
                {
                    labelUpdate.Text = "Загружено " + count + " данных из "+lengt;
                });
               // System.Threading.Thread.Sleep(5000);
            }
            
        }
        private void LoadData()
        {
            controller.SetGroups();
            controller.GetGoods();
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show("Загрузка завершена");
            });
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            controller.UpdateBase();
        }

        private void LoadStore()
        {
            controller.GetObjects();
            controller.SetStore();
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show("Загрузка завершена");
            });
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            /* controller.GetLengthZCount();
             var thread1 = new Thread(LoadStore);
             var thread2 = new Thread(UpdateLabel);
             thread1.Start();
             thread2.Start();*/
            var XmlWrite = new XMLWrite(controller.GetSqlitecontroller());
            XmlWrite.CreateDocument("goods.xml");

        }

        private void labelUpdate_Click(object sender, EventArgs e)
        {

        }

        private void пробШтрихкодыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var forms = new FormBadBarcodes(controller.GetSqlitecontroller());
            forms.ShowDialog();
        }

        private void товарыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var forms = new FormGoods(controller.GetSqlitecontroller());
            forms.ShowDialog();
        }
    }
}
