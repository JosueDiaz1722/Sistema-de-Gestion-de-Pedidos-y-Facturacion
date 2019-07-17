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
    public class CNFactura
    {
        private CDFactura objDato = new CDFactura();
        private int numfactura;
        private int numpedido;
        private DateTime fecha;
        private string estado;
        private string idCliente;

        public int Numfactura { get => numfactura; set => numfactura = value; }
        public int Numpedido { get => numpedido; set => numpedido = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Estado { get => estado; set => estado = value; }
        public string IdCliente { get => idCliente; set => idCliente = value; }

        public CNFactura(){
            }

        public DataTable ListaFactura()
        {
            DataTable Tabla;
            Tabla = objDato.ListaFactura();
            return Tabla;
        }

        public DataTable ListaConsumidor()
        {
            DataTable Tabla;
            Tabla = objDato.ListaConsumidor();
            return Tabla;
        }

        public DataTable BuscarNumeroFactura()
        {
            DataTable Tabla;
            Tabla = objDato.buscarFactura(numfactura);
            return Tabla;
        }

        public DataTable BuscarPedidoFactura()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarPedidoFactura(numfactura);
            return Tabla;
        }

        public DataTable BuscarClienteFactura()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarFacturaCliente(idCliente);
            return Tabla;
        }

        public void EmitirFactura()
        {
            objDato.InsertarFactura(Numpedido,numfactura, fecha);
        }

        public void EmitirConsumidor()
        {
            objDato.InsertarConsumidor(Numpedido, numfactura, fecha);
        }

        public void AnularFactura()
        {
            objDato.AnularFactrua( numfactura);
        }
    }
}
