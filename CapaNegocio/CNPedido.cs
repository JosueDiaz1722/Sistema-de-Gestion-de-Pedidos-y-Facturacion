using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;


namespace CapaNegocio
{
    public class CNPedido
    {
        private CDPedido objDato = new CDPedido();
        private int numPedido;
        private string idCliente;
        private DateTime Fecha;
        private decimal subtotal;
        private decimal Iva;
        private decimal servicio;
        private decimal total;
        private string estado;
        private int mesa;

        public int NumPedido { get => numPedido; set => numPedido = value; }
        public string IdCliente { get => idCliente; set => idCliente = value; }
        public DateTime Fecha1 { get => Fecha; set => Fecha = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }
        public decimal Iva1 { get => Iva; set => Iva = value; }
        public decimal Servicio { get => servicio; set => servicio = value; }
        public string Estado { get => estado; set => estado = value; }
        public decimal Total { get => total; set => total = value; }
        public int Mesa { get => mesa; set => mesa = value; }

        public CNPedido()
        {
        }

        public DataTable ListaPedidos()
        {
            DataTable Tabla;
            Tabla = objDato.ListaPedidos();
            return Tabla;
        }

        public DataTable BuscarNumeroPedido()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarNoPedido(numPedido);
            return Tabla;
        }

        public DataTable BuscarClientePedido()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarClientePedido(idCliente);
            return Tabla;
        }

        public DataTable BuscarPedidoFactura()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarPedidoFactura(numPedido,Fecha);
            return Tabla;
        }

        public DataTable BuscarClientePedidoDistintos()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarClientePedidoDistintos(idCliente);
            return Tabla;
        }

        public void AnularPedido()
        {
            objDato.AnularPedido(numPedido, Fecha);
        }

        public void RegistarPedido()
        {
            objDato.InsertarPedido(numPedido, idCliente, Fecha1, subtotal, servicio, Iva1, total,Mesa);
        }

        public void EliminarPedido()
        {
            objDato.EliminarPedido(numPedido, Fecha);
        }
    }
}
