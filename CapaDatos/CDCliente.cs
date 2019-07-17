using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDCliente
    {
        private CDConexion Conexion = new CDConexion();
        private SqlDataReader leer;
        private SqlCommand Comando = new SqlCommand();

        public DataTable ListaClientes()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaClientes";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable ListaClientesCompleta()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaClienteEstado";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarID(string id)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarID";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarNombre(string nombre)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarNombre";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@nombre", nombre);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarApellido(string apellido)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarApellido";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@apellido", apellido);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarDir(string dir)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarDir";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@dir", dir);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarTel(string tel)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarTel";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@tel", tel);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarCor(string cor)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarCor";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@cor", cor);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarEst(string est)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarEst";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@est", est);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }
        public void InsertarCliente(string id, string nombre, string apellido, string direccion, string telefono, string correo, string tipoID) 
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "IngresarCliente";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.Parameters.AddWithValue("@nombre", nombre);
            Comando.Parameters.AddWithValue("@apellido", apellido);
            Comando.Parameters.AddWithValue("@direccion", direccion);
            Comando.Parameters.AddWithValue("@telefono", telefono);
            Comando.Parameters.AddWithValue("@correo", correo);
            Comando.Parameters.AddWithValue("@tipoid", tipoID);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();

        }

        public void DardeBaja(string id)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "DarBaja";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void Eliminar(string id)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EliminarID";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void DardeAlta(string id)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "DarAlta";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void ModificarCliente(string id, string nombre, string apellido, string direccion, string telefono, string correo, string tipoID)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ModificarCliente";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.Parameters.AddWithValue("@nombre", nombre);
            Comando.Parameters.AddWithValue("@apellido", apellido);
            Comando.Parameters.AddWithValue("@direccion", direccion);
            Comando.Parameters.AddWithValue("@telefono", telefono);
            Comando.Parameters.AddWithValue("@correo", correo);
            Comando.Parameters.AddWithValue("@tipoid", tipoID);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();

        }
    }
}
