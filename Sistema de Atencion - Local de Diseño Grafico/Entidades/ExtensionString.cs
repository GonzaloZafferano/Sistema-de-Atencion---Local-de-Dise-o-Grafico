using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtensionString
    {
        /// <summary>
        /// Evalua que una cadena cumpla con la expresion regular recibida como argumento.
        /// </summary>
        /// <param name="cadena">Cadena a evaluar.</param>
        /// <param name="expresion">Expresion regular que se debe respetar.</param>
        /// <returns>True si la cadena cumple con la expresion regular, caso contrario False.</returns>
        private static bool EsCadenaValida(string cadena, string expresion)
        {
            bool retorno = false;

            if (!string.IsNullOrWhiteSpace(cadena) && !string.IsNullOrWhiteSpace(expresion))
            {
                Regex expresionRegular = new Regex(expresion);

                retorno = expresionRegular.IsMatch(cadena);
            }

            return retorno;
        }

        /// <summary>
        /// Determina si un caracter representa una letra minuscula.
        /// </summary>
        /// <param name="caracter">Caracter que se evaluara.</param>
        /// <returns>True si el caracter es una letra minuscula, False si no lo es.</returns>
        private static bool EsLetraMinuscula(char caracter)
        {
            return ExtensionString.EsCadenaValida(caracter.ToString(), "^[a-z]$");
        }

        /// <summary>
        /// Evalua si una cadena esta compuesta de caracteres alfabeticos (incluye espacios).
        /// </summary>
        /// <param name="cadena">Cadena que se evaluara.</param>
        /// <returns>True si la cadena es Alfabetica, caso contrario, False.</returns>
        public static bool EsCadenaAlfabeticaConEspacios(this string cadena)
        {
            return ExtensionString.EsCadenaValida(cadena, "^[a-zA-Z ]+$");
        }

        /// <summary>
        /// Determina si una cadena es alfanumerica (Con espacios).
        /// </summary>
        /// <param name="cadena">Cadena que se evaluara.</param>
        /// <returns>True si es una cadena Alfanumerica, caso contrario False.</returns>
        public static bool EsCadenaAlfanumericaConEspacios(this string cadena)
        {
            return ExtensionString.EsCadenaValida(cadena, "^[a-zA-Z0-9 ]+$");
        }

        /// <summary>
        /// Determina si una cadena es alfanumerica (Sin espacios).
        /// </summary>
        /// <param name="cadena">Cadena que se evaluara.</param>
        /// <returns>True si es una cadena Alfanumerica, caso contrario False.</returns>
        public static bool EsCadenaAlfanumerica(this string cadena)
        {
            return ExtensionString.EsCadenaValida(cadena, "^[a-zA-Z0-9]+$");
        }

        /// <summary>
        /// Evalua si una cadena respeta el formato telefonico.
        /// </summary>
        /// <param name="cadena">Cadena que se evaluara.</param>
        /// <returns>True si la cadena respeta el formato telefonico (00-0000-0000), caso contrario, False.</returns>
        public static bool EsFormatoTelefonico(this string cadena)
        {
            return ExtensionString.EsCadenaValida(cadena, "^[0-9]{2}-[0-9]{4}-[0-9]{4}$");
        }

        /// <summary>
        /// Convierte en Mayuscula un caracter alfabetico que esta en minuscula.
        /// </summary>
        /// <param name="caracter">Caracter a evaluar</param>
        /// <returns>Un caracter alfabetico en mayuscula. En caso de ser un caracter invalido, lo retorna sin modificaciones.</returns>
        private static char ConvertirUnCaracterMinusculaEnMayuscula(char caracter)
        {
            char retorno = caracter;

            if (ExtensionString.EsLetraMinuscula(caracter))
            {
                retorno = (char)(caracter - 32);
            }

            return retorno;
        }

        /// <summary>
        /// Convierte la primera letra de una palabra en Mayuscula, en caso de ser necesario.
        /// </summary>
        /// <param name="cadena">Cadena que se evaluara.</param>
        /// <returns>Una copia de la cadena, con la primera letra de la palabra en Mayuscula.</returns>
        private static string ConvertirPrimeraLetraDePalabraEnMayuscula(string cadena)
        {
            string retorno = string.Empty;

            if (!string.IsNullOrWhiteSpace(cadena))
            {
                char[] caracteres = cadena.ToCharArray();

                caracteres[0] = ExtensionString.ConvertirUnCaracterMinusculaEnMayuscula(caracteres[0]);

                retorno = new string(caracteres);
            }
            return retorno;
        }

        /// <summary>
        /// Convierte el primer caracter de cada palabra en mayuscula, y el resto en minusculas.
        /// </summary>
        /// <param name="cadena">Cadena que se evaluara.</param>
        /// <returns>Una copia de la cadena con la primera letra de cada palabra convertida en mayuscula, y el resto en minusculas.</returns>
        private static string ConvertirCaracterInicialDeCadaPalabraAMayuscula(string cadena)
        {
            string cadenaAuxiliar = string.Empty;

            if (!string.IsNullOrWhiteSpace(cadena))
            {
                string[] palabras = cadena.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < palabras.Length; i++)
                {
                    palabras[i] = ExtensionString.ConvertirPrimeraLetraDePalabraEnMayuscula(palabras[i]);
                }
                cadenaAuxiliar = ExtensionString.ObtenerCadenaDeTexto(palabras);
            }

            return cadenaAuxiliar;
        }

        /// <summary>
        /// Obtiene una cadena de texto a partir de un array de palabras.
        /// </summary>
        /// <param name="arrayDePalabras">Array de palabras que se utilizara para formar la cadena.</param>
        /// <returns>Una cadena a partir de un array de palabras.</returns>
        private static string ObtenerCadenaDeTexto(string[] arrayDePalabras)
        {
            StringBuilder sb = new StringBuilder();

            if (arrayDePalabras != null)
            {
                foreach (string palabra in arrayDePalabras)
                {
                    sb.Append($"{palabra} ");
                }
            }

            return sb.ToString().Trim();
        }

        /// <summary>
        /// Da el formato de descripcion (primera letra del texto en Mayuscula, un unico espacio entre palabras, y termina en punto).
        /// </summary>
        /// <param name="cadena">Cadena que se evaluara.</param>
        /// <returns>Una copia de la cadena con la primera letra del texto convertida a mayusculas, sin espacios en blanco extras, y termina en punto.</returns>
        public static string DarFormatoDeDescripcion(this string cadena)
        {
            string cadenaAuxiliar = string.Empty;

            if (!string.IsNullOrWhiteSpace(cadena))
            {
                string[] palabras = cadena.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                cadenaAuxiliar = ExtensionString.ObtenerCadenaDeTexto(palabras);

                if (ExtensionString.EsLetraMinuscula(cadenaAuxiliar[0]))
                {
                    cadenaAuxiliar = ExtensionString.ConvertirPrimeraLetraDePalabraEnMayuscula(cadenaAuxiliar);
                }

                if (cadenaAuxiliar[cadenaAuxiliar.Length - 1] != '.')
                {
                    cadenaAuxiliar += ".";
                }
            }

            return cadenaAuxiliar;
        }

        /// <summary>
        /// Da el formato de nombre (primera letra de cada palabra en Mayuscula, resto de la palabra en minusculas).
        /// Tambien se encarga de borrar espacios EXTRAS, dejando, de ser necesario, un unico espacio en blanco entre palabras.
        /// </summary>
        /// <param name="cadena">Cadena que se evaluara.</param>
        /// <returns>Una copia de la cadena con la primera letra de cada palabra convertida a mayusculas, el resto en minusculas, y sin espacios en blanco extras.</returns>
        public static string DarFormatoDeNombre(this string cadena)
        {
            string cadenaAuxiliar = string.Empty;

            if (!string.IsNullOrWhiteSpace(cadena))
            {
                cadenaAuxiliar = ExtensionString.ConvertirCaracterInicialDeCadaPalabraAMayuscula(cadena);
            }

            return cadenaAuxiliar;
        }
    }
}
