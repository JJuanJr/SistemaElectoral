
namespace SistemaElectoral.Datos.Convocatoria
{
    using SistemaElectoral.Models;
    using System.Data;
    using SistemaElectoral.Datos;
    using SistemaElectoral.Data;

    public class ConvocatoriaData
    {
        private static Convocatoria DataRowToConvocatoria(DataRow row)
        {
            Convocatoria modelo = new Convocatoria();
            modelo.id = row.Field<uint>("id");
            modelo.nombre = row.Field<string>("nombre");
            modelo.fecha_inicio = row.Field<DateTime>("fecha_inicio");
            modelo.fecha_fin = row.Field<DateTime>("fecha_fin");
            modelo.cant_ganadores = row.Field<uint>("cant_ganadores");
            modelo.estado = row.Field<string>("estado");
            modelo.fk_id_cargo = row.Field<uint>("fk_id_cargo");
            modelo.fk_id_comite = row.Field<uint>("fk_id_comite");
            modelo.fk_id_eleccion = row.Field<uint>("fk_id_eleccion");
            return modelo;
        }

        private static List<Convocatoria> TablaToList(DataTable tabla)
        {
            List<Convocatoria> lista = new List<Convocatoria>();
            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(DataRowToConvocatoria(row));
            }
            return lista;
        }

        public static List<Convocatoria> Consultar()
        {
            string sql = "";
            sql += "select id, nombre, fecha_inicio, fecha_fin, cant_ganadores, estado, fk_id_comite, fk_id_eleccion, fk_id_cargo ";
            sql += "from convocatoria ";
            sql += "where estado = 'Activo' ";
            sql += "order by fecha_inicio asc";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            return TablaToList(dt);
        }

        public static Convocatoria Consultar(int id)
        {
            string sql = "";
            sql += "select id, nombre, fecha_inicio, fecha_fin, cant_ganadores, estado, fk_id_comite, fk_id_eleccion, fk_id_cargo ";
            sql += "from convocatoria ";
            sql += "where estado = 'Activo' ";
            sql += "and id = " + id + " ";
            sql += "order by fecha_inicio asc";
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            return TablaToList(dt).First();
        }

        public static void Eliminar(int id)
        {
            string sql = "";
            sql += "update convocatoria set ";
            sql += "estado = 'Inactivo' ";
            sql += "where id = " + id;
            Conexion.EjecutarOperacion(sql);
        }

        public static void Actualizar(Convocatoria modelo)
        {
            string comando = "update convocatoria set ";
            comando += "nombre='" + modelo.nombre + "', ";
            comando += "fecha_inicio='" + modelo.fecha_inicio.ToString("yyyy-MM-dd HH-mm") + "', ";
            comando += "fecha_fin='" + modelo.fecha_fin.ToString("yyyy-MM-dd HH-mm") + "' ";
            comando += "where id=" + modelo.id.ToString();
            Conexion.EjecutarOperacion(comando);
        }

        public static void Guardar(Convocatoria modelo)
        {
            string comando = "insert into convocatoria(nombre, fecha_inicio, fecha_fin, fk_id_comite, fk_id_eleccion, fk_id_cargo) values(";
            comando += "'" + modelo.nombre + "',";
            comando += "'" + modelo.fecha_inicio.ToString("yyyy-MM-dd") + "',";
            comando += "'" + modelo.fecha_fin.ToString("yyyy-MM-dd") + "',";
            comando += modelo.fk_id_comite + ",";
            comando += modelo.fk_id_eleccion + ",";
            comando += modelo.fk_id_cargo + ")";
            Conexion.EjecutarOperacion(comando);
        }

        public static List<EquipoModel> ListarInscriptos(int id)
        {
            string sql = "";
            sql += "select equipo.id as id, equipo.nombre as nombre, equipo.fk_id_partido as fk_id_partido ";
            sql += "from equipo ";
            sql += "inner join equipo_convocatoria ";
            sql += "on equipo.id=equipo_convocatoria.id_equipo ";
            sql += "where equipo_convocatoria.id_convocatoria=" + id;
            DataTable dt = Conexion.EjecutarSelectMysql(sql);
            List<EquipoModel> lista = EquipoData.DataTableToList(dt);
            return lista;
        }
    }
}
