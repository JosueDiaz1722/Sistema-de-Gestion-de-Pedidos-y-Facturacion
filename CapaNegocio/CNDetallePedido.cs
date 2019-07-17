using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CNDetallePedido
    {
        CDDetallePedido objDato = new CDDetallePedido();
        private int numPedido;
        private string idProducto;
        private int cantidad;
        private decimal preciototal;
        private DateTime fecha;

        public CNDetallePedido()
        {
        }

        public int Cantidad1 { get => cantidad; set => cantidad = value; }
        public string IdProducto { get => idProducto; set => idProducto = value; }
        public int NumPedido { get => numPedido; set => numPedido = value; }
        public decimal Preciototal { get => preciototal; set => preciototal = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }

        public DataTable ListaDetallePedidos()
        {
            DataTable Tabla;
            Tabla = objDato.ListaDetallePedido(numPedido,fecha);
            return Tabla;
        }

        public void RegistarDetallePedido()
        {
            objDato.InsertarDetallePedido(numPedido, idProducto, Cantidad1, Preciototal,Fecha);
        }
    }
}
