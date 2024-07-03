using Repository.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Pedido_compra
{
    internal interface Ipedido_compra
    {
        bool add(Pedido_compramodelo pedido_compraomodelo);
        bool update(Pedido_compramodelo productomodelo);
        bool delete(int id);
        IEnumerable<Pedido_compramodelo> GetALL();



    }
}