using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDProductos
    {
        private CDConexion Conexion = new CDConexion();
        private SqlDataReader leer;
        private SqlCommand Comando = new SqlCommand();

        public DataTable ListarProductos()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaProductos";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable ListarProductosRecientes()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaProductosRecientes";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable ListarIngredientes()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaIngredientes";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable ListarTipo()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "listaTipo";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarIDProd(string id)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarIDProd";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarTipoProd(string id)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarTipoProd";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarNomProd(string id)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarNomProd";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void EliminarProd(string id)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EliminarProd";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void InsertarProducto(string id, string descripcion, int tipo, decimal pvp, decimal precioBruto)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarProducto";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.Parameters.AddWithValue("@nombre", descripcion);
            Comando.Parameters.AddWithValue("@pvp", pvp);
            Comando.Parameters.AddWithValue("@precio", precioBruto);
            Comando.Parameters.AddWithValue("@tipo", tipo);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void ModificarProducto(string id, string descripcion, int tipo, decimal pvp, decimal precioBruto)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ModificarProducto";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.Parameters.AddWithValue("@nombre", descripcion);
            Comando.Parameters.AddWithValue("@pvp", pvp);
            Comando.Parameters.AddWithValue("@precio", precioBruto);
            Comando.Parameters.AddWithValue("@tipo", tipo);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public DataTable BuscarTipo(string id)
        {
            DataTable dato = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarTipo";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@tipo", id);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            dato.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return dato;
        }
    }
}
