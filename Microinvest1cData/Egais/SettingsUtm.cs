using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Microinvest1cData.Egais
{
   public  class SettingsUtm // Настройки УТМ
    {
        private String url;
        private String port;
        private String fsrar;
        private int id;

        public SettingsUtm()
        {
        }

        public SettingsUtm(string url, string port, string fsrar)
        {
            this.url = url;
            this.port = port;
            this.fsrar = fsrar;
        }

        public string Url { get => url; set => url = value; }
        public string Port { get => port; set => port = value; }
        public string Fsrar { get => fsrar; set => fsrar = value; }
        public int Id { get => id; set => id = value; }
    }
}
