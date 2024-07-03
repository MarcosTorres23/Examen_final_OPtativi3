using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Detalle_pedido
{
    public class Detalle_pedidomodelo
    {
        public string id { get; set; }
        public string id_pedido { get; set; }
        public string id_producto { get; set; }
        public string cantidad_producto { get; set; }
        public string subtotal { get; set; }
    
    }
}
