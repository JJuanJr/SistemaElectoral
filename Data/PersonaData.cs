using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Datos.Persona
{
    public class PersonaData
    {

        public static List<PersonaModel> DataTableToList(DataTable dt)
        {
            List<PersonaModel> lista = new List<PersonaModel>();
            foreach (DataRow row in dt.Rows)
            {
                PersonaModel modelo = new PersonaModel();
                modelo.id = row.Field<ulong>("id");
                modelo.nombre = row.Field<string>("nombre");
                modelo.apellido = row.Field<string>("apellido");
                modelo.edad = row.Field<uint>("edad");
                modelo.genero = row.Field<string>("genero");
                modelo.fk_id_rol = row.Field<uint>("fk_id_rol");
                lista.Add(modelo);
            }
            return lista;
        }

        public static void Guardar(PersonaModel modelo)
        {
            string sql = "";
            sql += "insert into persona values ";
            sql += "(" + modelo.id + ",";
            sql += "'" + modelo.nombre + "',";
            sql += "'" + modelo.apellido + "',";
            sql += modelo.edad + ",";
            sql += "'" + modelo.genero + "',";
            sql += "'" + modelo.id + "',";
            sql += "'" + modelo.id + "',";
            sql += modelo.fk_id_rol + ")";
            Conexion.EjecutarOperacion(sql);
        }

        public static List<PersonaModel> Consultar()
        {
            string sql = "";
            sql += "select id, nombre, apellido, edad, genero, fk_id_rol ";
            sql += "from persona ";
            sql += "order by id";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            List<PersonaModel> lista = DataTableToList(dt);
            return lista;
        }
    }
}
