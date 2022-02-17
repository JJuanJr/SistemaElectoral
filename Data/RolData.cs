using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Datos.Rol
{
    public class RolData
    {
        public static List<RolModel> DataTableToList(DataTable dt)
        {
            List<RolModel> lista = new List<RolModel>();
            foreach (DataRow row in dt.Rows)
            {
                RolModel modelo = new RolModel();
                modelo.id = row.Field<uint>("id");
                modelo.nombre = row.Field<string>("nombre");
                modelo.estado = row.Field<string>("estado");
                lista.Add(modelo);
            }
            return lista;
        }

        public static List<RolModel> Consultar()
        {
            string sql = "";
            sql += "select id, nombre, estado ";
            sql += "from rol ";
            sql += "where estado='Activo'";
            sql += "order by id asc";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            List<RolModel> lista = DataTableToList(dt);
            return lista;
        }
    }
}
