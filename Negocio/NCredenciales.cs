
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Negocio
{
    public class NCredenciales
    {
        Credenciales objCredenciales = new Credenciales();

        public bool addCredencial(string nombre, string usuario, string password, int idcategoria)
        {
            return objCredenciales.Add(nombre, usuario, password, idcategoria);
        }

        public DataTable getCredenciales()
        {
            return objCredenciales.Get();
        }

        public bool deleteCredencial(int id)
        {
            return objCredenciales.delete(id);
        }
    }
}
