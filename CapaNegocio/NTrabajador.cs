using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NTrabajador
    {
        //Metodos
        //Metodo Insertar que llama al metodo Insertar de la Clase DTrabajador
        // de la CapaDatos
        public static string Insertar(string nombre, string apellido,string num_documento,
            string direccion, string telefono, string correo,string acceso,string usuario,string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Correo = correo;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;


            return Obj.Insertar(Obj);
        }
        //Metodo Editar que llama al metodo Editar de la Clase DTrabajador
        // de la CapaDatos
        public static string Editar(int idtrabajador, string nombre, string apellido, string num_documento,
            string direccion, string telefono, string correo, string acceso, string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Correo = correo;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Editar(Obj);
        }
        //Metodo Eliminar que llama al metodo Elimina de la Clase DTrabajador
        // de la CapaDatos
        public static string Eliminar(int idtrabajador)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;
            return Obj.Eliminar(Obj);
        }
        //Metodo Mostrar que llama al metodo Mostrar de la Clase DTrabajador
        // de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostrar();
        }
        //Metodo BuscarRazon_social que llama al metodo BuscarRazon_social de la Clase DTrabajador
        // de la CapaDatos
        public static DataTable BuscarApellido(string textobuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellido(Obj);
        }
        //Metodo BuscarNum_documento que llama al metodo BuscarNum_Documento de la Clase DTrabajador
        // de la CapaDatos
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }
        //Metodo BuscarNum_documento que llama al metodo BuscarNum_Documento de la Clase DTrabajador
        // de la CapaDatos
        public static DataTable Login(string usuario,string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }

    }
}
