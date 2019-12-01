using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NCliente
    {
        //Metodos
        //Metodo Insertar que llama al metodo Insertar de la Clase DCliente
        // de la CapaDatos
        public static string Insertar(string nombre, 
            string tipo_documento,string num_documento,
            string direccion, string telefono, string correo)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Correo = correo;

            return Obj.Insertar(Obj);
        }
        //Metodo Editar que llama al metodo Editar de la Clase DCliente
        // de la CapaDatos
        public static string Editar(int idcliente,string nombre,
            string tipo_documento,string num_documento,
            string direccion, string telefono, string correo)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;
            Obj.Nombre = nombre;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Correo = correo;
            return Obj.Editar(Obj);
        }
        //Metodo Eliminar que llama al metodo Elimina de la Clase DCliente
        // de la CapaDatos
        public static string Eliminar(int idcliente)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;
            return Obj.Eliminar(Obj);
        }
        //Metodo Mostrar que llama al metodo Mostrar de la Clase DCliente
        // de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }
        //Metodo BuscarRazon_social que llama al metodo BuscarRazon_social de la Clase DCliente
        // de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
        //Metodo BuscarNum_documento que llama al metodo BuscarNum_Documento de la Clase DProveedor
        // de la CapaDatos
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }
    }
}
