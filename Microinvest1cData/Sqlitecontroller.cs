﻿using Microinvest1cData.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microinvest1cData
{
   public  class Sqlitecontroller
    {
        //private String ConnectionString = "";
        private SQLiteConnection sqliteConnection;
        //private bool flag;
        public Sqlitecontroller()
        {
            if (!File.Exists(@"microinvest.db")) // если базы данных нету, то...
            {
                CreateBase();
            }
            else
            {
                sqliteConnection = new SQLiteConnection("Data Source=microinvest.db;Version=3;");
                CreateTable();
            }
        }
        private void CreateBase()
        {
            SQLiteConnection.CreateFile(@"microinvest.db");
            sqliteConnection = new SQLiteConnection("Data Source=microinvest.db;Version=3;");
            //flag = true;
            CreateTable();
        }
        private void Open()
        {

            sqliteConnection.Open();
        }

        private void Close()
        {
            sqliteConnection.Close();
        }

        public void SetGoods(Goods goods)
        {
            Open();
            var command = new SQLiteCommand
            {
                CommandText = "INSERT INTO Goods (mid,uuid,Code,name,Name2,Groupid,type,mark,Measure) VALUES(@id,@uuid,@code,@name,@name2,@groupid,@type,@mark,@measure)"
            };
            command.Parameters.AddWithValue("@id", goods.MID);
            command.Parameters.AddWithValue("@uuid", goods.UUid);
            command.Parameters.AddWithValue("@code", goods.Code);
            command.Parameters.AddWithValue("@name", goods.Name);
            command.Parameters.AddWithValue("@name2", goods.Name2);
            command.Parameters.AddWithValue("@groupid", goods.Groupid);
            command.Parameters.AddWithValue("@type", goods.Type);
            command.Parameters.AddWithValue("@mark", goods.Mark);
            command.Parameters.AddWithValue("@measure", goods.Measure);
            SqlNotQuery(command);
            Close();
        }

        public bool isBarcode(String Barcode)
        {
            var command = new SQLiteCommand { CommandText = "Select Barcode from Barcodes where Barcode=@bar" };
            command.Parameters.AddWithValue("@bar", Barcode);
            using(var reader = DataReader(command))
            {
                return reader.HasRows;
            }
        }
        public List<String> GetGroupsCode(int lenthCode)
        {
            Open();
            var list = new List<String>();
            var command = new SQLiteCommand { CommandText = "Select code from GoodsGroups where length(code)=@code" };
            command.Parameters.AddWithValue("@code", lenthCode);
            using (var reader = DataReader(command))
            {
                while (reader.Read())
                {
                    var str = reader["code"].ToString();
                    list.Add(str);
                }
            }
            Close();
            return list;
        }

        public String GetUUID(String code)
        {
            Open();
            var uuid = "";
            var command = new SQLiteCommand { CommandText = "Select uuid from GoodsGroups where code=@code" };
            command.Parameters.AddWithValue("@code", code);
            using (var reader = DataReader(command))
            {
                while (reader.Read())
                {
                    uuid = reader["uuid"].ToString();
                    
                }
            }
            Close();
            return uuid;
        }
        public void SetStore(Store store)
        {
            Open();
            var command = new SQLiteCommand
            {
                CommandText= "Insert Into Store(mId,objid,qtty) VALUES(@id,@objid,@qtty)"
            };
            command.Parameters.AddWithValue("@id", store.mId);
            command.Parameters.AddWithValue("@objid", store.mObjId);
            command.Parameters.AddWithValue("@qtty", store.Qtty);
            SqlNotQuery(command);
            Close();
        }

        public void SetBarcode(int id,String BarCode,int measure,String uuid)
        {
            Open();
            if (!isBarcode(BarCode))
            {
                var command = new SQLiteCommand{ CommandText= "Insert INTO Barcodes (mId,Barcode,measure,UUId) VALUES(@id,@barcode,@measure,@UUID)" };
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@barcode", BarCode);
                command.Parameters.AddWithValue("@measure", measure);
                command.Parameters.AddWithValue("@UUID", uuid);
                SqlNotQuery(command);
            }
            Close();
        }
        public void SetBarcode3(int id, String BarCode, int measure)
        {
            Open();

                var command = new SQLiteCommand { CommandText = "Insert INTO Barcodes3 (mId,Barcode,measure) VALUES(@id,@barcode,@measure)" };
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@barcode", BarCode);
                command.Parameters.AddWithValue("@measure", measure);
                SqlNotQuery(command);
   
            Close();
        }

        public List<Groups> GetGroups()
        {
            Open();
            var list = new List<Groups>();
            var command = new SQLiteCommand
            {
                CommandText = "Select * from Goodsgroups"
            };
            using(var reader = DataReader(command))
            {
                while (reader.Read())
                {
                    var group = new Groups
                    {
                        UUid = reader["uuid"].ToString(),
                        Name = reader["name"].ToString(),
                        MId = int.Parse(reader["mid"].ToString()),
                        PaerntUUid = reader["ruuid"].ToString(),
                        Code = reader["code"].ToString()
                    };
                    list.Add(group);
                }
            }
            Close();
            return list;
        }

        public void InsertGorups(Groups groups)
        {
            Open();
            var command = new SQLiteCommand { CommandText = "INSERT INTO GoodsGroups(mID,Name,code,uuid,ruuid) VALUES(@id,@name,@code,@uuid,@ruuid)" };
            command.Parameters.AddWithValue("@id", groups.MId);
            command.Parameters.AddWithValue("@name", groups.Name);
            command.Parameters.AddWithValue("@code", groups.Code);
            command.Parameters.AddWithValue("@uuid", groups.UUid);
            command.Parameters.AddWithValue("@ruuid", groups.PaerntUUid);
            SqlNotQuery(command);
            Close();
        }
        public string getGroupUUID(int id)
        {
            Open();
            var uuid = "";
            var command = new SQLiteCommand { CommandText = "Select uuid from GoodsGroups where mid=@id" };
            command.Parameters.AddWithValue("@id", id);
            using(var reader = DataReader(command))
            {
                reader.Read();
                uuid = reader["uuid"].ToString();
            }
            Close();
            return uuid;
        }

        public List<Goods> GetGoods()
        {
            var list = new List<Goods>();
            Open();
            var command = new SQLiteCommand
            {
                CommandText = "Select * from Goods"
            };
            using(var reader = DataReader(command))
            {
                while (reader.Read())
                {
                    var good = new Goods
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        MID = int.Parse(reader["MID"].ToString()),
                        Mark = int.Parse(reader["mark"].ToString()),
                        Groupid = int.Parse(reader["Groupid"].ToString()),
                        Type  = int.Parse(reader["type"].ToString()),
                        Name = reader["name"].ToString(),
                        Name2 = reader["name2"].ToString(),
                        Code = reader["code"].ToString(),
                        UUid = reader["uuid"].ToString(),
                        Measure = reader["Measure"].ToString()
                    };
                    list.Add(good);
                }
            }

            Close();
            return list;
        }
        public List<Barcodes3> GetBarcodes3()
        {
            Open();
            var list = new List<Barcodes3>();
            var command = new SQLiteCommand
            {
                CommandText = "Select * from Barcodes3"
            };
            using(var reader = DataReader(command))
            {
                while (reader.Read())
                {
                    var barcode = new Barcodes3
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        MID = int.Parse(reader["mID"].ToString()),
                        Barcode = reader["Barcode"].ToString()
                        
                    };
                    list.Add(barcode);
                }
            }

            Close();
            return list;
        }
        public List<Barcodes3> GetBarcodes()
        {
            Open();
            var list = new List<Barcodes3>();
            var command = new SQLiteCommand
            {
                CommandText = "Select * from Barcodes"
            };
         //   command.Parameters.AddWithValue("@id", id);
            using (var reader = DataReader(command))
            {
                while (reader.Read())
                {
                    var barcode = new Barcodes3
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        MID = int.Parse(reader["mID"].ToString()),
                        Barcode = reader["Barcode"].ToString(),
                        UUId = reader["uuid"].ToString()
                    };
                    list.Add(barcode);
                }
            }

            Close();
            return list;
        }

        public void Delete()
        {
            Open();
            SqlNotQuery(new SQLiteCommand { CommandText = "Delete From Store" });
            SqlNotQuery(new SQLiteCommand { CommandText = "Delete From Prices" });
            Close();
        }
        public String GoodsUUid(int id)
        {
            Open();
            var uuid = "";
            var command = new SQLiteCommand { CommandText = "Select uuid from Goods where mid=@id" };
            command.Parameters.AddWithValue("@id", id);
            using (var reader = DataReader(command))
            {
                reader.Read();
                uuid = reader["uuid"].ToString();
            }
            Close();
            return uuid;
        }
        public void DeleteBarcodes(int id)
        {
            Open();
            var command = new SQLiteCommand
            {
                CommandText = "Delete From Barcodes3 where id=@id"
            };
            command.Parameters.AddWithValue("@id", id);
            SqlNotQuery(command);
            Close();
        }
        public void UIpdateBarcodes(Barcodes3 bar)
        {
            Open();
            var command = new SQLiteCommand
            {
                CommandText = "Update Barcodes3 set Barcode=@barcode where id=@id"
            };
            command.Parameters.AddWithValue("@id", bar.ID);
            command.Parameters.AddWithValue("@barcode", bar.Barcode);
            SqlNotQuery(command);
            Close();
        }
        public void SetObjects(Objects objects)
        {
            Open();
            var command = new SQLiteCommand
            {
                CommandText = "INSERT INTO Objects(mid,name,uuid,typePrice) VALUES(@id,@name,@uuid,@typePrice)"
            };
            command.Parameters.AddWithValue("@id", objects.ID);
            command.Parameters.AddWithValue("@name", objects.Name);
            command.Parameters.AddWithValue("@uuid", objects.UUID);
            command.Parameters.AddWithValue("@typePrice", objects.TypePrice);
            SqlNotQuery(command);
            Close();
        }
        public void setPrice(Price p)
        {
            Open();
            var command = new SQLiteCommand
            {
                CommandText = "INSERT INTO Prices (mid,type,Price) VALUES(@id,@type,@price)"
            };
            command.Parameters.AddWithValue("@id", p.MId);
            command.Parameters.AddWithValue("@type", p.Type);
            command.Parameters.AddWithValue("@price", p.Total);
            SqlNotQuery(command);
            Close();
        }

        private void SqlNotQuery(SQLiteCommand command)
        {
            command.Connection = sqliteConnection;
            command.ExecuteNonQuery();
        }
        private SQLiteDataReader DataReader(SQLiteCommand command)
        {
            command.Connection = sqliteConnection;
            return command.ExecuteReader();
        }

        private void CreateTable()
        {
            Open();
            SqlNotQuery(new SQLiteCommand
            {
                CommandText = "CREATE  TABLE  IF NOT EXISTS 'Goods' ('id'	INTEGER,'mid'	INTEGER,'uuid'	TEXT,'Code'	TEXT,'Name'	TEXT,'Name2' TEXT," +
                "'Groupid'	INTEGER,'type'	INTEGER,'mark'	INTEGER,'Measure' TEXT,PRIMARY KEY('id' AUTOINCREMENT))"
            });
            SqlNotQuery(new SQLiteCommand
            {
                CommandText = "CREATE TABLE IF NOT EXISTS 'Partnerts' ('id'	INTEGER,'uuid'	TEXT,'mid'	INTEGER,'Company'	TEXT,'inn'	TEXT,'Kpp'	" +
                "TEXT,'type'	INTEGER,'CardNuber'	TEXT,PRIMARY KEY('id' AUTOINCREMENT))"
            });
            SqlNotQuery(new SQLiteCommand
            {
                CommandText = "CREATE TABLE IF NOT EXISTS 'Objects' ('id'	INTEGER,'mid'	INTEGER,'Name'	TEXT,'uuid'	TEXT,'TypePrice'	INTEGER,PRIMARY KEY('id' AUTOINCREMENT))"
            });
            SqlNotQuery(new SQLiteCommand
            {
                CommandText= "CREATE TABLE IF NOT EXISTS  'Barcodes3' ('id'	INTEGER,'mid'	INTEGER,'Barcode'	TEXT,'Measure'	INTEGER,PRIMARY KEY('id' AUTOINCREMENT))"
            });
            SqlNotQuery(new SQLiteCommand
            {
                CommandText= "CREATE TABLE IF NOT EXISTS 'GoodsGroups' ('id'	INTEGER,'mid'	INTEGER,'name'	TEXT,'code' TEXT,'uuid'	TEXT,'ruuid'	TEXT,PRIMARY KEY('id' AUTOINCREMENT))"
            });
            SqlNotQuery(new SQLiteCommand
            {
                CommandText= "CREATE TABLE IF NOT EXISTS  'Barcodes' ('id'	INTEGER,'mid'	INTEGER,'Barcode'	TEXT,'Measure'	INTEGER,'uuid' TEXT,PRIMARY KEY('id' AUTOINCREMENT))"
            });
            SqlNotQuery(new SQLiteCommand
            {
                CommandText= "CREATE TABLE IF NOT EXISTS 'Prices' ('id'	INTEGER,'type'	INTEGER,'mId'	INTEGER,'Price'	REAL,PRIMARY KEY('id' AUTOINCREMENT))"
            });
            SqlNotQuery(new SQLiteCommand
            {
                CommandText= "CREATE TABLE IF NOT EXISTS 'Store' ('id'	INTEGER,'mId'	INTEGER,'objid'	INTEGER,'qtty'	REAL,PRIMARY KEY('id' AUTOINCREMENT))"
            });
            Close();
        }
        public void UpdateBase()
        {
            Close();
            File.Delete(@"microinvest.db");
            CreateBase();

        }

    }
}
