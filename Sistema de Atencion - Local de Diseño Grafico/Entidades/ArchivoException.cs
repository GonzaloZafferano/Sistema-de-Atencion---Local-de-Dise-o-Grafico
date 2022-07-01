using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArchivoException : Exception
    {
        /// <summary>
        /// Representa una excepcion ocurrida con los Archivoa.
        /// </summary>
        /// <param name="message">Mensaje de la excepcion.</param>
        public ArchivoException(string message) : base(message)
        {
        }

        /// <summary>
        /// Representa una excepcion ocurrida con los Archivoa.
        /// </summary>
        /// <param name="message">Mensaje de la excepcion.</param>
        /// <param name="innerException">Excepcion interna.</param>
        public ArchivoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
