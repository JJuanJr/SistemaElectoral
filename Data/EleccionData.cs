using SistemaElectoral.Datos;
using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Data
{
    public class EleccionData
    {
        public static EleccionModel DataRowToEleccion(DataRow row)
        {
            EleccionModel modelo = new EleccionModel();
            modelo.id = row.Field<uint>("id");
            modelo.nombre = row.Field<string>("nombre");
            modelo.fecha_inicio = row.Field<DateTime>("fecha_inicio");
            modelo.fecha_fin = row.Field<DateTime>("fecha_fin");
            return modelo;
        }

        public static List<EleccionModel> DataTableToList(DataTable dt)
        {
            List<EleccionModel> lista = new List<EleccionModel>();
            foreach (DataRow row in dt.Rows)
            {
                EleccionModel modelo = DataRowToEleccion(row);
                lista.Add(modelo);
            }
            return lista;
        }

        public static List<EleccionModel> Consultar()
        {
            string sql = "";
            sql += "select id, nombre, fecha_inicio, fecha_fin ";
            sql += "from eleccion";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            List<EleccionModel> lista = DataTableToList(dt);
            return lista;
        }

        public static EleccionModel Consultar(uint id)
        {
            string sql = "";
            sql += "select id, nombre, fecha_inicio, fecha_fin ";
            sql += "from eleccion ";
            sql += "where id = " + id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            EleccionModel modelo = DataRowToEleccion(dt.Rows[0]);
            return modelo;
        }
    }
}
