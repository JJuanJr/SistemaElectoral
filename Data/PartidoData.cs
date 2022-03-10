using SistemaElectoral.Datos;
using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Data
{
    public class PartidoData
    {
        public static PartidoModel DataRowToPartido(DataRow row)
        {
            PartidoModel modelo = new PartidoModel();
            modelo.id = row.Field<uint>("id");
            modelo.nombre = row.Field<string>("nombre");
            modelo.estado = row.Field<string>("estado");
            return modelo;
        }

        public static List<PartidoModel> DataTableToList(DataTable dt)
        {
            List<PartidoModel> lista = new List<PartidoModel>();
            foreach(DataRow row in dt.Rows)
            {
                lista.Add(DataRowToPartido(row));
            }
            return lista;
        }

        public static List<PartidoModel> Consultar()
        {
            string sql = "";
            sql += "select id, nombre, estado ";
            sql += "from partido ";
            sql += "where estado = 'Activo'";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            return DataTableToList(dt);
        }

        public static string ObtenerNombrePartido(uint id)
        {
            string sql = "";
            sql += "select nombre ";
            sql += "from partido ";
            sql += "where id = " + id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            return dt.Rows[0].Field<string>("nombre");
        }
    }
}
