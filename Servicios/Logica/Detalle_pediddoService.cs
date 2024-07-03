using Repository.Clientes;
using Repository.Detalle_pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Logica
{
    public class Detalle_pediddoService : IDetalles_pedido
    {
        private Detalle_pedidoRepository detalle_pedidoRepository;
        public Detalle_pediddoService(string connectionString)
        {
            detalle_pedidoRepository = new Detalle_pedidoRepository(connectionString);

        }
        public bool add(Detalle_pedidomodelo detalle_pedido)
        {
            return validardatos(detalle_pedido) ? detalle_pedidoRepository.add(detalle_pedido) : throw new Exception("Error de Datos, comprovar en detalle_pedido");

        }
        public IEnumerable<Detalle_pedidomodelo> GetAll()
        {

            return detalle_pedidoRepository.GetAll();
        }
        public bool delete(int id)
        {
            return id > 0 ? detalle_pedidoRepository.delete(id) : false;
        }
        public bool update(Detalle_pedidomodelo detalle_pedidomodelo)
        {
            return validardatos(detalle_pedidomodelo) ? detalle_pedidoRepository.update(detalle_pedidomodelo) : throw new Exception("Error de Validacion de datos en detalles_pedidos, favor corrovorar");
        }
        private bool esnumero(string cadena)
        {
            foreach (char c in cadena)
            {
                if (!char.IsDigit(c)) return false;
            }
            return true;

        }
        private bool validardatos(Detalle_pedidomodelo detalle_pedido)
        {

            if (detalle_pedido == null)
                return false;
            if (string.IsNullOrEmpty(detalle_pedido.id_producto) && detalle_pedido.id_producto.Length < 1)
                return false;
            if (string.IsNullOrEmpty(detalle_pedido.id_pedido) && detalle_pedido.id_pedido.Length < 1)
                return false;
            if (string.IsNullOrEmpty(detalle_pedido.cantidad_producto) && detalle_pedido.cantidad_producto.Length < 1)
                return false;
            if (string.IsNullOrEmpty(detalle_pedido.subtotal)) return false;



           
            return true;
        }


    }
}

