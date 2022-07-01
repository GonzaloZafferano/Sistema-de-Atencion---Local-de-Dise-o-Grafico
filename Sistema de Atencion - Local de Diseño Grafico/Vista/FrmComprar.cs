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
    public partial class FrmComprar : Form
    {
        private Empleado empleado;
        private Cliente cliente;
        private CarritoDeCompra carrito;
        List<ProductoEnCarrito> productosEnCarrito;
        List<Producto> productos;
        Task taskCargarListaProductos;
        Task taskCargarListaEnCarrito;

        public FrmComprar(Empleado empleado, Cliente cliente, CarritoDeCompra carrito)
        {
            this.InitializeComponent();
           
            this.empleado = empleado;
            this.cliente = cliente;
            this.carrito = carrito;
            this.productosEnCarrito = new List<ProductoEnCarrito>();
            this.productos = new List<Producto>();
        }

        private void FrmComprar_Load(object sender, EventArgs e)
        {
            this.Hide();

            this.taskCargarListaProductos = Task.Run(() => this.CargarListaDeProductos());

            this.Width = 1356;

            StringBuilder sb = new StringBuilder();

            Task taskArmarTituloFormulario = Task.Run(() =>
            {
                sb.Append("Menu Atender Cliente. ");
                sb.Append($"{this.empleado.GetType().Name}: ");
                sb.Append($"{this.empleado.NombreUsuario} ");
                sb.Append($"({this.empleado.NombreCompleto})");
            });

            this.dgvListaProductos.Width = 1090;
            this.dgvListaCarrito.Width = 1310;
            this.txtDetallesProducto.Width = 1090;
            this.nUpDownCantidad.Location = new Point(this.dgvListaProductos.Width + this.dgvListaProductos.Location.X - this.nUpDownCantidad.Width, this.nUpDownCantidad.Location.Y);
            this.lblCantidad.Location = new Point(this.nUpDownCantidad.Location.X - this.lblCantidad.Width - 10, this.lblCantidad.Location.Y);

            this.rBtnChico.Checked = true;
            this.rBtnSinColor.Checked = true;
            this.nUpDownCantidad.Minimum = 1;
            this.nUpDownCantidad.Maximum = 100;

            this.CargarDataGridProductos();

            this.dgvListaCarrito.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvListaCarrito.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

            taskArmarTituloFormulario.Wait();

            this.Text = sb.ToString();

            this.Show();
        }

        /// <summary>
        /// Carga el datagrid Lista de productos con datos, invocando distintos metodos.
        /// </summary>
        private void CargarDataGridProductos()
        {
            this.CrearColumnasDataGridProductos();
            this.AsociarPropiedadesDataGridProductos();
            this.DarEstiloAColumnasDataGridProductos();

            if (this.taskCargarListaProductos != null &&
                this.taskCargarListaProductos.Status == TaskStatus.Running)
            {
                this.taskCargarListaProductos.Wait();
            }

            this.dgvListaProductos.DataSource = this.productos;
            this.OrdenarColumnasDataGridProductos();
        }

        /// <summary>
        /// Crea las columnas del datagrid Lista de productos.
        /// </summary>
        private void CrearColumnasDataGridProductos()
        {
            this.dgvListaProductos.Columns.Add("id", "Id");
            this.dgvListaProductos.Columns.Add("nombre", "Producto");
            this.dgvListaProductos.Columns.Add("descripcion", "Descripcion");
            this.dgvListaProductos.Columns.Add("precio", "Precio");
            this.dgvListaProductos.Columns.Add("tipo", "Tipo");
        }

        /// <summary>
        /// Asocia propiedades a cada columna del datagrid Lista de productos.
        /// </summary>
        private void AsociarPropiedadesDataGridProductos()
        {
            this.dgvListaProductos.Columns["id"].DataPropertyName = "IdProducto";
            this.dgvListaProductos.Columns["nombre"].DataPropertyName = "NombreProducto";
            this.dgvListaProductos.Columns["descripcion"].DataPropertyName = "DescripcionProducto";
            this.dgvListaProductos.Columns["precio"].DataPropertyName = "PrecioProducto";
            this.dgvListaProductos.Columns["tipo"].DataPropertyName = "Tipo";
        }

        /// <summary>
        /// Carga la lista de la instancia con elementos de la clase Productos.
        /// </summary>
        private void CargarListaDeProductos()
        {
            for (int i = 0; i < Producto.Count; i++)
            {
                this.productos.Add(Producto.ObtenerUnProductoDeLaListaPorIndice(i));
            }
        }

        /// <summary>
        /// Le da el estilo a las columnas
        /// </summary>
        private void DarEstiloAColumnasDataGridProductos()
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
        /// Ordena las columnas del datagrid Lista de productos y les asigna un ancho.
        /// </summary>
        private void OrdenarColumnasDataGridProductos()
        {
            this.dgvListaProductos.Columns["id"].DisplayIndex = 0;
            this.dgvListaProductos.Columns["nombre"].DisplayIndex = 1;
            this.dgvListaProductos.Columns["tipo"].DisplayIndex = 2;
            this.dgvListaProductos.Columns["descripcion"].DisplayIndex = 3;
            this.dgvListaProductos.Columns["precio"].DisplayIndex = 4;            
        }

        /// <summary>
        /// Actualiza el datagrid de Lista en carrito.
        /// </summary>
        private void RefrescarDataGridCarrito()
        {
            this.dgvListaCarrito.DataSource = null;

            this.taskCargarListaEnCarrito = Task.Run(() => this.CargarListaDeProductosEnCarrito());
            
            this.CargarDataGridCarrito();
            this.ActualizarPrecio();
        }

        /// <summary>
        /// Carga la lista de elementos en el datagrid.
        /// </summary>
        private void CargarListaDeProductosEnCarrito()
        {
            this.productosEnCarrito.Clear();

            for (int i = 0; i < this.carrito.Count; i++)
            {
                this.productosEnCarrito.Add(this.carrito.ObtenerUnProductoDelCarritoPorIndice(i));
            }
        }

        /// <summary>
        /// Carga el datagrid lista en carrito.
        /// </summary>
        private void CargarDataGridCarrito()
        {
            this.CrearColumnasDataGridCarrito();
            this.AsociarPropiedadesAlDataGridCarrito();
            this.DarEstiloAColumnasDataGridCarrito();

            if (this.taskCargarListaEnCarrito != null &&
                this.taskCargarListaEnCarrito.Status == TaskStatus.Running)
            {
                this.taskCargarListaEnCarrito.Wait();
            }
            
            this.dgvListaCarrito.DataSource = this.productosEnCarrito;
            this.OrdenarColumnasDataGridCarrito();
        }

        /// <summary>
        /// Actualiza el precio en el Label del total.
        /// </summary>
        private void ActualizarPrecio()
        {
            this.lblTotal.Text = $"Total: ${string.Format("{0:0,0.00}", this.carrito.PrecioTotalAcumuladoEnCarritoSinDescuentoIncluido)}";
        }

        /// <summary>
        /// Crea las columnas del datagrid lista en carrito.
        /// </summary>
        private void CrearColumnasDataGridCarrito()
        {
            this.dgvListaCarrito.Columns.Add("id", "Id");
            this.dgvListaCarrito.Columns.Add("nombre", "Producto");
            this.dgvListaCarrito.Columns.Add("descripcion", "Descripcion");
            this.dgvListaCarrito.Columns.Add("precio", "Precio x Unidad");
            this.dgvListaCarrito.Columns.Add("cantidad", "Cantidad");
            this.dgvListaCarrito.Columns.Add("precioTotal", "Precio Total");
        }

        /// <summary>
        /// Asocia propiedades en las columnas del datagrid lista en carrito.
        /// </summary>
        private void AsociarPropiedadesAlDataGridCarrito()
        {
            this.dgvListaCarrito.Columns["id"].DataPropertyName = "IdProducto";
            this.dgvListaCarrito.Columns["nombre"].DataPropertyName = "NombreProducto";
            this.dgvListaCarrito.Columns["descripcion"].DataPropertyName = "DescripcionProducto";
            this.dgvListaCarrito.Columns["precio"].DataPropertyName = "PrecioUnitarioProductoEnCarrito";
            this.dgvListaCarrito.Columns["cantidad"].DataPropertyName = "Cantidad";
            this.dgvListaCarrito.Columns["precioTotal"].DataPropertyName = "PrecioTotalProductoEnCarrito";
        }

        /// <summary>
        /// Le da el estilo a las columnas
        /// </summary>
        private void DarEstiloAColumnasDataGridCarrito()
        {
            this.dgvListaCarrito.Columns["id"].Width = 75;
            this.dgvListaCarrito.Columns["nombre"].Width = 220;
            this.dgvListaCarrito.Columns["descripcion"].Width = 450;
            this.dgvListaCarrito.Columns["precio"].Width = 220;
            this.dgvListaCarrito.Columns["cantidad"].Width = 125;

            this.dgvListaCarrito.Columns["precioTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dgvListaCarrito.Columns["id"].DefaultCellStyle.Format = "D4";
            this.dgvListaCarrito.Columns["cantidad"].DefaultCellStyle.Format = "D4";
            this.dgvListaCarrito.Columns["precio"].DefaultCellStyle.Format = "$0,0.00";
            this.dgvListaCarrito.Columns["precioTotal"].DefaultCellStyle.Format = "$0,0.00";

            this.dgvListaCarrito.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListaCarrito.Columns["precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            this.dgvListaCarrito.Columns["nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListaCarrito.Columns["cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvListaCarrito.Columns["precioTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// Ordena las columnas del datagrid lista en carrito.
        /// </summary>
        private void OrdenarColumnasDataGridCarrito()
        {
            this.dgvListaCarrito.Columns["id"].DisplayIndex = 0;
            this.dgvListaCarrito.Columns["nombre"].DisplayIndex = 1;
            this.dgvListaCarrito.Columns["descripcion"].DisplayIndex = 2;
            this.dgvListaCarrito.Columns["precio"].DisplayIndex = 3;
            this.dgvListaCarrito.Columns["cantidad"].DisplayIndex = 4;
            this.dgvListaCarrito.Columns["precioTotal"].DisplayIndex = 5;           
        }

        private void btnCargarALaLista_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvListaCarrito.SelectedRows != null && this.dgvListaProductos.SelectedRows.Count > 0)
                {
                    Producto producto = (this.dgvListaProductos.SelectedRows[0].DataBoundItem as Producto);

                    if (producto != null)
                    {
                        if (producto is Disenio)
                        {
                            foreach (Control control in this.gBoxTamanio.Controls)
                            {
                                if (control is RadioButton && ((RadioButton)control).Checked &&
                                    Enum.TryParse(((RadioButton)control).Text, out Disenio.Tamanio tamanio))
                                {
                                    producto = producto.ClonarProducto(tamanio);
                                }
                            }
                        }
                        else if (producto is Impresion)
                        {
                            producto = producto.ClonarProducto(this.rBtnColor.Checked);
                        }

                        ProductoEnCarrito productoEnCarrito = new ProductoEnCarrito(producto, (int)this.nUpDownCantidad.Value, this.txtDetallesProducto.Text);

                        if(this.carrito.CargarProductoEnCarrito(productoEnCarrito))
                        {
                            this.txtDetallesProducto.Clear();
                            this.RefrescarDataGridCarrito();
                        }                  
                    }
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("No se ha podido cargar el producto en el carrito. Reintente mas tarde", "Aviso: Error al cargar producto.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(CargaDeDatosInvalidosException ex)
            {
                MessageBox.Show(ex.Message, "Aviso: Error al cargar producto.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show($"Debe seleccionar un producto.", "Aviso: Debe seleccionar un producto.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBorrarDelCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.dgvListaCarrito.SelectedRows != null && this.dgvListaCarrito.SelectedRows.Count > 0)
                {
                    ProductoEnCarrito productoEnCarrito = (this.dgvListaCarrito.SelectedRows[0].DataBoundItem as ProductoEnCarrito);

                    if(productoEnCarrito != null && this.carrito.EliminarProductoDelCarrito(productoEnCarrito))
                    {
                        this.RefrescarDataGridCarrito();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Debe seleccionar un producto.", "Aviso: Debe seleccionar un producto.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvListaProductos_SelectionChanged(object sender, EventArgs e)
        {
            if(this.dgvListaProductos.SelectedRows.Count > 0)
            {
                if(this.dgvListaProductos.SelectedRows[0].DataBoundItem is Disenio)
                {
                    this.gBoxTamanio.Visible = true;
                    this.gBoxColor.Visible = false;
                    this.nUpDownCantidad.Value = 1;
                    this.nUpDownCantidad.Enabled = false;
                }
                else if (this.dgvListaProductos.SelectedRows[0].DataBoundItem is Impresion)
                {
                    this.gBoxTamanio.Visible = false;
                    this.gBoxColor.Visible = true;
                    this.nUpDownCantidad.Enabled = true;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(this.carrito.Count > 0)
            {
                FrmConfirmarCompra confirmarCompra = new FrmConfirmarCompra(this.empleado, this.cliente, this.carrito);
                if(confirmarCompra.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("El carrito esta vacio", "Aviso: Carrito vacio.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
