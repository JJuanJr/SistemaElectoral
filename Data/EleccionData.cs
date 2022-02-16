using SistemaElectoral.Datos;
using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Data
{
    public class EleccionData
    {
        public static List<EleccionModel> DataTableToList(DataTable dt)
        {
            List<EleccionModel> lista = new List<EleccionModel>();
            foreach (DataRow row in dt.Rows)
            {
                EleccionModel modelo = new EleccionModel();
                modelo.id = row.Field<uint>("id");
                modelo.fecha_inicio = row.Field<DateTime>("fecha_inicio");
                modelo.fecha_fin = row.Field<DateTime>("fecha_fin");
                lista.Add(modelo);
            }
            return lista;
        }

        public static string ObtenerFecha(uint id)
        {
            string sql = "";
            sql += "select fecha_inicio, fecha_fin ";
            sql += "from eleccion ";
            sql += "where id=" + id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            string fecha = dt.Rows[0].Field<DateTime>("fecha_inicio").ToString("yyyy-MM-dd");
            fecha += " / ";
            fecha += dt.Rows[0].Field<DateTime>("fecha_fin").ToString("yyyy-MM-dd");
            return fecha;
        }

        public static List<EleccionModel> Consultar()
        {
            string sql = "";
            sql += "select id, fecha_inicio, fecha_fin ";
            sql += "from eleccion";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            List<EleccionModel> lista = DataTableToList(dt);
            return lista;
        }
    }
}
