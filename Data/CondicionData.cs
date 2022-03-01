using SistemaElectoral.Datos;
using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Data
{
    public class CondicionData
    {
        public static CondicionModel DataRowToCondicion(DataRow row)
        {
            CondicionModel modelo = new CondicionModel();
            modelo.id = row.Field<uint>("id");
            modelo.descripcion = row.Field<string>("descripcion");
            return modelo;
        }

        public static List<CondicionModel> DataTableToList(DataTable dt)
        {
            List<CondicionModel> lista = new List<CondicionModel>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(DataRowToCondicion(row));
            }
            return lista;
        }

        public static List<CondicionModel> Consultar()
        {
            string sql = "";
            sql += "select id, descripcion ";
            sql += "from condicion ";
            sql += "order by descripcion asc";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            return DataTableToList(dt);
        }
    }
}
