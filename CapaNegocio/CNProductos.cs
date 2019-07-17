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
    public class CNProductos
    {
        private CDProductos objDato = new CDProductos();
        private String codigoProducto;
        private String nombreTipo;
        private String nombreProducto;
        private decimal PVP;
        private decimal preciobruto;
        private int tipo;

        public String codigoProd
        {
            set {codigoProducto = value; }
            get { return codigoProducto; }
        }

        public String nomTipo
        {
            set { nombreTipo = value; }
            get { return nombreTipo; }
        }

        public String nombreProd
        {
            set { nombreProducto = value; }
            get { return nombreProducto; }
        }

        public decimal PrecioUni
        {
            set { PVP = value; }
            get { return PVP; }
        }

        public decimal PrecioB
        {
            set { preciobruto = value; }
            get { return preciobruto; }
        }

        public int Tipo { get => tipo; set => tipo = value; }

        public CNProductos()
        {

        }

        public DataTable ListaProd()
        {
            DataTable Tabla;
            Tabla = objDato.ListarProductos();
            return Tabla;
        }

        public DataTable ListaTipo()
        {
            DataTable Tabla;
            Tabla = objDato.ListarTipo();
            return Tabla;
        }

        public DataTable BuscarIDProd()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarIDProd(codigoProd);
            return Tabla;
        }

        public DataTable BuscarTipoProd()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarTipoProd(nombreTipo);
            return Tabla;
        }
        public DataTable BuscarNomProd()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarNomProd(nombreProducto);
            return Tabla;
        }
        public void EliminarProd()
        {
            objDato.EliminarProd(codigoProd);
        }

        public void insertarProducto()
        {
            objDato.InsertarProducto(codigoProd, nombreProducto, Tipo, PVP,PrecioB);
        }

        public void modificarProducto()
        {
            objDato.ModificarProducto(codigoProd, nombreProducto, Tipo, PVP, PrecioB);
        }

        public DataTable buscarTipo()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarTipo(nombreTipo);
            return Tabla;
        }
    }

}
