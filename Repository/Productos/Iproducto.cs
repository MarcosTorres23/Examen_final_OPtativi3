using Repository.Sucursal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Productos
{
    internal interface Iproducto
    {
        bool add(Productomodelo productomodelo);
        bool update(Productomodelo productomodelo);
        bool delete(int id);
        IEnumerable<Productomodelo> GetALL();



    }
}
