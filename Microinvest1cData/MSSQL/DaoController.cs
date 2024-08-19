
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microinvest1cData.MSSQL
{
   public class DaoController
    {
        private DAOServer server;
        private int Id = 0;

        public DaoController(Settings settings)
        {
            server = new DAOServer(settings);
        }
    
    }
}
