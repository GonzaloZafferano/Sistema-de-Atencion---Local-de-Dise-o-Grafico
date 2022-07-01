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
    public partial class FrmAltaUsuario : Form
    {
        private Administrador administrador;
        public FrmAltaUsuario(Administrador administrador)
        {
            this.InitializeComponent();
            this.administrador = administrador;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {  
            try
            {
                if (string.IsNullOrWhiteSpace(this.txtNombre.Text) || string.IsNullOrWhiteSpace(this.txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(this.txtNombreUsuario.Text) || string.IsNullOrWhiteSpace(this.txtSalario.Text) ||
                    string.IsNullOrWhiteSpace(this.txtDni.Text))
                {
                    throw new NullReferenceException();
                }

                if (int.TryParse(this.txtDni.Text, out int dniEntero) && double.TryParse(this.txtSalario.Text, out double salarioDouble))
                {
                    Empleado nuevoEmpleado;

                    if (this.cBoxEsAdmin.Checked)
                    {
                        nuevoEmpleado = new Administrador(this.txtNombre.Text, this.txtApellido.Text, dniEntero, salarioDouble, this.txtNombreUsuario.Text);
                    }
                    else
                    {
                        nuevoEmpleado = new Empleado(this.txtNombre.Text, this.txtApellido.Text, dniEntero, salarioDouble, this.txtNombreUsuario.Text);
                    }

                    nuevoEmpleado = this.administrador.CargarUnEmpleadoAlSistema(nuevoEmpleado);

                    MessageBox.Show($"Se ha cargado el empleado exitosamente! {Environment.NewLine}{nuevoEmpleado}", "Aviso: Alta exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("El campo Dni/Salario no ha sido cargado correctamente. Por favor, respete el formato.", "Aviso: Carga de datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (CargaDeDatosInvalidosException ex)
            {
                MessageBox.Show(ex.Message, "Aviso: Carga de datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Se deben completar todos los campos para continuar.", "Aviso: Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception)
            {
                MessageBox.Show("En este momento no se pueden guardar cambios en el sistema. Por favor reintente mas tarde.", "Aviso: No se pueden guardar los cambios.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAltaUsuario_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Menu Alta Usuario. Administrador: ");
            sb.Append($"{this.administrador.NombreUsuario} ");
            sb.Append($"({this.administrador.NombreCompleto})");

            this.Text = sb.ToString();

            this.cBoxEsAdmin.Visible = this.administrador is Jefe;
        }
    }
}
