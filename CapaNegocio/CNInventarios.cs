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
    public class CNInventarios
    {
        private CDInventario objDato = new CDInventario();
        private string codigioInventario;
        private string descripcion;
        private int unidadMedida;
        private decimal cantidad;
        private decimal precioUni;
        private decimal precioTotal;

        public CNInventarios()
        {

        }
        public string CodigioInventario { get => codigioInventario; set => codigioInventario = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int UnidadMedida { get => unidadMedida; set => unidadMedida = value; }
       
        public decimal PrecioUni { get => precioUni; set => precioUni = value; }
        public decimal PrecioTotal { get => precioTotal; set => precioTotal = value; }
        public decimal Cantidad { get => cantidad; set => cantidad = value; }

        public void insertarInventario()
        {
            objDato.InsertarInventario(codigioInventario, descripcion, unidadMedida, Cantidad, precioUni, precioTotal);
        }

        public void modificarInventario()
        {
            objDato.ModificarInventario(codigioInventario,descripcion,unidadMedida,Cantidad,precioUni,precioTotal);
        }

        public DataTable BuscarDescripcionInv()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarDescripcionInv(descripcion);
            return Tabla;
        }

        public DataTable BuscarIDInv()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarIDInv(codigioInventario);
            return Tabla;
        }

        public void EliminarInv()
        {
            objDato.EliminarInv(codigioInventario);
        }

        public DataTable ListaInventario()
        {
            DataTable Tabla;
            Tabla = objDato.ListaInventario();
            return Tabla;
        }

        public DataTable ListaInventarioMod()
        {
            DataTable Tabla;
            Tabla = objDato.ListaInventarioMod();
            return Tabla;
        }
    }
}
