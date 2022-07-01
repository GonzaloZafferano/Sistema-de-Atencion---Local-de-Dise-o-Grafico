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
    public partial class FrmJefe : Form
    {
        private Jefe jefe;

        public FrmJefe(Jefe jefe)           
        {
            this.InitializeComponent();
            this.jefe = jefe;
        }

        private void FrmJefe_FormClosing(object sender, FormClosingEventArgs e)
        {            
            if ((this.DialogResult == DialogResult.OK && MessageBox.Show("¿Seguro desea cerrar sesion?", "Aviso: Cerrar sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) ||
                this.DialogResult == DialogResult.Cancel && MessageBox.Show("¿Seguro desea salir del sistema?", "Aviso: Salir sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }            
        }

        private void FrmJefe_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Menu Jefe. Jefe: ");
            sb.Append($"{this.jefe.NombreUsuario} ");
            sb.Append($"({this.jefe.NombreCompleto})");

            this.Text = sb.ToString();
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            FrmGestionUsuarios gestionUsuarios = new FrmGestionUsuarios(this.jefe);

            this.Hide();

            if(gestionUsuarios.ShowDialog() == DialogResult.Retry)
            {
                this.DialogResult = DialogResult.Retry;
            }

            this.Show();
        }

        private void btnGestionClientes_Click(object sender, EventArgs e)
        {
            FrmGestionClientes gestionClientes = new FrmGestionClientes(this.jefe);

            this.Hide();

            gestionClientes.ShowDialog();

            this.Show();
        }

        private void btnGestionProductos_Click(object sender, EventArgs e)
        {
            FrmGestionProductos gestionProductos = new FrmGestionProductos(this.jefe);

            this.Hide();

            gestionProductos.ShowDialog();

            this.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnAtenderClienteAsociado_Click(object sender, EventArgs e)
        {
            if(Cliente.Count > 0)
            {
                if(Producto.Count > 0)
                {
                    FrmListaClientes clientes = new FrmListaClientes(this.jefe);

                    this.Hide();

                    if(clientes.ShowDialog() == DialogResult.OK)
                    {           
                        try
                        {
                            CarritoDeCompra carrito = new CarritoDeCompra(clientes.Cliente.Dni);

                            FrmComprar compra= new FrmComprar(this.jefe, clientes.Cliente, carrito);
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
            if (Producto.Count > 0)
            {
                try
                {
                    CarritoDeCompra carrito = new CarritoDeCompra(Cliente.ClienteTemporal.Dni);

                    FrmComprar compra = new FrmComprar(this.jefe, Cliente.ClienteTemporal, carrito);
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

        private void btnTicketsDeCompra_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, string> tickets = Compra.LeerTicketsDeCompra();

                if (tickets.Count > 0)
                {
                    FrmTicketsDeCompra formularioTickets = new FrmTicketsDeCompra(this.jefe, tickets);
                    formularioTickets.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No hay tickets cargados en el sistema.", "Aviso: No hay tickets cargados.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (ArchivoException ex)
            {
                MessageBox.Show($"Ha ocurrido un error con los archivos de respaldo: {ex.Message}. No se pueden leer los tickets.", "Aviso: Error con los archivos de respaldo.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception)
            {
                MessageBox.Show("Error. No se pueden leer los tickets en este momento.", "Aviso: Error al intentar leer los tickets.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            FrmCambiarPassword cambiarPassword = new FrmCambiarPassword(this.jefe);

            if (cambiarPassword.ShowDialog() == DialogResult.Retry)
            {
                this.DialogResult = DialogResult.Retry;
            }
        }

        private void btnReactivarEmpleado_Click(object sender, EventArgs e)
        {
            FrmReactivar formularioDeReactivacion = new FrmReactivar(this.jefe, true);

            if (formularioDeReactivacion.ShowDialog() == DialogResult.OK)
            {
                this.jefe.RefrescarListaEmpleados();
            }
        }

        private void btnReactivarCliente_Click(object sender, EventArgs e)
        {
            FrmReactivar formularioDeReactivacion = new FrmReactivar(this.jefe, false);

            if(formularioDeReactivacion.ShowDialog() == DialogResult.OK)
            {
                this.jefe.RefrescarListaClientes();
            }
        }
    }
}
