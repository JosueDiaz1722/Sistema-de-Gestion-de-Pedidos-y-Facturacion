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
    public class CNDatos
    {
        CDDatoscs objDato = new CDDatoscs();
        private int idDato;
        private string Nombre;
        private string detalle;
        private decimal valor;

        public int IdDato { get => idDato; set => idDato = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Detalle { get => detalle; set => detalle = value; }
        public decimal Valor { get => valor; set => valor = value; }

        public DataTable ListaDatos()
        {
            DataTable Tabla;
            Tabla = objDato.ListaDatos();
            return Tabla;
        }

        public DataTable NumeroMesas()
        {
            DataTable Tabla;
            Tabla = objDato.NumeroMesas();
            return Tabla;
        }

        public DataTable NumeroPedido()
        {
            DataTable Tabla;
            Tabla = objDato.NumeroPedido();
            return Tabla;
        }

        public DataTable NumeroFactura()
        {
            DataTable Tabla;
            Tabla = objDato.NumeroFactura();
            return Tabla;
        }

        public DataTable Servicio()
        {
            DataTable Tabla;
            Tabla = objDato.Servicio();
            return Tabla;
        }

        public DataTable IVA()
        {
            DataTable Tabla;
            Tabla = objDato.IVA();
            return Tabla;
        }

        public void UpdateNumeroPedido()
        {
            objDato.UpdateNumeroPedido(valor);
        }

        public void UpdateNumeroFactura()
        {
            objDato.UpdateNumeroFactura(valor);
        }
        public void UpdateCargo()
        {
            objDato.UpdateCargo(Nombre1,idDato);
        }

        public void UpdateTipo()
        {
            objDato.UpdateTipo(Nombre1, idDato);
        }

        public void UpdateMedida()
        {
            objDato.UpdateMedida(Nombre1, idDato);
        }

        public void DeleteCargo()
        {
            objDato.DeleteCargo(Nombre1, idDato);
        }

        public void DeleteTipo()
        {
            objDato.DeleteTipo(Nombre1, idDato);
        }

        public void DeleteMedida()
        {
            objDato.DeleteMedida(Nombre1, idDato);
        }

        public void UpdateDato()
        {
            objDato.UpdateDato(Nombre1, valor);
        }

        public void AddCargo()
        {
            objDato.AddCargo(Nombre1);
        }

        public void AddTipo()
        {
            objDato.AddTipo(Nombre1);
        }

        public void AddMedida()
        {
            objDato.AddMedida(Nombre1);
        }



        public DataTable Cargos()
        {
            DataTable Tabla;
            Tabla = objDato.Cargos();
            return Tabla;
        }

        public DataTable Tipo()
        {
            DataTable Tabla;
            Tabla = objDato.Tipo();
            return Tabla;
        }

        public DataTable Medida()
        {
            DataTable Tabla;
            Tabla = objDato.Medida();
            return Tabla;
        }
    }
}
