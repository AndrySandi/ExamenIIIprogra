using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Examen_lll.Clases;

namespace Examen_lll
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["VehiculosConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT u.Email, u.Clave, u.nombre, u.Apellido, u.Tipo from Usuarios u"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid1.DataSource = dt;
                            datagrid1.DataBind();

                        }
                    }
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ClsUsuario.email = txtCorreo.Text;
            ClsUsuario.clave = txtClave.Text;
            ClsUsuario.nombre = txtNombre.Text;
            ClsUsuario.apellido = txtApellido.Text;
            ClsUsuario.tipo = txtTipo.Text;

            ClsUsuario.Agregar(ClsUsuario.email, ClsUsuario.clave, ClsUsuario.nombre, ClsUsuario.apellido);
            LlenarGrid();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            ClsUsuario.email = txtCorreo.Text;
            ClsUsuario.clave = txtClave.Text;
            ClsUsuario.nombre = txtNombre.Text;
            ClsUsuario.apellido = txtApellido.Text;
            ClsUsuario.tipo = txtTipo.Text;

            ClsUsuario.Eliminar(ClsUsuario.email);
            LlenarGrid();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ClsUsuario.email = txtCorreo.Text;
            ClsUsuario.clave = txtClave.Text;
            ClsUsuario.nombre = txtNombre.Text;
            ClsUsuario.apellido = txtApellido.Text;
            ClsUsuario.tipo = txtTipo.Text;

            ClsUsuario.Modificar(ClsUsuario.email, ClsUsuario.clave, ClsUsuario.nombre, ClsUsuario.apellido);
            LlenarGrid();
        }
    }
}