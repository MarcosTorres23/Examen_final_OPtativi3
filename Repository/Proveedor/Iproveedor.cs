using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Proveedor
{
 
    public interface Iproveedor
    {
        bool add(Proveedormodelo proveedormodelo);
        bool update(Proveedromodelo proveedormodelo);
        bool delete(int id);
        IEnumerable<Proveedormodelo> GetAll();
    }
}