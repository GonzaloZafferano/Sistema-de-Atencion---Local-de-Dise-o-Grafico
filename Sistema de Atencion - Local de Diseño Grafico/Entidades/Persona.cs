using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Jefe))]
    [XmlInclude(typeof(Cliente))]
    [XmlInclude(typeof(Empleado))]
    [XmlInclude(typeof(Administrador))]
    public abstract class Persona : IObtenerIgualdad
    {
        public enum EstaActivo { Activo, No_Activo }

        private string nombre;
        private string apellido;
        private int dni;
        protected EstaActivo estaActivo;

        /// <summary>
        /// Constructor publico para SERIALIZACION. NO UTILIZAR ESTA SOBRECARGA para instanciar.
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Construtor de  la clase Persona.
        /// </summary>
        /// <param name="nombre">nombre persona</param>
        /// <param name="apellido">apellido persona</param>
        /// <param name="dni">dni persona</param>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalidos.</exception>
        /// <exception cref="NullReferenceException">Datos NULL.</exception>
        protected Persona(string nombre, string apellido, int dni)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
        }

        /// <summary>
        /// Retorna true si la persona esta activa en cuanto al sistema, caso contrario False.
        /// </summary>
        [Browsable(false)]
        internal EstaActivo Activo
        {
            get
            {
                return this.estaActivo;
            }
        }

        /// <summary>
        /// Obtiene el dni de la persona. Setea el dni previa validacion.
        /// </summary>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalidos.</exception>
        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                if (value >= 1000000 && value <= 99999999)
                {
                    this.dni = value;
                }
                else
                {
                    throw new CargaDeDatosInvalidosException("Dni Invalido.");
                }               
            }
        }

        /// <summary>
        /// Obtiene el nombre de la persona. Setea el nombre previa validacion.
        /// IMPLEMENTACION METODOS DE EXTENSION.
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalidos.</exception>
        /// <exception cref="NullReferenceException">Datos NULL.</exception>
        /// </summary>
        [Browsable(false)]
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (value.EsCadenaAlfabeticaConEspacios())
                    {
                        this.nombre = value.DarFormatoDeNombre();
                    }
                    else
                    {
                        throw new CargaDeDatosInvalidosException("El nombre contiene caracteres invalidos.");
                    }
                }
                else
                {
                    throw new NullReferenceException("El nombre no puede ser NULL o Vacio o Espacios en blanco");
                }
            }
        }

        /// <summary>
        /// Obtiene el apellido de la persona. Setea el apellido previa validacion.
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalidos.</exception>
        /// <exception cref="NullReferenceException">Datos NULL.</exception>
        /// </summary>
        [Browsable(false)]
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (value.EsCadenaAlfabeticaConEspacios())
                    {
                        this.apellido = value.DarFormatoDeNombre();
                    }
                    else
                    {
                        throw new CargaDeDatosInvalidosException("El apellido contiene caracteres invalidos.");
                    }
                }
                else
                {
                    throw new NullReferenceException("El apellido no puede ser NULL o Vacio o Espacios en blanco");
                }
            }
        }

        /// <summary>
        /// Obtiene el nombre completo de la persona.
        /// </summary>
        public string NombreCompleto
        {
            get
            {
                return $"{this.Apellido}, {this.Nombre}";
            }
        }

        protected abstract bool ExistePersonaPorDni(int dni);

        /// <summary>
        /// Obtiene una cadena con todos los datos de la persona.
        /// </summary>
        /// <returns>Una cadena con todos los datos de la persona.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Dni: {this.Dni}");
            sb.AppendLine($"Nombre: {this.Nombre}");
            sb.AppendLine($"Apellido: {this.Apellido}");

            return sb.ToString();
        }

        /// <summary>
        /// Evalua que un DNI no se encuentre cargado en el sistema respectivo a la instancia invocadora.
        /// Lanza una excepcion en caso de que se encuente cargado.
        /// </summary>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalidos.</exception>
        protected void VerificarDniDuplicado()
        {
            if (this.ExistePersonaPorDni(this.Dni))
            {
                throw new CargaDeDatosInvalidosException("El Dni ingresado ya se encuentra cargado en el sistema.");
            }
        }

        /// <summary>
        /// Evalua si 2 personas son iguales segun el identificador (dni)
        /// </summary>
        /// <param name="identificador">identificador</param>
        /// <returns>True si es la misma, caso contrario False.</returns>
        public bool EsMismoIdentificador(int identificador)
        {
            return this == identificador;
        }

        /// <summary>
        /// Evalua si 2 elementos son iguales.
        /// </summary>
        /// <typeparam name="T">Clase que implemente la interfaz IObtenerIgualdad</typeparam>
        /// <param name="elemento">Elemento que se evaluara.</param>
        /// <returns>True si es el mismo elemento, caso contrario False.</returns>
        public bool EsMismoElemento<T>(T elemento) where T : class, IObtenerIgualdad
        {
            bool retorno = false;

            if(elemento is Persona personaAuxiliar)
            {
                retorno = this == personaAuxiliar;
            }

            return retorno;
        }

        public static bool operator ==(Persona persona, int dni)
        {
            bool retorno = false;

            if(persona is not null)
            {
                retorno = persona.Dni == dni;
            }
            return retorno;
        }

        public static bool operator !=(Persona persona, int dni)
        {
            return !(persona == dni);
        }

        public static bool operator ==(Persona personaUno, Persona personaDos)
        {
            bool retorno = false;

            if (personaUno is not null && personaDos is not null)
            {
                retorno = personaUno.Dni == personaDos.Dni;
            }
            return retorno;
        }

        public static bool operator !=(Persona personaUno, Persona personaDos)
        {
            return !(personaUno == personaDos);
        }
    }
}
