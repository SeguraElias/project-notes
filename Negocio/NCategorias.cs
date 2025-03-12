using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Negocio
{
    public class NCategorias
    {
        Categorias objCategorias = new Categorias();

        public DataTable getCategorias()
        {
            return objCategorias.Get();
        }
    }
}
