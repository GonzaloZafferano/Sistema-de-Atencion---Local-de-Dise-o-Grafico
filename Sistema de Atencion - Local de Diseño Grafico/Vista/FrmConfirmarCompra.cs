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
    public partial class FrmConfirmarCompra : Form
    {
        private Empleado empleado;
        private Cliente cliente;
        private CarritoDeCompra carrito;
        CancellationTokenSource tokenDeCancelacion;
        CancellationToken token;

        public FrmConfirmarCompra(Empleado empleado, Cliente cliente, CarritoDeCompra carrito)
        {
            this.InitializeComponent();
            this.empleado = empleado;
            this.cliente = cliente;
            this.carrito = carrito;
        }

        /// <summary>
        /// Resalta el 'lblTotal', haciendo que cambie de color cada cierto tiempo (en milisegundos)
        /// </summary>
        private void ResaltarLblTotal()
        {
            this.tokenDeCancelacion = new CancellationTokenSource();
            this.token = tokenDeCancelacion.Token;

            Task.Run(() =>
            {
                while(!token.IsCancellationRequested)
                {
                    this.AlternarColorDelLblTotal();
                    Thread.Sleep(350);
                }
            });
        }

        /// <summary>
        /// Alterna el color de las letras del 'lblTotal', entre rojo y negro.
        /// </summary>
        private void AlternarColorDelLblTotal()
        {
            if(this.lblTotal.InvokeRequired)
            {
                this.lblTotal.Invoke(new Action(this.AlternarColorDelLblTotal));
            }
            else
            {
                this.lblTotal.ForeColor = this.lblTotal.ForeColor == Color.Red ? Color.Black : Color.Red;
            }
        }

        /// <summary>
        /// Carga el form con datos de la compra.
        /// IMPLEMENTA TASK Y LAMBDA.
        /// </summary>
        /// <param name="sender">objeto que disparo el evento</param>
        /// <param name="e">datos del evento</param>
        private void ConfirmarCompra_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Menu Confirmar Compra. ");
            sb.Append($"{this.empleado.GetType().Name}: ");
            sb.Append($"{this.empleado.NombreUsuario} ");
            sb.Append($"({this.empleado.NombreCompleto})");

            this.Text = sb.ToString();

            this.rTxtCarrito.Text = this.carrito.ToString();

            sb.Clear();

            Task taskVerificarSiElClienteEsRecurrente = Task.Run(() =>
            {
                if (this.cliente.EsClienteRecurrente)
                {
                    sb.AppendLine("Hay un descuento del 5% por ser cliente recurrente!");
                }
            });

            Task taskVerificarSiEsClienteVIP = Task.Run(() =>
            {
                if (this.cliente.EsClienteVIP)
                {
                    sb.AppendLine("Hay un descuento del 5% por ser cliente VIP!");
                }
            });

            Task.WaitAll(taskVerificarSiElClienteEsRecurrente, taskVerificarSiEsClienteVIP);
            
            sb.AppendLine($"Precio total: ${string.Format("{0:0,0.00}", this.carrito.PrecioFinalAcumuladoEnCarritoConDescuentoIncluido)}");

            this.lblTotal.Text = sb.ToString();
            this.lblNombreCliente.Text = $"Cliente: {this.cliente.NombreCompleto}";

            this.ResaltarLblTotal();

            this.cBoxMedioDePago.DataSource = Enum.GetValues(typeof(Compra.MedioDePago));
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(this.cBoxMedioDePago.SelectedItem != null && Enum.TryParse(this.cBoxMedioDePago.Text, out Compra.MedioDePago medioDePago))
            {
                try
                {
                    Compra compra = new Compra(this.carrito.DniCliente,this.carrito.Descuento, this.carrito.PrecioFinalAcumuladoEnCarritoConDescuentoIncluido, this.empleado.Id, medioDePago, DateTime.Now, carrito.ToString());

                    compra = Compra.CargarUnaCompraAlSistema(compra);
                    
                    compra.GenerarTicketDeCompra();

                    MessageBox.Show(compra.DetallesCompra, "Aviso: Compra exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;        
                }
                catch(CargaDeDatosInvalidosException ex)
                {
                    MessageBox.Show(ex.Message, "Aviso: Carga de datos invalidos.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(NullReferenceException)
                {
                    MessageBox.Show("No se ha podido procesar la compra", "Aviso: Error al procesar compra.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ArchivoException ex)
                {
                    MessageBox.Show($"Ocurrio un error relacionado con los archivos de respaldo: {ex.Message}. No se guardaran los cambios realizados al cerrar sesion.", "Aviso: Error con los archivos de respaldo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("En este momento no se pueden guardar cambios en el sistema. Por favor reintente mas tarde.", "Aviso: No se pueden guardar los cambios.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmConfirmarCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.tokenDeCancelacion is not null)
            {
                this.tokenDeCancelacion.Cancel();
            }
        }
    }
}
