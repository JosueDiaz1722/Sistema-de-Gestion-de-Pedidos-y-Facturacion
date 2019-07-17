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
    public class CNUsuario
    {
        private CDUsuarios objDato = new CDUsuarios();
        private string nombreUsario;
        private string password;
        private string correo;
        private string nombrecargo;
        private int cargo;
        
        public String Usuario
        {
            set
            {
                if (value == "USUARIO")
                {
                    nombreUsario = "No ha ingresado usuario";
                }
                else
                {
                    nombreUsario = value;
                }
            }
            get { return nombreUsario; }
        }

        public String Pass
        {
            set {
                if (value == "CONTRASEÑA")
                {
                    password = "No ha ingresado contraseña";
                }
                else
                {
                    password = value;
                }
            }
            get { return password; }
        }

        public string Correo { get => correo; set => correo = value; }
        public string Nombrecargo { get => nombrecargo; set => nombrecargo = value; }
        public int Cargo { get => cargo; set => cargo = value; }

        public CNUsuario()
        {

        }

        public SqlDataReader IniciarSesion()
        {
            SqlDataReader Loguear;
            Loguear = objDato.iniciarSesion(Usuario,Pass);
            return Loguear;
        }

        public DataTable ListaUsuarios()
        {
            DataTable Tabla;
            Tabla = objDato.ListaUsuarios();
            return Tabla;
        }

        public DataTable BuscarUsuario()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarUsuario(nombreUsario);
            return Tabla;
        }

        public DataTable BuscarUsuarioCorreo()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarUsuarioCorreo(correo);
            return Tabla;
        }

        public DataTable ListaCargo()
        {
            DataTable Tabla;
            Tabla = objDato.ListaCargo();
            return Tabla;
        }

        public DataTable BuscarIndex()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarIndex(Nombrecargo);
            return Tabla;
        }

        public DataTable BuscarPass()
        {
            DataTable Tabla;
            Tabla = objDato.BuscarPass(nombreUsario);
            return Tabla;
        }

        public void InsertarUsuario()
        {
            objDato.InsertarUsuario(nombreUsario, password, Correo, Cargo);
        }

        public void ModificarUsuario()
        {
            objDato.ModificarUsuario(nombreUsario, password, Correo, Cargo);
        }

        public void EliminarUsuario()
        {
            objDato.EliminarUsuario(nombreUsario);
        }

        public void ActivarUsuario()
        {
            objDato.ActivarUsuario(nombreUsario);
        }

        public void DesactivarUsuario()
        {
            objDato.DesactivarUsuario(nombreUsario);
        }
    }
}
