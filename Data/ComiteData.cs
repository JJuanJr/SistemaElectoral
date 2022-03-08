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
            sql += "select id, nombre ";
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
            sql += "select id, nombre ";
            sql += "from comite";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            List<ComiteModel> lista = DataTableToList(dt);
            return lista;
        }
    }
}
