using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Disenio))]
    [XmlInclude(typeof(Impresion))]
    public abstract class Producto : IObtenerIgualdad, IArchivo
    {
        //IMPLEMENTACION EVENTOS
        public static event CargarProgresoDeLecturaHandler OnCargaCompleta;
        public static event LecturaDeDatosHandler OnLecturaDeFuenteDeDatos;

        private const string rutaRelativaArchivo = "Productos\\productos";

        private static ListaGenerica<Producto> productos;
        private static ProductoDAO productoDao;
        private int idProducto;
        private string nombreProducto;
        private string descripcion;
        private double precioProducto;

        /// <summary>
        /// constructor estatico de la clase Producto.
        /// Inicializa la  lista Generica y lee el archivo de productos para cargarlos en el sistema.
        /// </summary>
        static Producto()
        {
            Producto.productos = new ListaGenerica<Producto>();

            Producto.productoDao = new ProductoDAO();
        }

        /// <summary>
        /// Constructor publico para SERIALIZACION. NO UTILIZAR ESTA SOBRECARGA para instanciar.
        /// </summary>
        public Producto()
        {

        }

        /// <summary>
        /// Constructor de prodcuto, crea un producto asignando el ID recibido.
        /// Este constructor se utiliza para cargar elementos ya existentes o clonar.
        /// </summary>
        /// <param name="nombre">nombre producto</param>
        /// <param name="descripcion">descripcion producto</param>
        /// <param name="precio">precio producto</param>
        /// <param name="id">Id del producto</param>
        protected Producto(string nombre, string descripcion, double precio, int id)
            : this(nombre, descripcion, precio)
        {
            this.IdProducto = id;
        }

        /// <summary>
        /// Constructor de prodcuto, crea un producto asignando el ID recibido.
        /// Este constructor se utiliza para cargar elementos ya existentes o clonar.
        /// </summary>
        /// <param name="nombre">nombre producto</param>
        /// <param name="descripcion">descripcion producto</param>
        /// <param name="precio">precio producto</param>
        protected Producto(string nombre, string descripcion, double precio)
        {
            this.NombreProducto = nombre;
            this.DescripcionProducto = descripcion;
            this.PrecioProducto = precio;
        }

        public abstract string Tipo { get; }

        /// <summary>
        /// Obtiene la cantidad de productos en el sistema.
        /// </summary>
        public static int Count
        {
            get
            {
                return Producto.productos.Count;
            }
        }

        /// <summary>
        /// Obtiene y setea el Id del producto, previa validacion.
        /// </summary>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalidos.</exception>
        public int IdProducto
        {
            get
            {
                return this.idProducto;
            }
            set
            {
                if (value > 0)
                {
                    this.idProducto = value;
                }
                else
                {
                    throw new CargaDeDatosInvalidosException("El id del producto no puede ser 0 o negativo.");
                }
            }
        }

        /// <summary>
        /// Obtiene y setea el nombre del producto previa validacion.
        /// </summary>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalidos.</exception>
        /// <exception cref="NullReferenceException">Datos NULL.</exception>
        public string NombreProducto
        {
            get
            {
                return this.nombreProducto;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (value.EsCadenaAlfanumericaConEspacios())
                    {
                        this.nombreProducto = value.DarFormatoDeNombre();
                    }
                    else
                    {
                        throw new CargaDeDatosInvalidosException("El nombre del producto solo puede contener letras, numeros y/o espacios.");
                    }
                }
                else
                {
                    throw new NullReferenceException("El nombre del producto no puede ser NULL o Vacio o Espacios en blanco");
                }
            }
        }

        /// <summary>
        /// Obtiene y setea la descripcion del producto previa validacion.
        /// </summary>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalidos.</exception>
        /// <exception cref="NullReferenceException">Datos NULL.</exception>
        public string DescripcionProducto
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.descripcion = value.DarFormatoDeDescripcion();
                }
                else
                {
                    throw new NullReferenceException("La descripcion no puede ser NULL o Vacio o Espacios en blanco");
                }
            }
        }

        /// <summary>
        /// Obtiene y setea el precio del producto previa validacion.
        /// </summary>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalidos.</exception>
        public virtual double PrecioProducto
        {
            get
            {
                return this.precioProducto;
            }
            set
            {
                if (value > 0)
                {
                    this.precioProducto = value;
                }
                else
                {
                    throw new CargaDeDatosInvalidosException("El precio del producto no puede ser 0 o negativo.");
                }
            }
        }

        public abstract Producto ClonarProducto<T>(T parametro) where T : struct;

        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        /// <param name="id">id del producto.</param>
        /// <returns>El producto que corresponde al ID, caso contrario NULL.</returns>
        public static Producto ObtenerProductoPorId(int id)
        {
            return Producto.productos.ObtenerElementoPorIdentificador(id);
        }

        /// <summary>
        /// Obtiene un elemento por indice.
        /// </summary>
        /// <param name="indice">indice del elemento que se busca.</param>
        /// <returns>El elemento que corresponde al indice.</returns>
        /// <exception cref="IndexOutOfRangeException">Indice fuera de rango.</exception>
        public static Producto ObtenerUnProductoDeLaListaPorIndice(int indice)
        {
            if (indice >= 0 && indice < Producto.Count)
            {
                return Producto.productos[indice];
            }
            throw new IndexOutOfRangeException("Indice fuera de rango");
        }
              
        /// <summary>
        /// Obtiene una cadena con todos los datos del producto.
        /// </summary>
        /// <returns>Una cadena con todos los datos del producto.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id Producto: {this.IdProducto}");
            sb.AppendLine($"Nombre Producto: {this.NombreProducto}");
            sb.AppendLine($"Descripcion: {this.DescripcionProducto}");
            sb.AppendLine($"Precio Base: ${string.Format("{0:0,0.00}", this.PrecioProducto)}");

            return sb.ToString();
        }

        /// <summary>
        /// Evalua si 2 elementos son iguales.
        /// </summary>
        /// <typeparam name="T">Clase que implemente la interfaz IObtenerIgualdad</typeparam>
        /// <param name="elemento">Elemento que se evaluara.</param>
        /// <returns>True si es el mismo elemento, caso contrario False.</returns>
        public bool EsMismoElemento<T>(T elemento) where T : class, IObtenerIgualdad
        {
            bool retorno = false;
            if(elemento is Producto productoAuxiliar)
            {
                retorno = this == productoAuxiliar;
            }
            return retorno;
        }

        /// <summary>
        /// Evalua si 2 productos son iguales segun el identificador (id)
        /// </summary>
        /// <param name="identificador">identificador</param>
        /// <returns>True si es el misma, caso contrario False.</returns>
        public bool EsMismoIdentificador(int identificador)
        {
            return this == identificador;
        }

        /// <summary>
        /// Agrega un producto en la base de datos, obtiene su Id, lo carga al sistema y lo retorna con el Id correspondiente.
        /// </summary>
        /// <param name="producto">producto a guardar.</param>
        /// <returns>El producto almacenado, con el ID correspondiente.</returns>
        /// <exception cref="ArchivoException">Error al intentar cargar en el archivo.</exception>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public static Producto CargarUnProductoAlSistema(Producto producto)
        {
            Producto ultimoProducto;

            try
            {
                if (producto is not null)
                {
                    Producto.productoDao.InsertarEnBaseDeDatos(producto);

                    ultimoProducto = productoDao.ObtenerUltimoElementoCargadoEnBaseDeDatos();

                    if(Producto.productos.CargarElementoAlSistema(ultimoProducto))
                    {
                        Task.Run(() =>
                        {
                            try
                            {
                                ((IArchivo)producto).GuardarArchivo();
                            }
                            catch (Exception)
                            {

                            }
                        });
                    }

                    return ultimoProducto;
                }
                throw new ArgumentNullException("Producto es NULL");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Modifica un producto en la base de datos.
        /// </summary>
        /// <param name="producto">Producto modificado.</param>
        /// <returns>True si se opero con exito, caso contrario False.</returns>
        /// <exception cref="ArchivoException">Error al intentar cargar en el archivo.</exception>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public static bool CargarUnProductoModificadoAlSistema(Producto producto)
        {
            try
            {
                if (producto is not null)
                {
                    Producto.productoDao.ActualizarEnBaseDeDatos(producto);

                    Task.Run(() =>
                    {
                        try
                        {
                            ((IArchivo)producto).GuardarArchivo();
                        }
                        catch(Exception)
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
        /// Elimina un producto en la base de datos y del sistema.
        /// </summary>
        /// <param name="producto">Producto a eliminar.</param>
        /// <returns>True si se opero con exito, caso contrario False.</returns>
        /// <exception cref="ArchivoException">Error al intentar cargar en el archivo.</exception>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public static bool EliminarUnProductoDelSistema(Producto producto)
        {
            try
            {
                bool retorno = false;

                if (producto is not null)
                {
                    Producto.productoDao.EliminarDeBaseDeDatos(producto);

                    if(Producto.productos.EliminarElementoDelSistema(producto))
                    {
                        Task.Run(() =>
                        {
                            try
                            {
                                ((IArchivo)producto).GuardarArchivo();
                            }
                            catch (Exception)
                            {

                            }
                        });
                        retorno = true;
                    }

                    return retorno;
                }
                throw new ArgumentNullException("Producto NULL");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee la lista de productos que esta respaldada en una Base de datos, y la carga al sistema.
        /// IMPLEMENTA SERIALIZACION, TASK, LAMBDA Y EVENTOS.
        /// </summary>
        /// <exception cref="BaseDeDatosException">Error al leer de la BBDD</exception>
        public static void CargarProductosAlSistemaDesdeBBDD()
        {
            try
            {
                Task.Run(() =>
                {
                    if (Producto.OnLecturaDeFuenteDeDatos is not null)
                    {
                        Producto.OnLecturaDeFuenteDeDatos("Cargando productos...");
                    }
                });

                List<Producto> productos = Producto.productoDao.LeerTodosLosRegistrosDeBaseDeDatos();

                for (int i = 0; i < productos.Count; i++)
                {
                    Producto.productos.CargarElementoAlSistema(productos[i]);
                }

                Task.Run(() =>
                {
                    if (Producto.OnCargaCompleta is not null)
                    {
                        Producto.OnCargaCompleta(25);
                    }
                });
            }
            catch (Exception)
            {
                throw new BaseDeDatosException("No se ha podido leer correctamente la base de datos: Tabla Productos");
            }
        }

        /// <summary>
        /// Lee la lista de productos que esta respaldada en un archivo, y la carga al sistema.
        /// IMPLEMENTA SERIALIZACION, TASK, LAMBDA Y EVENTOS.
        /// </summary>
        /// <exception cref="ArchivoException">Error al leer el archivo</exception>
        public static void LeerArchivoProductos()
        {
            try
            {
                Task.Run(() =>
                {
                    if (Producto.OnLecturaDeFuenteDeDatos is not null)
                    {
                        Producto.OnLecturaDeFuenteDeDatos("Cargando productos...");
                    }
                });

                List<Producto> productosDeserializados = SerializadorXml<List<Producto>>.Leer(Producto.rutaRelativaArchivo);

                for (int i = 0; i < productosDeserializados.Count; i++)
                {
                    Producto.productos.CargarElementoAlSistema(productosDeserializados[i]);
                }

                Task.Run(() =>
                {
                    if (Producto.OnCargaCompleta is not null)
                    {
                        Producto.OnCargaCompleta(25);
                    }
                });
            }
            catch (Exception)
            {
                throw new ArchivoException("No se ha podido leer el archivo de Productos.");
            }
        }

        /// <summary>
        /// Lee la lista de productos que esta respaldada en un archivo, y la carga al sistema.
        /// Este metodo captura todas las excepciones pero no toma acciones sobre ellas, ya que es invocado unicamente por el constructor estatico.
        /// </summary>
        /// <exception cref="ArchivoException">Error al leer el archivo</exception>
        void IArchivo.LeerArchivo()
        {
            try
            {
                Producto.LeerArchivoProductos();          
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Guarda la lista de productos en un archivo, respaldando la informacion.
        /// </summary>
        /// <returns>True si pudo guardar, caso contrario False.</returns>
        /// <exception cref="ArchivoException">Error referente al archivo.</exception>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        bool IArchivo.GuardarArchivo()
        {
            try
            {
                List<Producto> productosASerializar = new List<Producto>();

                for (int i = 0; i < Producto.Count; i++)
                {
                    productosASerializar.Add(Producto.productos[i]);
                }

                return SerializadorXml<List<Producto>>.GuardarXml(Producto.rutaRelativaArchivo, productosASerializar);
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
                throw new Exception("Ocurrio un error externo al sistema al intentar serializar el producto. Clase Producto. Revisar InnerException", ex);
            }
        }

        public static bool operator ==(Producto producto, int id)
        {
            bool retorno = false;

            if(producto is not null)
            {
                retorno = producto.IdProducto == id;
            }
            return retorno;
        }
        
        public static bool operator !=(Producto producto, int id)
        {
            return !(producto == id);
        }
                
        public static bool operator == (Producto productoUno, Producto productoDos)
        {
            bool retorno = false;

            if(productoUno is not null && productoDos is not null)
            {
                retorno = productoUno.IdProducto == productoDos.IdProducto;
            }

            return retorno;
        }
        
        public static bool operator !=(Producto productoUno, Producto productoDos)
        {
            return !(productoUno == productoDos);
        }
    }
}
