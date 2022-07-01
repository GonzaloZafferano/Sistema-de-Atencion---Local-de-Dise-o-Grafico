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
    public partial class FrmCambiarPassword : Form
    {
        private Empleado empleado;
        public FrmCambiarPassword(Empleado empleado)
        {
            InitializeComponent();
            this.empleado = empleado;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (this.txtPassNueva.Text == this.txtPassConfirmada.Text)
            {
                if (this.empleado.ChequearPassword(this.txtPassActual.Text))
                {
                    try
                    {
                        this.empleado.Password = this.txtPassNueva.Text;

                        this.empleado.ActualizarPasswordEnFuentesDeInformacion();

                        MessageBox.Show("Contraseña modificada exitosamente. Se cerrara la sesion.", "Aviso: Modificacion exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.DialogResult = DialogResult.Retry;
                    }
                    catch (CargaDeDatosInvalidosException ex)
                    {
                        MessageBox.Show(ex.Message, "Aviso: Carga de datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Debe completar todos los campos para continuar", "Aviso: Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Ha ocurrido un error al intentar guardar los datos. Si el problema persiste, reintente mas tarde.", "Aviso: Error al guardar.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    MessageBox.Show("La 'contraseña actual' es invalida", "Aviso: Contraseña invalida", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("La 'contraseña nueva' debe coincidir con la 'contraseña de confirmacion'.", "Aviso: Contraseñas no coinciden", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCambiarPassword_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Menu Cambio de contraseña. {this.empleado.GetType().Name}: ");
            sb.Append($"{this.empleado.NombreUsuario} ");
            sb.Append($"({this.empleado.NombreCompleto})");

            this.Text = sb.ToString();

            this.lblNombreUsuario.Text = this.empleado.NombreUsuario;
        }
    }
}
