using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDInventario
    {
        private CDConexion Conexion = new CDConexion();
        private SqlDataReader leer;
        private SqlCommand Comando = new SqlCommand();

        public DataTable ListaInventario()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaInventario";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable ListaInventarioMod()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaInventarioMod";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }


        public DataTable BuscarIDInv(string id)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarIDInv";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarDescripcionInv(string id)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarDescripcionInv";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void InsertarInventario(string id, string descripcion, int unidadMedida, decimal cantidad, decimal precioUni, decimal precioTotal)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "IngresarInventario";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.Parameters.AddWithValue("@descripcion", descripcion);
            Comando.Parameters.AddWithValue("@unidad", unidadMedida);
            Comando.Parameters.AddWithValue("@cantidad", cantidad);
            Comando.Parameters.AddWithValue("@precioU", precioUni);
            Comando.Parameters.AddWithValue("@precioT", precioTotal);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void ModificarInventario(string id, string descripcion, int unidadMedida, decimal cantidad, decimal precioUni, decimal precioTotal)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ModificarInventario";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.Parameters.AddWithValue("@descripcion", descripcion);
            Comando.Parameters.AddWithValue("@unidad", unidadMedida);
            Comando.Parameters.AddWithValue("@cantidad", cantidad);
            Comando.Parameters.AddWithValue("@precioU", precioUni);
            Comando.Parameters.AddWithValue("@precioT", precioTotal);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();

        }

        public void EliminarInv(string id)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EliminarInv";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
    }
}
