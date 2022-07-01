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
    public partial class FrmUsuario : Form
    {
        private Empleado empleado;
        public FrmUsuario(Empleado empleado)
        {
            this.InitializeComponent();
            this.empleado = empleado;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Menu Usuario. Usuario: ");
            sb.Append($"{this.empleado.NombreUsuario} ");
            sb.Append($"({this.empleado.NombreCompleto})");

            this.Text = sb.ToString();
        }

        private void FrmUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if((this.DialogResult == DialogResult.OK && MessageBox.Show("¿Seguro desea cerrar sesion?", "Aviso: Cerrar sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) ||
                this.DialogResult == DialogResult.Cancel && MessageBox.Show("¿Seguro desea salir del sistema?", "Aviso: Salir sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnAtenderClienteAsociado_Click(object sender, EventArgs e)
        {
            if (Cliente.Count > 0)
            {
                if (Producto.Count > 0)
                {
                    FrmListaClientes clientes = new FrmListaClientes(this.empleado);

                    this.Hide();

                    if (clientes.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            CarritoDeCompra carrito = new CarritoDeCompra(clientes.Cliente.Dni);

                            FrmComprar compra = new FrmComprar(this.empleado, clientes.Cliente, carrito);
                            compra.ShowDialog();
                        }
                        catch (CargaDeDatosInvalidosException)
                        {
                            MessageBox.Show("El Dni del cliente seleccionado es invalido, no se puede proceder a la compra.", "Aviso: Datos invalidos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.Show();
                }
                else
                {
                    MessageBox.Show("No hay productos cargados en el sistema para vender.", "Aviso: Sin productos cargados.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No hay clientes cargados en el sistema.", "Aviso: Sin clientes cargados.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAtenderClienteTemporal_Click(object sender, EventArgs e)
        {
            if(Producto.Count > 0)
            {
                try
                {
                    CarritoDeCompra carrito = new CarritoDeCompra(Cliente.ClienteTemporal.Dni);

                    FrmComprar compra = new FrmComprar(this.empleado, Cliente.ClienteTemporal, carrito);
                    compra.ShowDialog();
                }
                catch (CargaDeDatosInvalidosException)
                {
                    MessageBox.Show("En este momento no se puede procesar la compra de un cliente temporal. Reintente mas tarde.", "Aviso: No se puede procesar la compra.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay productos cargados en el sistema para vender.", "Aviso: Sin productos cargados.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            FrmCambiarPassword cambiarPassword = new FrmCambiarPassword(this.empleado);

            if (cambiarPassword.ShowDialog() == DialogResult.Retry)
            {
                this.DialogResult = DialogResult.Retry;
            }
        }
    }
}
