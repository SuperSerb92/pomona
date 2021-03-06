using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Osa.Unidocs.Shared.DataAccess;
using System.Data.SqlClient;
using System.Net;
using System.Data;
using System.Reflection;
//using Microsoft.AspNetCore.Http;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DBModel
{
    public class Database
    {
     
        #region Methods

        public static DataTable ExecuteScript(string query, int timeOut = 35)
        {
            DataTable result = new DataTable();
            try
            {

                //IDBManager dbManager = Database.DBManager;
                //dbManager.ExecuteReader(CommandType.Text, query, timeOut);
                //result.Load(dbManager.DataReader);
                //dbManager.DataReader.Close();
                //dbManager = null;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public static void Execute(string query)
        {
            try
            {
               // IDBManager dbManager = Database.DBManager;
               // dbManager.ExecuteNonQuery(CommandType.Text, query);

               // dbManager = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        //ovde da ide konekcija i execute queries
        public static IDbConnection GetDbConnection(string dataSource, string provider, string username, string password, 
            string initialCatalog = "")
        {
            try
            {
                string connectionString = "";
                IDbConnection dbConnection;

                connectionString += "Pooling = False;";
                connectionString += " user id = " + username + ";";
                connectionString += " data source = " + dataSource + ";";
                connectionString += " password = " + password + ";";
                if (!string.IsNullOrEmpty(initialCatalog))
                    connectionString += "Initial Catalog = " + initialCatalog + ";";               
                    connectionString += " MultipleActiveResultSets=True";
                dbConnection = new SqlConnection(connectionString);

                dbConnection.Open();

                return dbConnection;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion

    }
}
