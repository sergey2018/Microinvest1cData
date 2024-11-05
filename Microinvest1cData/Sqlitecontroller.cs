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
            SqlNotQuery(new SQLiteCommand { CommandText = "" });
            Close();
        }

    }
}
