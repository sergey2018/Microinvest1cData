
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
                    var barcode1 = reader["BarCode1"].ToString();
                    if(barcode1 !=""){
                        sqlitecontroller.SetBarcode(goods.ID, barcode1, 0);
                    }
                    var barcode2 = reader["BarCode2"].ToString();
                    if (barcode2 != "")
                    {
                        sqlitecontroller.SetBarcode(goods.ID, barcode2, 0);
                    }

                }
            }
            server.Disconnect();
           
        }
        public void GetFirsGrups()
        {
            
            server.Connect();
            var command = new SqlCommand { CommandText = "Select * From GoodsGroups where len(code)=3" };
            using(var reader = server.DataReader(command))
            {
                while (reader.Read())
                {
                    var groups = new Groups
                    {
                        Name = reader["Name"].ToString(),
                        Code = reader["code"].ToString(),
                        UUid = Guid.NewGuid().ToString(),
                        MId = int.Parse(reader["id"].ToString()),
                        PaerntUUid = ""
                    };
                    sqlitecontroller.insertGorups(groups);
                }
            }
            server.Disconnect();
        }

        public void SetGroups()
        {
            var leht = LenCount();
            GetFirsGrups();
            var i = 3;
            while (i < leht)
            {
               
                var list = sqlitecontroller.GetGroupsCode(i);
                foreach(String str in list)
                {
                   var group =  getSearchCode(str, i+3);
                    if(group != null)
                    {
                        group.PaerntUUid = sqlitecontroller.GetUUID(str);
                        sqlitecontroller.insertGorups(group);
                    }
                }
                i = i + 3;
            }
        }
        public Groups getSearchCode(String code, int count)
        {
            server.Connect();
            var command = new SqlCommand { CommandText = "Select * from GoodsGroups where code like @Code and len(code)=@count" };
            command.Parameters.AddWithValue("@Code", code + "%");
            command.Parameters.AddWithValue("@count", count);
            using (var reader = server.DataReader(command)) {
                if (!reader.HasRows)
                {
                    return null;
                }
                else
                {
                    reader.Read();
                    var groups = new Groups
                    {
                        Name = reader["Name"].ToString(),
                        Code = reader["code"].ToString(),
                        UUid = Guid.NewGuid().ToString(),
                        MId = int.Parse(reader["id"].ToString()),
                        PaerntUUid=""
                    };
                    return groups;

                }
            }
           server.Disconnect();

        }

        public int LenCount()
        {
            var count = 0;
            server.Connect();
            var command = new SqlCommand { CommandText = "Select max(len(code))as 'count' From GoodsGroups" };


            using (var reader = server.DataReader(command))
            {
                reader.Read();
                count = int.Parse(reader["count"].ToString());

            }
            server.Disconnect();
            return count;
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
