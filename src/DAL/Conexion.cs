using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class Conexion
    {
        private readonly string cadenaConexion =
            "Server=.\\SQLEXPRESS;Database=RegistroAnimalesPerdidos;Trusted_Connection=True;TrustServerCertificate=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}