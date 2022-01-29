using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace ABMProductos
{
    class Datos
    {
        OleDbConnection conexion;
        OleDbCommand comando;
        OleDbDataReader lector;
        string cadenaConexion = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\Users\Admins\Desktop\7-abm-productos-turno-manana-1w1112003WilliamsKaterinne-master\ABMProductos\DBFProducto.mdb";

        public Datos()
        {
            conexion = new OleDbConnection();
            conexion.ConnectionString = cadenaConexion;
            comando = new OleDbCommand();
        }
        public Datos(string cadenaConexion)
        {
            conexion = new OleDbConnection(cadenaConexion);
            comando = new OleDbCommand();
        } 

        public OleDbDataReader pLector
        {
            set { lector = value; }
            get { return lector; }
        }
        public string pCadenaConexion
        {
            set { cadenaConexion = value; }
            get { return cadenaConexion; }
        }

        public void conectar()
        {
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }

        public void desconectar()
        {
            conexion.Close();
        }

        public void leerTabla(string nombreTabla)
        {
            conectar();
            comando.CommandText = "select * from " + nombreTabla;
            lector = comando.ExecuteReader();
            //la conexión no se cierra
        }

        public DataTable cargarTabla(string nombreTabla) //tipo de dato DataTable
        {
            conectar();
            DataTable tabla = new DataTable();
            comando.CommandText = "select * from " + nombreTabla;
            tabla.Load(comando.ExecuteReader());
            desconectar(); //acá si cierro la conexión
            return tabla; //recordar que debo devolver algo

        }

        public void actualizar(string consultaSQL)
        {
            conectar();
            comando.CommandText = consultaSQL;
            comando.ExecuteNonQuery();
            desconectar();
        }
    }
}
