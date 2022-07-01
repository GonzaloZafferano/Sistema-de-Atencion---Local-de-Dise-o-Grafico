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
    public partial class FrmModificarProducto : Form
    {
        private Administrador administrador;
        private Producto producto;
        public FrmModificarProducto(Administrador administrador, Producto producto)
        {
            this.InitializeComponent();
            this.producto = producto;
            this.administrador = administrador;
        }

        private void FrmModificarProducto_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Menu Modificacion Producto. Administrador: ");
            sb.Append($"{this.administrador.NombreUsuario} ");

            this.Text = sb.ToString();

            this.lblNombre.Text = this.producto.NombreProducto;
            this.rTxtBoxDescripcion.Text = this.producto.DescripcionProducto;
            this.txtPrecio.Text = this.producto.PrecioProducto.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string descripcion = this.rTxtBoxDescripcion.Text;
            string precio = this.txtPrecio.Text;

            if(descripcion != this.producto.DescripcionProducto || precio != this.producto.PrecioProducto.ToString())
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(descripcion) || string.IsNullOrWhiteSpace(precio))
                    {
                        throw new NullReferenceException();
                    }

                    if (double.TryParse(precio, out double precioDouble))
                    {
                        this.producto.PrecioProducto = precioDouble;
                        this.producto.DescripcionProducto = descripcion;

                        this.administrador.CargarUnProductoModificadoAlSistema(this.producto);
                        
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
                    MessageBox.Show("Debe completar todos los campos para continuar", "Aviso: Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                catch (Exception)
                {
                    MessageBox.Show("En este momento no se pueden guardar cambios en el sistema. Por favor reintente mas tarde.", "Aviso: No se pueden guardar los cambios.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Un momento! No ha realizado modificaciones.", "Aviso: No se modificaron datos.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
