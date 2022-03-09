using SistemaElectoral.Datos;
using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Data
{
    public class CargoData
    {

        public static List<CargoModel> DataTableToList(DataTable dt)
        {
            List<CargoModel> lista = new List<CargoModel>();
            foreach (DataRow row in dt.Rows)
            {
                CargoModel modelo = new CargoModel();
                modelo.id = row.Field<uint>("id");
                modelo.nombre = row.Field<string>("nombre");
                modelo.estado = row.Field<string>("estado");
                lista.Add(modelo);
            }
            return lista;
        }

        public static string ObtenerNombreCargo(uint id)
        {
            string sql = "";
            sql += "select nombre ";
            sql += "from cargo ";
            sql += "where id=" + id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            string nombre = dt.Rows[0].Field<string>("nombre");
            return nombre;
        }

        public static List<CargoModel> Consultar()
        {
            string sql = "";
            sql += "select id, nombre, estado ";
            sql += "from cargo ";
            sql += "order by nombre asc";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            List<CargoModel> lista = DataTableToList(dt);
            return lista;
        }

    }
}
