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
