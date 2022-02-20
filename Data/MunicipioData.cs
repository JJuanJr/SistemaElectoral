using SistemaElectoral.Datos;
using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Data
{
    public class MunicipioData
    {
        public static MunicipioModel DataRowToMunicipio(DataRow row)
        {
            MunicipioModel modelo = new MunicipioModel();
            modelo.id = row.Field<uint>("id");
            modelo.nombre = row.Field<string>("nombre");
            modelo.fk_id_departamento = row.Field<uint>("fk_id_departamento");
            return modelo;
        }

        public static MunicipioModel Consultar(uint id)
        {
            string sql = "";
            sql += "select id, nombre, fk_id_departamento ";
            sql += "from municipio ";
            sql += "where id=" + id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            return DataRowToMunicipio(dt.Rows[0]);
        }
        public static string ObtenerNombreMunicipio(uint id)
        {
            string sql = "";
            sql += "select nombre ";
            sql += "from municipio ";
            sql += "where id=" + id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            string nombre = dt.Rows[0].Field<string>("nombre");
            return nombre;
        }
    }
}
