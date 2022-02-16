using SistemaElectoral.Datos;
using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Data
{
    public class EquipoData
    {
        public static List<EquipoModel> DataTableToList(DataTable dt)
        {
            List<EquipoModel> lista = new List<EquipoModel>();
            foreach (DataRow row in dt.Rows)
            {
                EquipoModel modelo = new EquipoModel();
                modelo.id = row.Field<uint>("id");
                modelo.nombre = row.Field<string>("nombre");
                modelo.fk_id_partido = row.Field<uint>("fk_id_partido");
                lista.Add(modelo);
            }
            return lista;
        }

        public static string ObtenerNombreEquipo(uint fk)
        {
            string sql = "";
            sql += "select nombre ";
            sql += "from partido ";
            sql += "where partido.id=" + fk;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            string nombre = dt.Rows[0].Field<string>("nombre");
            return nombre;
        }

    }
}
