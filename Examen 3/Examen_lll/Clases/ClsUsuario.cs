using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen_lll.Clases
{
    public class ClsUsuario
    {
        public static string email { get; set; }

        public static string clave { get; set; }

        public static string nombre { get; set; }

        public static string apellido { get; set; }

        public static string tipo { get; set; }


        public static int ValidarLogin(string email, string clave)
        {
            int retorno = 0;
            int tipo = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DboConnection.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ValidarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@email", email));
                    cmd.Parameters.Add(new SqlParameter("@clave", clave));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            ClsUsuario.tipo = rdr["tipo"].ToString();
                            retorno = 1;
                        }

                    }

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return retorno;
        }

        public static int Agregar(string email, string clave, string nombre, string apellido)
        {
            int retorno = 0;
            string tipo = "Usuario";
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DboConnection.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarUsuarios", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@email", email));
                    cmd.Parameters.Add(new SqlParameter("@clave", clave));
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@apellido", apellido));
                    cmd.Parameters.Add(new SqlParameter("@tipo", tipo));

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

        public static int Eliminar(string email)
        {
            int retorno = 0;
            string tipo = "Usuario";
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DboConnection.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarUsuarios", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@email", email));

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


        public static int Modificar(string email, string clave, string nombre, string apellido)
        {
            int retorno = 0;
            string tipo = "Usuario";
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DboConnection.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("actualizarUsuarios ", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@email", email));
                    cmd.Parameters.Add(new SqlParameter("@clave", clave));
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@apellido", apellido));
                    cmd.Parameters.Add(new SqlParameter("@tipo", tipo));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
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

