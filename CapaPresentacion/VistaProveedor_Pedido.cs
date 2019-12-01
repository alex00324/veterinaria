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
    public partial class VistaProveedor_Pedido : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public VistaProveedor_Pedido()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtRazon_Social, "Ingrese Razon Social del Proveedor");
            this.ttMensaje.SetToolTip(this.txtContacto, "Ingrese el Contacto del Proveedor");
            this.ttMensaje.SetToolTip(this.txtNum_Documento, "Ingrese Numero de documento del Proveedor");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese Direccion del Proveedor");
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
            this.txtRazon_Social.Text = string.Empty;
            this.txtContacto.Text = string.Empty;
            this.txtNum_Documento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtCorreo.Text = string.Empty;
            this.txtIdproveedor.Text = string.Empty;
        }
        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtRazon_Social.ReadOnly = !valor;
            this.txtContacto.ReadOnly = !valor;
            this.cbTipo_Documento.Enabled = valor;
            this.txtNum_Documento.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtCorreo.ReadOnly = !valor;
            this.txtIdproveedor.ReadOnly = !valor;
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
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtRazon_Social.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtRazon_Social.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos,serán remarcados");
                    errorIcono.SetError(txtRazon_Social, "Ingrese un Valor");
                    errorIcono.SetError(txtNum_Documento, "Ingrese un Valor");

                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NProveedor.Insertar(this.txtRazon_Social.Text.Trim().ToUpper(),
                            this.txtContacto.Text,
                            this.cbTipo_Documento.Text, txtNum_Documento.Text, txtDireccion.Text,
                            txtTelefono.Text, txtCorreo.Text);
                    }
                    else
                    {
                        rpta = NProveedor.Editar(Convert.ToInt32(this.txtIdproveedor.Text),
                            this.txtRazon_Social.Text.Trim().ToUpper(),
                            this.txtContacto.Text,
                            this.cbTipo_Documento.Text, txtNum_Documento.Text, txtDireccion.Text,
                            txtTelefono.Text, txtCorreo.Text);
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
            if (!this.txtIdproveedor.Text.Equals(""))
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
            this.txtIdproveedor.Text = string.Empty;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Razon Social"))
            {
                this.BuscarRazon_Social();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
       
        }

        private void VistaProveedor_Pedido_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
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
            this.dataListado.DataSource = NProveedor.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros:" + Convert.ToString(dataListado.Rows.Count);
        }
        //Metodo BuscarRazon_Social
        private void BuscarRazon_Social()
        {
            this.dataListado.DataSource = NProveedor.BuscarRazon_Social(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros:" + Convert.ToString(dataListado.Rows.Count);
        }
        //Metodo BuscarNum_Documento
        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = NProveedor.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros:" + Convert.ToString(dataListado.Rows.Count);
        }
    }
}
