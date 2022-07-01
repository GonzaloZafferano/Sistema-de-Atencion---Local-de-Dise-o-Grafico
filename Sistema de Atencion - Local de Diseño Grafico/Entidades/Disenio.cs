using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Disenio : Producto
    {
        public enum Tamanio { Chico = 1, Mediano = 2, Grande = 3 }

        private Tamanio tamanio;

        /// <summary>
        /// Contructor de clase Disenio. Crea un nuevo objeto con un nuevo ID.
        /// </summary>
        /// <param name="nombre">Nombre del producto.</param>
        /// <param name="descripcion">Descripcion del producto.</param>
        /// <param name="precio">Precio del producto.</param>
        /// <param name="tamanio">Tamaño del diseño.</param>
        public Disenio(string nombre, string descripcion, double precio, Tamanio tamanio)
            : base(nombre, descripcion, precio)
        {
            this.TamanioDisenio = tamanio;
        }

        /// <summary>
        /// Constructor publico para SERIALIZACION. NO UTILIZAR ESTA SOBRECARGA para instanciar.
        /// </summary>
        public Disenio()
        {

        }

        /// <summary>
        /// Contructor de clase Disenio. Crea un objeto con el ID recibido.
        /// Este constructor se utiliza para cargar elementos ya existentes o clonar.
        /// </summary>
        /// <param name="nombre">Nombre del producto.</param>
        /// <param name="descripcion">Descripcion del producto.</param>
        /// <param name="precio">Precio del producto.</param>
        /// <param name="tamanio">Tamaño del diseño.</param>
        /// <param name="id">Id del producto.</param>
        internal Disenio(string nombre, string descripcion, double precio, Tamanio tamanio, int id)
            : base(nombre, descripcion, precio, id)
        {
            this.TamanioDisenio = tamanio;
        }

        /// <summary>
        /// Obtiene y setea (serializacion) el tamaño del diseño.
        /// </summary>
        public Tamanio TamanioDisenio
        {
            get
            {
                return this.tamanio;
            }
            set
            {
                this.tamanio = value;
            }
        }

        /// <summary>
        /// Obtiene el tipo de producto.
        /// </summary>
        public override string Tipo
        {
            get
            {
                return "Diseño";
            }
        }

        /// <summary>
        /// Obtiene el precio del produto.
        /// </summary>
        public override double PrecioProducto 
        { 
            get
            {
                return base.PrecioProducto * (int)this.tamanio;
            }
        }

        /// <summary>
        /// Obtiene una cadena con todos los datos del producto.
        /// </summary>
        /// <returns>Una cadena con todos los datos del producto.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"Tamaño: {this.TamanioDisenio}");

            return sb.ToString();
        }

        /// <summary>
        /// Clona un producto de tipo Disenio.
        /// </summary>
        /// <typeparam name="T">Enumerado Tamanio</typeparam>
        /// <param name="parametro">elemento a clonar.</param>
        /// <returns>Un clon del producto.</returns>
        /// <exception cref="NullReferenceException">Producto NULL</exception>
        public override Disenio ClonarProducto<T>(T parametro) 
        {
            if(parametro is Tamanio tamanio)
            {
                return new Disenio(this.NombreProducto, this.DescripcionProducto, this.PrecioProducto, tamanio, this.IdProducto);
            }

            throw new NullReferenceException("Diseño NULL");
        }
    }
}
