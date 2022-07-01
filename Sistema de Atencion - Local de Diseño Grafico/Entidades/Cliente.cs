using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Cliente : Persona, IArchivo
    {
        //IMPLEMENTACION EVENTOS
        public static event CargarProgresoDeLecturaHandler OnCargaCompleta;
        public static event LecturaDeDatosHandler OnLecturaDeFuenteDeDatos;

        private const string rutaRelativaArchivo = "Clientes\\clientes";

        private static ListaGenerica<Cliente> clientes;
        private static Cliente clienteTemporal;
        private static ClienteDAO clienteDao;
        private string telefono;

        /// <summary>
        /// Constructor publico para SERIALIZACION. NO UTILIZAR ESTA SOBRECARGA para instanciar.
        /// </summary>
        public Cliente()
        {

        }

        /// <summary>
        /// Constructor estatico de la clase clientes. Inicializa la lista generica, 
        /// un cliente que representara a todos los clientes temporales, Lee y carga el archivo de clientes al sistema.
        /// </summary>
        static Cliente()
        {
            Cliente.clientes = new ListaGenerica<Cliente>();

            Cliente.clienteDao = new ClienteDAO();

            Cliente.clienteTemporal = new Cliente("X", "X", 1000000, "00-0000-0000");
        }

        /// <summary>
        /// Contructor publico de la clase Clientes.
        /// </summary>
        /// <param name="nombre">Nombre cliente</param>
        /// <param name="apellido">Apellido cliente</param>
        /// <param name="dni">Dni cliente</param>
        /// <param name="telefono">telefono cliente.</param>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalida</exception>
        /// <exception cref="NullReferenceException">Datos NULL.</exception>
        public Cliente(string nombre, string apellido, int dni, string telefono)
            : this(nombre, apellido, dni, telefono, Persona.EstaActivo.Activo)
        {
            base.VerificarDniDuplicado();
        }

        /// <summary>
        /// Contructor publico de la clase Clientes.
        /// </summary>
        /// <param name="nombre">Nombre cliente</param>
        /// <param name="apellido">Apellido cliente</param>
        /// <param name="dni">Dni cliente</param>
        /// <param name="telefono">telefono cliente.</param>
        /// <param name="estaActivo">Indica si el cliente esta activo o no.</param>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalida</exception>
        /// <exception cref="NullReferenceException">Datos NULL.</exception>
        internal Cliente(string nombre, string apellido, int dni, string telefono, Persona.EstaActivo estaActivo)
            : base(nombre, apellido, dni)
        {
            this.Telefono = telefono;
            base.estaActivo = estaActivo;
        }

        /// <summary>
        /// Retorna la cantidad de clientes en el sistema.
        /// </summary>
        public static int Count
        {
            get
            {
                return Cliente.clientes.Count;
            }
        }

        /// <summary>
        /// Retorna el telefono del cliente.
        /// Setea el telefono de un cliente, que cumpla con el formato requerido {00-0000-0000}
        /// IMPLEMENTACION METODOS DE EXTENSION.
        /// </summary>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalida</exception>
        /// <exception cref="NullReferenceException">Datos NULL.</exception>
        public string Telefono
        {
            get
            {
                return this.telefono;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if(value.EsFormatoTelefonico())
                    {
                        this.telefono = value;
                    }
                    else
                    {
                        throw new CargaDeDatosInvalidosException("Telefono invalido. Por favor, respete el formato de telefono especificado.");
                    }
                }
                else
                {
                    throw new NullReferenceException("Telefono NULL");
                }
            }
        }

        /// <summary>
        /// Retorna al cliente temporal, que representa a los clientes esporadicos no registrados.
        /// </summary>
        [Browsable(false)]
        public static Cliente ClienteTemporal
        {
            get
            {
                return Cliente.clienteTemporal;
            }
        }

        /// <summary>
        /// Retorna True si el cliente es considerado recurrente (5 o mas compras en los ultimos 30 dias, a partir del dia consultado).
        /// </summary>
        [Browsable(false)]
        public bool EsClienteRecurrente
        {
            get
            {
                bool retorno = false;

                if(this != Cliente.ClienteTemporal)
                {
                    retorno = this.CantidadDeComprasEnUltimoPeriodo(30) >= 7;
                }

                return retorno;
            }
        }

        /// <summary>
        /// Retorna True si el cliente es considerado VIP (Una inversion mayor a los $5.000 en los ultimos 3 meses, a partir del dia consultado).
        /// </summary>
        [Browsable(false)]
        public bool EsClienteVIP
        {
            get
            {
                bool retorno = false;

                if(this != Cliente.ClienteTemporal)
                {
                    retorno = this.InversionTotalHastaHoy(90) > 25000;
                }

                return retorno;
            }
        }

        /// <summary>
        /// Obtiene la inversion total del cliente en el ultimo año, a partir del dia consultado.
        /// </summary>
        public double InversionTotalUltimoAnio
        {
            get
            {
                return this.InversionTotalHastaHoy(365);
            }
        }

        /// <summary>
        /// Obtiene un cliente a partir del indice recibido.
        /// </summary>
        /// <param name="indice">Indice del cliente.</param>
        /// <returns>El cliente encontrado en el indice.</returns>
        /// <exception cref="IndexOutOfRangeException">Indice fuera de rango.</exception>
        public static Cliente ObtenerUnClienteDeLaListaPorIndice(int indice)
        {
            if(indice >= 0 && indice < Cliente.Count)
            {
                return Cliente.clientes[indice];
            }
            throw new IndexOutOfRangeException("Indice Fuera de Rango");
        }

        /// <summary>
        /// Evalua si en la BBDD (tabla Clientes) ya existe un cliente (Activo o No_Activo), a traves del DNI.
        /// </summary>
        /// <param name="dni">Dni cliente.</param>
        /// <returns>True si existe, caso contrario False.</returns>
        protected override bool ExistePersonaPorDni(int dni)
        {
            try
            {
               return !(Cliente.clienteDao.LeerUnRegistroDeBaseDeDatosPorIdentificador(dni) is null);
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Evalua si en la lista del sistema (Activos) ya existe un cliente, a traves del DNI.
        /// </summary>
        /// <param name="dni">Dni cliente</param>
        /// <returns>True si existe, caso contrario False.</returns>
        public static bool ExisteClienteEnSistemaPorDni(int dni)
        {
            return Cliente.clientes.ExisteElementoPorIdentificador(dni);
        }

        /// <summary>
        /// Obtiene un cliente por su DNI.
        /// </summary>
        /// <param name="dni">Dni cliente.</param>
        /// <returns>El cliente encontrado, caso contrario NULL.</returns>
        internal static Cliente ObtenerClientePorDni(int dni)
        {
            Cliente cliente = null;

            for (int i = 0; i < Cliente.Count; i++)
            {
                if (Cliente.clientes[i] == dni)
                {
                    cliente = Cliente.clientes[i];
                    break;
                }
            }
            return cliente;
        }       

        /// <summary>
        /// Calcula la cantidad de compras que realizo el cliente en el ultimo periodo.
        /// </summary>
        /// <param name="dias">Dias a partir de los cuales se quiere obtener la cantidad de compras.</param>
        /// <returns>Cantidad de compras en el periodo indicado.</returns>
        private int CantidadDeComprasEnUltimoPeriodo(int dias)
        {
            List<Compra> comprasCliente = Compra.ObtenerListaComprasDeUnCliente(this);
            DateTime mesPasado = DateTime.Now.AddDays(Math.Abs(dias) * -1);
            int contadorCompras = 0;
            
            foreach(Compra compra in comprasCliente)
            {
                if(compra.FechaCompra > mesPasado)
                {
                    contadorCompras++;
                }
            }
            return contadorCompras;
        }

        /// <summary>
        /// Calcula la inversion total que realizo el cliente en el ultimo periodo.
        /// </summary>
        /// <param name="dias">Dias a partir de los cuales se quiere obtener la inversion total.</param>
        /// <returns>Inversion total en el periodo indicado.</returns>
        private double InversionTotalHastaHoy(int dias)
        {
            List<Compra> comprasCliente = Compra.ObtenerListaComprasDeUnCliente(this);
            DateTime fechaPasada = DateTime.Now.AddDays(Math.Abs(dias) * -1);
            double totalInvertido = 0;
            
            foreach (Compra compra in comprasCliente)
            {
                if (compra.FechaCompra > fechaPasada)
                {
                    totalInvertido += compra.PrecioTotal;  
                }
            }
            return totalInvertido;
        }

        /// <summary>
        /// Obtiene una cadena con todos los datos del cliente.
        /// </summary>
        /// <returns>Una cadena con todos los datos del cliente.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.ToString()}");
            sb.AppendLine($"Telefono: {this.Telefono}");
            sb.AppendLine($"Inversion Anual: ${string.Format("{0:0,0.00}", this.InversionTotalUltimoAnio)}");

            return sb.ToString();    
        }

        /// <summary>
        /// Agrega un cliente en la base de datos y lo carga al sistema.
        /// </summary>
        /// <param name="cliente">cliente a guardar.</param>
        /// <returns>True si pudo cargar al cliente, caso contrario False.</returns>
        /// <exception cref="ArchivoException">Error al intentar cargar en el archivo.</exception>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public static bool CargarUnaClienteAlSistema(Cliente cliente)
        {
            try
            {
                bool retorno = false;

                if (cliente is not null && cliente != Cliente.clienteTemporal)
                {
                    Cliente.clienteDao.InsertarEnBaseDeDatos(cliente);

                    if(Cliente.clientes.CargarElementoAlSistema(cliente))
                    {
                        Task.Run(() =>
                        {
                            try
                            {
                                ((IArchivo)cliente).GuardarArchivo();
                            }
                            catch(Exception)
                            {

                            }
                        });

                        retorno = true;
                    }

                    return retorno; 
                }
                throw new ArgumentNullException("Cliente es NULL o se intenta cargar al cliente por defecto.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Modifica un cliente en la base de datos.
        /// IMPLEMENTA TASK Y LAMBDA.
        /// </summary>
        /// <param name="cliente">cliente modificado.</param>
        /// <returns>True si se opero con exito, caso contrario False.</returns>
        /// <exception cref="ArchivoException">Error al intentar cargar en el archivo.</exception>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public static bool CargarUnClienteModificadoAlSistema(Cliente cliente)
        {
            try
            {
                if (cliente is not null)
                {
                    Cliente.clienteDao.ActualizarEnBaseDeDatos(cliente);

                    Task.Run(() =>
                    {
                        try
                        {
                            ((IArchivo)cliente).GuardarArchivo();
                        }
                        catch (Exception)
                        {

                        }
                    });
                    return true;
                }
                throw new ArgumentNullException("Cliente NULL");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina un cliente en la base de datos y del sistema.
        /// </summary>
        /// <param name="cliente">cliente a eliminar.</param>
        /// <returns>True si se opero con exito, caso contrario False.</returns>
        /// <exception cref="ArchivoException">Error al intentar cargar en el archivo.</exception>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public static bool EliminarUnClienteDelSistema(Cliente cliente)
        {
            try
            {
                bool retorno = false;

                if (cliente is not null)
                {
                    Cliente.clienteDao.EliminarDeBaseDeDatos(cliente);

                    if(Cliente.clientes.EliminarElementoDelSistema(cliente))
                    {
                        Task.Run(() =>
                        {
                            try
                            {
                                ((IArchivo)cliente).GuardarArchivo();
                            }
                            catch (Exception)
                            {

                            }
                        });
                        retorno = true;
                    }

                    return retorno;
                }
                throw new ArgumentNullException("Cliente NULL");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Refresca la lista de clientes, vaciandola y volviendo a cargarla con los clientes.
        /// </summary>
        /// <returns>True su se leyo la lista de la BBDD y se pudo cargar correctamente, caso contrario False.</returns>
        internal static bool RefrescarListaClientes()
        {
            try
            {
                Cliente.clientes.VaciarLista();

                Cliente.CargarClientesAlSistemaDesdeBBDD();

                return true;
            }
            catch (BaseDeDatosException)
            {
                return false;
            }
        }

        /// <summary>
        /// Lee la lista de clientes que esta respaldada en una Base de datos, y la carga al sistema.
        /// Este metodo captura todas las excepciones pero no toma acciones sobre ellas, ya que es invocado unicamente por el constructor estatico.
        /// IMPLEMENTA BBDD, TASK, LAMBDA Y EVENTOS.
        /// </summary>
        /// <exception cref="BaseDeDatosException">Error al leer de la BBDD</exception>
        public static void CargarClientesAlSistemaDesdeBBDD()
        {
            try
            {
                Task.Run(() =>
                {
                    if (Cliente.OnLecturaDeFuenteDeDatos is not null)
                    {
                        Cliente.OnLecturaDeFuenteDeDatos("Cargando clientes...");
                    }
                });

                List<Cliente> clientes = Cliente.clienteDao.LeerTodosLosRegistrosDeBaseDeDatos();

                for (int i = 0; i < clientes.Count; i++)
                {
                    Cliente.clientes.CargarElementoAlSistema(clientes[i]);
                }

                Task.Run(() =>
                {
                    if (Cliente.OnCargaCompleta is not null)
                    {
                        Cliente.OnCargaCompleta(25);
                    }
                });
            }
            catch (Exception)
            {
                throw new BaseDeDatosException("No se ha podido leer correctamente la base de datos: Tabla Clientes");
            }
        }

        /// <summary>
        /// Lee el archivo de clientes y lo carga en la lista del sistema.
        /// IMPLEMENTA SERIALIZACION, TASK, LAMBDA Y EVENTOS.
        /// </summary>
        /// <exception cref="ArchivoException">Error al leer el archivo</exception>
        public static void LeerArchivoClientes()
        {
            try
            {
                Task.Run(() =>
                {
                    if (Cliente.OnLecturaDeFuenteDeDatos is not null)
                    {
                        Cliente.OnLecturaDeFuenteDeDatos("Cargando clientes...");
                    }
                });

                List<Cliente> clientesDeserializados = SerializadorXml<List<Cliente>>.Leer(Cliente.rutaRelativaArchivo);

                for (int i = 0; i < clientesDeserializados.Count; i++)
                {
                    Cliente.clientes.CargarElementoAlSistema(clientesDeserializados[i]);
                }

                Task.Run(() =>
                {
                    if(Cliente.OnCargaCompleta is not null)
                    {
                        Cliente.OnCargaCompleta(25);
                    }
                });
            }
            catch (Exception)
            {
                throw new ArchivoException("No se ha podido leer el archivo de Clientes.");
            }
        }

        /// <summary>
        /// Lee el archivo de clientes y lo carga en la lista del sistema.
        /// IMPLEMENTACION SERIALIZACION.
        /// Este metodo captura todas las excepciones pero no toma acciones sobre ellas, ya que es invocado unicamente por el constructor estatico.
        /// </summary>
        /// <exception cref="ArchivoException">Error al leer el archivo</exception>
        void IArchivo.LeerArchivo()
        {
            try
            {
                Cliente.LeerArchivoClientes();
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Guarda un cliente en archivo. IMPLEMENTACION SERIALIZACION.
        /// </summary>
        /// <returns>True si se guardo el cliente en el archivo.</returns>
        /// <exception cref="ArchivoException">Error relacionado con el archivo.</exception>
        /// <exception cref="ArgumentNullException">Datos NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        internal static bool GuardarArchivoClientes()
        {
            try
            {
                List<Cliente> clientesASerializar = new List<Cliente>();

                for (int i = 0; i < Cliente.Count; i++)
                {
                    clientesASerializar.Add(Cliente.clientes[i]);
                }

                return SerializadorXml<List<Cliente>>.GuardarXml(Cliente.rutaRelativaArchivo, clientesASerializar);
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
                throw new Exception("Ocurrio un error externo al sistema al intentar serializar el cliente. Clase Cliente. Revisar InnerException", ex);
            }
        }

        /// <summary>
        /// Guarda un cliente en archivo. IMPLEMENTACION SERIALIZACION.
        /// </summary>
        /// <returns>True si se guardo el cliente en el archivo.</returns>
        /// <exception cref="ArchivoException">Error relacionado con el archivo.</exception>
        /// <exception cref="ArgumentNullException">Datos NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        bool IArchivo.GuardarArchivo()
        {
            try
            {
                return Cliente.GuardarArchivoClientes();
            }
            catch(Exception)
            {
                throw;
            }           
        }
    }
}
