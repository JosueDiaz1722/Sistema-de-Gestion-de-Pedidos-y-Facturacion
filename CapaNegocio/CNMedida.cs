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
    public class CNMedida
    {
        private CDMedida objDato = new CDMedida();
        private String unidad;
        private String estado;
        
        public CNMedida()
        {

        }

        public string Unidad { get => unidad; set => unidad = value; }
        public string Estado { get => estado; set => estado = value; }

        public void InsertarMedida()
        {
            objDato.InsertarUnidad(unidad);
        }

        public void EliminarMedida()
        {
            objDato.EliminarMedida(unidad);
        }

        public DataTable BuscarIndex()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarIndex(unidad);
            return Tabla;
        }

        public DataTable ListaMedida()
        {
            DataTable Tabla;
            Tabla = objDato.ListaUnidad();
            return Tabla;
        }
    }
}
