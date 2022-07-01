using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades 
{
    [XmlInclude(typeof(Jefe))]
    public class Administrador : Empleado, IArchivo
    {
        //IMPLEMENTACION EVENTOS
        public static event CargarProgresoDeLecturaHandler OnCargaCompleta;
        public static event LecturaDeDatosHandler OnLecturaDeFuenteDeDatos;

        private const string rutaRelativaArchivo = "Empleados\\empleados";

        protected static ListaGenerica<Empleado> empleados;
        private static EmpleadoDAO empleadoDao;

        /// <summary>
        /// Constructor estatico de la clase Administrador. Inicializa la lista generica de empleados y Lee el archivo de empleados para cargarlos a dicha lista.
        /// </summary>
        static Administrador()
        {
            Administrador.empleados = new ListaGenerica<Empleado>();

            Administrador.empleadoDao = new EmpleadoDAO();
        }

        /// <summary>
        /// Constructor publico para SERIALIZACION. NO UTILIZAR ESTA SOBRECARGA para instanciar.
        /// </summary>
        public Administrador()
        {

        }

        /// <summary>
        /// Constructor publico de Administrador. Carga un empleado luego de validar todos sus datos, 
        /// y verificar que el dni y el nombre de usuario no esten cargados en el sistema de empleados
        /// </summary>
        /// <param name="nombre">nombre empleado</param>
        /// <param name="apellido">apellido emppleado</param>
        /// <param name="dni">dni empleado</param>
        /// <param name="salario">salario empleado</param>
        /// <param name="nombreUsuario">usuario de empleado.</param>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalida</exception>
        /// <exception cref="NullReferenceException">Datos NULL.</exception>
        public Administrador(string nombre, string apellido, int dni, double salario, string nombreUsuario)
            : base(nombre, apellido, dni, salario, nombreUsuario)
        {
            this.Puesto = Empleado.Rol.Administrador;
        }

        /// <summary>
        /// Constructor interno de Administrador. Carga un empleado luego de validar todos sus datos.
        /// Este constructor se utiliza para cargar elementos ya existentes o clonar.
        /// </summary>
        /// <param name="id">Id del empleado</param>
        /// <param name="dni">dni empleado</param>
        /// <param name="nombre">nombre empleado</param>
        /// <param name="apellido">apellido emppleado</param>
        /// <param name="salario">salario empleado</param>
        /// <param name="nombreUsuario">usuario de empleado.</param>
        /// <param name="password">password de empleado.</param>
        /// <param name="estaActivo">Indica si el empleado esta activo o no.</param>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalida</exception>
        /// <exception cref="NullReferenceException">Datos NULL.</exception>
        internal Administrador(int id, int dni, string nombre, string apellido, double salario, string nombreUsuario, string password, EstaActivo estaActivo)
            : base(id, dni, nombre, apellido, salario, nombreUsuario, password, estaActivo)
        {
            this.Puesto = Empleado.Rol.Administrador;
        }

        /// <summary>
        /// Cantidad de empleados cargados en sistema.
        /// </summary>
        public static int Count
        {
            get
            {
                return empleados.Count;
            }
        }

        /// <summary>
        /// Evalua si una persona ya existe en la lista de empleados (Activos), por su DNI.
        /// </summary>
        /// <param name="dni">Dni empleado</param>
        /// <returns>True si existe, caso contrario False.</returns>
        public new static bool ExistePersonaPorDni(int dni)
        {
            return Administrador.empleados.ExisteElementoPorIdentificador(dni);
        }

        /// <summary>
        /// Obtiene un empleado por su indice.
        /// </summary>
        /// <param name="indice">Indice</param>
        /// <returns>El empleado correspondiente al indice.</returns>
        /// <exception cref="IndexOutOfRangeException">Si el indice recibido esta fuera de rango.</exception>
        public static Empleado ObtenerUnEmpleadoDeLaListaPorIndice(int indice)
        {
            if (indice >= 0 && indice < Administrador.Count)
            {
                return Administrador.empleados[indice];
            }
            throw new IndexOutOfRangeException("Indice Fuera de Rango");
        }
           
        /// <summary>
        /// Obtiene el primer empleado de una lista, que coincida con el puesto especificado por parametro.
        /// </summary>
        /// <returns>El primer empleado coincidente con el puesto. Si no encuentra coincidencia, retorna NULL</returns>
        public static Empleado ObtenerElPrimerEmpleadoQueCoincidaConElPuesto(Empleado.Rol puesto)
        {
            Empleado retorno = null;
            Empleado empleadoAuxiliar;

            for (int i = 0; i < Administrador.Count; i++)
            {
                empleadoAuxiliar = Administrador.ObtenerUnEmpleadoDeLaListaPorIndice(i);

                if (empleadoAuxiliar is not null && empleadoAuxiliar.Puesto == puesto)
                {
                    retorno = empleadoAuxiliar;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Evalua si existe el nombre de usuario en la lista de empleados.
        /// </summary>
        /// <param name="nombreUsuario">nombre de usuario del empleado</param>
        /// <returns>True si existe, caso contrario False.</returns>
        internal static bool ExisteNombreUsuario(string nombreUsuario)
        {
            try
            {
                return !(Administrador.empleadoDao.LeerUnRegistroDeBaseDeDatosPorNombreDeUsuario(nombreUsuario) is null);
            }
            catch (Exception)
            {

            }
            return true;
        }

        /// <summary>
        /// Evalua si un DNI ya se encuentra cargado en la BBDD.
        /// </summary>
        /// <param name="dni">Dni a evaluar.</param>
        /// <returns>True si ya esta cargado, caso contrario False.</returns>
        internal static bool ExisteDniCargadoEnSistemaDeEmpleados(int dni)
        {
            try
            {
                return !(Administrador.empleadoDao.LeerUnRegistroDeBaseDeDatosPorDni(dni) is null);
            }
            catch (Exception)
            {

            }
            return true;
        }

        /// <summary>
        /// Cambia el puesto de un empleado, manteniendo el ID del mismo y todos sus datos.
        /// Si recibe un Jefe o Empleado, retorna un Administrador. Si recibe un Administrador, retorna un Empleado.
        /// </summary>
        /// <param name="empleado">Empleado que se cambiara de puesto.</param>
        /// <returns>Empleado con el puesto modificado.</returns>
        /// <exception cref="NullReferenceException">Empleado NULL</exception>
        public static Empleado CambiarPuestoDeEmpleado(Empleado empleado)
        {
            return Empleado.ClonarEmpleadoIntercambiandoPuesto(empleado);
        }

        /// <summary>
        /// Carga un cliente al sistema.
        /// </summary>
        /// <param name="cliente">cliente a cargar.</param>
        /// <returns>True si lo cargo, caso contrario False.</returns>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public bool CargarUnClienteAlSistema(Cliente cliente)
        {
            return Cliente.CargarUnaClienteAlSistema(cliente);
        }

        /// <summary>
        /// Carga un cliente que ha sido modificado a la BBDD.
        /// </summary>
        /// <param name="cliente">cliente a cargar.</param>
        /// <returns>True si lo cargo, caso contrario False.</returns>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public bool CargarUnClienteModificadoAlSistema(Cliente cliente)
        {
            return Cliente.CargarUnClienteModificadoAlSistema(cliente);
        }

        /// <summary>
        /// Elimina un cliente del sistema
        /// </summary>
        /// <param name="cliente">cliente a eliminar.</param>
        /// <returns>True si lo elimino, caso contrario False.</returns>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public bool EliminarUnClienteDelSistema(Cliente cliente)
        {
            return Cliente.EliminarUnClienteDelSistema(cliente);
        }

        /// <summary>
        /// Carga un producto en la base de datos, obtiene un Id, lo carga a la aplicacion y lo retorna con el Id correspondiente.
        /// </summary>
        /// <param name="producto">producto a cargar.</param>
        /// <returns>Retorna el producto con el Id que se le asigno en la Base de Datos.</returns>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public Producto CargarUnProductoAlSistema(Producto producto)
        {
            return Producto.CargarUnProductoAlSistema(producto);
        }

        /// <summary>
        /// Carga una modificacion de un producto en la base de datos.
        /// </summary>
        /// <param name="producto">producto a cargar.</param>
        /// <returns>True si lo cargo, caso contrario False.</returns>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public bool CargarUnProductoModificadoAlSistema(Producto producto)
        {
            return Producto.CargarUnProductoModificadoAlSistema(producto);
        }

        /// <summary>
        /// Elimina un producto de la BBDD y del sistema
        /// </summary>
        /// <param name="producto">producto a eliminar.</param>
        /// <returns>True si lo cargo, caso contrario False.</returns>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public bool EliminarUnProductoDelSistema(Producto producto)
        {
            return Producto.EliminarUnProductoDelSistema(producto);
        }

        /// <summary>
        /// Agrega un empleado en la base de datos, obtiene su Id, la carga al sistema y la retorna con el Id correspondiente.
        /// </summary>
        /// <param name="empleado">empleado a cargar.</param>
        /// <returns>El empleado almacenado, con el ID correspondiente.</returns>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public virtual Empleado CargarUnEmpleadoAlSistema(Empleado empleado)
        {
            Empleado ultimoEmpleado;

            try
            {                
                if (empleado is not null && !empleado.EsAdministrador)
                {                  
                    Administrador.empleadoDao.InsertarEnBaseDeDatos(empleado);

                    ultimoEmpleado = empleadoDao.ObtenerUltimoElementoCargadoEnBaseDeDatos();

                    if(Administrador.empleados.CargarElementoAlSistema(ultimoEmpleado))
                    {
                        Task.Run(()=>
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
                throw new ArgumentNullException("Empleado es NULL o se intenta cargar a un Administrador.");
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
        public virtual bool CargarUnEmpleadoModificadoAlSistema(Empleado empleado)
        {
            try
            {
                bool retorno = false;

                if (empleado is not null && !empleado.EsAdministrador)
                {
                    Administrador.empleadoDao.ActualizarEnBaseDeDatos(empleado);

                    if(Administrador.RefrescarListaEmpleados())   
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
                throw new ArgumentNullException("Empleado NULL o es Administrador");
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
        public virtual bool EliminarUnEmpleadoDelSistema(Empleado empleado)
        {
            try
            {
                bool retorno = false;

                if (empleado is not null && !empleado.EsAdministrador)
                {
                    Administrador.empleadoDao.EliminarDeBaseDeDatos(empleado);

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
                throw new ArgumentNullException("Empleado NULL o es Administrador");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Refresca la lista de empleados, vaciandola y volviendo a cargarla con los empleados.
        /// </summary>
        /// <returns>True su se leyo la lista de la BBDD y se pudo cargar correctamente, caso contrario False.</returns>
        internal static bool RefrescarListaEmpleados()
        {
            try
            {
                Administrador.empleados.VaciarLista();

                Administrador.CargarEmpleadosAlSistemaDesdeBBDD();

                return true;
            }
            catch(BaseDeDatosException)
            {
                return false;
            }
        }

        /// <summary>
        /// Carga un Jefe por defecto en caso de que no se haya podido cargar desde la base de datos.
        /// </summary>
        private static void CargarJefePrimerIngreso()
        {
            Administrador.empleados.CargarElementoAlSistema(new Jefe("Jefe", "Por Defecto", 1000000, 1, "Jefe"));
        }

        /// <summary>
        /// Evalua si hay un Jefe cargado en el sistema.
        /// </summary>
        /// <returns>True si existe un Jefe, caso contrario False.</returns>
        private static bool SistemaPoseeJefe()
        {
            bool retorno = false;

            for(int i = 0; i < Administrador.Count; i++)
            {
                if(Administrador.empleados[i] is Jefe)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Lee la lista de empleados que esta respaldada en una Base de datos, y la carga al sistema.
        /// IMPLEMENTA BBDD, TASK, LAMBDA Y EVENTOS.
        /// </summary>
        /// <exception cref="BaseDeDatosException">Error al leer de la BBDD</exception>
        public static void CargarEmpleadosAlSistemaDesdeBBDD()
        {
            try
            {
                Task.Run(() =>
                {
                    if (Administrador.OnLecturaDeFuenteDeDatos is not null)
                    {
                        Administrador.OnLecturaDeFuenteDeDatos("Cargando empleados...");
                    }
                });

                List<Empleado> empleados = Administrador.empleadoDao.LeerTodosLosRegistrosDeBaseDeDatos();

                for (int i = 0; i < empleados.Count; i++)
                {
                    Administrador.empleados.CargarElementoAlSistema(empleados[i]);
                }

                if(!Administrador.SistemaPoseeJefe())
                {                   
                    Administrador.CargarJefePrimerIngreso();                   
                }

                Task.Run(() =>
                {
                    if (Administrador.OnCargaCompleta is not null)
                    {
                        Administrador.OnCargaCompleta(25);
                    }
                });
            }
            catch (Exception)
            {
                throw new BaseDeDatosException("No se ha podido leer correctamente la base de datos: Tabla Empleados");
            }
        }

        /// <summary>
        /// Version de instancia. Guarda la lista de empleados en un archivo, respaldando la informacion.
        /// IMPLEMENTACION SERIALIZACION E INTERFACES.
        /// </summary>
        /// <returns>True si pudo guardar, caso contrario False.</returns>
        /// <exception cref="ArchivoException">Error referente al archivo.</exception>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        bool IArchivo.GuardarArchivo()
        {
            try
            {
                return Administrador.GuardarArchivoEmpleados();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Version Estatica. Guarda la lista de empleados en un archivo, respaldando la informacion.
        /// IMPLEMENTACION SERIALIZACION E INTERFACES.
        /// </summary>
        /// <returns>True si pudo guardar, caso contrario False.</returns>
        /// <exception cref="ArchivoException">Error referente al archivo.</exception>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        internal static bool GuardarArchivoEmpleados()
        {
            try
            {
                List<Empleado> empleadosASerializar = new List<Empleado>();

                for (int i = 0; i < Administrador.Count; i++)
                {
                    empleadosASerializar.Add(Administrador.empleados[i]);
                }

                return SerializadorXml<List<Empleado>>.GuardarXml(Administrador.rutaRelativaArchivo, empleadosASerializar);
            }
            catch (ArchivoException)
            {
                throw;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error externo al sistema al intentar serializar el empleado. Clase Administrador. Revisar InnerException", ex);
            }
        }

        /// <summary>
        /// Version de instancia. Lee la lista de empleados que esta respaldada en un archivo, y la carga al sistema.
        /// </summary>
        /// <exception cref="ArchivoException">Error al leer el archivo</exception>
        void IArchivo.LeerArchivo()
        {
            try
            {
                Administrador.LeerArchivoEmpleados();
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Version Estatica. Lee la lista de empleados que esta respaldada en un archivo, y la carga al sistema.
        /// IMPLEMENTA SERIALIZACION, TASK, LAMBDA Y EVENTOS.
        /// </summary>
        /// <exception cref="ArchivoException">Error al leer el archivo</exception>
        public static void LeerArchivoEmpleados()
        {
            try
            {
                Task.Run(() =>
                {
                    if (Administrador.OnLecturaDeFuenteDeDatos is not null)
                    {
                        Administrador.OnLecturaDeFuenteDeDatos("Cargando empleados...");
                    }
                });

                List<Empleado> empleadosDeserializados = SerializadorXml<List<Empleado>>.Leer(Administrador.rutaRelativaArchivo);

                for (int i = 0; i < empleadosDeserializados.Count; i++)
                {
                    Administrador.empleados.CargarElementoAlSistema(empleadosDeserializados[i]);
                }

                Task.Run(() =>
                {
                    if (Administrador.OnCargaCompleta is not null)
                    {
                        Administrador.OnCargaCompleta(25);
                    }
                });
            }
            catch (Exception)
            {
                throw new ArchivoException("No se ha podido leer el archivo de Empleados.");
            }
        }
    }
}
