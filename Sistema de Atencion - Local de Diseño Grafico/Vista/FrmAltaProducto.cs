using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Vista
{
    public partial class FrmAltaProducto : Form
    {
        private Administrador administrador;
        public FrmAltaProducto(Administrador administrador)
        {
            this.InitializeComponent();
            this.administrador = administrador;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.txtNombre.Text) || string.IsNullOrWhiteSpace(this.rTxtBoxDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(this.txtPrecio.Text))
                {
                    throw new NullReferenceException();
                }

                if (double.TryParse(this.txtPrecio.Text, out double precioDouble))
                {
                    Producto producto;

                    if (this.rBtnDisenio.Checked)
                    {
                        producto = new Disenio(this.txtNombre.Text, this.rTxtBoxDescripcion.Text, precioDouble, Disenio.Tamanio.Chico);
                    }
                    else
                    {
                        producto = new Impresion(this.txtNombre.Text, this.rTxtBoxDescripcion.Text, precioDouble, false);
                    }

                    producto = this.administrador.CargarUnProductoAlSistema(producto);
                    
                    MessageBox.Show($"Se ha cargado el producto exitosamente! {Environment.NewLine}{producto}", "Aviso: Alta exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;                    
                }
                else
                {
                    MessageBox.Show("El campo Precio no ha sido cargado correctamente. Por favor, respete el formato.", "Aviso: Carga de datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (CargaDeDatosInvalidosException ex)
            {
                MessageBox.Show(ex.Message, "Aviso: Carga de datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Debe completar todos los campos para continuar.", "Aviso: Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception)
            {
                MessageBox.Show("En este momento no se pueden guardar cambios en el sistema. Por favor reintente mas tarde.", "Aviso: No se pueden guardar los cambios.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAltaProducto_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Menu Alta Producto. Administrador: ");
            sb.Append($"{this.administrador.NombreUsuario} ");

            this.Text = sb.ToString();

            this.rBtnDisenio.Checked = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
