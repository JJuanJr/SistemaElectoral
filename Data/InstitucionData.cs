using SistemaElectoral.Datos;
using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Data
{
    public class InstitucionData
    {
        public static InstitucionModel DataRowToInstitucion(DataRow row)
        {
            InstitucionModel modelo = new InstitucionModel();
            modelo.nombre = row.Field<string>("nombre");
            modelo.nombre_rector = row.Field<string>("nombre_rector");
            modelo.registro = row.Field<string>("registro");
            modelo.telefono = row.Field<long>("telefono");
            modelo.logo = row.Field<string>("logo");
            modelo.fk_id_ubicacion = row.Field<uint>("fk_id_ubicacion");
            return modelo;
        }

        public static InstitucionModel Consultar()
        {
            string sql = "";
            sql += "select nombre, nombre_rector, registro, telefono, logo, fk_id_ubicacion ";
            sql += "from institucion";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            InstitucionModel modelo = DataRowToInstitucion(dt.Rows[0]);
            return modelo;
        }

        public static void Actualizar(InstitucionModel modelo)
        {
            if (modelo.imagen != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), modelo.logo);
                using var stream = new FileStream(path, FileMode.Create);
                modelo.imagen.CopyTo(stream);
            }

            string sql = "";
            sql += "update institucion set ";
            sql += "nombre='" + modelo.nombre + "', ";
            sql += "registro='" + modelo.registro + "', ";
            sql += "nombre_rector='" + modelo.nombre_rector + "', ";
            sql += "telefono='" + modelo.telefono + "', ";
            sql += "fk_id_ubicacion=" + modelo.fk_id_ubicacion;
            Conexion.EjecutarOperacion(sql);
        }
    }
}
