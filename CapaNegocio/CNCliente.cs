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
    public class CNCliente
    {
        private CDCliente objDato = new CDCliente();
        private String id;
        private String nombre;
        private String apellido;
        private String direccion;
        private String telefono;
        private String correo;
        private String tipoid;
        private String estado;

        public CNCliente()
        {
           
        }

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Tipoid { get => tipoid; set => tipoid = value; }
        public string Estado { get => estado; set => estado = value; }

        public void InsertarCliente()
        {
            objDato.InsertarCliente(id, nombre, apellido, direccion, telefono, correo, tipoid);
        }

        public void DarBaja()
        {
            objDato.DardeBaja(id);
        }

        public void DarAlta()
        {
            objDato.DardeAlta(id);
        }

        public void Eliminar()
        {
            objDato.Eliminar(id);
        }

        public DataTable ListaClientes()
        {
            DataTable Tabla;
            Tabla = objDato.ListaClientes();
            return Tabla;
        }

        public DataTable ListaClientesCompleta()
        {
            DataTable Tabla;
            Tabla = objDato.ListaClientesCompleta();
            return Tabla;
        }

        public DataTable BuscarID()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarID(id);
            return Tabla;
        }

        public DataTable BuscarNombre()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarNombre(nombre);
            return Tabla;
        }

        public DataTable BuscarApellido()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarApellido(apellido);
            return Tabla;
        }

        public DataTable BuscarDir()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarDir(direccion);
            return Tabla;
        }

        public DataTable BuscarTel()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarTel(telefono);
            return Tabla;
        }

        public DataTable BuscarCor()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarCor(correo);
            return Tabla;
        }

        public DataTable BuscarEst()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarEst(estado);
            return Tabla;
        }

        public void ModificarCliente()
        {
            objDato.ModificarCliente(id, nombre, apellido, direccion, telefono, correo, tipoid);
        }
    }
}
