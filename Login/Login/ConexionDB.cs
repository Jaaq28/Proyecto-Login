using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data.SqlClient;

namespace Login
{
   public class ConexionDB
    {
        readonly string cadena = " Data Source=.;Initial Catalog=Login; Intregrated Security=true ";

        public bool ValidarUsuario(Usuario user)
        {
            bool esUsuarioValido = false;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT 1 FROM USUARIO WHERE USUARIO = @User AND Clave = @Clave; ");

                using (SqlConnection _conexion = new SqlConnection(cadena))
                {
                    _conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add(" @User ", System.Data.SqlDbType.NVarChar, 50).Value = user.CodigoUsuario;
                        comando.Parameters.Add(" @Clave ", System.Data.SqlDbType.NVarChar, 50).Value = user.Clave;

                        esUsuarioValido = Convert.ToBoolean(comando.ExecuteScalar());

                    }

                }

            }
            catch (Exception)
            {
                
            }
            return esUsuarioValido;

        }
    }

}
