using SistemaElectoral.Datos;
using System.Data;

namespace SistemaElectoral.Data
{
    public class DepartamentoData
    {
        public static string ObtenerNombreDepartamento(uint id)
        {
            string sql = "";
            sql += "select nombre ";
            sql += "from departamento ";
            sql += "where id=" + id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            string nombre = dt.Rows[0].Field<string>("nombre");
            return nombre;
        }
    }
}
