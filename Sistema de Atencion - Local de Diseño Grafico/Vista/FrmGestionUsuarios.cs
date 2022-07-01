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
    public partial class FrmGestionUsuarios : Form
    {
        private List<Empleado> empleados;
        private Administrador administrador;
        private Task taskCargarListaDeUsuarios;

        public FrmGestionUsuarios(Administrador administrador)
        {
            this.InitializeComponent();
            this.administrador = administrador;
            this.empleados = new List<Empleado>();
        }

        private void GestionUsuarios_Load(object sender, EventArgs e)
        {
            this.Hide();

            StringBuilder sb = new StringBuilder();

            Task taskArmarTituloForm = Task.Run(() =>
            {
                sb.Append("Menu Gestion Usuarios. Administrador: ");
                sb.Append($"{this.administrador.NombreUsuario} ");
                sb.Append($"({this.administrador.NombreCompleto})");
            });

            this.Width = 1399;
            this.dgwListaUsuarios.Width = 1360;

            this.btnAsignarNuevoJefe.Visible = this.administrador is Jefe;

            this.RefrescarDataGrid();

            taskArmarTituloForm.Wait();
            this.Text = sb.ToString();
            
            this.Show();
        }

        /// <summary>
        /// Refresca el datagrid
        /// </summary>
        private void RefrescarDataGrid()
        {
            this.dgwListaUsuarios.DataSource = null;

            this.taskCargarListaDeUsuarios = Task.Run(() => this.CargarListaDeEmpleados(this.administrador is Jefe));

            this.CargarDataGrid();
        }

        /// <summary>
        /// Carga la lista de la instancia con los Empledos cargados en el sistema.
        /// </summary>
        /// <param name="tipoEmpleado"></param>
        private void CargarListaDeEmpleados(bool tipoEmpleado)
        {
            this.empleados.Clear();

            for(int i = 0; i < Administrador.Count; i++)
            {
                Empleado empleado = Administrador.ObtenerUnEmpleadoDeLaListaPorIndice(i);

                if((empleado.EsAdministrador == tipoEmpleado || tipoEmpleado))
                {
                    this.empleados.Add(empleado);
                }
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

            if(this.taskCargarListaDeUsuarios is not null &&
               this.taskCargarListaDeUsuarios.Status == TaskStatus.Running)
            {
                this.taskCargarListaDeUsuarios.Wait();
            }
            
            this.dgwListaUsuarios.DataSource = this.empleados;
            this.OrdenarColumnasDataGrid();
        }

        /// <summary>
        /// Crea las columnas del datagrid.
        /// </summary>
        private void CrearColumnasDataGrid()
        {
            this.dgwListaUsuarios.Columns.Add("id", "Id");
            this.dgwListaUsuarios.Columns.Add("nombreCompleto", "Nombre");
            this.dgwListaUsuarios.Columns.Add("nombreUsuario", "Usuario");
            this.dgwListaUsuarios.Columns.Add("dni", "Dni");
            this.dgwListaUsuarios.Columns.Add("puesto", "Puesto");
            this.dgwListaUsuarios.Columns.Add("salario", "Salario");
            this.dgwListaUsuarios.Columns.Add("cantidadVentas", "Cant. Ventas");
            this.dgwListaUsuarios.Columns.Add("gananciasGeneradas", "Ganancias Generadas");
            this.dgwListaUsuarios.Columns.Add("promedioGanancias", "Promedio Ganancias");
        }

        /// <summary>
        /// Asocia propiedades a las columnas del datagrid.
        /// </summary>
        private void AsociarPropiedadesAlDataGrid()
        {
            this.dgwListaUsuarios.Columns["id"].DataPropertyName = "Id";
            this.dgwListaUsuarios.Columns["nombreCompleto"].DataPropertyName = "NombreCompleto";
            this.dgwListaUsuarios.Columns["nombreUsuario"].DataPropertyName = "NombreUsuario";
            this.dgwListaUsuarios.Columns["dni"].DataPropertyName = "Dni";
            this.dgwListaUsuarios.Columns["puesto"].DataPropertyName = "Puesto";
            this.dgwListaUsuarios.Columns["salario"].DataPropertyName = "Salario";
            this.dgwListaUsuarios.Columns["cantidadVentas"].DataPropertyName = "CantidadVentasConcretadas";
            this.dgwListaUsuarios.Columns["gananciasGeneradas"].DataPropertyName = "GananciasGeneradas";
            this.dgwListaUsuarios.Columns["promedioGanancias"].DataPropertyName = "PromedioGananciasGeneradas";
        }

        /// <summary>
        /// Le da el estilo a las columnas
        /// </summary>
        private void DarEstiloAColumnasDataGrid()
        {
            this.dgwListaUsuarios.Columns["id"].Width = 75;
            this.dgwListaUsuarios.Columns["dni"].Width = 125;
            this.dgwListaUsuarios.Columns["nombreCompleto"].Width = 200;
            this.dgwListaUsuarios.Columns["cantidadVentas"].Width = 75;
            this.dgwListaUsuarios.Columns["nombreUsuario"].Width = 130;
            this.dgwListaUsuarios.Columns["puesto"].Width = 155;
            this.dgwListaUsuarios.Columns["salario"].Width = 180;
            this.dgwListaUsuarios.Columns["gananciasGeneradas"].Width = 200;

            this.dgwListaUsuarios.Columns["promedioGanancias"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dgwListaUsuarios.Columns["id"].DefaultCellStyle.Format = "D4";
            this.dgwListaUsuarios.Columns["cantidadVentas"].DefaultCellStyle.Format = "D4";
            this.dgwListaUsuarios.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgwListaUsuarios.Columns["cantidadVentas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgwListaUsuarios.Columns["salario"].DefaultCellStyle.Format = "$0,0.00";
            this.dgwListaUsuarios.Columns["promedioGanancias"].DefaultCellStyle.Format = "$0,0.00";
            this.dgwListaUsuarios.Columns["gananciasGeneradas"].DefaultCellStyle.Format = "$0,0.00";
        }

        /// <summary>
        /// Ordena las columnas del datagrid y les asigna un ancho.
        /// </summary>
        private void OrdenarColumnasDataGrid()
        {
            this.dgwListaUsuarios.Columns["id"].DisplayIndex = 0;
            this.dgwListaUsuarios.Columns["dni"].DisplayIndex = 1;
            this.dgwListaUsuarios.Columns["nombreCompleto"].DisplayIndex = 2;
            this.dgwListaUsuarios.Columns["nombreUsuario"].DisplayIndex = 3;
            this.dgwListaUsuarios.Columns["puesto"].DisplayIndex = 4;
            this.dgwListaUsuarios.Columns["salario"].DisplayIndex = 5;
            this.dgwListaUsuarios.Columns["cantidadVentas"].DisplayIndex = 6;
            this.dgwListaUsuarios.Columns["gananciasGeneradas"].DisplayIndex = 7;
            this.dgwListaUsuarios.Columns["promedioGanancias"].DisplayIndex = 8;
        }        

        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            FrmAltaUsuario formularioAltaUsuario = new FrmAltaUsuario(this.administrador);
            if(formularioAltaUsuario.ShowDialog() == DialogResult.OK)
            {
                this.RefrescarDataGrid();
            }
        }

        private void btnBajaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.dgwListaUsuarios.SelectedRows.Count > 0 && this.dgwListaUsuarios.SelectedRows[0] != null)
                {
                    Empleado empleado = (this.dgwListaUsuarios.SelectedRows[0].DataBoundItem as Empleado);

                    if(empleado is not null && empleado != this.administrador)
                    {
                        DialogResult respuesta = MessageBox.Show($"¿Seguro desea eliminar al empleado seleccionado? {Environment.NewLine}{empleado}", "Aviso: Eliminar empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                       
                        if(respuesta == DialogResult.Yes && this.administrador.EliminarUnEmpleadoDelSistema(empleado))
                        {
                            this.RefrescarDataGrid();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar a si mismo.", "Aviso: Autoreferencia", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show($"Debe seleccionar un usuario.", "Aviso: Debe seleccionar un usuario.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("En este momento no se pueden guardar cambios en el sistema. Por favor reintente mas tarde.", "Aviso: No se pueden guardar los cambios.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificacionUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.dgwListaUsuarios.SelectedRows.Count > 0 && this.dgwListaUsuarios.SelectedRows[0] != null)
                {
                    Empleado empleado = (this.dgwListaUsuarios.SelectedRows[0].DataBoundItem as Empleado); 
               
                    if(empleado is not null)
                    {
                        FrmModificarUsuario formularioModificarUsuario = new FrmModificarUsuario(this.administrador, empleado);
                        if(formularioModificarUsuario.ShowDialog() == DialogResult.OK)
                        {
                            this.RefrescarDataGrid();                        
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Debe seleccionar un usuario.", "Aviso: Debe seleccionar un usuario.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAsignarNuevoJefe_Click(object sender, EventArgs e)
        {
            Jefe nuevoJefe;
            Administrador nuevoAdministrador;
            Empleado empleadoSeleccionado;
            try
            {
                if (this.dgwListaUsuarios.SelectedRows.Count > 0 && this.dgwListaUsuarios.SelectedRows[0] != null)
                {
                    empleadoSeleccionado = this.dgwListaUsuarios.SelectedRows[0].DataBoundItem as Empleado;

                    if (empleadoSeleccionado != null)
                    {
                        if(empleadoSeleccionado != this.administrador)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine("Un momento! El sistema solo puede tener un Jefe.");
                            sb.AppendLine("Si continua con la operacion, el Jefe actual sera degradado a Administrador, siendo sustituido por un nuevo Jefe, posteriormente se cerrara la sesion.");
                            sb.AppendLine("¿Desea continuar de todas formas?");

                            DialogResult respuesta = MessageBox.Show(sb.ToString(), "Aviso: Alerta de sustitucion de Jefe.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                            if (respuesta == DialogResult.Yes)
                            {
                                nuevoJefe = Jefe.AsignarPuestoDeJefeAEmpleado(empleadoSeleccionado);

                                nuevoAdministrador = Jefe.CambiarPuestoDeEmpleado(this.administrador) as Administrador;

                                nuevoJefe.CargarUnEmpleadoModificadoAlSistema(nuevoJefe);

                                nuevoJefe.CargarUnEmpleadoModificadoAlSistema(nuevoAdministrador);

                                this.administrador = nuevoJefe;

                                this.DialogResult = DialogResult.Retry;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se puede asignar como Jefe a si mismo, ya es Jefe.", "Aviso: Autoreferencia.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                }                
            }
            catch (CargaDeDatosInvalidosException ex)
            {
                MessageBox.Show(ex.Message, "Aviso: Carga de datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No se ha podido realizar el cambio de puesto.", "Aviso: Error al intentar cambiar el puesto.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show($"Debe seleccionar un usuario.", "Aviso: Debe seleccionar un usuario.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("En este momento no se pueden guardar cambios en el sistema. Por favor reintente mas tarde.", "Aviso: No se pueden guardar los cambios.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
