using SistemaElectoral.Datos;
using System.Data;

namespace SistemaElectoral.Data
{
    public class MunicipioData
    {
        public static string ObtenerNombreMunicipio(uint id)
        {
            string sql = "";
            sql += "select nombre ";
            sql += "from municipio ";
            sql += "where id=" + id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            string nombre = dt.Rows[0].Field<string>("nombre");
            return nombre;
        }
    }
}
