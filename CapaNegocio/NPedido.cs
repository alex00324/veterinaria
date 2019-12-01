using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NPedido
    {
        //Metodo Insertar que llama al metodo Insertar de la Clase DPedido
        // de la CapaDatos
        public static string Insertar(string nombre, string cantidad,string proveedor,string telefono)
        {
            DPedidos Obj = new DPedidos();
            Obj.Nombre = nombre;
            Obj.Cantidad = cantidad;
            Obj.Proveedor = proveedor;
            Obj.Telefono = telefono;
            return Obj.Insertar(Obj);
        }
        //Metodo Editar que llama al metodo Editar de la Clase DPedidos
        // de la CapaDatos
        public static string Editar(int idpedido,string nombre, string cantidad,string proveedor,string telefono)
        {
            DPedidos Obj = new DPedidos();
            Obj.Idpedido = idpedido;
            Obj.Nombre = nombre;
            Obj.Cantidad = cantidad;
            Obj.Proveedor = proveedor;
            Obj.Telefono = telefono;
            return Obj.Editar(Obj);
        }
        //Metodo Eliminar que llama al metodo Elimina de la Clase DPedidos
        // de la CapaDatos
        public static string Eliminar(int idpedido)
        {
            DPedidos Obj = new DPedidos();
            Obj.Idpedido = idpedido;
            return Obj.Eliminar(Obj);
        }
        //Metodo Mostrar que llama al metodo Mostrar de la Clase DPedidos
        // de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DPedidos().Mostrar();
        }
        //Metodo BuscarNombre que llama al metodo BuscarNombre 
        // de la Clase DPedidos de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DPedidos Obj = new DPedidos();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }



    }
}
