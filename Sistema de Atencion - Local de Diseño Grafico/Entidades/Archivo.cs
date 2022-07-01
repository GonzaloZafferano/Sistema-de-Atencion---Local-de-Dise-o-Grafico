using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal static class Archivo
    {
        private const string extension = ".txt";
        private static readonly string rutaDeDirectorioBase;
        private static readonly char caracterSeparador;

        /// <summary>
        /// Constructor estatico de la clase Archivo. Carga ruta base donde se guardaran todos los archivos.
        /// </summary>
        static Archivo()
        {
            Archivo.caracterSeparador = Path.DirectorySeparatorChar;

            Archivo.rutaDeDirectorioBase = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RespaldoArchivos");
        }

        /// <summary>
        /// Obtiene una ruta absoluta del archivo o directorio, al combinar la ruta relativa recibida por parametro 
        /// con la ruta base donde se guardan todos los archivos.
        /// </summary>
        /// <param name="rutaRelativa">Ruta relativa del archivo o directorio.</param>
        /// <returns>Ruta absoluta del archivo (si recibio como argumento una ruta relativa de un archivo) 
        /// o ruta absoluta del directorio (si recibio como argumento una ruta relativa de un directorio).</returns>
        /// <exception cref="ArgumentNullException">Parametro null.</exception>
        private static string ObtenerRutaAbsolutaDeArchivoODirectorioAPartirDeUnaRutaRelativa(string rutaRelativa)
        {
            string rutaAbsoluta;
            if(!string.IsNullOrWhiteSpace(rutaRelativa))
            {
                rutaAbsoluta = Path.Combine(Archivo.rutaDeDirectorioBase, rutaRelativa);

                rutaAbsoluta = rutaAbsoluta.Replace('\\', Archivo.caracterSeparador);

                rutaAbsoluta = rutaAbsoluta.Replace('/', Archivo.caracterSeparador);

                return rutaAbsoluta;
            }
            throw new ArgumentNullException("La ruta relativa es NULL");
        }

        /// <summary>
        /// Obtiene unicamente la ruta completa de los directorios, a partir de una ruta absoluta de un archivo.
        /// </summary>
        /// <param name="rutaAbsolutaDelArchivo">Ruta absoluta del archivo</param>
        /// <returns>Ruta completa del directorio.</returns>        
        /// <exception cref="ArchivoException">Error con la ruta.</exception>
        private static string ObtenerRutaAbsolutaDelDirectorioAPartirDeUnaRutaAbsolutaDeUnArchivo(string rutaAbsolutaDelArchivo)
        {
            string rutaCompletaDelDirectorio = rutaAbsolutaDelArchivo.Substring(0, rutaAbsolutaDelArchivo.LastIndexOf(Archivo.caracterSeparador) +1);

            if(string.IsNullOrWhiteSpace(rutaCompletaDelDirectorio))
            {
                throw new ArchivoException($"La ruta del archivo '{rutaAbsolutaDelArchivo}' es Invalida");
            }        
            return rutaCompletaDelDirectorio;            
        }

        /// <summary>
        /// Obtiene el nombre y extension de un archivo a partir de una ruta absoluta.
        /// </summary>
        /// <param name="rutaAbsolutaDelArchivo">Ruta absoluta del archivo.</param>
        /// <returns>Nombre y extension del archivo.</returns>
        /// <exception cref="ArchivoException">Ruta invalida.</exception>
        private static string ObtenerNombreDelArchivo(string rutaAbsolutaDelArchivo)
        {
            if(rutaAbsolutaDelArchivo.Contains(Archivo.caracterSeparador))
            {
                return rutaAbsolutaDelArchivo.Substring(rutaAbsolutaDelArchivo.LastIndexOf(Archivo.caracterSeparador) +1);            
            }          
            throw new ArchivoException($"La ruta absoluta '{rutaAbsolutaDelArchivo}' es invalida");
        }

        /// <summary>
        /// Obtiene una ruta segura para guardar archivos, creando los directorios indicados en caso de no existir,
        /// siempre y cuando la ruta no contenga errores o caracteres invalidos.
        /// </summary>
        /// <param name="rutaRelativaArchivo">Ruta relativa del archivo.</param>
        /// <returns>Una ruta segura para operar con archivos.</returns>
        /// <exception cref="ArchivoException">Error con la ruta.</exception>
        internal static string ObtenerUnaRutaValidaDelArchivoParaGuardar(string rutaRelativaArchivo) 
        {
            string rutaAbsolutaDelArchivo = Archivo.ObtenerRutaAbsolutaDeArchivoODirectorioAPartirDeUnaRutaRelativa(rutaRelativaArchivo);

            string rutaAbsolutaDelDirectorio = Archivo.ObtenerRutaAbsolutaDelDirectorioAPartirDeUnaRutaAbsolutaDeUnArchivo(rutaAbsolutaDelArchivo);

            if(Directory.Exists(rutaAbsolutaDelDirectorio) || Directory.CreateDirectory(rutaAbsolutaDelDirectorio).Exists)
            {
                return rutaAbsolutaDelArchivo;
            }
            throw new ArchivoException($"No se pudo obtener un directorio valido de la ruta '{rutaAbsolutaDelDirectorio}'.");           
        }

        /// <summary>
        /// Obtiene una ruta segura para leer archivos, uniendo la ruta relativa con la ruta base del directorio,
        /// y evaluando que efectivamente exista el archivo.
        /// </summary>
        /// <param name="rutaRelativaArchivo">Ruta relativa del archivo.</param>
        /// <returns>Una ruta segura para leer archivos.</returns>
        /// <exception cref="ArchivoException">Error con la ruta.</exception>
        internal static string ObtenerUnaRutaValidaDelArchivoParaLeer(string rutaRelativaDelArchivo)
        {
            string rutaAbsolutaDelArchivo = Archivo.ObtenerRutaAbsolutaDeArchivoODirectorioAPartirDeUnaRutaRelativa(rutaRelativaDelArchivo);

            if (File.Exists(rutaAbsolutaDelArchivo))
            {
                return rutaAbsolutaDelArchivo;
            }
            throw new ArchivoException($"La ruta del archivo '{rutaAbsolutaDelArchivo}' no existe.");
        }

        /// <summary>
        /// Guarda un archivo en la ruta especificada.
        /// </summary>
        /// <param name="rutaRelativaDelArchivo">Ruta relativa del archivo.</param>
        /// <param name="textoAGuardarEnArchivo">Texto a guardar en el archivo.</param>
        /// <returns>True si pudo guardar el archivo.</returns>
        /// <exception cref="ArchivoException">Error con la ruta.</exception>
        /// <exception cref="ArgumentNullException">Ruta null.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        internal static bool Guardar(string rutaRelativaDelArchivo, string textoAGuardarEnArchivo)
        {
            string rutaSeguraParaGuardar;
            try
            {
                rutaSeguraParaGuardar = Archivo.ObtenerUnaRutaValidaDelArchivoParaGuardar(rutaRelativaDelArchivo);

                File.WriteAllText(rutaSeguraParaGuardar, textoAGuardarEnArchivo);

                return true;
            }
            catch(ArchivoException)
            {
                throw;
            }
            catch(ArgumentNullException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new Exception("Fallo externo al sistema. Clase Archivo. Revisar InnerException", ex);
            }
        }      

        /// <summary>
        /// Lee un archivo.
        /// </summary>
        /// <param name="rutaRelativaDelArchivo">Ruta relativa del archivo.</param>
        /// <returns>El texto (formato string) contenido en el archivo.</returns>
        /// <exception cref="ArchivoException">Error con la ruta.</exception>
        /// <exception cref="ArgumentNullException">Ruta null.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public static string Leer(string rutaRelativaDelArchivo)
        {
            string rutaSeguraParaLeer;
            try
            {
                rutaSeguraParaLeer = Archivo.ObtenerUnaRutaValidaDelArchivoParaLeer(rutaRelativaDelArchivo);

                return File.ReadAllText(rutaSeguraParaLeer);
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
                throw new Exception("Fallo externo al sistema. Clase Archivo. Revisar InnerException", ex);
            }
        }

        /// <summary>
        /// Guarda un archivo .Txt en la ruta especificada.
        /// </summary>
        /// <param name="rutaRelativaArchivo">Ruta relativa del archivo.</param>
        /// <param name="textoAGuardarEnArchivo">Texto a guardar en el archivo.</param>
        /// <returns>True si pudo guardar el archivo.</returns>
        /// <exception cref="ArchivoException">Error con la ruta.</exception>
        /// <exception cref="ArgumentNullException">Ruta null.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public static bool GuardarTxt(string rutaRelativaArchivo, string textoAGuardarEnArchivo)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(rutaRelativaArchivo))
                {
                    if (!rutaRelativaArchivo.EndsWith(Archivo.extension))
                    {
                        rutaRelativaArchivo += Archivo.extension;
                    }
                    return Archivo.Guardar(rutaRelativaArchivo, textoAGuardarEnArchivo);
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
                throw new Exception("Fallo externo al sistema. Clase Archivo. Revisar InnerException", ex);
            }
        }

        /// <summary>
        /// Realiza una busqueda en el directorio BASE del sistema para obtener un Dictionary con los nombres y contenidos
        /// de los archivos encontrados en la ruta relativa del directorio especificado.
        /// </summary>
        /// <param name="rutaRelativaDelDirectorio">Ruta relativa del directorio.</param>
        /// <param name="patronDeArchivoBuscado">Fragmento del nombre del archivo/s buscado.</param>
        /// <returns>Un Dictionary con nombre del archivo (KEY) y el texto del archivo (VALUE).</returns>
        /// <exception cref="ArchivoException">Error con la ruta del archivo.</exception>
        /// <exception cref="ArgumentNullException">Datos NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public static Dictionary<string, string> LeerArchivosDeUnDirectorio(string rutaRelativaDelDirectorio, string patronDeArchivoBuscado)
        {
            try
            {
                string rutaAbsolutaDelDirectorio = Archivo.ObtenerRutaAbsolutaDeArchivoODirectorioAPartirDeUnaRutaRelativa(rutaRelativaDelDirectorio);
                Dictionary<string, string> archivosYTextos = new Dictionary<string, string>();
                string archivoLeido;
                string nombreArchivo;

                if (Directory.Exists(rutaAbsolutaDelDirectorio))
                {
                    string[] rutas = Directory.GetFiles(rutaAbsolutaDelDirectorio);

                    for (int i = 0; i < rutas.Length; i++)
                    {
                        if(rutas[i].Contains(patronDeArchivoBuscado))
                        {
                            nombreArchivo = Archivo.ObtenerNombreDelArchivo(rutas[i]);
                            archivoLeido = Archivo.Leer(rutas[i]);

                            archivosYTextos.Add(nombreArchivo, archivoLeido);
                        }
                    }
                    return archivosYTextos;
                }
                throw new ArchivoException($"La ruta del directorio '{rutaAbsolutaDelDirectorio}' no existe.");
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
                throw new Exception("Fallo externo al sistema. Clase Archivo. Revisar InnerException", ex);
            }
        }
    }
}
