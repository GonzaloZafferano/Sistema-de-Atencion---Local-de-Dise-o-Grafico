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
    public partial class FrmAltaCliente : Form
    {
        private Administrador administrador;
        public FrmAltaCliente(Administrador administrador)
        {
            this.InitializeComponent();
            this.administrador = administrador;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {          
            try
            {
                if (string.IsNullOrWhiteSpace(this.txtNombre.Text) || string.IsNullOrWhiteSpace(this.txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(this.txtDni.Text) || string.IsNullOrWhiteSpace(this.txtTelefono.Text))
                {
                    throw new NullReferenceException();
                }

                if (int.TryParse(this.txtDni.Text, out int dniNumerico))
                {
                    Cliente cliente = new Cliente(this.txtNombre.Text, this.txtApellido.Text, dniNumerico, this.txtTelefono.Text);

                    if (this.administrador.CargarUnClienteAlSistema(cliente))
                    {
                        MessageBox.Show($"Se ha cargado el cliente de forma exitosa! {Environment.NewLine}{cliente}", "Aviso: Alta Exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo cargar el cliente en el sistema.", "Aviso: Error de Carga.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El campo Dni no ha sido cargado correctamente. Por favor, respete el formato.", "Aviso: Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch(CargaDeDatosInvalidosException ex)
            {
                MessageBox.Show(ex.Message, "Aviso: Carga de datos invalida", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Se deben completar todos los campos para continuar.", "Aviso: Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception)
            {
                MessageBox.Show("En este momento no se pueden guardar cambios en el sistema. Por favor reintente mas tarde.", "Aviso: No se pueden guardar los cambios.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();                
        }

        private void FrmAltaCliente_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Menu Alta Cliente. Administrador: ");
            sb.Append($"{this.administrador.NombreUsuario} ");

            this.Text = sb.ToString();
        }
    }
}
