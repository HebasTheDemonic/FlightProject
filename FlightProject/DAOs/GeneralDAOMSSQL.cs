using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject.DAOs
{
    internal class GeneralDAOMSSQL : IGeneralDAO
    {
        public void CleanFlightList()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQLConnectionString"].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "CLEAN_FLIGHTS_LIST";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                connection.Close();
            }
        }

        public void DBTestPrep()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQLConnectionString"].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "START_TESTING";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                connection.Close();
            }
        }

        public void DBClear()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQLConnectionString"].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "CLEAR_DB";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                connection.Close();
            }
        }

        public int DoesUsernameExist(string userName)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQLConnectionString"].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "DOES_USERNAME_EXIST";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter usernameParameter = new SqlParameter();
                usernameParameter.SqlDbType = SqlDbType.Char;
                usernameParameter.SqlValue = userName;
                usernameParameter.ParameterName = "@USER";

                SqlParameter returnValueParameter = new SqlParameter();
                returnValueParameter.SqlDbType = SqlDbType.Int;
                returnValueParameter.Direction = ParameterDirection.Output;
                returnValueParameter.ParameterName = "@VALUE";

                sqlCommand.Parameters.Add(usernameParameter);
                sqlCommand.Parameters.Add(returnValueParameter);

                connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                result = (int)returnValueParameter.Value;
                connection.Close();
            }
            return result;
        }
    }
}
