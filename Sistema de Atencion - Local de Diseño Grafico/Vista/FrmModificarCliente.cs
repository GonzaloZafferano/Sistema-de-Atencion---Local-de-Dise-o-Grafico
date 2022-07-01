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
    public partial class FrmModificarCliente : Form
    {
        private Cliente cliente;
        private Administrador administrador;
        public FrmModificarCliente(Administrador administrador, Cliente cliente)
        {
            this.InitializeComponent();
            this.cliente = cliente;
            this.administrador = administrador;
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Menu Modificacion Cliente. Administrador: ");
            sb.Append($"{this.administrador.NombreUsuario} ");

            this.Text = sb.ToString();

            this.txtTelefono.Text = this.cliente.Telefono;
            this.lblNombreCompletoCliente.Text = $"{this.cliente.Apellido}, {this.cliente.Nombre}"; 
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(this.txtTelefono.Text != this.cliente.Telefono)
            {
                try
                {
                    this.cliente.Telefono = this.txtTelefono.Text;

                    this.administrador.CargarUnClienteModificadoAlSistema(this.cliente);
      
                    this.DialogResult = DialogResult.OK;

                }
                catch(CargaDeDatosInvalidosException ex)
                {
                    MessageBox.Show(ex.Message, "Aviso: Carga de datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                catch(NullReferenceException)
                {
                    MessageBox.Show("Debe completar el campo telefono para continuar.", "Aviso: Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                catch (Exception)
                {
                    MessageBox.Show("En este momento no se pueden guardar cambios en el sistema. Por favor reintente mas tarde.", "Aviso: No se pueden guardar los cambios.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Un momento! No ha realizado modificaciones.", "Aviso: No se modificaron datos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
