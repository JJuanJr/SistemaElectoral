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
            modelo.estado = row.Field<string>("estado");
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
            sql += "select id, nombre, fecha_inicio, fecha_fin, estado ";
            sql += "from eleccion ";
            sql += "where estado = 'Activo'";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            List<EleccionModel> lista = DataTableToList(dt);
            return lista;
        }

        public static EleccionModel Consultar(uint id)
        {
            string sql = "";
            sql += "select id, nombre, fecha_inicio, fecha_fin, estado ";
            sql += "from eleccion ";
            sql += "where id = " + id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            EleccionModel modelo = DataRowToEleccion(dt.Rows[0]);
            return modelo;
        }

        public static void Guardar(EleccionModel modelo)
        {
            string sql = "";
            sql += "insert into eleccion(nombre, fecha_inicio, fecha_fin, estado) values ";
            sql += "('" + modelo.nombre + "', ";
            sql += "'" + modelo.fecha_inicio.ToString("yyyy-MM-dd HH-mm") + "', ";
            sql += "'" + modelo.fecha_fin.ToString("yyyy-MM-dd HH-mm") + "', ";
            sql += "'Activo')";
            Conexion.EjecutarOperacion(sql);
        }

        public static void Actualizar(EleccionModel modelo)
        {
            string sql = "";
            sql += "update eleccion set ";
            sql += "nombre = '" + modelo.nombre + "', ";
            sql += "fecha_inicio = '" + modelo.fecha_inicio.ToString("yyyy-MM-dd HH-mm") + "', ";
            sql += "fecha_fin = '" + modelo.fecha_fin.ToString("yyyy-MM-dd HH-mm") + "' ";
            sql += "where id = " + modelo.id;
            Conexion.EjecutarOperacion(sql);
        }

        public static void Eliminar(uint id)
        {
            string sql = "";
            sql += "update eleccion set ";
            sql += "estado = 'Inactivo' ";
            sql += "where id = " + id;
            Conexion.EjecutarOperacion(sql);
        }
    }
}
