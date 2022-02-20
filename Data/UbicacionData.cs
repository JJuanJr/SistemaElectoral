using SistemaElectoral.Datos;
using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Data
{
    public class UbicacionData
    {
        public static UbicacionModel DataRowToUbicacion(DataRow row)
        {
            UbicacionModel modelo = new UbicacionModel();
            modelo.id = row.Field<uint>("id");
            modelo.direccion = row.Field<string>("direccion");
            modelo.fk_id_municipo = row.Field<uint>("fk_id_municipio");
            return modelo;
        }

        public static UbicacionModel Consultar(uint id)
        {
            string sql = "";
            sql += "select id, direccion, fk_id_municipio ";
            sql += "from ubicacion ";
            sql += "where id=" + id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            UbicacionModel modelo = DataRowToUbicacion(dt.Rows[0]);
            return modelo;
        }
    }
}
