using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NProveedor
    {
        //Metodo Insertar que llama al metodo Insertar de la Clase DProveedor
        // de la CapaDatos
        public static string Insertar(string razon_proveedor,string contacto, string tipo_documento,string num_documento,
            string direccion, string telefono, string correo)
        {
            DProveedor Obj = new DProveedor();
            Obj.Razon_Social = razon_proveedor;
            Obj.Contacto = contacto;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Correo = correo;

            return Obj.Insertar(Obj);
        }
        //Metodo Editar que llama al metodo Editar de la Clase Dcategoria
        // de la CapaDatos
        public static string Editar(int idproveedor,string razon_proveedor,string contacto, string tipo_documento, string num_documento,
            string direccion, string telefono, string correo)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            Obj.Razon_Social = razon_proveedor;
            Obj.Contacto = contacto;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Correo = correo;
            return Obj.Editar(Obj);
        }
        //Metodo Eliminar que llama al metodo Elimina de la Clase DProveedor
        // de la CapaDatos
        public static string Eliminar(int idproveedor)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            return Obj.Eliminar(Obj);
        }
        //Metodo Mostrar que llama al metodo Mostrar de la Clase DProveedor
        // de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }
        //Metodo BuscarRazon_social que llama al metodo BuscarRazon_social de la Clase DProveedor
        // de la CapaDatos
        public static DataTable BuscarRazon_Social(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarRazon_Social(Obj);
        }
        //Metodo BuscarNum_documento que llama al metodo BuscarNum_Documento de la Clase DProveedor
        // de la CapaDatos
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }

    }
}
