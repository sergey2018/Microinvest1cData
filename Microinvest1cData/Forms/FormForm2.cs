using Microinvest1cData.Query;
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
    public partial class FormForm2 : Form
    {
        private Sqlitecontroller controller;
        private List<String> Form2s;
        private List<String> refids;
        public FormForm2(Sqlitecontroller utm)
        {
            InitializeComponent();

            //var query = new QueryFormF2();
            controller = utm;
            controller.initSettigs();
            Form2s = new List<String>();
            refids = controller.GetRefid("QueryForm2");
            if (refids.Count > 0)
            {
                Form2s = controller.GetFormB();
                foreach (String s in Form2s)
                {
                    int rows = dataGridViewForm2.Rows.Add();
                    dataGridViewForm2.Rows[rows].Cells[0].Value = s;
                    dataGridViewForm2.Rows[rows].Cells[1].Value = "Ожидание";
                }
                sendQueryEgais();
            }
            // var form2 = query.Parser("ReplyForm2.xml");
        }

        private async void sendQueryEgais()
        {
            await Task.Run(() => UpdateEgais());
        }
        private void buttonForm2All_Click(object sender, EventArgs e)
        {
            Form2s = controller.GetFormB();
            foreach(String s in Form2s)
            {
                int rows = dataGridViewForm2.Rows.Add();
                dataGridViewForm2.Rows[rows].Cells[0].Value = s;
                dataGridViewForm2.Rows[rows].Cells[1].Value = "Новый";
            }
        }
        private void SendEgais()
        {
            for (int i = 0; i < Form2s.Count; i++)
            {
                var query = new QueryFormF2();
                query.SetSettings(controller.SettingsUtm());
                var refid = query.Create(Form2s[i]);
                controller.InsertRefid("QueryForm2", refid);
                this.Invoke((MethodInvoker)delegate {
                    dataGridViewForm2.Rows[i].Cells[1].Value = "Ожидание";
                });
            }
            refids = controller.GetRefid("QueryForm2");
            UpdateEgais();

        }
        private void SetDataGridStatus(String form2)
        {
            this.Invoke((MethodInvoker)delegate {
                for (int i = 0; i < dataGridViewForm2.Rows.Count; i++)
                {
                    if (dataGridViewForm2.Rows[i].Cells[0].Value.Equals(form2))
                    {

                        dataGridViewForm2.Rows[i].Cells[1].Value = "Записано в базу";
                    }
                }

            });
        }
        private void UpdateEgais()
        {
            var query = new QueryFormF2();
            query.SetSettings(controller.SettingsUtm());
            while (refids.Count > 0)
            {
                foreach(String refid in refids)
                {
                    var url = query.QueryEgaisSend(refid);
                    if (url != "")
                    {
                        var form2 = query.GetForm2(url);
                        controller.insertForm2(form2);
                        controller.SetProducer(form2.Shipper);
                        controller.SetProducer(form2.Consignee);
                        //form2.Product.Setproduct();
                        controller.SetProduct(form2.Product);
                        SetDataGridStatus(form2.FormB);
                        query.DeleteDocument(url);
                        controller.DeleteRefid(refid);

                    }

                }
                refids.Clear();
                refids = controller.GetRefid("QueryForm2");
            }

        }
        private async void buttonSendUTM_Click(object sender, EventArgs e)
        {
            await Task.Run(() => SendEgais());
        }
    }
}
