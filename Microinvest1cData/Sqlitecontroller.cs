using Microinvest1cData.Data;
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
        private String ConnectionString = "";
        private SQLiteConnection sqliteConnection;
        //private bool flag;
        public Sqlitecontroller()
        {
            if (!File.Exists(@"microinvest.db")) // если базы данных нету, то...
            {
                SQLiteConnection.CreateFile(@"microinvest.db");
                sqliteConnection = new SQLiteConnection("Data Source=microinvest.db;Version=3;");
                //flag = true;
                CreateTable();
            }
            else
            {
                sqliteConnection = new SQLiteConnection("Data Source=microinvest.db;Version=3;");
            }
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
                CommandText = "INSERT INTO Goods (mid,uuid,Code,name,Name2,Groupid,type,mark) VALUES(@id,@uuid,@code,@name,@name2,@groupid,@type,@mark)"
            };
            command.Parameters.AddWithValue("@id", goods.ID);
            command.Parameters.AddWithValue("@uuid", goods.UUid);
            command.Parameters.AddWithValue("@code", goods.Code);
            command.Parameters.AddWithValue("@name", goods.Name);
            command.Parameters.AddWithValue("@name2", goods.Name2);
            command.Parameters.AddWithValue("@groupid", goods.Groupid);
            command.Parameters.AddWithValue("@type", goods.Type);
            command.Parameters.AddWithValue("@mark", goods.Mark);
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
                "'Groupid'	INTEGER,'type'	INTEGER,'mark'	INTEGER,PRIMARY KEY('id' AUTOINCREMENT))"
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
                CommandText= "CREATE TABLE IF NOT EXISTS 'GoodsGroups' ('id'	INTEGER,'mid'	INTEGER,'name'	TEXT,'uuid'	TEXT,'ruuid'	TEXT,PRIMARY KEY('id' AUTOINCREMENT))"
            });
            SqlNotQuery(new SQLiteCommand
            {
                CommandText= "CREATE TABLE IF NOT EXISTS  'Barcodes' ('id'	INTEGER,'mid'	INTEGER,'Barocdes'	TEXT,'Measure'	INTEGER,PRIMARY KEY('id' AUTOINCREMENT))"
            });
            Close();
        }

    }
}
