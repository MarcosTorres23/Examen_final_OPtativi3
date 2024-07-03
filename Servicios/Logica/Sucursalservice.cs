using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Repository.Data.Facturas;
using Repository.Sucursal;
using System.Data;
using Dapper;
using System.Net.Mail;

namespace Servicios.Logica
{
    public class Sucursalservice : ISucursal
    {
        private SucursalRepository sucursalRepository;
        public Sucursalservice(string connectionString) {

            sucursalRepository = new SucursalRepository(connectionString);
        }


        public bool mailvalido(string email)
        {
            try
            {
                var direccionmail = new MailAddress(email);
                return direccionmail.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool Validardatos(Sucursalmodelo sucursal)
        {
            Regex regexNroFactura = new Regex(@"^\d{3}-\d{3}-\d{6}$");

            if (string.IsNullOrEmpty(sucursal.descripccion)) return false;
            if (string.IsNullOrEmpty(sucursal.direccion) || sucursal.direccion.Length < 10) return false;
            if (string.IsNullOrEmpty(sucursal.telefono)) return false;
            if (string.IsNullOrEmpty(sucursal.whatsapp)) return false;
            if (string.IsNullOrEmpty(sucursal.mail) || !!mailvalido(sucursal.mail)) return false;
            if (string.IsNullOrEmpty(sucursal.estado)) return false;

            return true;
        }

        public bool add(Sucursalmodelo sucursal)
        {
            return Validardatos(sucursal) ? sucursalRepository.add(sucursal) : throw new Exception("Error de la Validacion de Datos, corroborar :3"); 

        }
        public IEnumerable<Sucursalmodelo> GetALL()
        {
            return sucursalRepository.GetAll(); 
        }
        public bool delete(int id)
        {
            return id > 0 ? sucursalRepository.delete(id) : false;
        }
        public bool update(Sucursalmodelo sucursalmodelo)
        {
            return Validardatos(sucursalmodelo) ? sucursalRepository.update(sucursalmodelo) : throw new Exception("Error al validar datos vuelva a intentar");


        }

    }
}
