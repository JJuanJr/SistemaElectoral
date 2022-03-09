using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaElectoral.Datos;
using SistemaElectoral.Models;
using System.Data;

namespace SistemaElectoral.Data
{
    public class CondicionData
    {
        public static CondicionModel DataRowToCondicion(DataRow row)
        {
            CondicionModel modelo = new CondicionModel();
            modelo.id = row.Field<uint>("id");
            modelo.descripcion = row.Field<string>("descripcion");
            return modelo;
        }

        public static List<CondicionModel> DataTableToList(DataTable dt)
        {
            List<CondicionModel> lista = new List<CondicionModel>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(DataRowToCondicion(row));
            }
            return lista;
        }

        public static void Guardar(CondicionModel modelo)
        {
            string sql = "";
            sql += "insert into condicion(descripcion, estado) values ";
            sql += "('" + modelo.descripcion + "', ";
            sql += "'Activo')";
            Conexion.EjecutarOperacion(sql);
        }

        public static List<CondicionModel> Consultar()
        {
            string sql = "";
            sql += "select id, descripcion ";
            sql += "from condicion ";
            sql += "where estado = 'Activo' ";
            sql += "order by descripcion asc";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            return DataTableToList(dt);
        }

        public static List<SelectListItem> ListToSelectList(uint id_conv)
        {
            List<CondicionModel> lista = Consultar();
            List<SelectListItem> condiciones = lista.ConvertAll(m =>
            {
                return new SelectListItem()
                {
                    Value = m.id.ToString(),
                    Text = m.descripcion,
                    Selected = TieneCondicion(id_conv, m.id)
                };
            });
            return condiciones;
        }

        public static List<SelectListItem> ListToSelectList()
        {
            List<CondicionModel> lista = Consultar();
            List<SelectListItem> condiciones = lista.ConvertAll(m =>
            {
                return new SelectListItem()
                {
                    Value = m.id.ToString(),
                    Text = m.descripcion,
                    Selected = false
                };
            });
            return condiciones;
        }

        public static bool TieneCondicion(uint id_conv, uint id_condicion)
        {
            string sql = "";
            sql += "select id_condicion, id_convocatoria, estado ";
            sql += "from condicion_convocatoria ";
            sql += "where condicion_convocatoria.estado = 'Activo' ";
            sql += "and id_condicion = " + id_condicion + " ";
            sql += "and id_convocatoria = " + id_conv;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public static CondicionModel Consultar(uint id)
        {
            string sql = "";
            sql += "select id, descripcion ";
            sql += "from condicion ";
            sql += "where estado = 'Activo' ";
            sql += "and id = " + id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            return DataRowToCondicion(dt.Rows[0]);
        }

        public static void Actualizar(CondicionModel modelo)
        {
            string sql = "";
            sql += "update condicion set ";
            sql += "descripcion = '" + modelo.descripcion + "' ";
            sql += "where id = " + modelo.id;
            Conexion.EjecutarOperacion(sql);
        }

        public static void Eliminar(uint id)
        {
            string sql = "";
            sql += "update condicion set ";
            sql += "estado = 'Inactivo' ";
            sql += "where id = " + id;
            Conexion.EjecutarOperacion(sql);
        }
    }
}
