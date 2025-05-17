
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
       // private int Id = 0;
        private int Count = 0;
        private int Langth = 0;
        private bool UpdateFlag = true;

        public DaoController(Settings settings)
        {
            server = new DAOServer(settings);
            sqlitecontroller = new Sqlitecontroller();
        }
        public int GetCount() => Count;
        public int GetLength() => Langth;
        public bool GetUpdateFlag() => UpdateFlag;
        public Sqlitecontroller GetSqlitecontroller() => sqlitecontroller;
        public void GetGoods()
        {
            Count = 0;
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
                    goods.Measure = reader["Measure1"].ToString();
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
                  if(barcode1.Trim() !=""){
                        sqlitecontroller.SetBarcode(goods.ID, barcode1, 0);
                    }
                    var barcode2 = reader["BarCode2"].ToString();
                    if (barcode2.Trim() != "")
                    {
                        sqlitecontroller.SetBarcode(goods.ID, barcode2, 0);
                    }
                    var barcode3 = reader["BarCode3"].ToString();
                    if (barcode3.Trim() != "")
                    {
                        sqlitecontroller.SetBarcode3(goods.ID, barcode3, 0);
                    }
                    var price = new Price();
                    price.Type = 0;
                    price.MId = int.Parse(reader["ID"].ToString());
                    price.Total = double.Parse(reader["PriceIn"].ToString());
                    sqlitecontroller.setPrice(price);
                    for (int i = 1; i < 11; i++)
                    {
                        var price1 = new Price();
                        price1.Type = i;
                        price1.MId = int.Parse(reader["ID"].ToString());
                        price1.Total = double.Parse(reader["PriceOut"+i].ToString());
                        sqlitecontroller.setPrice(price1);
                    }

                    Count++;
                }
            }
            UpdateFlag = false;
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
        public void GetLengthZCount()
        {

            server.Connect();
            var command = new SqlCommand { CommandText = "Select Count(*) as 'Count' From Store where goodid in (Select id from Goods where catalog2='' and deleted=0 and id>1)" };
            using (var reader = server.DataReader(command))
            {

                reader.Read();
                Langth = int.Parse(reader["Count"].ToString());
                
            }
            server.Disconnect();
        }
        public void GetLengthZCountG()
        {

            server.Connect();
            var command = new SqlCommand { CommandText = "Select Count(*) as 'Count' from Goods where catalog2='' and deleted=0 and id>1" };
            using (var reader = server.DataReader(command))
            {

                reader.Read();
                Langth = int.Parse(reader["Count"].ToString());

            }
            server.Disconnect();
        }
        public void SetStore()
        {
            Count = 0;
            server.Connect();
            var command = new SqlCommand { CommandText = "Select * From Store where goodid in (Select id from Goods where catalog2='' and deleted=0 and id>1)" };
            using(var reader = server.DataReader(command))
            {
                while (reader.Read())
                {
                    var store = new Store
                    {
                        mId = int.Parse(reader["goodid"].ToString()),
                        mObjId = int.Parse(reader["Objectid"].ToString()),
                        Qtty = Double.Parse(reader["qtty"].ToString())
                    };
                    sqlitecontroller.SetStore(store);
                    Count = Count + 1;
                }
                
            }
            UpdateFlag = false;
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
                   var groups =  getSearchCode(str, i+3);
                    if(groups != null)
                    {
                        foreach(Groups group in groups)
                        {
                            group.PaerntUUid = sqlitecontroller.GetUUID(str);
                            sqlitecontroller.insertGorups(group);
                        }
                    }
                }
                i = i + 3;
            }
        }
        public List<Groups> getSearchCode(String code, int count)
        {
            server.Connect();
            var groups = new List<Groups>();
            var command = new SqlCommand { CommandText = "Select * from GoodsGroups where code like @Code and len(code)=@count" };
            command.Parameters.AddWithValue("@Code", code + "%");
            command.Parameters.AddWithValue("@count", count);
            using (var reader = server.DataReader(command)) {
                if (!reader.HasRows)
                {
                    server.Disconnect();
                    return null;
                }
                else
                {
                    while (reader.Read())
                    {
                        var group = new Groups

                        {
                            Name = reader["Name"].ToString(),
                            Code = reader["code"].ToString(),
                            UUid = Guid.NewGuid().ToString(),
                            MId = int.Parse(reader["id"].ToString()),
                            PaerntUUid = ""
                        };
                        groups.Add(group);
                    }
                    server.Disconnect();
                    return groups;

                }
            }
           

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
                CommandText = "Select * from Objects where id>1 and deleted=0"
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
                    sqlitecontroller.SetObjects(obj);
                }
            }
            server.Disconnect();
        }
        public void UpdateBase()
        {
            sqlitecontroller.UpdateBase();
        }
    
    }
}
