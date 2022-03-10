using Newtonsoft.Json;
using SistemaElectoral.Datos;
using SistemaElectoral.Datos.Persona;
using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Data
{
    public class EquipoData
    {
        public static EquipoModel DataRowToEquipo(DataRow row)
        {
            EquipoModel modelo = new EquipoModel();
            modelo.id = row.Field<uint>("id");
            modelo.nombre = row.Field<string>("nombre");
            modelo.fk_id_partido = row.Field<uint>("fk_id_partido");
            return modelo;
        }
        public static List<EquipoModel> DataTableToList(DataTable dt)
        {
            List<EquipoModel> lista = new List<EquipoModel>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(DataRowToEquipo(row));
            }
            return lista;
        }

        public static string ObtenerNombreEquipo(uint fk)
        {
            string sql = "";
            sql += "select nombre ";
            sql += "from partido ";
            sql += "where partido.id=" + fk;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            string nombre = dt.Rows[0].Field<string>("nombre");
            return nombre;
        }

        public static EquipoModel Consultar(uint id)
        {
            string sql = "";
            sql += "select id, nombre, estado, fk_id_partido ";
            sql += "from equipo ";
            sql += "where id=" + id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            return DataRowToEquipo(dt.Rows[0]);
        }

        public static List<EquipoModel> Consultar()
        {
            string sql = "";
            sql += "select id, nombre, estado, fk_id_partido ";
            sql += "from equipo ";
            sql += "where estado = 'Activo'";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            List<EquipoModel> lista = DataTableToList(dt);
            return lista;
        }

        public static EquipoModel ConsultarPertenece(ulong id_pers)
        {
            string sql = "";
            sql += "select equipo.id, equipo.nombre, equipo.estado, equipo.fk_id_partido ";
            sql += "from equipo ";
            sql += "inner join persona_equipo on persona_equipo.id_persona = " + id_pers + " ";
            sql += "where equipo.estado = 'Activo' ";
            sql += "and persona_equipo.estado = 'Activo'";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            return DataRowToEquipo(dt.Rows[0]);
        }


        public static List<PersonaModel> ConsultarInscriptos(int id_equipo)
        {
            string sql = "";
            sql += "select persona.id as id, persona.nombre as nombre, persona.apellido as apellido, persona.edad as edad, persona.genero as genero, persona.foto as foto, persona.fk_id_rol as fk_id_rol ";
            sql += "from persona ";
            sql += "inner join persona_equipo ";
            sql += "on persona_equipo.id_persona = persona.id ";
            sql += "where persona_equipo.estado = 'Activo' ";
            sql += "and persona_equipo.id_equipo = " + id_equipo;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            List<PersonaModel> lista = new List<PersonaModel>();
            foreach (DataRow row in dt.Rows)
            {
                PersonaModel modelo = PersonaData.DataRowToPersona(row);
                lista.Add(modelo);
            }
            return lista;
        }

        public static void Guardar(EquipoModel modelo)
        {
            string sql = "";
            sql += "insert into equipo(nombre, estado, fk_id_partido) values ";
            sql += "('" + modelo.nombre + "', ";
            sql += "'Activo', ";
            sql += modelo.fk_id_partido + ")";
            Conexion.EjecutarOperacion(sql);
        }

        public static void Actualizar(EquipoModel modelo)
        {
            string sql = "";
            sql += "update equipo set ";
            sql += "nombre = '" + modelo.nombre + "', ";
            sql += "fk_id_partido = " + modelo.fk_id_partido + " ";
            sql += "where id = " + modelo.id;
            Conexion.EjecutarOperacion(sql);
        }

        public static void Eliminar(uint id)
        {
            string sql = "";
            sql += "update equipo set ";
            sql += "estado = 'Inactivo' ";
            sql += "where id = " + id;
            Conexion.EjecutarOperacion(sql);
        }

        public static void Entrar(uint id_equipo, ulong id_persona)
        {
            string sql = "";
            sql += "replace into persona_equipo values ";
            sql += "(" + id_persona + ", ";
            sql += id_equipo + ", ";
            sql += "'Activo')";
            Conexion.EjecutarOperacion(sql);
        }
    }
}
