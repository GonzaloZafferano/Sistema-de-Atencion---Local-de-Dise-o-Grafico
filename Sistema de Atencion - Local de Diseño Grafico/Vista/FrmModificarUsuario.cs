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
    public partial class FrmModificarUsuario : Form
    {
        private Administrador administrador;
        private Empleado empleado;
        public FrmModificarUsuario(Administrador administrador, Empleado empleadoAModificar)
        {
            this.InitializeComponent();
            this.administrador = administrador;
            this.empleado = empleadoAModificar;
        }

        private void FrmModificarUsuario_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Menu modificacion usuario. Administrador: ");
            sb.Append($"{this.administrador.NombreUsuario} ");

            this.Text = sb.ToString();
            this.lblNombreUsuario.Text = this.empleado.NombreUsuario;
            this.txtSalario.Text = this.empleado.Salario.ToString();

            this.cBoxEsAdmin.Visible = this.administrador is Jefe && this.empleado is not Jefe;
            this.cBoxEsAdmin.Checked = this.empleado.EsAdministrador;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.txtSalario.Text != this.empleado.Salario.ToString() || this.cBoxEsAdmin.Checked != this.empleado.EsAdministrador)
            {
                if (double.TryParse(this.txtSalario.Text, out double salario))
                {
                    try
                    {
                        this.empleado.Salario = salario;

                        if(this.cBoxEsAdmin.Checked != this.empleado.EsAdministrador)
                        {
                            this.empleado = Administrador.CambiarPuestoDeEmpleado(this.empleado);
                        }

                        this.administrador.CargarUnEmpleadoModificadoAlSistema(this.empleado);

                        this.DialogResult = DialogResult.OK;   
                    }
                    catch(CargaDeDatosInvalidosException ex)
                    {
                        MessageBox.Show(ex.Message, "Aviso: Carga de datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    catch(NullReferenceException)
                    {
                        MessageBox.Show("Error. No se pudo modificar el usuario.", "Aviso: No se pudo modificar el usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("En este momento no se pueden guardar cambios en el sistema. Por favor reintente mas tarde.", "Aviso: No se pueden guardar los cambios.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El campo Salario no ha sido cargado correctamente. Por favor, respete el formato.", "Aviso: Carga de datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
