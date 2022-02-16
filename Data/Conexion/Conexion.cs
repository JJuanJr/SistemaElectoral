using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace SistemaElectoral.Datos
{
    public class Conexion
    {

        private static MySqlConnection conexion = new MySqlConnection("Server=Localhost;Database=elecciones;Uid=root;Pwd=root;");


        private static bool Conectar()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        private static void Desconectar()
        {
            conexion.Close();
        }

        public static void EjecutarOperacion(string sentencia)
        {
            if (Conectar())
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = sentencia;
                comando.CommandType = CommandType.Text;
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                Desconectar();
            }
            else
            {
                throw new Exception("No ha sido posible conectarse a la Base de Datos");
            }
        }

        public static DataTable EjecutarConsulta(string sentencia, List<MySqlParameter> ListaParametros, CommandType TipoComando)
        {
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = new MySqlCommand(sentencia, conexion);
            adaptador.SelectCommand.CommandType = TipoComando;

            foreach (MySqlParameter parametro in ListaParametros)
            {
                adaptador.SelectCommand.Parameters.Add(parametro);
            }
            DataSet resultado = new DataSet();
            adaptador.Fill(resultado);

            return resultado.Tables[0];
        }


        public static string cad_Conexion()
        {
            return "Server=Localhost;Database=elecciones;Uid=root;Pwd=root;";

        }

        public static MySqlConnection ConectarMysql() //Metoto para conectar a C# a MySQL
        {
            string CadenaConexion;
            CadenaConexion = cad_Conexion();
            MySqlConnection Conexion = new MySqlConnection(CadenaConexion);
            Conexion.Open();
            return Conexion;
        }


        public static DataTable EjecutarSelectMysql(string p)
        {
            DataSet dt = new DataSet();

            MySqlConnection Conn = ConectarMysql();
            MySqlCommand ComandoSelect = new MySqlCommand(p);
            ComandoSelect.Connection = Conn;

            // MySqlDataReader Resultado;
            MySqlDataAdapter da = new MySqlDataAdapter(p, Conn);
            //da = ComandoSelect.ExecuteReader();
            da.Fill(dt);
            Conn.Close();
            return dt.Tables[0];
        }
    }
}
