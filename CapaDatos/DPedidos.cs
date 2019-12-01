using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPedidos
    {
        private int _Idpedido;
        private string _Nombre;
        private string _Cantidad;
        private string _Proveedor;
        private string _Telefono;
        private string _TextoBuscar;

      

        public int Idpedido
        {
            get { return _Idpedido; }
            set { _Idpedido = value; }
        }
        
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
       
        public string Cantidad

        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        
        public string Proveedor
        {
            get { return _Proveedor; }
            set { _Proveedor = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //Constructores
        public DPedidos()
        {

        }
        public DPedidos(int idpedido,string nombre,string cantidad,string proveedor,string telefono)
        {
            this.Idpedido = idpedido;
            this.Nombre = nombre;
            this.Cantidad = cantidad;
            this.Proveedor = proveedor;
            this.Telefono = telefono;

        }
        //Insertar
        public string Insertar(DPedidos Pedido)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //codigo
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();
                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_pedidos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdpedido = new SqlParameter();
                ParIdpedido.ParameterName = "@idpedido";
                ParIdpedido.SqlDbType = SqlDbType.Int;
                ParIdpedido.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdpedido);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 1024;
                ParNombre.Value = Pedido.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.VarChar;
                ParCantidad.Size = 50;
                ParCantidad.Value = Pedido.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParProveedor = new SqlParameter();
                ParProveedor.ParameterName = "@proveedor";
                ParProveedor.SqlDbType = SqlDbType.VarChar;
                ParProveedor.Size = 1024;
                ParProveedor.Value = Pedido.Proveedor;
                SqlCmd.Parameters.Add(ParProveedor);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Pedido.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);


                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }
        //Metodo editar
        public string Editar(DPedidos Pedido)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //codigo
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();
                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_pedidos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdpedido = new SqlParameter();
                ParIdpedido.ParameterName = "@idpedido";
                ParIdpedido.SqlDbType = SqlDbType.Int;
                ParIdpedido.Value = Pedido.Idpedido;
                SqlCmd.Parameters.Add(ParIdpedido);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 1024;
                ParNombre.Value = Pedido.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.VarChar;
                ParCantidad.Size = 50;
                ParCantidad.Value = Pedido.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParProveedor = new SqlParameter();
                ParProveedor.ParameterName = "@proveedor";
                ParProveedor.SqlDbType = SqlDbType.VarChar;
                ParProveedor.Size = 1024;
                ParProveedor.Value = Pedido.Proveedor;
                SqlCmd.Parameters.Add(ParProveedor);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Pedido.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
        //Metodo eliminar
        public string Eliminar(DPedidos Pedido)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //codigo
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();
                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_pedido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdpedido = new SqlParameter();
                ParIdpedido.ParameterName = "@idpedido";
                ParIdpedido.SqlDbType = SqlDbType.Int;
                ParIdpedido.Value = Pedido.Idpedido;
                SqlCmd.Parameters.Add(ParIdpedido);


                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Elimino el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
        //Metodo mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("pedido");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_pedido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;

            }
            return DtResultado;
        }
        //Metodo Buscarnombre
        public DataTable BuscarNombre(DPedidos Pedido)
        {
            DataTable DtResultado = new DataTable("pedido");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_pedido_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Pedido.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;

            }
            return DtResultado;
        }
    }
}
