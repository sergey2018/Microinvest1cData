
using Microinvest1cData.Data;
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
        private Sqlitecontroller sqlitecontroller;
        private int Id = 0;

        public DaoController(Settings settings)
        {
            server = new DAOServer(settings);
            sqlitecontroller = new Sqlitecontroller();
        }


        public void GetGoods()
        {
            server.Connect();
            var command = new SqlCommand
            {
                CommandText = "Select * from Goods where catalog2='' and deleted=0 and id>1"
            };
            using (var reader = server.DataReader(command))
            {
                while (reader.Read())
                {
                    var goods = new Goods();
                    goods.ID = int.Parse(reader["ID"].ToString());
                    goods.Name = reader["name"].ToString();
                    goods.Name2 = reader["name2"].ToString();
                    goods.Type = int.Parse(reader["type"].ToString());
                    goods.Groupid = int.Parse(reader["Groupid"].ToString());
                    goods.Code = reader["code"].ToString();
                    goods.UUid = Guid.NewGuid().ToString();
                    var catalog3 = reader["Catalog3"].ToString();
                    if (catalog3.IndexOf(" 2 ") == -1)
                    {
                        goods.Mark = 0;
                    }
                    else
                    {
                        goods.Mark = 1;
                    }
                    sqlitecontroller.SetGoods(goods);
                }
            }
            server.Disconnect();
           
        }

        public void GetObjects()
        {
            server.Connect();
            var commend = new SqlCommand
            {
                CommandText = "Select * from Objects where id>1 and delete=0"
            };
            using(var reader = server.DataReader(commend))
            {
                while (reader.Read())
                {
                    var obj = new Objects
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        Name = reader["name"].ToString(),
                        UUID = Guid.NewGuid().ToString(),
                        TypePrice = int.Parse(reader["PriceGroup"].ToString())
                    };
                }
            }
            server.Disconnect();
        }
    
    }
}
