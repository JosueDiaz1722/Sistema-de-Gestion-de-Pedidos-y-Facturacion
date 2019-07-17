using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace CapaDatos
{
    public class CDUsuarios
    {
        private CDConexion Conexion = new CDConexion();
        private SqlDataReader leer;
        private SqlCommand Comando = new SqlCommand();

        public SqlDataReader iniciarSesion(string user, string pass)
        {
            SqlCommand comando = new SqlCommand("InciarSesion", Conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Usuario", user);
            comando.Parameters.AddWithValue("@Password", pass);
            leer = comando.ExecuteReader();
            return leer;
        }

        public DataTable ListaCargo()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaCargo";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable ListaUsuarios()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaUsuarios";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarIndex(string id)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarIndexCargo";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarPass(string id)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarPass";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarUsuario(string id)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarUsuario";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarUsuarioCorreo(string id)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarUsuarioCorreo";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void EliminarUsuario(string id)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EliminarUsuario";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void DesactivarUsuario(string id)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "DesactivarUsuario";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void ActivarUsuario(string id)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ActivarUsuario";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void InsertarUsuario(string id, string pass, string correo, int cargo)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "CrearUsuario";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.Parameters.AddWithValue("@password", pass);
            Comando.Parameters.AddWithValue("@correo", correo);
            Comando.Parameters.AddWithValue("@idCargo", cargo);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();

        }

        public void ModificarUsuario(string id, string pass, string correo, int cargo)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ModificarUsuario";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.Parameters.AddWithValue("@password", pass);
            Comando.Parameters.AddWithValue("@correo", correo);
            Comando.Parameters.AddWithValue("@idCargo", cargo);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();

        }
    }
}
