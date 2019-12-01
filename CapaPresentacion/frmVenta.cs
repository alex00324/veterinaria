using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmVenta : Form
    {
        private bool IsNuevo=false;
        
        public int Idtrabajador;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;
        private decimal ValorEnCaja = 0;
        private int Registro = 0;
       
        private static frmVenta _instancia;
        public static frmVenta GetInstancia()
        {
            if(_instancia==null)
            {
                _instancia = new frmVenta();
            }
            return _instancia;
        }

        public void setCliente(string idcliente,string nombre)
        {
            this.txtIdcliente.Text = idcliente;
            this.txtCliente.Text = nombre;
        }
        public void setArticulo(string iddetalle_ingreso,string nombre,
            decimal precio_compra,decimal precio_venta, int stock)
         //   DateTime fecha_vencimiento)
        {
            this.txtIdarticulo.Text = iddetalle_ingreso;
            this.txtArticulo.Text = nombre;
            this.txtPrecioCompra.Text = Convert.ToString(precio_compra);
            this.txtPrecioVenta.Text = Convert.ToString(precio_venta);
            this.txtStock_Actual.Text = Convert.ToString(stock);
           // this.dtFecha_Vencimiento.Value = fecha_vencimiento;

        }



        public frmVenta()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtCliente, "Seleccione un Cliente");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Ingrese un numero del comprobante");
            this.ttMensaje.SetToolTip(this.txtCantidad, "Ingrese la Cantidad del Articulo");
            this.ttMensaje.SetToolTip(this.txtArticulo, "Seleccione un Articulo");
            this.txtIdcliente.Visible = false;
            this.btnImprimir.Visible = false;
            this.txtIdarticulo.Visible = false;
            this.txtPrecioCompra.Visible = false;
            
            this.label12.Visible = false;
            this.txtCliente.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;
            this.dtFecha_Vencimiento.Enabled = false;
            this.txtPrecioCompra.ReadOnly = true;
            this.txtStock_Actual.ReadOnly = true;
            this.dtFecha_Vencimiento.Visible = false;
            this.label15.Visible = false;
            
        }
        //Mostrar Mensaje de Confirmacion 
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //Mostrar Mensaje de Error

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtIdventa.Text = string.Empty;
            this.txtIdcliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtIgv.Text = string.Empty;
            this.lblTotal_Pagado.Text = "0,0";
            this.txtIgv.Text = "19";
            this.crearTabla();

        }
        private void limpiarDetalle()
        {
            this.txtIdarticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStock_Actual.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
            this.txtDescuento.Text = string.Empty;
            this.txtDescuento.Text = "0";
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdventa.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIgv.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cbTipo_Comprobante.Enabled = valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtPrecioCompra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.txtStock_Actual.ReadOnly = !valor;
            this.txtDescuento.ReadOnly = !valor;
            this.dtFecha_Vencimiento.Enabled = valor;

            this.btnBuscarArticulo.Enabled = valor;
            this.btnBuscarCliente.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;

        }
        //Habilitar los Botones
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }
        //Metodo para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[2].Visible = false;
        }
        //Metodo Mostrar
        private void Mostrar()
        {
       
            this.dataListado.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros:" + Convert.ToString(dataListado.Rows.Count);
            Registro = (dataListado.Rows.Count);
                   
        }
        private void Ventas()
        {
            if (Registro == 0)
            {
                this.lblValorEnCaja.Text = "0,00";
                
                
            }
            else
            {
                this.dataListado1.DataSource = NVenta.Mostrar_ventas();
                ValorEnCaja = Convert.ToDecimal(this.dataListado1.CurrentRow.Cells["Total_Ventas"].Value);
                this.lblValorEnCaja.Text = ValorEnCaja.ToString("C");
                
            }
            this.dataListado1.Visible = false;
        }
        //Metodo BuscarFechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NVenta.BuscarFechas(this.dtFecha1.Value.ToString("yyyy/MM/dd"),
                this.dtFecha2.Value.ToString("yyyy/MM/dd"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros:" + Convert.ToString(dataListado.Rows.Count);
        }

        private void MostrarDetalle()
        {
            this.dataListas_Detalle.DataSource = NVenta.MostrarDetalle(this.txtIdventa.Text);

        }
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("iddetalle_ingreso", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            //Relacionar nuestro DataGridView con nuestro DataTable
            this.dataListas_Detalle.DataSource = this.dtDetalle;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
           
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
            this.Ventas();
           


        }

        private void frmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmVistaCliente_Venta vista = new frmVistaCliente_Venta();
            vista.ShowDialog();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            frmVistaArticulo_Venta vista = new frmVistaArticulo_Venta();
            vista.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminiar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NVenta.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se Eliminó Correctamente la venta");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Mostrar();
                    this.Ventas();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }



        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(true);
            this.txtCorrelativo.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(false);
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
               
                if (this.txtIdcliente.Text == string.Empty
                    || this.txtCorrelativo.Text == string.Empty || this.txtIgv.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos,serán remarcados");
                    errorIcono.SetError(txtIdcliente, "Ingrese un Valor");
                    errorIcono.SetError(txtCorrelativo, "Ingrese un Valor");
                    errorIcono.SetError(txtIgv, "Ingrese un Valor");
                }
                else
                {

                    if (this.IsNuevo)
                    {
                       
                        rpta = NVenta.Insertar(Convert.ToInt32(this.txtIdcliente.Text),Idtrabajador,
                            dtFecha.Value, cbTipo_Comprobante.Text, txtCorrelativo.Text,
                            Convert.ToDecimal(txtIgv.Text), dtDetalle);
                        
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se Insertó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.limpiarDetalle();
                    this.Mostrar();
                    this.Ventas();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtIdarticulo.Text == string.Empty || this.txtCantidad.Text == string.Empty
                    || this.txtDescuento.Text == string.Empty || this.txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos,serán remarcados");
                    errorIcono.SetError(txtIdarticulo, "Ingrese un Valor");
                    errorIcono.SetError(txtCantidad, "Ingrese un Valor");
                    errorIcono.SetError(txtDescuento, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese un Valor");
                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["iddetalle_ingreso"]) == Convert.ToInt32(this.txtIdarticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("YA se encuentra el articulo en el detalle");
                        }
                    }
                    if (registrar && Convert.ToInt32(txtCantidad.Text)<=Convert.ToInt32(txtStock_Actual.Text))
                    {
                        decimal subTotal = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecioVenta.Text)-Convert.ToDecimal(this.txtDescuento.Text);
                        totalPagado = totalPagado + subTotal;
                        this.lblTotal_Pagado.Text = totalPagado.ToString("#0.00#");
                    
                        //Agregar ese detalle al datalistadoDetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["iddetalle_ingreso"] = Convert.ToInt32(this.txtIdarticulo.Text);
                        row["articulo"] = this.txtArticulo.Text;
                        row["cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["descuento"] = Convert.ToDecimal(this.txtDescuento.Text);
                        row["subtotal"] = subTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();

                    }
                    else
                    {
                        MensajeError("No hay Stock suficiente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdventa.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idventa"].Value);
            this.txtCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cliente"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha"].Value);
            this.cbTipo_Comprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_comprobante"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["correlativo"].Value);
            this.lblTotal_Pagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["total"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dataListas_Detalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];
                //disminuir el total pagado
                this.totalPagado = this.totalPagado - Convert.ToDecimal(row["subtotal"].ToString());
                this.lblTotal_Pagado.Text = totalPagado.ToString("#0.00");
               
                //Removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            frmReporteFactura frm = new frmReporteFactura();
            frm.Idventa = Convert.ToInt32(this.dataListado.CurrentRow.Cells["idventa"].Value);
            frm.ShowDialog();
        }

        private void lblValorEnCaja_Click(object sender, EventArgs e)
        {

        }

        private void dataListas_Detalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnventas_Click(object sender, EventArgs e)
        {
            
            
            
        
        }
    }
}
