using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jefe : Administrador
    {
        /// <summary>
        /// Constructor publico para SERIALIZACION. NO UTILIZAR ESTA SOBRECARGA para instanciar.
        /// </summary>
        public Jefe()
        {

        }

        /// <summary>
        /// Constructor de la clase Jefe. Obtiene un nuevo Jefe con nuevo ID.
        /// </summary>
        /// <param name="nombre">nombre jefe</param>
        /// <param name="apellido">apellido jefe</param>
        /// <param name="dni">dni jefe</param>
        /// <param name="salario">salario jefe</param>
        /// <param name="nombreUsuario">nomrbe usuario jefe</param>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalida</exception>
        /// <exception cref="NullReferenceException">Datos NULL.</exception>
        public Jefe(string nombre, string apellido, int dni, double salario, string nombreUsuario)
            : base(nombre, apellido, dni, salario, nombreUsuario)
        {
            this.Puesto = Empleado.Rol.Jefe;
        }

        /// <summary>
        /// Constructor de la clase Jefe. Obtiene jefe, asignando el ID recibido.
        /// Este constructor se utiliza para cargar elementos ya existentes o clonar.
        /// </summary>
        /// <param name="id">Id del jefe</param>
        /// <param name="dni">dni jefe</param>
        /// <param name="nombre">nombre jefe</param>
        /// <param name="apellido">apellido jefe</param>
        /// <param name="salario">salario jefe</param>
        /// <param name="nombreUsuario">nomrbe usuario jefe</param>
        /// <param name="password">contraseña del jefe</param>
        /// <param name="estaActivo">Indica si el empleado esta activo o no.</param>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalida</exception>
        /// <exception cref="NullReferenceException">Datos NULL.</exception>
        internal Jefe(int id, int dni, string nombre, string apellido, double salario, string nombreUsuario, string password, EstaActivo estaActivo)
            : base(id, dni, nombre, apellido, salario, nombreUsuario, password, estaActivo)
        {
            this.Puesto = Empleado.Rol.Jefe;
        }

        /// <summary>
        /// Asigna el puesto de jefe a un empleado existente.
        /// </summary>
        /// <param name="empleado">Empleado que sera el nuevo Jefe</param>
        /// <returns>Un nuevo Jefe.</returns>
        /// <exception cref="NullReferenceException">Empleado NULL</exception>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalida</exception>
        public static Jefe AsignarPuestoDeJefeAEmpleado(Empleado empleado)
        {
            if (empleado is not null)
            {
                return Empleado.AsignarNuevoJefe(empleado);

            }
            throw new NullReferenceException("Empleado null");
        }

        /// <summary>
        /// Agrega un empleado en la base de datos, obtiene su Id, la carga al sistema y la retorna con el Id correspondiente.
        /// </summary>
        /// <param name="empleado">empleado a cargar.</param>
        /// <returns>El empleado almacenado, con el ID correspondiente.</returns>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public override Empleado CargarUnEmpleadoAlSistema(Empleado empleado)
        {
            Empleado ultimoEmpleado;

            try
            {
                if (empleado is not null)
                {
                    EmpleadoDAO empleadoDao = new EmpleadoDAO();

                    empleadoDao.InsertarEnBaseDeDatos(empleado);

                    ultimoEmpleado = empleadoDao.ObtenerUltimoElementoCargadoEnBaseDeDatos();

                    if(Administrador.empleados.CargarElementoAlSistema(ultimoEmpleado))
                    {
                        Task.Run(() =>
                        {
                            try
                            {
                                ((IArchivo)this).GuardarArchivo();
                            }
                            catch(Exception)
                            {

                            }
                        });
                    }

                    return ultimoEmpleado;
                }
                throw new ArgumentNullException("Empleado es NULL");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Modifica un empleado en la base de datos. Limpia la lista y la vuelve a cargar con los empleados de la BBDD.
        /// </summary>
        /// <param name="empleado">empleado modificado.</param>
        /// <returns>True si se opero con exito, caso contrario False.</returns>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public override bool CargarUnEmpleadoModificadoAlSistema(Empleado empleado)
        {
            try
            {
                bool retorno = false;
                if (empleado is not null)
                {
                    EmpleadoDAO empleadoDao = new EmpleadoDAO();

                    empleadoDao.ActualizarEnBaseDeDatos(empleado);

                    if (Administrador.RefrescarListaEmpleados())
                    {
                        Task.Run(() =>
                        {
                            try
                            {
                                ((IArchivo)this).GuardarArchivo();
                            }
                            catch (Exception)
                            {

                            }
                        });
                        retorno = true;
                    }

                    return retorno;
                }
                throw new ArgumentNullException("Empleado NULL");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina un empleado en la base de datos y del sistema.
        /// </summary>
        /// <param name="empleado">empleado a eliminar.</param>
        /// <returns>True si se opero con exito, caso contrario False.</returns>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public override bool EliminarUnEmpleadoDelSistema(Empleado empleado)
        {
            try
            {
                bool retorno = false;

                if (empleado is not null)
                {
                    EmpleadoDAO empleadoDao = new EmpleadoDAO();

                    empleadoDao.EliminarDeBaseDeDatos(empleado);

                    if(Administrador.empleados.EliminarElementoDelSistema(empleado))
                    {
                        Task.Run(() =>
                        {
                            try
                            {
                                ((IArchivo)this).GuardarArchivo();
                            }
                            catch (Exception)
                            {

                            }
                        });
                        retorno = true;
                    }
                    return retorno;
                }
                throw new ArgumentNullException("Empleado NULL");
            }
            catch (Exception)
            {
                throw;
            }           
        }

        /// <summary>
        /// Refresca la lista de clientes, y la guarda en un archivo.
        /// </summary>
        public void RefrescarListaClientes()
        {
            Cliente.RefrescarListaClientes();

            Task.Run(()=>
            {
                try 
                {
                    Cliente.GuardarArchivoClientes();
                }
                catch(Exception)
                {

                }

            });
        }

        /// <summary>
        /// Refresca la lista de empleados, y la guarda en un archivo.
        /// </summary>
        public new void RefrescarListaEmpleados()
        {
            Administrador.RefrescarListaEmpleados();

            Task.Run(() =>
            {
                try
                {
                    Administrador.GuardarArchivoEmpleados();
                }
                catch
                {

                }
            });
        }

        /// <summary>
        /// Reactiva un cliente
        /// </summary>
        /// <param name="dni">Dni del cliente</param>
        /// <returns>True si encontro y reactivo al cliente, caso contrario False.</returns>
        /// <exception cref="CargaDeDatosInvalidosException">Dni invalido</exception>
        /// <exception cref="ArgumentException">Argumento null</exception>
        /// <exception cref="Exception">Error.</exception>
        public bool ReactivarCliente(int dni)
        {
            try
            {
                if (dni >= 1000000 && dni <= 99999999)
                {
                    return new ClienteDAO().ReactivarCliente(dni);
                }
                throw new CargaDeDatosInvalidosException("El dni es invalido. Debe tener entre 7 y 8 numeros.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Reactiva un empleado.
        /// </summary>
        /// <param name="dni">dni del empleado</param>
        /// <returns>True si encontro y reactivo al empleado, caso contrario False.</returns>
        /// <exception cref="CargaDeDatosInvalidosException">Dni invalido</exception>
        /// <exception cref="ArgumentException">Argumento null</exception>
        /// <exception cref="Exception">Error.</exception>
        public bool ReactivarEmpleado(int dni)
        {
            try
            {
                if (dni >= 1000000 && dni <= 99999999)
                {
                    return new EmpleadoDAO().ReactivarEmpleado(dni);
                }
                throw new CargaDeDatosInvalidosException("El dni es invalido. Debe tener entre 7 y 8 numeros.");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
