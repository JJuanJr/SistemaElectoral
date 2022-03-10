using Newtonsoft.Json;
using SistemaElectoral.Datos;
using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Data
{
    public class ComiteData
    {

        public static ComiteModel DataRowToComite(DataRow row)
        {
            ComiteModel modelo = new ComiteModel();
            modelo.id = row.Field<uint>("id");
            modelo.nombre = row.Field<string>("nombre");
            modelo.estado = row.Field<string>("estado");
            return modelo;
        }

        public static List<ComiteModel> DataTableToList(DataTable dt)
        {
            List<ComiteModel> lista = new List<ComiteModel>();
            foreach (DataRow row in dt.Rows)
            {
                ComiteModel modelo = DataRowToComite(row);
                lista.Add(modelo);
            }
            return lista;
        }

        public static ComiteModel ObtenerComiteSesion(PersonaModel persona)
        {
            string sql = "";
            sql += "select comite.id, comite.nombre, comite.estado ";
            sql += "from comite ";
            sql += "inner join persona_comite ";
            sql += "on persona_comite.id_persona = " + persona.id + " ";
            sql += "where persona_comite.estado = 'Activo' ";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            return DataRowToComite(dt.Rows[0]);
        }

        public static List<ComiteModel> Consultar()
        {
            string sql = "";
            sql += "select id, nombre, estado ";
            sql += "from comite ";
            sql += "where estado = 'Activo'";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            List<ComiteModel> lista = DataTableToList(dt);
            return lista;
        }

        public static ComiteModel Consultar(uint id)
        {
            string sql = "";
            sql += "select id, nombre, estado ";
            sql += "from comite ";
            sql += "where id = " + id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            return DataRowToComite(dt.Rows[0]);
        }

        public static void Guardar(ComiteModel modelo)
        {
            string sql = "";
            sql += "insert into comite(nombre, estado) values ";
            sql += "('" + modelo.nombre + "', ";
            sql += "'Activo')";
            Conexion.EjecutarOperacion(sql);
        }

        public static void Actualizar(ComiteModel modelo)
        {
            string sql = "";
            sql += "update comite set ";
            sql += "nombre = '" + modelo.nombre + "' ";
            sql += "where id = " + modelo.id;
            Conexion.EjecutarOperacion(sql);
        }

        public static void Eliminar(uint id)
        {
            string sql = "";
            sql += "update comite set ";
            sql += "estado = 'Inactivo' ";
            sql += "where id = " + id;
            Conexion.EjecutarOperacion(sql);
        }
    }
}
