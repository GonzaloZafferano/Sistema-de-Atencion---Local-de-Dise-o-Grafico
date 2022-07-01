using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Entidades;

namespace Vista
{
    public partial class FrmPantallaInicial : Form
    {
        CancellationTokenSource tokenDeCancelacion;
        CancellationToken token;
        Task taskCargarDatos;        
        bool cargaExitosa;     

        public FrmPantallaInicial()
        {
            InitializeComponent();

            this.tokenDeCancelacion = new CancellationTokenSource();
            this.token = tokenDeCancelacion.Token;
            this.cargaExitosa = false;
        }

        /// <summary>
        /// True si hay una tarea asignada, caso contrario False.
        /// </summary>
        private bool HayTareaAsignada
        {
            get
            {
                return this.taskCargarDatos != null;
            }
        }

        /// <summary>
        /// Inicia el temporizador que verificara continuamente si se ha cargado toda la informacion al sistema.
        /// </summary>
        private void PrepararTemporizadorDeDescarga()
        {            
            this.tmrEvaluarDescarga.Tick += this.VerificarAvanceDeProgressBar;
            this.tmrEvaluarDescarga.Interval = 750;
        }

        /// <summary>
        /// Verifica el avance de la progressBar
        /// </summary>
        /// <param name="sender">Objeto que activa el evento</param>
        /// <param name="e">Informacion del evento</param>
        private void VerificarAvanceDeProgressBar(object sender, EventArgs e)
        {
            if (this.pBarDescargaDatos.Value == 100 && this.cargaExitosa)
            {
                this.LimpiarEventosYTrabajosParalelos();

                this.Hide();   

                FrmLogin login = new FrmLogin();
                login.ShowDialog();

                this.Close();
            }
        }

        /// <summary>
        /// Libera los recursos utilizados
        /// </summary>
        private void LimpiarEventosYTrabajosParalelos()
        {
            Administrador.OnCargaCompleta -= this.CargarProgresoDeDescargaEnProgressBar;
            Producto.OnCargaCompleta -= this.CargarProgresoDeDescargaEnProgressBar;
            Compra.OnCargaCompleta -= this.CargarProgresoDeDescargaEnProgressBar;
            Cliente.OnCargaCompleta -= this.CargarProgresoDeDescargaEnProgressBar;

            Administrador.OnLecturaDeFuenteDeDatos -= LecturaDeDatos;
            Cliente.OnLecturaDeFuenteDeDatos -= LecturaDeDatos;
            Producto.OnLecturaDeFuenteDeDatos -= LecturaDeDatos;
            Compra.OnLecturaDeFuenteDeDatos -= LecturaDeDatos;

            this.tmrEvaluarDescarga.Tick -= this.VerificarAvanceDeProgressBar;

            this.tmrEvaluarDescarga.Stop();
            this.tmrEvaluarDescarga.Dispose();
            
            this.tokenDeCancelacion.Cancel();
        }

        /// <summary>
        /// Resalta el label de importar, intercambiando el color entre rojo y negro.
        /// </summary>
        private void ResaltarLabelImportar()
        {
            if (this.lblImportar.InvokeRequired)
            {
                this.lblImportar.Invoke(new Action(ResaltarLabelImportar));
            }
            else
            {
                this.lblImportar.ForeColor = this.lblImportar.ForeColor == Color.Black ? Color.Red : Color.Black;
            }
        }

        /// <summary>
        /// Carga el porcentaje de progreso recibido por parametro a la Progress Bar.
        /// </summary>
        /// <param name="progresoDeDescarga">Porcentaje de progreso de una tarea.</param>
        private void CargarProgresoDeDescargaEnProgressBar(int progresoDeDescarga)
        {
            if (this.pBarDescargaDatos.InvokeRequired)
            {
                this.pBarDescargaDatos.Invoke(new Action<int>(this.CargarProgresoDeDescargaEnProgressBar), progresoDeDescarga);
            }
            else
            {
                if ((this.pBarDescargaDatos.Value + progresoDeDescarga) <= 100)
                {
                    this.pBarDescargaDatos.Value += progresoDeDescarga;
                }
            }
        }

