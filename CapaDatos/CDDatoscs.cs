using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDDatoscs
    {
        private CDConexion Conexion = new CDConexion();
        private SqlDataReader leer;
        private SqlCommand Comando = new SqlCommand();

        public DataTable ListaDatos()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaDatos";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable NumeroMesas()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "mesas";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable NumeroPedido()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "numeropedido";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable NumeroFactura()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ObtnerFactura";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }
        public void UpdateNumeroPedido(decimal numero)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "updateNumeroPedido";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", numero);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void UpdateNumeroFactura(decimal numero)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "updateNumeroFactura";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", numero);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void UpdateCargo(string numero, int id)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "UpdateCargo";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@cargo", numero);
            Comando.Parameters.AddWithValue("@id", id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void DeleteCargo(string numero, int id)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "DeleteCargo";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@cargo", numero);
            Comando.Parameters.AddWithValue("@id", id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void AddCargo(string numero)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AddCargo";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@cargo", numero);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void AddTipo(string numero)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AddTipo";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@cargo", numero);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void AddMedida(string numero)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AddMedida";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@cargo", numero);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }


        public void UpdateTipo(string numero, int id)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "UpdateTipo";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@cargo", numero);
            Comando.Parameters.AddWithValue("@id", id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void UpdateMedida(string numero, int id)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "UpdateMedida";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@cargo", numero);
            Comando.Parameters.AddWithValue("@id", id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void DeleteTipo(string numero, int id)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "DeleteTipo";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@cargo", numero);
            Comando.Parameters.AddWithValue("@id", id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void DeleteMedida(string numero, int id)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "DeleteMedida";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@cargo", numero);
            Comando.Parameters.AddWithValue("@id", id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public void UpdateDato(string numero, decimal id)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "UpdateDatos";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@valor", id);
            Comando.Parameters.AddWithValue("@nombre", numero);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

        public DataTable Servicio()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "Servicio";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable IVA()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "IVA";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable Cargos()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaCargoCompleta";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable Tipo()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaTipoCompleta";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable Medida()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListaMedidaCompleta";
            Comando.CommandType = CommandType.StoredProcedure;
            leer = Comando.ExecuteReader();
            Tabla.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }
    }
}
