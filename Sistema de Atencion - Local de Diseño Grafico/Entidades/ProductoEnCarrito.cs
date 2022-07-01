using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductoEnCarrito : IObtenerIgualdad
    {
        private static int contadorIdsTemporal;
        private Producto producto;
        private int cantidad;
        private string descripcion;
        private int idTemporal;

        /// <summary>
        /// Constructor estatico de Producto en carrito. Inicializa un contador de Ids temporal
        /// </summary>
        static ProductoEnCarrito()
        {
            ProductoEnCarrito.contadorIdsTemporal = 0;
        }

        /// <summary>
        /// Constructor de clase.
        /// </summary>
        /// <param name="producto">nombre producto</param>
        /// <param name="cantidad">cantidad producto</param>
        /// <param name="descripcion">descripcion producto</param>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalida.</exception>
        /// <exception cref="NullReferenceException">Datos NULL</exception>
        public ProductoEnCarrito(Producto producto, int cantidad, string descripcion)
        {
            this.Producto = producto;
            this.Cantidad = cantidad;
            this.DescripcionProducto = descripcion;
            this.idTemporal = ++ProductoEnCarrito.contadorIdsTemporal;
        }

        /// <summary>
        /// Obtiene el id temporal del producto en carrito.
        /// </summary>
        [Browsable(false)]
        public int IdTemporalProductoEnCarrito
        {
            get
            {
                return this.idTemporal;
            }
        }

        /// <summary>
        /// Obtiene el producto en carrito.
        /// </summary>
        [Browsable(false)]
        public Producto Producto
        {
            get
            {
                return this.producto;
            }
            private set
            {
                if(value is not null)
                {
                    this.producto = value;
                }
                else
                {
                    throw new NullReferenceException("Producto es NULL");
                }
            }
        }

        /// <summary>
        /// Obtiene la cantidad del producto.
        /// </summary>
        public int Cantidad
        {
            get
            {
                return this.cantidad;
            }
            private set
            {
                if(value > 0)
                {
                    this.cantidad = value;
                }
                else
                {
                    throw new CargaDeDatosInvalidosException($"La cantidad del producto '{this.Producto.NombreProducto}' en carrito no puede ser 0 o negativa.");
                }
            }
        }

        /// <summary>
        /// Obtiene la descripcion del producto en carrito.
        /// </summary>
        public string DescripcionProducto
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(this.producto.ToString());
                sb.AppendLine($"Detalles adicionales: {(string.IsNullOrWhiteSpace(this.descripcion)? "-" : this.descripcion)}");

                return sb.ToString();
            }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.descripcion = value.DarFormatoDeDescripcion();
                }
            }
        }

        /// <summary>
        /// Obtiene el id del producto que se cargo en el carrito.
        /// </summary>
        public int IdProducto
        {
            get
            {
                return this.Producto.IdProducto;
            }          
        }

        /// <summary>
        /// Obtiene el nombre del producto que se cargo en el carrito.
        /// </summary>
        public string NombreProducto
        {
            get
            {
                return this.Producto.NombreProducto;
            }
        }      

        /// <summary>
        /// Obtiene el precio X unidad del producto.
        /// </summary>
        public double PrecioUnitarioProductoEnCarrito
        {
            get
            {
                return this.Producto.PrecioProducto;  
            }         
        }

        /// <summary>
        /// Obtiene el precio por Cantidad del producto cargado en carrito.
        /// </summary>
        public double PrecioTotalProductoEnCarrito
        {
            get
            {
                return this.PrecioUnitarioProductoEnCarrito * this.Cantidad;
            }
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

            if(elemento is ProductoEnCarrito productoAuxiliar)
            {
                retorno = productoAuxiliar.IdTemporalProductoEnCarrito == this.IdTemporalProductoEnCarrito;
            }
            return retorno;
        }

        /// <summary>
        /// Evalua si 2 elementos son iguales segun el identificador (dni)
        /// </summary>
        /// <param name="identificador">identificador</param>
        /// <returns>True si es el misma, caso contrario False.</returns>
        public bool EsMismoIdentificador(int identificador)
        {
            return this.IdTemporalProductoEnCarrito == identificador;
        }
    }
}
