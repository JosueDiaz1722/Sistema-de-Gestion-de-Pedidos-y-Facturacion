using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace CapaDatos
{
    public class CDDetallePedido
    {
        private CDConexion Conexion = new CDConexion();
        private SqlDataReader leer;
        private SqlCommand Comando = new SqlCommand();

        public DataTable ListaDetallePedido(int id, DateTime fecha)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaDetallePedido";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id",id);
            Comando.Parameters.AddWithValue("@fecha", fecha);
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void InsertarDetallePedido(int id, string idProdcuto, int cantidad, decimal subtotal, DateTime fecha)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "registarDetallePedido";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.Parameters.AddWithValue("@idProducto", idProdcuto);
            Comando.Parameters.AddWithValue("@cantidad", cantidad);
            Comando.Parameters.AddWithValue("@preciototal", subtotal);
            Comando.Parameters.AddWithValue("@fecha", fecha);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();

        }
    }
}
