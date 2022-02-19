using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Datos.Rol
{
    public class RolData
    {

        public static RolModel DataRowToRol(DataRow row)
        {
            RolModel modelo = new RolModel();
            modelo.id = row.Field<uint>("id");
            modelo.nombre = row.Field<string>("nombre");
            modelo.estado = row.Field<string>("estado");
            return modelo;
        }
        public static List<RolModel> DataTableToList(DataTable dt)
        {
            List<RolModel> lista = new List<RolModel>();
            foreach (DataRow row in dt.Rows)
            {
                RolModel modelo = DataRowToRol(row);
                lista.Add(modelo);
            }
            return lista;
        }

        public static void Eliminar(int id)
        {
            string sql = "";
            sql += "delete from rol ";
            sql += "where id=" + id;
            Conexion.EjecutarOperacion(sql);
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

        public static RolModel Consultar(int id)
        {
            string sql = "";
            sql += "select id, nombre, estado ";
            sql += "from rol ";
            sql += "where id=" + id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            RolModel modelo = DataRowToRol(dt.Rows[0]);
            return modelo;
        }

        public static void Guardar(RolModel modelo)
        {
            string sql = "";
            sql += "insert into rol(nombre, estado) values";
            sql += "('" + modelo.nombre + "', ";
            sql += "'Activo')";
            Conexion.EjecutarOperacion(sql);
        }

        public static void Actualizar(RolModel modelo)
        {
            string sql = "";
            sql += "update rol ";
            sql += "set nombre='" + modelo.nombre + "' ";
            sql += "where id=" + modelo.id;
            Conexion.EjecutarOperacion(sql);
        }
    }
}
