using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CarritoDeCompra
    {
        private ListaGenerica<ProductoEnCarrito> productosEnCarrito;
        private int dniCliente;

        /// <summary>
        /// Constructor de CarritoDeCompra. Crea un nuevo carrito de compras.
        /// </summary>
        /// <param name="dniCliente">Cliente dueño del carrito de compras.</param>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalida</exception>
        public CarritoDeCompra(int dniCliente)
        {
            productosEnCarrito = new ListaGenerica<ProductoEnCarrito>();
            this.DniCliente = dniCliente;
        }

        /// <summary>
        /// Cantidad de productos en el carrito de compras.
        /// </summary>
        public int Count
        {
            get
            {
                return this.productosEnCarrito.Count;
            }
        }

        /// <summary>
        /// Retorna el Dni del cliente dueño del carrito de compras.
        /// Setea el DNI previa validacion.
        /// </summary>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalidos.</exception>
        public int DniCliente
        {
            get
            {
                return this.dniCliente;
            }
            private set
            {
                if(value >=1000000 && value <=99999999)
                {
                    dniCliente = value;
                }
                else
                {
                    throw new CargaDeDatosInvalidosException("El Dni del cliente es invalido.");
                }
            }
        }

        /// <summary>
        /// Retorna el precio total acumulado en el carrito de compras, SIN el descuento.
        /// </summary>
        public double PrecioTotalAcumuladoEnCarritoSinDescuentoIncluido
        {
            get
            {
                double retorno = 0;
                for(int i = 0; i < this.productosEnCarrito.Count; i++)
                {
                    retorno += this.productosEnCarrito[i].PrecioTotalProductoEnCarrito;
                }
                return retorno;
            }
        }

        /// <summary>
        /// Retorna el precio total acumulado en el carrito de compras, CON el descuento.
        /// </summary>
        public double PrecioFinalAcumuladoEnCarritoConDescuentoIncluido
        {
            get
            {
                return this.PrecioTotalAcumuladoEnCarritoSinDescuentoIncluido -
                    (this.PrecioTotalAcumuladoEnCarritoSinDescuentoIncluido * this.DescuentoAplicado()/100);
            }
        }

        /// <summary>
        /// Retorna el descuento aplicado al cliente.
        /// </summary>
        public int Descuento
        {
            get
            {
                return this.DescuentoAplicado();
            }
        }

        /// <summary>
        /// Calcula el descuento que le corresponde al cliente.
        /// </summary>
        /// <returns>El descuento aplicado al cliente.</returns>
        private int DescuentoAplicado()
        {
            int descuento = 0;

            Cliente cliente = Cliente.ObtenerClientePorDni(this.dniCliente);

            if (cliente is not null)
            {
                descuento += cliente.EsClienteRecurrente ? 5 : 0;
                descuento += cliente.EsClienteVIP ? 5 : 0;
            }
            return descuento;
        }

        /// <summary>
        /// Carga un producto al carrito de compras.
        /// </summary>
        /// <param name="producto">Producto a cargar.</param>
        /// <returns>True si se pudo cargar el producto, caso contrario False.</returns>
        public bool CargarProductoEnCarrito(ProductoEnCarrito producto)
        {
            return this.productosEnCarrito.CargarElementoAlSistema(producto);
        }

        /// <summary>
        /// Elimina un producto del carrito de compras.
        /// </summary>
        /// <param name="producto">Producto a eliminar.</param>
        /// <returns>True si lo pudo eliminar, caso contrario False.</returns>
        public bool EliminarProductoDelCarrito(ProductoEnCarrito producto)
        {
            return this.productosEnCarrito.EliminarElementoDelSistema(producto);
        }

        /// <summary>
        /// Obtiene un producto a traves de su id.
        /// </summary>
        /// <param name="id">Id del producto.</param>
        /// <returns>El producto en carrito, NULL si no lo encontro.</returns>
        /// <exception cref="NullReferenceException">Producto no existe.</exception>
        public ProductoEnCarrito ObtenerProductoEnCarritoPorId(int id)
        {
            return this.productosEnCarrito.ObtenerElementoPorIdentificador(id);
        }

        /// <summary>
        /// Obtiene un producto en carrito a traves de su indice.
        /// </summary>
        /// <param name="indice">Indice del producto</param>
        /// <returns>El producto en el indice especificado.</returns>
        /// <exception cref="IndexOutOfRangeException">Indice fuera de rango.</exception>
        public ProductoEnCarrito ObtenerUnProductoDelCarritoPorIndice(int indice)
        {     
            if (indice >= 0 && indice < this.Count)
            {
                return this.productosEnCarrito[indice];
            }
            throw new IndexOutOfRangeException("Indice Fuera de Rango");
        }

        /// <summary>
        /// Retorna una cadena con todos los productos en el carrito y sus detalles.
        /// </summary>
        /// <returns>Una cadena con todos los productos en el carrito y sus detalles.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<----Productos en carrito---->");

            for(int i = 0; i < this.productosEnCarrito.Count; i++)
            {
                sb.Append($"{i + 1}) ");
                sb.Append($"{this.productosEnCarrito[i].NombreProducto}. ");
                sb.Append(this.productosEnCarrito[i].DescripcionProducto);
                sb.Append($"(${string.Format("{0:0,0.00}", this.productosEnCarrito[i].PrecioUnitarioProductoEnCarrito)} x ");
                sb.Append($"{this.productosEnCarrito[i].Cantidad} unidades = ");
                sb.AppendLine($"${string.Format("{0:0,0.00}", this.productosEnCarrito[i].PrecioTotalProductoEnCarrito)})");
            }

            return sb.ToString();
        }
    }
}
