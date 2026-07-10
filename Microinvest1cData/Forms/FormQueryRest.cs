
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microinvest1cData.Egais;
using Microinvest1cData.Query;

namespace Microinvest1cData.Forms
{
    public partial class FormQueryRest : Form
    {
        private Sqlitecontroller controller;
        private List<Product> restShops;
        private List<String> refids;
        public  FormQueryRest(Sqlitecontroller utm)
        {
            InitializeComponent();
            controller = utm;
            controller.initSettigs();
            refids = controller.GetRefid("QueryAP");
            if (refids.Count > 0)
            {
                restShops = controller.GetRestShopsQuery1();
                foreach (Product rest in restShops)
                {
                    int rows = dataGridViewData.Rows.Add();
                    dataGridViewData.Rows[rows].Cells[0].Value = rest.Name;
                    dataGridViewData.Rows[rows].Cells[1].Value = rest.AlcCode;
                    dataGridViewData.Rows[rows].Cells[2].Value = "Ожидание";
                }
            }
            sendQueryEgais();
        }
        private async  void sendQueryEgais()
        {
            await Task.Run(() => UpdateEgais());
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            restShops = controller.GetRestShopsQuery();
            foreach(Product rest in restShops)
            {
                int rows = dataGridViewData.Rows.Add();
                dataGridViewData.Rows[rows].Cells[0].Value = rest.Name;
                dataGridViewData.Rows[rows].Cells[1].Value = rest.AlcCode;
                dataGridViewData.Rows[rows].Cells[2].Value = "Новый";
            }
        }
        private void UpdateEgais()
        {
            var query = new QueryAP();
            query.SetSettings(controller.SettingsUtm());
            while (refids.Count > 0)
            {
                foreach(String refid in refids)
                {
                    var url = query.QueryEgaisSend(refid);
                    if (url != "")
                    {
                        var product = query.getProduct(url);

                        if (controller.GEtProudceruuid(product.Producer.ClientRegid) == "")
                        {
                            product.Producer.UUID = Guid.NewGuid().ToString();
                            controller.SetProducer(product.Producer);
                        }
                        controller.UpdateImporter(product.Product, product.Producer.ClientRegid);
                        SetDataGridStatus(product.Product.AlcCode,product.Product.Name);


                        
                        query.DeleteDocument(url);
                        controller.DeleteRefid(refid);
                    }

                }
                refids.Clear();
                refids = controller.GetRefid("QueryAP");
            }
        }
        private void SetDataGridStatus(String alcocod, String Name)
        {
            this.Invoke((MethodInvoker)delegate {
                for (int i = 0; i < dataGridViewData.Rows.Count; i++)
                {
                    if (dataGridViewData.Rows[i].Cells[1].Value.Equals(alcocod))
                    {
                        dataGridViewData.Rows[i].Cells[0].Value = Name;
                        dataGridViewData.Rows[i].Cells[2].Value = "Записано в базу";
                    }
                }

            });
        }
        private void SendEgais()
        {
            for(int i = 0; i<restShops.Count; i++)
            {
                var query = new QueryAP();
                query.SetSettings(controller.SettingsUtm());
                var refid = query.Create(restShops[i].AlcCode);
                controller.InsertRefid("QueryAP", refid);
                this.Invoke((MethodInvoker)delegate {
                    dataGridViewData.Rows[i].Cells[2].Value = "Ожидание";
                });
            }
            refids = controller.GetRefid("QueryAP");
            UpdateEgais();

        }

        private async  void buttonSend_Click(object sender, EventArgs e)
        {
            await Task.Run(() => SendEgais());
        }

        private void buttonSendAll_Click(object sender, EventArgs e)
        {
            restShops = controller.GetRestShopsQuery1();
            foreach (Product rest in restShops)
            {
                int rows = dataGridViewData.Rows.Add();
                dataGridViewData.Rows[rows].Cells[0].Value = rest.Name;
                dataGridViewData.Rows[rows].Cells[1].Value = rest.AlcCode;
                dataGridViewData.Rows[rows].Cells[2].Value = "Новый";
            }
        }
    }
}
