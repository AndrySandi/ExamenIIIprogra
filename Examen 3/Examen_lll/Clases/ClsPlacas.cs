using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen_lll.Clases
{
    public class ClsPlacas
    {
        public static string NumPlaca { get; set; }

        public static string IdUsuario { get; set; }

        public static string monto { get; set; }

        public static string idPlaca { get; set; }

        public static int Agregar(string NumPlaca, string IdUsuario, string monto)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DboConnection.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarPlacas", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Num_placa", NumPlaca)); 
                    cmd.Parameters.Add(new SqlParameter("@Id_Usuario", IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("@Monto", monto));

                    retorno = cmd.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static int Eliminar(string idPlaca)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DboConnection.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarPlacas", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@idPlaca", idPlaca));

                    retorno = cmd.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }
            return retorno;
        }

    }
}