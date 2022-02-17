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

        public static EquipoModel Consultar(int id)
        {
            string sql = "";
            sql += "select id, nombre, fk_id_partido ";
            sql += "from equipo ";
            sql += "where id=" + id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            return DataRowToEquipo(dt.Rows[0]);
        }

        public static List<EquipoModel> Consultar()
        {
            string sql = "";
            sql += "select id, nombre, fk_id_partido ";
            sql += "from equipo";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            List<EquipoModel> lista = DataTableToList(dt);
            return lista;
        }


        public static List<PersonaModel> ConsultarInscriptos(int id)
        {
            string sql = "";
            sql += "select persona.id as id, persona.nombre as nombre, persona.apellido as apellido, persona.edad as edad, persona.genero as genero, persona.fk_id_rol as fk_id_rol ";
            sql += "from persona ";
            sql += "inner join estudiante ";
            sql += "on estudiante.id_persona = persona.id ";
            sql += "inner join equipo_estudiante ";
            sql += "on equipo_estudiante.id_estudiante = estudiante.id_persona ";
            sql += "inner join equipo ";
            sql += "on equipo_estudiante.id_equipo = equipo.id ";
            sql += "where equipo_estudiante.estado = 'Activo'";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            List<PersonaModel> lista = new List<PersonaModel>();
            foreach (DataRow row in dt.Rows)
            {
                PersonaModel modelo = PersonaData.DataRowToPersona(row);
                lista.Add(modelo);
            }
            return lista;
        }
    }
}
