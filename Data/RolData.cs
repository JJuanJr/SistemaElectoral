using Newtonsoft.Json;
using SistemaElectoral.Data;
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
            modelo.permisos = PermisoData.ListToSelectList(modelo.id);
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
            sql += "update rol set ";
            sql += "rol.estado = 'Inactivo' ";
            sql += "where rol.id =" + id;
            Conexion.EjecutarOperacion(sql);

            RolModel modelo = Consultar(id);
            foreach (var item in modelo.permisos)
            {
                sql = "replace into permiso_rol(id_permiso, id_rol, estado) values";
                sql += "(" + item.Value + ", ";
                sql += modelo.id + ", ";
                sql += "'Inactivo')";
                Conexion.EjecutarOperacion(sql);
            }
        }

        public static List<RolModel> Consultar()
        {
            string sql = "";
            sql += "select id, nombre, estado ";
            sql += "from rol ";
            sql += "where estado = 'Activo'";
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
            sql += "where id =" + id;
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

            sql = "select id ";
            sql += "from rol ";
            sql += "where nombre = '" + modelo.nombre + "'";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            modelo.id = dt.Rows[0].Field<uint>("id");

            foreach (var item in modelo.permisos)
            {
                if (item.Selected)
                {
                    sql = "insert into permiso_rol(id_permiso, id_rol, estado) values";
                    sql += "(" + item.Value + ", ";
                    sql += modelo.id + ", ";
                    sql += "'Activo')";
                    Conexion.EjecutarOperacion(sql);
                }
            }
        }

        public static void Actualizar(RolModel modelo)
        {
            string sql = "";
            sql += "update rol ";
            sql += "set nombre='" + modelo.nombre + "' ";
            sql += "where id=" + modelo.id;
            Conexion.EjecutarOperacion(sql);

            foreach (var item in modelo.permisos)
            {
                sql = "replace into permiso_rol(id_permiso, id_rol, estado) values";
                sql += "(" + item.Value + ", ";
                sql += modelo.id + ", ";
                sql += "'" + (item.Selected ? "Activo" : "Inactivo") + "')";
                Conexion.EjecutarOperacion(sql);
            }
        }

        public static int TienePermiso(Object tempdata, string nombre)
        {
            if (tempdata == null)
            {
                return -1;
            }
            PersonaModel modelo = JsonConvert.DeserializeObject<PersonaModel>(tempdata.ToString());

            string sql = "";
            sql += "select persona.id, permiso.descripcion ";
            sql += "from persona ";
            sql += "inner join rol ";
            sql += "on persona.fk_id_rol=rol.id ";
            sql += "inner join permiso_rol ";
            sql += "on permiso_rol.id_rol=rol.id ";
            sql += "inner join permiso ";
            sql += "on permiso_rol.id_permiso=permiso.id ";
            sql += "where permiso_rol.id_rol=" + modelo.fk_id_rol + " ";
            sql += "and permiso_rol.estado='Activo' ";
            sql += "and permiso.descripcion='" + nombre + "' ";
            sql += "and persona.id=" + modelo.id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            return 0;
        }
    }
}
