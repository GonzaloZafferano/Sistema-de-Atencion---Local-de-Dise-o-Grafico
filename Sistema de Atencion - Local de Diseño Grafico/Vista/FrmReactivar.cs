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
    public partial class FrmReactivar : Form
    {
        Jefe jefe;
        bool esEmpleado;

        public FrmReactivar(Jefe jefe, bool esEmpleado)
        {
            InitializeComponent();
            this.jefe = jefe;
            this.esEmpleado = esEmpleado;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmReactivar_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
 
            sb.Append($"Menu de reactivacion de {(this.esEmpleado? "Empleados" : "Clientes")}. ");
            sb.Append($"Jefe:  ");
            sb.Append($"{this.jefe.NombreUsuario} ");
            sb.Append($"({this.jefe.NombreCompleto})");

            this.Text = sb.ToString();

            this.btnReactivarEmpleado.Visible = this.esEmpleado;
            this.btnReactivarCliente.Visible = !this.esEmpleado;

            this.lblIngreseDni.Text = this.esEmpleado ? "Ingrese dni del empleado: " : "Ingrese dni del cliente: ";
        }

        private void btnReactivarCliente_Click(object sender, EventArgs e)
        {    
            if(int.TryParse(txtDni.Text, out int dni))
            {
                try
                {
                    if(!Cliente.ExisteClienteEnSistemaPorDni(dni))
                    {
                        if (this.jefe.ReactivarCliente(dni))
                        {   
                            MessageBox.Show($"Se ha reactivado exitosamente el cliente con dni: {dni}", "Aviso: Reactivacion exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El cliente que se intenta reactivar, ya esta activo.", "Aviso: Cliente ya esta activo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch(CargaDeDatosInvalidosException ex)
                {
                    MessageBox.Show(ex.Message, "Aviso: Dni invalido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show($"No se ha encontrado un cliente con el dni: {dni}", "Aviso: Dni no encontrado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingrese unicamente números.", "Aviso: Dni invalido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReactivarEmpleado_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtDni.Text, out int dni))
            {
                try
                {
                    if(!Administrador.ExistePersonaPorDni(dni))
                    {
                        if (this.jefe.ReactivarEmpleado(dni))
                        {
                            MessageBox.Show($"Se ha reactivado exitosamente el empleado con dni: {dni}", "Aviso: Reactivacion exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El empleado que se intenta reactivar, ya esta activo.", "Aviso: Empleado ya esta activo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (CargaDeDatosInvalidosException ex)
                {
                    MessageBox.Show(ex.Message, "Aviso: Dni invalido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show($"No se ha encontrado un empleado con el dni: {dni}", "Aviso: Dni no encontrado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingrese unicamente números.", "Aviso: Dni invalido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
