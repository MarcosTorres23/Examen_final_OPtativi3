using Repository.Clientes;
using Repository.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Logica
{
    

    public class ProveedorService : Iproveedor
    {
        private ProveedorRepository proveedorRepository;
        public ProveedorService(string connectionString)
        {
            proveedorRepository = new ProveedorRepository(connectionString);

        }
        public bool add(Proveedormodelo proveedor)
        {
            return validardatos(proveedor) ? proveedorRepository.add(proveedor) : throw new Exception("Error de Datos, comprovar en proveedor");

        }
        public IEnumerable<Proveedormodelo> GetAll()
        {

            return proveedorRepository.GetAll();
        }
        public bool delete(int id)
        {
            return id > 0 ? proveedorRepository.delete(id) : false;
        }
        public bool update(Proveedormodelo proveedormodelo)
        {
            return validardatos(proveedormodelo) ? proveedorRepository.update(proveedormodelo) : throw new Exception("Error de Datos, comprovar en proveedor");
        }
        private bool esnumero(string cadena)
        {
            foreach (char c in cadena)
            {
                if (!char.IsDigit(c)) return false;
            }
            return true;

        }
        private bool validardatos(Proveedormodelo proveedor)
        {

            if (proveedor == null)
                return false;
            if (string.IsNullOrEmpty(proveedor.razon_social) && proveedor.razon_social.Length < 3)
                return false;
            if (string.IsNullOrEmpty(proveedor.tipo_doc) && proveedor.tipo_doc.Length < 3)
                return false;
            if (string.IsNullOrEmpty(proveedor.numero_doc) && proveedor.numero_doc.Length < 3)
                return false;
            if (string.IsNullOrEmpty(proveedor.direccion)) return false;
            if (string.IsNullOrEmpty(proveedor.mail)) return false;
            if (string.IsNullOrEmpty(proveedor.celular) || proveedor.celular.Length != 10 || !!esnumero(proveedor.celular))
                return false;
            if (string.IsNullOrEmpty(proveedor.estado)) return false;



            return false;
            return true;
        }

    }
}
