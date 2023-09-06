using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.Industrial.DAL
{
     public  class DataAccess
    {
        string dbConfig = ConfigurationManager.ConnectionStrings["db_Config"].ToString();
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        SqlTransaction transaction;

        public void Dispose() { 
        
        if (adapter != null){ adapter.Dispose();  adapter = null;}

        if(command != null){ command.Dispose();command = null;}
        
        if (transaction != null) { transaction.Dispose(); transaction = null;}
        
         if (connection != null){connection.Close(); connection.Dispose(); connection = null;}
        }

        public DataTable GetDatas(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                connection = new SqlConnection(dbConfig);
                connection.Open();

                adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally {
                this.Dispose();
            }
            
            return dt;
        }

        public DataTable GetStorageArea()
        {
            string strSql = "select * from storage_area";
            return this.GetDatas(strSql);
        }
        
        public DataTable GetDevices()
        {
            string strSql = "select * from devices";
            return this.GetDatas(strSql);
        }
        public DataTable GetMonitorValues()
        {
            string strSql = "select * from monitor_values ORDER BY address";
            return this.GetDatas(strSql);
        }
    }
    
}
