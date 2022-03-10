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

        public static PartidoModel Consultar(uint id)
        {
            string sql = "";
            sql += "select id, nombre, estado ";
            sql += "from partido ";
            sql += "where id = " + id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            return DataRowToPartido(dt.Rows[0]);
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

        public static void Guardar(PartidoModel modelo)
        {
            string sql = "";
            sql += "insert into partido(nombre, estado) values ";
            sql += "('" + modelo.nombre + "', ";
            sql += "'Activo')";
            Conexion.EjecutarOperacion(sql);
        }

        public static void Actualizar(PartidoModel modelo)
        {
            string sql = "";
            sql += "update partido set ";
            sql += "nombre = '" + modelo.nombre + "' ";
            sql += "where id = " + modelo.id;
            Conexion.EjecutarOperacion(sql);
        }

        public static void Eliminar(uint id)
        {
            string sql = "";
            sql += "update partido set ";
            sql += "estado = 'Inactivo' ";
            sql += "where id = " + id;
            Conexion.EjecutarOperacion(sql);
        }
    }
}
