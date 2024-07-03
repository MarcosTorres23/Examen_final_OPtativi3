using Dapper;
using Repository.Data.ConfiguracionDB;
using Repository.Productos;
using Repository.Sucursal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Pedido_compra
{
 

public class Pedido_compraRepository : Ipedido_compra
{
    IDbConnection connection;

    public Pedido_compraRepository(string connectionString)
    {

        connection = new ConnectionDB(connectionString).OpenConnection();
    }
    public bool add(Pedido_compramodelo pedido_compramodelo)
    {
        try
        {
            connection.Execute("INSERT INTO pedido_compra (id_proveedor, id_sucursal, fecha_hora, total)" +
                $"Values(@id_proveedor, @id_sucursal, @fecha_hora, @total)", pedido_compramodelo);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public IEnumerable<Pedido_compramodelo> GetAll()
    {
        return connection.Query<Pedido_compramodelo>("SELECT * FROM pedido_compra");
    }

    public bool delete(int id)
    {
        connection.Execute($"DELETE FROM pedido_compra WHERE id= {id}");

    }

    public bool update(Pedido_compramodelo pedido_compramodelo)
    {
        try
        {
            connection.Execute("UPDATE pedido_compra SET " +
            "@id_proveedor," +
            " @id_sucursal, " +
            "@fecha_hora, " +
            "@total)" +
                $"WHERE id = @id", pedido_compramodelo);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

}