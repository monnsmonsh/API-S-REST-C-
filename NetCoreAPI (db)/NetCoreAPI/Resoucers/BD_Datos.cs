using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace NetCoreAPI.Resoucers
{
    public class BD_Datos
    {
        //Catalog->es el name de la bd -- User-> user de bd
        public static string cadenaConexion = "Data Source=.;Initial Catalog=Test;User ID=sa;Password=adminroot";
       
        //Metodo ListarTablas se lista cuando hay mas de una tabla
        public static DataSet ListarTablas(string nombreProcedimiento, List<Parametro> parametros = null)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }
                DataSet tabla = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);


                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Metodo Listar para cuando un metodo almacenado solo retorna una tbl
        public static DataTable Listar(string nombreProcedimiento, List<Parametro> parametros = null)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }
                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);


                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Metodo cuando tenemos que guardar y update
        //cambiamos de bool a dynamic
        public static dynamic Ejecutar(string nombreProcedimiento, List<Parametro> parametros = null)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }

                int i = cmd.ExecuteNonQuery();

                //return (i > 0) ? true : false;
                bool exito = (i > 0) ? true : false;
                return new
                {
                    exito = exito,
                    mensaje = "exito"
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    exito = false,
                    mensaje = ex.Message
                };
                
                //return false;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
