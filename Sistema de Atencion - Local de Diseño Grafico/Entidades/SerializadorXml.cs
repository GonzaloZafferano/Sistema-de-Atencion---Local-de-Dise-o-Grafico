using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    internal static class SerializadorXml<T> where T : class, new()
    {
        private const string extension = ".xml";

        /// <summary>
        /// Serializa un elemento en formato XML y lo guarda en un archivo.
        /// IMPLEMENTACION DE SERIALIZACION.
        /// </summary>
        /// <param name="rutaRelativaArchivo">ruta relativa del archivo de destino.</param>
        /// <param name="elemento">elemento</param>
        /// <returns>True si pudo guardar con exito.</returns>
        /// <exception cref="ArchivoException">Error con la ruta.</exception>
        /// <exception cref="ArgumentNullException">Ruta null.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public static bool GuardarXml(string rutaRelativaArchivo, T elemento)
        {
            string rutaSeguraParaGuardar;
            try
            {
                if(!string.IsNullOrWhiteSpace(rutaRelativaArchivo) && elemento is not null)
                {
                    if (!rutaRelativaArchivo.EndsWith(SerializadorXml<T>.extension))
                    {
                        rutaRelativaArchivo += SerializadorXml<T>.extension;
                    }

                    rutaSeguraParaGuardar = Archivo.ObtenerUnaRutaValidaDelArchivoParaGuardar(rutaRelativaArchivo);

                    using (StreamWriter sw = new StreamWriter(rutaSeguraParaGuardar))
                    {
                        XmlSerializer xml = new XmlSerializer(typeof(T));
                        xml.Serialize(sw, elemento);
                        return true;
                    }
                }
                throw new ArgumentNullException("La ruta relativa del archivo o el elemento a serializar es NULL");
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
                throw new Exception("Fallo externo al sistema. Clase SerializadorXml. Revisar InnerException", ex);
            }
        }

        /// <summary>
        /// Lee un archivo para deserializar el objeto en formato XML.
        /// IMPLEMENTACION DE SERIALIZACION.
        /// </summary>
        /// <param name="rutaRelativaArchivo"></param>
        /// <returns>Elemento deserializado.</returns>
        /// <exception cref="ArchivoException">Error con la ruta.</exception>
        /// <exception cref="ArgumentNullException">Ruta null.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public static T Leer(string rutaRelativaArchivo)
        {
            string rutaSeguraParaLeer;
            try
            {
                if (!string.IsNullOrWhiteSpace(rutaRelativaArchivo))
                {
                    if (!rutaRelativaArchivo.EndsWith(SerializadorXml<T>.extension))
                    {
                        rutaRelativaArchivo += SerializadorXml<T>.extension;
                    }

                    rutaSeguraParaLeer = Archivo.ObtenerUnaRutaValidaDelArchivoParaLeer(rutaRelativaArchivo);

                    using (StreamReader sr = new StreamReader(rutaSeguraParaLeer))
                    {
                        XmlSerializer xml = new XmlSerializer(typeof(T));

                        if (xml.Deserialize(sr) is T elemento)
                        {
                            return elemento;
                        }

                        throw new ArchivoException("El elemento deserializado no corresponde con el tipo de dato esperado.");
                    }
                }
                throw new ArgumentNullException("La ruta relativa del archivo es NULL");
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
                throw new Exception("Fallo externo al sistema. Clase SerializadorXml. Revisar InnerException", ex);
            }
        }
    }
}
