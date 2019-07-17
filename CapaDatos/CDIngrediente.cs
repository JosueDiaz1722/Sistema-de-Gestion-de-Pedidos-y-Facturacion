using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{

    public class CDIngrediente
    {

        private CDConexion Conexion = new CDConexion();
        private SqlDataReader leer;
        private SqlCommand Comando = new SqlCommand();

        public DataTable ListaIngredientes(string id)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaIngredientes";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@producto", id);
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void InsertarIngrediente(string id, string iding,string descripcion, int medida, decimal cantidad)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarIngrediente";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.Parameters.AddWithValue("@idInv", iding);
            Comando.Parameters.AddWithValue("@nombre", descripcion);
            Comando.Parameters.AddWithValue("@unidad", medida);
            Comando.Parameters.AddWithValue("@cantidad", cantidad);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void ModificarIngrediente(string id, string iding, string descripcion, int medida, decimal cantidad)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ModificarIngrediente";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.Parameters.AddWithValue("@idInv", iding);
            Comando.Parameters.AddWithValue("@nombre", descripcion);
            Comando.Parameters.AddWithValue("@unidad", medida);
            Comando.Parameters.AddWithValue("@cantidad", cantidad);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void EliminarIngrediente(string id, string iding)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EliminarIngrediente";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.Parameters.AddWithValue("@idInv", iding);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
    }
}