        /// <summary>
        /// Resetea la progressBar.
        /// </summary>
        private void ResetearProgresoDeDescargaEnProgressBar()
        {
            if (this.pBarDescargaDatos.InvokeRequired)
            {
                this.pBarDescargaDatos.Invoke(new Action(this.ResetearProgresoDeDescargaEnProgressBar));
            }
            else
            {
                this.pBarDescargaDatos.Value = 0;
                this.pBarDescargaDatos.Visible = false;
                this.cargaExitosa = false;
                this.lblLecturaDeDatos.Visible = false;
            }
        }

        /// <summary>
        /// Muestra en el 'lblLecturaDeDatos' los datos que se estan leyendo.
        /// </summary>
        /// <param name="mensaje">Mensaje que se mostrara.</param>
        private void LecturaDeDatos(string mensaje)
        {
            if (this.lblLecturaDeDatos.InvokeRequired)
            {
                this.lblLecturaDeDatos.Invoke(new Action<string>(LecturaDeDatos), mensaje);
            }
            else
            {
                this.lblLecturaDeDatos.Text = mensaje;
            }
        }

        private void FrmPantallaInicial_Load(object sender, EventArgs e)
        {
            Administrador.OnCargaCompleta += this.CargarProgresoDeDescargaEnProgressBar;
            Producto.OnCargaCompleta += this.CargarProgresoDeDescargaEnProgressBar; 
            Compra.OnCargaCompleta += this.CargarProgresoDeDescargaEnProgressBar;
            Cliente.OnCargaCompleta += this.CargarProgresoDeDescargaEnProgressBar;

            Administrador.OnLecturaDeFuenteDeDatos += LecturaDeDatos;
            Compra.OnLecturaDeFuenteDeDatos += LecturaDeDatos;
            Cliente.OnLecturaDeFuenteDeDatos += LecturaDeDatos; 
            Producto.OnLecturaDeFuenteDeDatos += LecturaDeDatos;

            this.PrepararTemporizadorDeDescarga();
            
            Task.Run(() =>
            {
                while (!this.token.IsCancellationRequested)
                {
                    this.ResaltarLabelImportar();
                    Thread.Sleep(350);
                }
            });            
        }

        private void btnSalirApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPantallaInicial_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.LimpiarEventosYTrabajosParalelos();
        }

        private void btnImportarDesdeArchivos_Click(object sender, EventArgs e)
        {
            if(!this.HayTareaAsignada)
            {
                this.lblLecturaDeDatos.Visible = true;
                this.pBarDescargaDatos.Visible = true;
                this.tmrEvaluarDescarga.Start();

                this.taskCargarDatos = new Task(() =>
                {
                    try
                    {
                        Administrador.LeerArchivoEmpleados();
                        Cliente.LeerArchivoClientes();
                        Compra.LeerArchivoCompras();
                        Producto.LeerArchivoProductos();

                        this.cargaExitosa = true;               
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al intentar descargar informacion desde archivos. Si el problema continua, intente descargar desde Base de Datos.", "Aviso: Error en la descarga de informacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        this.ResetearProgresoDeDescargaEnProgressBar();
                        this.tmrEvaluarDescarga.Stop();
                        this.taskCargarDatos = null;
                    }
                });

                this.taskCargarDatos.Start();
            }
        }

        private void btnImportarDesdeBBDD_Click(object sender, EventArgs e)
        {
            if(!this.HayTareaAsignada)
            {
                this.lblLecturaDeDatos.Visible = true;
                this.pBarDescargaDatos.Visible = true;
                this.tmrEvaluarDescarga.Start();

                this.taskCargarDatos = new Task(() =>
                {
                    try
                    {
                        Administrador.CargarEmpleadosAlSistemaDesdeBBDD();
                        Producto.CargarProductosAlSistemaDesdeBBDD();
                        Compra.CargarComprasAlSistemaDesdeBBDD();
                        Cliente.CargarClientesAlSistemaDesdeBBDD();

                        this.cargaExitosa = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al intentar descargar informacion desde Base de Datos. Si el problema continua, intente descargar desde Archivos.", "Aviso: Error en la descarga de informacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        this.ResetearProgresoDeDescargaEnProgressBar();
                        this.tmrEvaluarDescarga.Stop();

                        this.taskCargarDatos = null;
                    }
                });
                
                this.taskCargarDatos.Start();
            }
        }      
    }
}
