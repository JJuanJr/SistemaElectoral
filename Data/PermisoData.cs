using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaElectoral.Datos;
using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Data
{
    public class PermisoData
    {
        public static PermisoModel DataRowToPermiso(DataRow row)
        {
            PermisoModel modelo = new PermisoModel();
            modelo.id = row.Field<uint>("id");
            modelo.descripcion = row.Field<string>("descripcion");
            modelo.estado = row.Field<string>("estado");
            return modelo;
        }

        public static List<PermisoModel> DataTableToList(DataTable dt)
        {
            List<PermisoModel> lista = new List<PermisoModel>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(DataRowToPermiso(row));
            }
            return lista;
        }

        public static List<PermisoModel> Consultar()
        {
            string sql = "";
            sql += "select id, descripcion, estado ";
            sql += "from permiso ";
            sql += "where estado = 'Activo' ";
            sql += "order by descripcion asc";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            return DataTableToList(dt);
        }

        public static List<SelectListItem> ListToSelectList(uint id_rol)
        {
            List<PermisoModel> lista = Consultar();
            List<SelectListItem> permisos = lista.ConvertAll(m =>
            {
                return new SelectListItem()
                {
                    Value = m.id.ToString(),
                    Text = m.descripcion,
                    Selected = TienePermiso(id_rol, m.id)
                };
            });
            return permisos;
        }

        public static List<SelectListItem> ListToSelectList()
        {
            List<PermisoModel> lista = Consultar();
            List<SelectListItem> permisos = lista.ConvertAll(m =>
            {
                return new SelectListItem()
                {
                    Value = m.id.ToString(),
                    Text = m.descripcion,
                    Selected = false
                };
            });
            return permisos;
        }

        public static bool TienePermiso(uint id_rol, uint id_permiso)
        {
            string sql = "";
            sql += "select id_permiso, id_rol, estado ";
            sql += "from permiso_rol ";
            sql += "where estado = 'Activo' ";
            sql += "and id_permiso = " + id_permiso + " ";
            sql += "and id_rol = " + id_rol;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
