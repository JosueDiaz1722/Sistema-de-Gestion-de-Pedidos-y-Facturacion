using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDPedido
    {
        private CDConexion Conexion = new CDConexion();
        private SqlDataReader leer;
        private SqlCommand Comando = new SqlCommand();

        public DataTable ListaPedidos()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaPedido";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarNoPedido(int id)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarPedidoNumero";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarClientePedido(string id)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarPedidoCliente";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarClientePedidoDistintos(string id)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarPedidoClienteDistinto";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarPedidoFactura(int id, DateTime fecha)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarPedidoFactura";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.Parameters.AddWithValue("@fecha", fecha);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void AnularPedido(int id, DateTime fecha)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AnularPedido";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.Parameters.AddWithValue("@fecha", fecha);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void InsertarPedido(int id, string idCliente, DateTime fecha, decimal subtotal, decimal servicio, decimal iva, decimal total, int mesa)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarPedido";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.Parameters.AddWithValue("@idcliente", idCliente);
            Comando.Parameters.AddWithValue("@fecha", fecha);
            Comando.Parameters.AddWithValue("@subtotal", subtotal);
            Comando.Parameters.AddWithValue("@servicio", servicio);
            Comando.Parameters.AddWithValue("@iva", iva);
            Comando.Parameters.AddWithValue("@total", total);
            Comando.Parameters.AddWithValue("@mesa", mesa);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();

        }

        public void EliminarPedido(int id, DateTime fecha)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EliminarPedido";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            Comando.Parameters.AddWithValue("@fecha", id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();

        }
    }
}
