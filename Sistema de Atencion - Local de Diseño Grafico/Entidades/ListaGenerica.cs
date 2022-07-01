using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ListaGenerica<T> where T : class, IObtenerIgualdad
    {
        private List<T> elementos;

        /// <summary>
        /// Contructor de la clase. Instancia una lista Encapsulada de elementos genericos.
        /// </summary>
        public ListaGenerica()
        {         
            this.elementos = new List<T>();
        }

        /// <summary>
        /// Retorna la cantidad de elementos.
        /// </summary>
        public int Count
        {
            get
            {
                return this.elementos.Count;
            }
        }

        /// <summary>
        /// Retorna el elemento en el indice especificado. IMPLEMENTACION GENERICS.
        /// </summary>
        /// <param name="indice">indice del elemento</param>
        /// <returns>El elemento en indice especificado.</returns>
        /// <exception cref="IndexOutOfRangeException">Indice fuera de rango</exception>
        public T this[int indice]
        {
            get
            {
                if(indice >= 0 && indice < this.Count)
                {
                    return this.elementos[indice];
                }
                else
                {
                    throw new IndexOutOfRangeException("El indice esta fuera del Rango");
                }                       
            }
        }

        /// <summary>
        /// Elimina todos los elementos de la lista.
        /// </summary>
        public void VaciarLista()
        {
            this.elementos.Clear();
        }

        /// <summary>
        /// Evalua si el elemento recibido por parametro existe en la lista. IMPLEMENTACION GENERICS.
        /// </summary>
        /// <param name="elemento">Elemento</param>
        /// <returns>True si existe el elemento, caso contrario False.</returns>
        private bool ExisteElementoEnSistema(T elemento)
        {
            bool retorno = false;

            if (elemento is not null)
            {
                foreach (T elementoAuxiliar in this.elementos)
                {
                    if (elementoAuxiliar.EsMismoElemento<T>(elemento))
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }

        /// <summary>
        /// Carga un elemento NO NULL al sistema, previa validacion de que no exista ya cargado.
        /// IMPLEMENTACION DE GENERICS.
        /// </summary>
        /// <param name="elemento">Elemento a cargar.</param>
        /// <returns>True si cargo al elemento, caso contrario (elemento ya estaba cargado o es null) False.</returns>
        public bool CargarElementoAlSistema(T elemento)
        {
            bool retorno = false;

            if(elemento is not null && !this.ExisteElementoEnSistema(elemento))
            {
                this.elementos.Add(elemento);
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Elimina un elemento del sistema. IMPLEMENTACION DE GENERICS.
        /// </summary>
        /// <param name="elemento">Elemento a eliminar.</param>
        /// <returns>True si elimino al elemento, caso contrario False.</returns>
        public bool EliminarElementoDelSistema(T elemento)
        {
            if (elemento is not null)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].EsMismoElemento<T>(elemento))
                    {
                        this.elementos.RemoveAt(i);
                        return true;                        
                    }
                } 
            }
            return false;
        }

        /// <summary>
        /// Evalua si un elemento existe en el sistema, a partir de un identificador (especificado en el metodo de instancia EsMismoIdentificador()).
        /// IMPLEMENTACION GENERICS.
        /// </summary>
        /// <param name="identificador">Identificador unico del elemento.</param>
        /// <returns>True si existe, caso contrario False.</returns>
        public bool ExisteElementoPorIdentificador(int identificador)
        {
            bool retorno = false;

            foreach (T productoAuxiliar in this.elementos)
            {
                if (productoAuxiliar.EsMismoIdentificador(identificador))
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Obtiene un elemento  a partir de un identificador (especificado en el metodo de instancia EsMismoIdentificador()).
        /// IMPLEMENTACION GENERICS.
        /// </summary>
        /// <param name="identificador">identificador del elemento.</param>
        /// <returns>El elemento que coincide con el identificador, caso contrario NULL.</returns>
        public T ObtenerElementoPorIdentificador(int identificador)
        {     
            foreach (T elementoAuxiliar in this.elementos)
            {
                if (elementoAuxiliar.EsMismoIdentificador(identificador))
                {
                    return elementoAuxiliar;
                }
            }
            return null;
        }
    }
}
