using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDFactura
    {
        private CDConexion Conexion = new CDConexion();
        private SqlDataReader leer;
        private SqlCommand Comando = new SqlCommand();


        public DataTable ListaFactura()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaFactura";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable ListaConsumidor()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaConsumidor";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable buscarFactura(int factura)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarFacturaCliente";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@num", factura);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarFacturaCliente(string id)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarFacturaCliente";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable BuscarPedidoFactura(int id)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "PedidoFactura";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", id);
            leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }


        public void InsertarFactura(int pedido, int factura, DateTime fecha)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarFactura";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", pedido);
            Comando.Parameters.AddWithValue("@factura", factura);
            Comando.Parameters.AddWithValue("@fecha", fecha);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();

        }

        public void InsertarConsumidor(int pedido, int factura, DateTime fecha)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarConsumidor";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", pedido);
            Comando.Parameters.AddWithValue("@factura", factura);
            Comando.Parameters.AddWithValue("@fecha", fecha);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();

        }

        public void AnularFactrua( int factura)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AnularFactura";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", factura);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();

        }
    }


}
