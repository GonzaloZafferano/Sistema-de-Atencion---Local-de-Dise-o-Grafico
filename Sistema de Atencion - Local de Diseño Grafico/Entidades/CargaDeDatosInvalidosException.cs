using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CargaDeDatosInvalidosException : Exception
    {
        /// <summary>
        /// Representa una excepcion ocurrida durante la carga de datos.
        /// </summary>
        /// <param name="message">Mensaje de la excepcion.</param>
        public CargaDeDatosInvalidosException(string message) : base(message)
        {
        }

        /// <summary>
        /// Representa una excepcion ocurrida durante la carga de datos.
        /// </summary>
        /// <param name="message">Mensaje de la excepcion.</param>
        /// <param name="innerException">Excepcion interna.</param>
        public CargaDeDatosInvalidosException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
