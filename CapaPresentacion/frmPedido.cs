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
    public partial class frmPedido : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;

       

        
        
        public frmPedido()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del articulo a pedir");
            this.btnImprimir.Visible = false;
            
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
            this.txtIdpedido.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
        }
        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdpedido.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtProveedor.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
        }
        //Habilitar los Botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }
        //Metodo para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }
        //Metodo Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NPedido.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros:" + Convert.ToString(dataListado.Rows.Count);
        }
        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NPedido.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros:" + Convert.ToString(dataListado.Rows.Count);
        }




        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmPedido_Load(object sender, EventArgs e)
        {

            this.Top = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos,serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NPedido.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                            this.txtCantidad.Text,
                            this.txtProveedor.Text.Trim(),
                            this.txtTelefono.Text);
                    }
                    else
                    {
                        rpta = NPedido.Editar(Convert.ToInt32(this.txtIdpedido.Text),
                            this.txtNombre.Text.Trim().ToUpper(),
                            this.txtCantidad.Text,
                            this.txtProveedor.Text.Trim(),
                            this.txtTelefono.Text);
                    }
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se Inserto de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOK("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdpedido.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe seleccionar primero el registro a Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NPedido.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se Eliminó Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Mostrar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);

            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdpedido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idpedido"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtCantidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cantidad"].Value);
            this.txtProveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["proveedor"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
       
        }

        private void txtIdproveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmPedido_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }
    }
}
