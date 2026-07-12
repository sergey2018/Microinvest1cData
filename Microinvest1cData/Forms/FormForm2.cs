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
        public FormForm2(Sqlitecontroller utm)
        {
            InitializeComponent();

            var query = new QueryFormF2();
            controller = utm;
           // var form2 = query.Parser("ReplyForm2.xml");
        }
    }
}
