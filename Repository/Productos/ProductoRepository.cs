using Dapper;
using Repository.Data.ConfiguracionDB;
using Repository.Productos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Repository.Productos
{

    public class ProductoRepository : Iproducto
    {
        IDbConnection connection;

        public ProductoRepository(string connectionString)
        {

            connection = new ConnectionDB(connectionString).OpenConnection();
        }
        public bool add(Productomodelo productomodelo)
        {
            try
            {
                connection.Execute("INSERT INTO productos (descripcion, cantidad_minima, cantidad_stock, precio_compra, precio_venta, categoria, marca, ,estado)" +
                    $"Values(@descripcion, @cantidad_minima, @cantidad_stock, @precio_compra, @precio_venta, @categoria, @marca, @estado)", productomodelo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Productomodelo> GetAll()
        {
            return connection.Query<Productomodelo>("SELECT * FROM productos");
        }

        public bool delete(int id)
        {
            connection.Execute($"DELETE FROM productos WHERE id= {id}");

        }

        public bool update(Productomodelo productomodelo)
        {
            try
            {
                connection.Execute("UPDATE productos SET " +
                "@descripcion," +
                    " @cantidad_minima, " +
                    " @cantidad_stock," +
                    " @precio_compra, " +
                    "@precio_venta, " +
                    "@categoria, " +
                    "@marca, " +
                    "@estado)" +
                    $"WHERE id = @id", productomodelo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
