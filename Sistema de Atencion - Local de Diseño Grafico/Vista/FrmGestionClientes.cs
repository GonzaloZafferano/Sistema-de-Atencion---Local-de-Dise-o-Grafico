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
    public partial class FrmGestionClientes : Form
    {
        private List<Cliente> clientes;
        private Administrador administrador;
        private Task taskCargarListaClientes;

        public FrmGestionClientes(Administrador administrador)
        {
            this.InitializeComponent();
            this.administrador = administrador;
            this.clientes = new List<Cliente>();
        }

        private void GestionClientes_Load(object sender, EventArgs e)
        {
            this.Hide();

            StringBuilder sb = new StringBuilder();
            
            Task taskArmarTituloFormulario = Task.Run(() =>
            {
                sb.Append("Menu Gestion de Clientes. Administrador: ");
                sb.Append($"{this.administrador.NombreUsuario} ");
                sb.Append($"({this.administrador.NombreCompleto})");
            });

            this.Width = 796;
            this.dgvListaClientes.Width = 750;

            this.RefrescarDataGrid();

            taskArmarTituloFormulario.Wait();
            this.Text = sb.ToString();

            this.Show();
        }
        
        /// <summary>
        /// Refresca el datagrid.
        /// </summary>
        private void RefrescarDataGrid()
        {
            this.dgvListaClientes.DataSource = null;

            this.taskCargarListaClientes = Task.Run(()=>this.CargarListaDeClientes());
            
            this.CargarDataGrid();
        }

        /// <summary>
        /// Carga la lista de la instancia con los Clientes del sistema
        /// </summary>
        private void CargarListaDeClientes()
        {
            this.clientes.Clear();

            for (int i = 0; i < Cliente.Count; i++)
            {
                this.clientes.Add(Cliente.ObtenerUnClienteDeLaListaPorIndice(i));
            }
        }

        /// <summary>
        /// Carga el datagrid
        /// </summary>
        private void CargarDataGrid()
        {
            this.CrearColumnasDataGrid();
            this.AsociarPropiedadesAlDataGrid();
            this.DarEstiloAColumnasDataGrid();

            if(this.taskCargarListaClientes is not null &&
               this.taskCargarListaClientes.Status == TaskStatus.Running)
            {
                this.taskCargarListaClientes.Wait();
            }

            this.dgvListaClientes.DataSource = this.clientes;
            this.OrdenarColumnasDataGrid();
        }
                
        /// <summary>
        /// Crea las columnas del datagrid
        /// </summary>
        private void CrearColumnasDataGrid()
        {
            this.dgvListaClientes.Columns.Add("dni", "Dni");
            this.dgvListaClientes.Columns.Add("nombreCompleto", "Nombre");
            this.dgvListaClientes.Columns.Add("telefono", "Telefono");
            this.dgvListaClientes.Columns.Add("inversionTotal", "Inversion Anual");
        }

        /// <summary>
        /// Asocia propiedades en las columnas del datagrid
        /// </summary>
        private void AsociarPropiedadesAlDataGrid()
        {
            this.dgvListaClientes.Columns["dni"].DataPropertyName = "Dni";
            this.dgvListaClientes.Columns["nombreCompleto"].DataPropertyName = "NombreCompleto";
            this.dgvListaClientes.Columns["telefono"].DataPropertyName = "Telefono";
            this.dgvListaClientes.Columns["inversionTotal"].DataPropertyName = "InversionTotalUltimoAnio";
        }

        /// <summary>
        /// Le da el estilo a las columnas
        /// </summary>
        private void DarEstiloAColumnasDataGrid()
        {
            this.dgvListaClientes.Columns["dni"].Width = 125;
            this.dgvListaClientes.Columns["telefono"].Width = 175;
            this.dgvListaClientes.Columns["nombreCompleto"].Width = 200;

            this.dgvListaClientes.Columns["inversionTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dgvListaClientes.Columns["inversionTotal"].DefaultCellStyle.Format = "$0,0.00";
        }

        /// <summary>
        /// Ordena las columnas del datagrid
        /// </summary>
        private void OrdenarColumnasDataGrid()
        {
            this.dgvListaClientes.Columns["dni"].DisplayIndex = 0;
            this.dgvListaClientes.Columns["nombreCompleto"].DisplayIndex = 1;
            this.dgvListaClientes.Columns["telefono"].DisplayIndex = 2;
            this.dgvListaClientes.Columns["inversionTotal"].DisplayIndex = 3;           
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            FrmAltaCliente formularioAltaCliente = new FrmAltaCliente(this.administrador);
            if(formularioAltaCliente.ShowDialog() == DialogResult.OK)
            {
                RefrescarDataGrid();
            }
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.dgvListaClientes.SelectedRows.Count > 0 && this.dgvListaClientes.SelectedRows[0] != null)
                {
                    Cliente cliente = this.dgvListaClientes.SelectedRows[0].DataBoundItem as Cliente;

                    if(cliente is not null)
                    {
                        FrmModificarCliente formularioModificarCliente = new FrmModificarCliente(this.administrador ,cliente);
                        if(formularioModificarCliente.ShowDialog() == DialogResult.OK)
                        {
                            this.RefrescarDataGrid();
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Debe seleccionar un cliente.", "Aviso: Debe seleccionar un cliente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBajaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.dgvListaClientes.SelectedRows.Count > 0 && this.dgvListaClientes.SelectedRows[0] != null)
                {
                    Cliente cliente = this.dgvListaClientes.SelectedRows[0].DataBoundItem as Cliente;

                    if(cliente is not null)
                    {
                        DialogResult respuesta = MessageBox.Show($"¿Seguro desea eliminar al cliente seleccionado? {Environment.NewLine}{cliente}", "Aviso", MessageBoxButtons.YesNo);

                        try
                        {
                            if(respuesta == DialogResult.Yes && this.administrador.EliminarUnClienteDelSistema(cliente))
                            {
                                this.RefrescarDataGrid();
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("En este momento no se pueden guardar cambios en el sistema. Por favor reintente mas tarde.", "Aviso: No se pueden guardar los cambios.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Debe seleccionar un cliente.", "Aviso: Debe seleccionar un cliente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
