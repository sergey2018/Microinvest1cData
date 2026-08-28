
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
using System.Threading;
using Microinvest1cData.Query;
using Microinvest1cData.Egais;

namespace Microinvest1cData.Forms
{
    public partial class FormR1 : Form
    {
        private QueryParametr parametr = new QueryParametr();
        private Sqlitecontroller controller;
        private List<StoreSklad> sklads;
        
        public FormR1(Sqlitecontroller utm)
        {
            InitializeComponent();
            controller = utm;
            parametr.SetSettings(controller.SettingsUtm());
            var refid = controller.GetRefid("QureyR1");
            if (refid.Count > 0)
            {
                createSend(refid[0]);
            }
            else
            {
                if (File.Exists("ReplyRests.xml"))
                {
                    sklads = new List<StoreSklad>();
                    sklads = parametr.Parser("ReplyRests.xml");
                    foreach (StoreSklad sklad in sklads)
                    {
                        int rows = DataGridR1.Rows.Add();
                        DataGridR1.Rows[rows].Cells[0].Value = sklad.Product.Name;
                        DataGridR1.Rows[rows].Cells[1].Value = sklad.Product.AlcCode;
                        DataGridR1.Rows[rows].Cells[2].Value = sklad.FormA;
                        DataGridR1.Rows[rows].Cells[3].Value = sklad.FormB;
                        DataGridR1.Rows[rows].Cells[4].Value = sklad.Qtty;
                    }

                }
            }
           
            
        }

        private async void createSend(String refid)
        {
            labelProcess.Text = "Ожидайте";
            buttonSend.Enabled = false;
            await Task.Run(() => UpdateEgais(refid));
        }
        private void UpdateEgais(String redid)
        {
            while (true)
            {
                String url = parametr.QueryEgaisSend(controller.SettingsUtm().Fsrar+"-"+redid);
                if (url != "")
                {
                    sklads = parametr.GetProduct(url);
                    String file = parametr.GetFile();
                    //controller.InsetFileName("R1", file);
                    if (sklads == null)
                    {
                        labelProcess.Invoke((MethodInvoker)delegate
                        {
                            labelProcess.Text = parametr.TiketComment;
                        });
                        parametr.DeleteDocument(url);
                        return;
                    }
                    parametr.DeleteDocument(url);
                    break;
                }
                
            }
            foreach (StoreSklad sklad in sklads)
            {
                DataGridR1.Invoke((MethodInvoker)delegate
                {
                    int rows = DataGridR1.Rows.Add();
                    DataGridR1.Rows[rows].Cells[0].Value = sklad.Product.Name;
                    DataGridR1.Rows[rows].Cells[1].Value = sklad.Product.AlcCode;
                    DataGridR1.Rows[rows].Cells[2].Value = sklad.FormA;
                    DataGridR1.Rows[rows].Cells[3].Value = sklad.FormB;
                    DataGridR1.Rows[rows].Cells[4].Value = sklad.Qtty;
                });
            }
            this.Invoke((MethodInvoker)delegate
            {
                buttonSend.Enabled = true;

                labelProcess.Text = "Дата: " + parametr.Date.ToString("dd.MM.yyyy hh:mm"); 
            });
            controller.DeleteRefid(redid);

        }
        private void saveRegid(String refid)
        {
            controller.InsertRefid("QureyR1", refid);
        }

        private async void  buttonSend_Click(object sender, EventArgs e)
        {

            if (File.Exists("ReplyRests.xml"))
            {
                File.Delete("ReplyRests.xml");
            }
            DataGridR1.Rows.Clear();
                String refid = parametr.Create() ;
             labelProcess.Text = "Ожидайте";
             buttonSend.Enabled = false;
            saveRegid(refid);   
             if (refid != "")
             {
                 await Task.Run(() => UpdateEgais(refid));
             }
            
        }
        private void InsertSklad()
        {
            /*controller.DeleteFormAB();
            foreach (StoreSklad sklad in sklads)
            {

                controller.InsertProduct(sklad);
                this.Invoke((MethodInvoker)delegate {
                    progressIsert.Value = progressIsert.Value + 1; 
                });
            }
            this.Invoke((MethodInvoker)delegate {
                progressIsert.Visible = false;
                MessageBox.Show("Товары добавлены");
            });
            */
        }
        private  async void button1_Click(object sender, EventArgs e)
        {

            progressIsert.Minimum = 0;
            progressIsert.Maximum = sklads.Count;
            progressIsert.Visible = true;
            progressIsert.Value = 0;
            await Task.Run(()=>InsertSklad());
            
        }
    }
}
