
namespace SistemaElectoral.Datos.Convocatoria
{
    using SistemaElectoral.Models;
    using System.Data;
    using SistemaElectoral.Datos;
    using SistemaElectoral.Data;

    public class ConvocatoriaData
    {

        private static List<Convocatoria> TablaToList(DataTable tabla)
        {
            List<Convocatoria> lista = new List<Convocatoria>();
            foreach (DataRow row in tabla.Rows)
            {
                Convocatoria modelo = new Convocatoria();
                modelo.id = row.Field<uint>("id");
                modelo.nombre = row.Field<string>("nombre");
                modelo.fecha_inicio = row.Field<DateTime>("fecha_inicio");
                modelo.fecha_fin = row.Field<DateTime>("fecha_fin");
                modelo.fk_id_cargo = row.Field<uint>("fk_id_cargo");
                modelo.fk_id_comite = row.Field<uint>("fk_id_comite");
                modelo.fk_id_eleccion = row.Field<uint>("fk_id_eleccion");
                lista.Add(modelo);
            }
            return lista;
        }

        public List<Convocatoria> Consultar()
        {
            DataTable dt = Conexion.EjecutarSelectMysql("select * from convocatoria");
            return TablaToList(dt);
        }

        public Convocatoria Consultar(int id)
        {
            DataTable dt = Conexion.EjecutarSelectMysql("select * from convocatoria where id=" + id.ToString());
            return TablaToList(dt).First();
        }

        public void Eliminar(int id)
        {
            string comando = "delete from convocatoria where id=" + id.ToString();
            Conexion.EjecutarOperacion(comando);
        }

        public void Actualizar(Convocatoria modelo)
        {
            string comando = "update convocatoria set ";
            comando += "nombre='" + modelo.nombre + "', ";
            comando += "fecha_inicio='" + modelo.fecha_inicio.ToString("yyyy-MM-dd HH-mm") + "', ";
            comando += "fecha_fin='" + modelo.fecha_fin.ToString("yyyy-MM-dd HH-mm") + "' ";
            comando += "where id=" + modelo.id.ToString();
            Conexion.EjecutarOperacion(comando);
        }

        public void Guardar(Convocatoria modelo)
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
