using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NIngreso
    {
//MEtodo INsertar
        public static string Insertar(int idtrabajador, int idproveedor,DateTime fecha,
            string tipo_comprobante,string correlativo,decimal igv,
            string estado ,DataTable dtDetalles)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idtrabajador = idtrabajador;
            Obj.Idproveedor = idproveedor;
            Obj.Fecha = fecha;
            Obj.Tipo_Comprobante = tipo_comprobante;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            Obj.Estado = estado;
            List<DDetalle_Ingresos> detalles = new List<DDetalle_Ingresos>();
            foreach(DataRow row in dtDetalles.Rows)
            {
                DDetalle_Ingresos detalle = new DDetalle_Ingresos();
                detalle.Idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                detalle.Precio_Compra = Convert.ToDecimal(row["precio_compra"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Stock_Inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["stock_inicial"].ToString());
                //detalle.Fecha_Ingreso = Convert.ToDateTime(row["fecha_ingreso"].ToString());
                //detalle.Fecha_Vencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString());
                detalles.Add(detalle);
            }


            return Obj.Insertar(Obj,detalles);
        }
        //Metodo Eliminar
        public static string Anular(int idingreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idingreso = idingreso;
            return Obj.Anular(Obj);
        }
        //Metodo Mostrar que llama al metodo Mostrar de la Clase Dcategoria
        // de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }
        //Metodo BuscarNombre que llama al metodo BuscarNombre de la Clase Dcategoria
        // de la CapaDatos
        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            DIngreso Obj = new DIngreso();

            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }
        public static DataTable MostrarDetalle(string textobuscar)
        {
            DIngreso Obj = new DIngreso();

            return Obj.MostrarDetalle(textobuscar);
        }
    }
}
