using Dapper;
using Repository.Data.ConfiguracionDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Sucursal
{
    public class SucursalRepository : ISucursal 
    {
        IDbConnection connection;

        public SucursalRepository(string connectionString)
        {

            connection = new ConnectionDB(connectionString).OpenConnection();
        }
        public bool add(Sucursalmodelo sucursalmodelo)
        {
            try
            {
                connection.Execute("INSERT INTO surcursal(descripcion, direccion, telefono, whatsapp, mail, estado)" +
                    $"Values(@descripcion, @direccion, @telefono, @whatsapp, @mail, @estado)", sucursalmodelo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Sucursalmodelo> GetAll()
        {
            return connection.Query<Sucursalmodelo>("SELECT * FROM sucursal");
        }

        public bool delete(int id)
        {
            connection.Execute($"DELETE FROM sucursal WHERE id= {id}");

        }

        public bool update(Sucursalmodelo sucursalmode)
        {
            try
            {
                connection.Execute("UPDATE sucursal SET " +
                    "@descripcion," +
                    " @direccion," +
                    " @telefono," +
                    " @whatsapp," +
                    " @mail,}" +
                    " @estado" +
                    $"WHERE id = @id", sucursalmode);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
