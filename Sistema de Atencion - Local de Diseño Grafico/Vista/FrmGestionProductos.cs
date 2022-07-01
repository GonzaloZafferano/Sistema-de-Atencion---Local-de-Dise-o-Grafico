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
    public partial class FrmGestionProductos : Form
    {
        private Administrador administrador;
        private List<Producto> productos;
        private Task taskCargarListaProductos;

        public FrmGestionProductos(Administrador administrador)
        {
            this.InitializeComponent();
            this.administrador = administrador;
            this.productos = new List<Producto>();
        }

        private void GestionProductos_Load(object sender, EventArgs e)
        {
            this.Hide();

            StringBuilder sb = new StringBuilder();

            Task taskArmarTituloFormulario = Task.Run(() =>
            {
                sb.Append("Menu Gestion de Producto. Administrador: ");
                sb.Append($"{this.administrador.NombreUsuario} ");
                sb.Append($"({this.administrador.NombreCompleto})");
            });

            this.Width = 1117;
            this.dgvListaProductos.Width = 1065;

            this.RefrescardataGrid();

            taskArmarTituloFormulario.Wait();
            this.Text = sb.ToString();
            
            this.Show();
        }

        /// <summary>
        /// Refresca el datagrid
        /// IMPLEMENTA TASK Y LAMBDA.
        /// </summary>
        private void RefrescardataGrid()
        {
            this.dgvListaProductos.DataSource = null;
            
            this.taskCargarListaProductos = Task.Run(()=> this.CargarListaProductos());

            this.CargarDataGrid();
        }

        /// <summary>
        /// Carga la lista de la instancia con los Productos cargados en el sistema.
        /// </summary>
        private void CargarListaProductos()
        {
            this.productos.Clear();

            for (int i = 0; i < Producto.Count; i++)
            {
                this.productos.Add(Producto.ObtenerUnProductoDeLaListaPorIndice(i));
            }
        }

        /// <summary>
        /// Carga el datagrid con datos.
        /// </summary>
        private void CargarDataGrid()
        {
            this.CrearColumnasDataGrid();
            this.AsociarPropiedadesAlDataGrid();
            this.DarEstiloAColumnasDataGrid();

            if(this.taskCargarListaProductos is not null &&
               this.taskCargarListaProductos.Status == TaskStatus.Running)
            {
                this.taskCargarListaProductos.Wait();
            }

            this.dgvListaProductos.DataSource = this.productos;
            this.OrdenarColumnasDataGrid();
        }

        /// <summary>
        /// Crea las columnas del datagrid.
        /// </summary>
        private void CrearColumnasDataGrid()
        {
            this.dgvListaProductos.Columns.Add("id", "Id");
            this.dgvListaProductos.Columns.Add("nombre", "Producto");
            this.dgvListaProductos.Columns.Add("descripcion", "Descripcion");
            this.dgvListaProductos.Columns.Add("precio", "Precio");
            this.dgvListaProductos.Columns.Add("tipo", "Tipo");
        }

        /// <summary>
        /// Asocia propiedades a las columnas del datagrid.
        /// </summary>
        private void AsociarPropiedadesAlDataGrid()
        {
            this.dgvListaProductos.Columns["id"].DataPropertyName = "IdProducto";
            this.dgvListaProductos.Columns["nombre"].DataPropertyName = "NombreProducto";
            this.dgvListaProductos.Columns["descripcion"].DataPropertyName = "DescripcionProducto";
            this.dgvListaProductos.Columns["precio"].DataPropertyName = "PrecioProducto";
            this.dgvListaProductos.Columns["tipo"].DataPropertyName = "Tipo";
        }
         
        /// <summary>
        /// Le da el estilo a las columnas
        /// </summary>
        private void DarEstiloAColumnasDataGrid()
        {
            this.dgvListaProductos.Columns["id"].Width = 75;
            this.dgvListaProductos.Columns["nombre"].Width = 220;
            this.dgvListaProductos.Columns["tipo"].Width = 125;
            this.dgvListaProductos.Columns["descripcion"].Width = 400;

            this.dgvListaProductos.Columns["precio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dgvListaProductos.Columns["precio"].DefaultCellStyle.Format = "$0,0.00";
            this.dgvListaProductos.Columns["id"].DefaultCellStyle.Format = "D4";
            this.dgvListaProductos.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// Ordena las columnas del datagrid.
        /// </summary>
        private void OrdenarColumnasDataGrid()
        {
            this.dgvListaProductos.Columns["id"].DisplayIndex = 0;
            this.dgvListaProductos.Columns["nombre"].DisplayIndex = 1;
            this.dgvListaProductos.Columns["tipo"].DisplayIndex = 2;
            this.dgvListaProductos.Columns["descripcion"].DisplayIndex = 3;
            this.dgvListaProductos.Columns["precio"].DisplayIndex = 4;           
        }

        private void btnAltaProducto_Click(object sender, EventArgs e)
        {
            FrmAltaProducto altaProducto = new FrmAltaProducto(this.administrador);
            if(altaProducto.ShowDialog() == DialogResult.OK)
            {
                this.RefrescardataGrid();
            }
        }

        private void btnModificacionProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.dgvListaProductos.SelectedRows != null && this.dgvListaProductos.SelectedRows.Count > 0)
                {
                    Producto producto = (this.dgvListaProductos.SelectedRows[0].DataBoundItem as Producto);

                    if(producto is not null)
                    {
                        FrmModificarProducto modificarProducto = new FrmModificarProducto(this.administrador, producto);
                        if(modificarProducto.ShowDialog() == DialogResult.OK)
                        {
                            this.RefrescardataGrid();
                        }
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show($"Debe seleccionar un producto.", "Aviso: Debe seleccionar un producto.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBajaProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvListaProductos.SelectedRows != null && this.dgvListaProductos.SelectedRows.Count > 0)
                {
                    Producto producto = (this.dgvListaProductos.SelectedRows[0].DataBoundItem as Producto);

                    if(producto != null)
                    {
                        DialogResult respuesta =  MessageBox.Show($"¿Seguro desea eliminar el producto seleccionado?{Environment.NewLine}{producto}", "Aviso: Eliminar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        try
                        {
                            if (respuesta == DialogResult.Yes && this.administrador.EliminarUnProductoDelSistema(producto))
                            {
                                this.RefrescardataGrid();
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
                MessageBox.Show($"Debe seleccionar un producto.", "Aviso: Debe seleccionar un producto.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
