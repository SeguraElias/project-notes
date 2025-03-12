using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion.Credenciales
{
	public partial class index : System.Web.UI.Page
	{
		NCredenciales credencialesNegocio = new NCredenciales();
		NCategorias categoriasNegocio = new NCategorias();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				cargarCredenciales();
				cargarCategorias();

            }
		}

		protected void cargarCredenciales()
		{
			gvCredenciales.DataSource = credencialesNegocio.getCredenciales();
			gvCredenciales.DataBind();
		}

		protected void cargarCategorias()
		{
			dropCategorias.DataSource = categoriasNegocio.getCategorias();
			dropCategorias.DataTextField = "nombre";
			dropCategorias.DataValueField = "id";
			dropCategorias.DataBind();

            dropCategorias.Items.Insert(0, new ListItem("Seleccione una opción", "0"));
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
			string nombre = txtNombre.Text;
			string usuario = txtUsuario.Text;
			string password = txtPassword.Text;
			int idcategoria = Convert.ToInt32(dropCategorias.SelectedValue);

			bool agregado = credencialesNegocio.addCredencial(nombre, usuario, password, idcategoria);
			if (agregado)
			{
                cargarCredenciales();
            }
			else
			{
                Response.Write("<script>alert('Error al agregar credencial');</script>");
            }
        }

        protected void gvCredenciales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
			if (e.CommandName == "Eliminar")
			{
				int id = Convert.ToInt32(e.CommandArgument);

				bool eliminado = credencialesNegocio.deleteCredencial(id);
				if (eliminado)
				{
					cargarCredenciales();
				}
				else
				{
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se pudo eliminar el registro');", true);
                }
			}
        }
    }
}