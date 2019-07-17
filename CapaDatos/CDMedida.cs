using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDMedida
    {
        private CDConexion Conexion = new CDConexion();
        private SqlDataReader leer;
        private SqlCommand Comando = new SqlCommand();

        public DataTable ListaUnidad()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaUnidad";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void InsertarUnidad(string unidad)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "IngresarUnidad";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@unidad", unidad);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void EliminarMedida(string id)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EliminarUnidad";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public DataTable BuscarIndex(string id)
        {
            DataTable dato = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarIndex";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@unidad", id);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            dato.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return dato;
        }

        
    }
}
