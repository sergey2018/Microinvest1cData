using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microinvest1cData.MSSQL
{
    public class DAOServer
    {
        private SqlConnection myConnection;
        private bool isConnect;

        public bool IsConnect { get => isConnect; }

        public DAOServer(Settings settings)
        {
            InitBase(settings);
        }

        public void InitBase(Settings setting)
        {
            
            
            
                myConnection = new SqlConnection("user id=" + setting.Login + ";" +
                                         "password=" + setting.Passwords + ";server=" + setting.Server + ";" +
                                         "Integrated Security=false;" +
                                         "database=" + setting.Base + "; " +
                                         "connection timeout=30;" +
               "MultipleActiveResultSets=True");
            
        }
        public void Connect()
        {
            try
            {
                myConnection.Open();
                isConnect = true;
            }
            catch (Exception e)
            {
                isConnect = false;
                Console.WriteLine(e.Message);
            }
        }
        public void Disconnect()
        {
            myConnection.Close();
        }
        public void SetInsert(SqlCommand command)
        {
            command.Connection = myConnection;
            command.ExecuteNonQuery();
        }
        public SqlDataReader DataReader(SqlCommand command)
        {
            command.Connection = myConnection;
            return command.ExecuteReader();
        }
        public DataSet DataAdapter(SqlCommand command)
        {
            command.Connection = myConnection;
            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            return ds;

        }
        public void Test()
        {
            Connect();
            Disconnect();
        }
    }
}
