using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Impresion : Producto
    {
        private bool tieneColor;

        /// <summary>
        /// Constructor publico para SERIALIZACION. NO UTILIZAR ESTA SOBRECARGA para instanciar.
        /// </summary>
        public Impresion()
        {

        }

        /// <summary>
        /// Contructor de la clase Impresion. Crea un nuevo objeto con nuevo ID.
        /// </summary>
        /// <param name="nombre">Nombre de la impresion.</param>
        /// <param name="descripcion">Descripcion de la impresion.</param>
        /// <param name="precio">Precio de la impresion.</param>
        /// <param name="tieneColor">Tiene color.</param>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalida</exception>
        /// <exception cref="NullReferenceException">Datos NULL.</exception>
        public Impresion(string nombre, string descripcion, double precio, bool tieneColor)
         : base(nombre, descripcion, precio)
        {
            this.TieneColor = tieneColor;

        }

        /// <summary>
        /// Contructor de la clase Impresion. Crea un objeto, asignandole el ID recibido.
        /// Utilizar este constructor para clonacion de Impresiones.
        /// </summary>
        /// <param name="nombre">Nombre de la impresion.</param>
        /// <param name="descripcion">Descripcion de la impresion.</param>
        /// <param name="precio">Precio de la impresion.</param>
        /// <param name="tieneColor">Tiene color.</param>
        /// <param name="id">Id del producto</param>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalida</exception>
        /// <exception cref="NullReferenceException">Datos NULL.</exception>
        internal Impresion(string nombre, string descripcion, double precio, bool tieneColor, int id)
            : base(nombre, descripcion, precio, id)
        {
            this.TieneColor = tieneColor;
        }

        /// <summary>
        /// Retorna True si el objeto tiene color, caso contrario False.
        /// </summary>
        public bool TieneColor
        {
            get
            {
                return this.tieneColor;
            }
            set
            {
                this.tieneColor = value;
            }
        }

        /// <summary>
        /// Retorna el tipo de del objeto.
        /// </summary>
        public override string Tipo
        {
            get
            {
                return "Impresion";
            }
        }

        /// <summary>
        /// Retorna el precio del producto, x1 si no tiene color, x2 si tiene color.
        /// </summary>
        public override double PrecioProducto 
        {
            get
            {
                return base.PrecioProducto * (!this.TieneColor ? 1 : 2);
            }
        }

        /// <summary>
        /// Obtiene una cadena con todos los datos del producto y sus detalles.
        /// </summary>
        /// <returns>Una cadena con todos los datos del producto y sus detalles.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"Color: {(this.TieneColor ? "SI" : "NO")}");

            return sb.ToString();
        }

        /// <summary>
        /// Clona un objeto de tipo Impresion, manteniendo su ID.
        /// </summary>
        /// <typeparam name="T">Parametro booleano que determina si el clon tendra color o no.</typeparam>
        /// <param name="parametro">Tipo Booleano</param>
        /// <returns>El producto clonado</returns>
        /// <exception cref="NullReferenceException">No se pudo clonar.</exception>
        public override Impresion ClonarProducto<T>(T parametro) 
        {   
            if(parametro is bool tieneColor)
            {
                return new Impresion(this.NombreProducto, this.DescripcionProducto, this.PrecioProducto, tieneColor, this.IdProducto);
            }
            throw new NullReferenceException("Impresion NULL");
        }
    }
}
