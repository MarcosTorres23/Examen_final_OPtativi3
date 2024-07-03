using Repository.Detalle_pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Detalle_pedido
{
    public interface IDetalles_pedido
    {
        bool add(Detalle_pedidomodelo detalle_pedidomodelo);
        bool update(Detalle_pedidomodelo detalle_pedidomodelo);
        bool delete(int id);
        IEnumerable<Detalle_pedidomodelo> GetAll();
    }
}
