using Dapper;
using Repository.Clientes;
using Repository.Data.ConfiguracionDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository.Proveedor
{
    public class ProveedorRepository : Iproveedor
    {

            IDbConnection connection;
            public ProveedorRepository(string connectionString)
            {

                connection = new ConnectionDB(connectionString).OpenConnection();
            }
            public bool add(Proveedormodelo proveedormodelo)
            {
                try
                {
                    connection.Execute("INSER INTO proveedor(razon_social,tipo_doc,numero_doc,direccion,mail,celular,estado)" +
                          $"Values( @razon_social, @tipo_doc, @numero_doc, @direccion, @mail, @celular, @estado )", proveedormodelo);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;

                }

            }
            public IEnumerable<Proveedormodelo> GetAll()
            {
                return connection.Query<Proveedormodelo>("Select * From proveedor");
            }

            public bool delete(int id)
            {
                connection.Execute($"Delete From proveedor Where id={id}");
            }
            public bool update(Proveedormodelo proveedormodelo)
            {
                try
                {

                    connection.Execute("UPDATE INTO proveedor Set " +
                        "razon_social=@nombre" +
                        "tipo_doc=@apellido," +
                        "numero_doc=@cedula," +
                        "direccion@direccion," +
                        "mail@mail," +
                        "celular@celular," +
                        "estado@estado" +
                        $"WERE id=@id", proveedormodelo);

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;

                }

            }
        }
    }

