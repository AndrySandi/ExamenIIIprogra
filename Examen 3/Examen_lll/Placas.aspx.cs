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
    public partial class Placas : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT p.Id_placa, p.Num_placa, p.Id_Usuario, p.Monto from Placa p"))
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
            ClsPlacas.NumPlaca = txtNum.Text;
            ClsPlacas.IdUsuario = txtId.Text;
            ClsPlacas.monto = txtMonto.Text;

            ClsPlacas.Agregar(ClsPlacas.NumPlaca, ClsPlacas.IdUsuario, ClsPlacas.monto);
            LlenarGrid();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            ClsPlacas.NumPlaca = txtNum.Text;
            ClsPlacas.IdUsuario = txtId.Text;
            ClsPlacas.monto = txtMonto.Text;
            ClsPlacas.idPlaca = txtMonto.Text;


            ClsPlacas.Eliminar(ClsPlacas.idPlaca);
            LlenarGrid();
        }
    }
}