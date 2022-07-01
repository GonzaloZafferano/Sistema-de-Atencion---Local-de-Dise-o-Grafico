using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entidades
{
    internal static class SerializadorJSON<T> where T : class
    {
        private const string extension = ".json";

        /// <summary>
        /// Serializa un elemento en formato JSON y lo guarda en un archivo.
        /// IMPLEMENTACION DE SERIALIZACION.
        /// </summary>
        /// <param name="rutaRelativaArchivo">ruta relativa del archivo de destino.</param>
        /// <param name="elemento">elemento</param>
        /// <returns>True si pudo guardar con exito.</returns>
        /// <exception cref="ArchivoException">Error con la ruta.</exception>
        /// <exception cref="ArgumentNullException">Ruta null.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public static bool GuardarJSON(string rutaRelativaArchivo, T elemento)
        {
            string jsonSerializado;

            try
            {
                if (!string.IsNullOrWhiteSpace(rutaRelativaArchivo) && elemento is not null)
                {
                    if (!rutaRelativaArchivo.EndsWith(SerializadorJSON<T>.extension))
                    {
                        rutaRelativaArchivo += SerializadorJSON<T>.extension;
                    }

                    jsonSerializado = JsonSerializer.Serialize(elemento);

                    return Archivo.Guardar(rutaRelativaArchivo, jsonSerializado);
                }
                throw new ArgumentNullException("La ruta relativa del archivo o el elemento a serializar es NULL");
            }
            catch (ArchivoException)
            {
                throw;
            }
            catch(ArgumentNullException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new Exception("Fallo externo al sistema. Clase SerializadorJSON. Revisar InnerException", ex);
            }            
        }

        /// <summary>
        /// Lee un archivo para deserializar el objeto en formato JSON.
        /// IMPLEMENTACION DE SERIALIZACION.
        /// </summary>
        /// <param name="rutaRelativaArchivo"></param>
        /// <returns>Elemento deserializado.</returns>
        /// <exception cref="ArchivoException">Error con la ruta.</exception>
        /// <exception cref="ArgumentNullException">Ruta null.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public static T Leer(string rutaRelativaArchivo)
        {
            string jsonFormatoString;
            try
            {
                if(!string.IsNullOrWhiteSpace(rutaRelativaArchivo))
                {
                    if (!rutaRelativaArchivo.EndsWith(SerializadorJSON<T>.extension))
                    {
                        rutaRelativaArchivo += SerializadorJSON<T>.extension;
                    }

                    jsonFormatoString = Archivo.Leer(rutaRelativaArchivo);
                
                    if(JsonSerializer.Deserialize(jsonFormatoString, typeof(T)) is T elemento)
                    {
                        return elemento;
                    }

                    throw new ArchivoException("El elemento deserializado no corresponde con el tipo de dato esperado.");
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
                throw new Exception("Fallo externo al sistema. Clase SerializadorJSON. Revisar InnerException", ex);
            }
        }
    }
}
