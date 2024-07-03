using Dapper;
using Repository.Data.ConfiguracionDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Detalle_pedido
{
    public class Detalle_pedidoRepository : IDetalles_pedido
    {


        IDbConnection connection;
        public Detalle_pedidoRepository(string connectionString)
        {

            connection = new ConnectionDB(connectionString).OpenConnection();
        }
        public bool add(Detalle_pedidomodelo detalle_pedidomodelo)
        {
            try
            {
                connection.Execute("INSER INTO detalle_pedido(id_pedido,id_producto,cantidad_producto,subtotal)" +
                      $"Values(@id_pedido, @id_producto, @cantidad_producto, @subtotal )", detalle_pedidomodelo);
                return true;
            }
            catch (Exception ex) {
                throw ex;

            }

        }
        public IEnumerable<Detalle_pedidomodelo> GetAll()
        {
            return connection.Query<Detalle_pedidomodelo>("Select * From detalle_pedido");
        }

        public bool delete(int id)
        {
            connection.Execute($"Delete From detalle_pedido Where id={id}");
        }
        public bool update(Detalle_pedidomodelo detalle_pedidomodelo)
        {
            try
            {

                connection.Execute("UPDATE INTO detalle_pedido Set (" +
                    "id_pedido=@id_pedido" +
                    "id_producto=@id_producto," +
                    "cantidad_producto=@cantidad_producto," +
                    "subtotal=@subtotal)" +
                     
                    $"WERE id=@id", detalle_pedidomodelo);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}
