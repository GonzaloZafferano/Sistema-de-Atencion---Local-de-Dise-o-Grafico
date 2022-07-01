using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Vista
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            this.InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado empleado = Empleado.ObtenerUsuarioParaIngresarAlSistema(this.txtUsuario.Text, this.txtPassWord.Text);

                this.IniciarSesion(empleado);
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Datos incorrectos. Por favor, reintente nuevamente.", "Aviso: Datos incorrectos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Inicia la sesion con el empleado recibido por parametro.
        /// </summary>
        /// <param name="empleado">Empleado que iniciara sesion.</param>
        private void IniciarSesion(Empleado empleado)
        {
            DialogResult respuesta;

            if(empleado is not null)
            {
                this.Hide();

                if (empleado.Puesto == Empleado.Rol.Jefe && empleado is Jefe jefe)
                {
                    FrmJefe sesionJefe = new FrmJefe(jefe);
                    respuesta = sesionJefe.ShowDialog();
                }
                else if (empleado.Puesto == Empleado.Rol.Administrador && empleado is Administrador administrador)
                {
                    FrmAdministrador sesionAdmin = new FrmAdministrador(administrador);
                    respuesta = sesionAdmin.ShowDialog();
                }
                else
                {
                    FrmUsuario sesionUsuario = new FrmUsuario(empleado);
                    respuesta = sesionUsuario.ShowDialog();
                }

                if(respuesta != DialogResult.Cancel)
                {
                    this.txtUsuario.Clear();
                    this.txtPassWord.Clear();
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                if(Object.ReferenceEquals(sender,this.btnIngresarUsuario))
                {
                    this.IngresoAutomatico(Empleado.Rol.Empleado);
                }
                else if(Object.ReferenceEquals(sender, this.btnIngresarAdministrador))
                {
                    this.IngresoAutomatico(Empleado.Rol.Administrador);
                }
                else
                {
                    this.IngresoAutomatico(Empleado.Rol.Jefe);
                }
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show(ex.Message, "Aviso: Empleado no encontrado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Obtiene el primer empleado que cumpla con el tipo de empleado solicitado, para el ingreso automatico al sistema
        /// </summary>
        /// <param name="puesto">Tipo de empleado que iniciara sesion.</param>
        private void IngresoAutomatico(Empleado.Rol puesto)
        {
            Empleado empleado = Administrador.ObtenerElPrimerEmpleadoQueCoincidaConElPuesto(puesto);          

            if(empleado is not null)
            {
                this.IniciarSesion(empleado);
            }
            else
            {
                throw new NullReferenceException($"No hay empleados del tipo '{puesto}' cargados en el sistema");
            }
        }
    }
}
