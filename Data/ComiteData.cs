using SistemaElectoral.Datos;
using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Data
{
    public class ComiteData
    {
        public static List<ComiteModel> DataTableToList(DataTable dt)
        {
            List<ComiteModel> lista = new List<ComiteModel>();
            foreach (DataRow row in dt.Rows)
            {
                ComiteModel modelo = new ComiteModel();
                modelo.id = row.Field<uint>("id");
                modelo.nombre = row.Field<string>("nombre");
                lista.Add(modelo);
            }
            return lista;
        }

        public static List<ComiteModel> Consultar()
        {
            string sql = "";
            sql += "select id, nombre ";
            sql += "from comite";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            List<ComiteModel> lista = DataTableToList(dt);
            return lista;
        }
    }
}
