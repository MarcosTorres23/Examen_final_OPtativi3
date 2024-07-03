using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Data.ConfiguracionDB;
using Dapper;
using System.Threading.Tasks;
using System.Data;

namespace Repository.Sucursal
{
    internal interface ISucursal
    {
        bool add(Sucursalmodelo sucursalmodelo);
        bool update(Sucursalmodelo sucursalmodelo);
        bool delete(int id);
        IEnumerable<Sucursalmodelo> GetALL();
    


    }
}
