
using Repository.Pedido_compra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicios.Logica
{
    public class PedidoCompraService : Ipedido_compra
    {
        private Pedido_compraRepository pedido_compraRepository;
        public PedidoCompraService(string connectionString)
        {
            pedido_compraRepository = new Pedido_compraRepository(connectionString);

        }
        public bool add(Pedido_compramodelo pedido_compra)
        {
            return validardatos(pedido_compra) ? pedido_compraRepository.add(pedido_compra) : throw new Exception("Error de Datos, comprovar en pedido_compra");

        }
        public IEnumerable<Pedido_compramodelo> GetAll()
        {

            return pedido_compraRepository.GetAll();
        }
        public bool delete(int id)
        {
            return id > 0 ? pedido_compraRepository.delete(id) : false;
        }
        public bool update(Pedido_compramodelo pedido_compramodelo)
        {
            return validardatos(pedido_compramodelo) ? pedido_compraRepository.update(pedido_compramodelo) : throw new Exception("Error de Validacion de datos en pedido_compra, favor corrovorar");
        }
        
        private bool validardatos(Pedido_compramodelo pedido_compra)
        {

            if (pedido_compra == null)
                return false;
            if (string.IsNullOrEmpty(pedido_compra.id)) return false;
            if (string.IsNullOrEmpty(pedido_compra.id_proveedor)) return false;
            if (string.IsNullOrEmpty(pedido_compra.id_sucursal))return false;
            if (string.IsNullOrEmpty(pedido_compra.fecha_hora)) return false;
            if (string.IsNullOrEmpty(pedido_compra.total)) return false;

            return true;
        }

    }
}
