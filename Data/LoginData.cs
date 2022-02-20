namespace SistemaElectoral.Datos.Login
{
    using SistemaElectoral.Models;
    using System.Data;
    using SistemaElectoral.Datos;
    public class LoginData
    {
        public static bool Validar(ulong user, string password)
        {
            string sql = "select id, contraseña from persona ";
            sql += "where id = " + user + " and ";
            sql += "contraseña = '" + password + "'";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
