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
    public class CNIngredientes
    {
        private CDIngrediente objDato = new CDIngrediente();
        private string codigoProducto;
        private string codigoIngrediente;
        private string descripcion;
        private int medida;
        private decimal cantidad;

        public CNIngredientes()
        {

        }

        public string CodigoProducto { get => codigoProducto; set => codigoProducto = value; }
        public string CodigoIngrediente { get => codigoIngrediente; set => codigoIngrediente = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Medida { get => medida; set => medida = value; }
        public decimal Cantidad { get => cantidad; set => cantidad = value; }

        public DataTable ListaIngredientes()
        {
            DataTable Tabla;
            Tabla = objDato.ListaIngredientes(CodigoProducto);
            return Tabla;
        }

        public void insertarIngrediente()
        {
            objDato.InsertarIngrediente(CodigoProducto, codigoIngrediente, descripcion, medida, cantidad);
        }

        public void modificarIngrediente()
        {
            objDato.ModificarIngrediente(CodigoProducto, codigoIngrediente, descripcion, medida, cantidad);
        }

        public void eliminarIngrediente()
        {
            objDato.EliminarIngrediente(CodigoProducto, codigoIngrediente);
        }
    }
}
