using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace Repository.Data.ConfiguracionDB
{
    public class ConnectionDB
    {
        /*private string connectionString = "Host=Localhost;Username=postgres;Pasword=0000;Database=DBB1;Port=5432";*/

        private string connectionString;

        public ConnectionDB(string _connectionString) { 
            this.connectionString = _connectionString;
        }


        public NpgsqlConnection OpenConnection()
        {
            try
            {
                var conn = new NpgsqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

