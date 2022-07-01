using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Jefe))]
    [XmlInclude(typeof(Administrador))]
    public class Empleado : Persona
    {
        public enum Rol { Empleado, Administrador, Jefe }

        private int id;
        private string nombreUsuario;
        private Rol puesto;
        private double salario;
        private string password;

        /// <summary>
        /// Constructor publico para SERIALIZACION. NO UTILIZAR ESTA SOBRECARGA para instanciar.
        /// </summary>
        public Empleado()
        {

        }

        /// <summary>
        /// Constructor de clase Empleado. Crea un nuevo empleado asignando un nuevo ID.
        /// </summary>
        /// <param name="nombre">nombre empleado</param>
        /// <param name="apellido">apellido emppleado</param>
        /// <param name="dni">dni empleado</param>
        /// <param name="salario">salario empleado</param>
        /// <param name="nombreUsuario">usuario de empleado.</param>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalida</exception>
        /// <exception cref="NullReferenceException">Datos NULL.</exception>
        public Empleado(string nombre, string apellido, int dni, double salario, string nombreUsuario)
            : this(dni, nombre, apellido, salario, nombreUsuario, dni.ToString(), EstaActivo.Activo)
        {
            this.VerificarDniDuplicado();
            this.VerificarNombreUsuarioDuplicado();
        }

        /// <summary>
        /// Constructor interno de clase Empleado. Crea un empleado asignando el ID recibido.
        /// Este constructor se utiliza para cargar elementos ya existentes o clonar.
        /// </summary>
        /// <param name="id">Id del empleado</param>
        /// <param name="dni">dni empleado</param>
        /// <param name="nombre">nombre empleado</param>
        /// <param name="apellido">apellido emppleado</param>
        /// <param name="salario">salario empleado</param>
        /// <param name="nombreUsuario">usuario de empleado.</param>
        /// <param name="password">password de empleado.</param>
        /// <param name="estaActivo">Indica si el empleado esta activo o no.</param>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalida</exception>
        /// <exception cref="NullReferenceException">Datos NULL.</exception>
        internal Empleado(int id, int dni, string nombre, string apellido, double salario, string nombreUsuario, string password, EstaActivo estaActivo)
            : this(dni, nombre, apellido, salario, nombreUsuario, password, estaActivo)
        {
            this.Id = id;
        }

        /// <summary>
        /// Constructor privado de la clase Empleado.
        /// </summary>
        /// <param name="dni">dni empleado</param>
        /// <param name="nombre">nombre empleado</param>
        /// <param name="apellido">apellido emppleado</param>
        /// <param name="salario">salario empleado</param>
        /// <param name="nombreUsuario">usuario de empleado.</param>
        /// <param name="estaActivo">Indica si el empleado esta activo o no.</param>
        /// <exception cref="CargaDeDatosInvalidosException">Carga de datos invalida</exception>
        /// <exception cref="NullReferenceException">Datos NULL.</exception>
        private Empleado(int dni, string nombre, string apellido, double salario, string nombreUsuario, string password, EstaActivo estaActivo)
            : base(nombre, apellido, dni)
        {
            this.Puesto = Empleado.Rol.Empleado;
            this.Password = password;
            this.NombreUsuario = nombreUsuario;
            this.Salario = salario;
            base.estaActivo = estaActivo;
        }

        /// <summary>
        /// Obtiene la cantidad de ventas concretadas por el empleado.
        /// </summary>
        public int CantidadVentasConcretadas
        {
            get
            {
                return this.VentasConcretadas();
            }
        }

        /// <summary>
        /// Obtiene las ganancias generadas por el empleado.
        /// </summary>
        public double GananciasGeneradas
        {
            get
            {
                return this.TotalGananciasGeneradas();
            }
        }

        /// <summary>
        /// Obtiene un promedio de las ganancias generadas por el empleado.
        /// </summary>
        public double PromedioGananciasGeneradas
        {
            get
            {
                double retorno = 0;

                if(this.CantidadVentasConcretadas > 0)
                {
                    retorno = this.GananciasGeneradas / this.CantidadVentasConcretadas;
                }
                return retorno;
            }
        }

        /// <summary>
        /// Obtiene y setea (serializacion) el salario del empleado, previa validacion.
        /// IMPLEMENTACION EXCEPCIONES.
        /// </summary>
        /// <exception cref="CargaDeDatosInvalidosException">Datos invalidos</exception>
        public double Salario
        {
            get
            {
                return this.salario;
            }
            set
            {
                if(value > 0)
                {
                    this.salario = value;
                }
                else
                {
                    throw new CargaDeDatosInvalidosException("El salario de un empleado no puede ser 0 o negativo.");
                }
            }
        }

        /// <summary>
        /// Obtiene y setea (serializacion) el nombre de usuario del empleado, previa validacion.
        /// IMPLEMENTACION EXCEPCIONES.
        /// </summary>
        /// <exception cref="CargaDeDatosInvalidosException">Datos invalidos</exception>
        /// <exception cref="NullReferenceException">Datos NULL</exception>
        public string NombreUsuario
        {
            get
            {
                return this.nombreUsuario;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if(value.Length >= 4 && value.Length <= 8)
                    {
                        if (value.EsCadenaAlfanumerica())
                        {
                            this.nombreUsuario = value.DarFormatoDeNombre();
                        }
                        else
                        {
                            throw new CargaDeDatosInvalidosException("El nombre de usuario solo puede contener letras y numeros.");
                        }
                    }
                    else
                    {
                        throw new CargaDeDatosInvalidosException("El nombre de usuario debe tener entre 4 y 8 caracteres.");
                    }
                }
                else
                {
                    throw new NullReferenceException("El nombre de usuario no puede ser NULL o Vacio o Espacios en blanco");
                }
            }
        }

        /// <summary>
        /// Obtiene y setea (serializacion) el ID del usuario del empleado, previa validacion.
        /// </summary>
        /// <exception cref="CargaDeDatosInvalidosException">Datos invalidos.</exception>
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value >= 0)
                {
                    this.id = value;
                }
                else
                {
                    throw new CargaDeDatosInvalidosException("El id del empleado no puede ser negativo.");
                }
            }
        }

        /// <summary>
        /// Obtiene si el empleado es administrador o no.
        /// </summary>
        [Browsable(false)]
        public bool EsAdministrador
        {
            get
            {
                bool retorno = true;

                if(this.Puesto == Empleado.Rol.Empleado)
                {
                    retorno = false;
                }

                return retorno;
            }
        }

        /// <summary>
        /// Obtiene y establece (serializacion) el puesto del empleado.
        /// </summary>
        public Rol Puesto
        {
            get
            {
                return this.puesto;
            }
            set
            {
                this.puesto = value;
            }
        }

        /// <summary>
        /// Obtiene la contraseña del empleado.
        /// </summary>
        /// <exception cref="CargaDeDatosInvalidosException">Carga invalida</exception>
        /// <exception cref="NullReferenceException">Datos NULL</exception>
        [Browsable(false)]
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (value.Length >= 4 && value.Length <= 8)
                    {
                        if (value.EsCadenaAlfanumerica())
                        {
                            this.password = value;
                        }
                        else
                        {
                            throw new CargaDeDatosInvalidosException("La contraseña solo puede contener letras y numeros.");
                        }
                    }
                    else
                    {
                        throw new CargaDeDatosInvalidosException("La contraseña debe tener entre 4 y 8 caracteres.");
                    }
                }
                else
                {
                    throw new NullReferenceException("La contraseña no puede ser NULL, Empty o espacios en blanco.");
                }
            }
        }

        /// <summary>
        /// Actualiza la contraseña de un empleado, cargandola en la BBDD.
        /// </summary>
        /// <returns>Cantidad de filas afectadas.</returns>
        /// <exception cref="ArchivoException">Error referente al archivo.</exception>
        /// <exception cref="ArgumentNullException">Argumento NULL.</exception>
        /// <exception cref="Exception">Error externo.</exception>
        public bool ActualizarPasswordEnFuentesDeInformacion()
        {
            try
            {
                EmpleadoDAO empleadoDao = new EmpleadoDAO();

                empleadoDao.ActualizarPasswordDeEmpleadoEnBaseDeDatos(this);

                Task.Run(()=> Administrador.GuardarArchivoEmpleados());
 
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene la cantidad  de ventas concretadas por el empleado.
        /// </summary>
        /// <returns>cantidad de ventas.</returns>
        private int VentasConcretadas()
        {
            int retorno = 0;

            for (int i = 0; i < Compra.Count; i++)
            {
                Compra compra = Compra.ObtenerCompraPorIndice(i);

                if (compra is not null && compra.IdUsuario == this.Id)
                {
                    retorno++;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Obtiene el total de ganancias generadas por el empleado.
        /// </summary>
        /// <returns>Ganancias generadas</returns>
        private double TotalGananciasGeneradas()
        {
            double retorno = 0;

            for (int i = 0; i < Compra.Count; i++)
            {
                Compra compra = Compra.ObtenerCompraPorIndice(i);

                if (compra is not null && compra.IdUsuario == this.Id)
                {
                    retorno += compra.PrecioTotal;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Verifica que un nombre de usuario no exista en el sistema. 
        /// Lanza una excepcion en caso de encontrar el nombre de usuario.
        /// </summary>
        /// <exception cref="CargaDeDatosInvalidosException">Datos invalidos</exception>
        private void VerificarNombreUsuarioDuplicado()
        {  
            if (Administrador.ExisteNombreUsuario(this.NombreUsuario))
            {
                throw new CargaDeDatosInvalidosException("El nombre de usuario ya existe.");
            }
        }

        /// <summary>
        /// Evalua si un empleado con el Dni recibido por parametro ya existe en el sistema.
        /// </summary>
        /// <param name="dni">Dni a evaluar.</param>
        /// <returns>True si encontro coincidencia, caso contrario False.</returns>
        protected override bool ExistePersonaPorDni(int dni)
        {
            return Administrador.ExisteDniCargadoEnSistemaDeEmpleados(dni); 
        }

        /// <summary>
        /// Chequea si la contraseña recibida por parametro es valida o no.
        /// </summary>
        /// <param name="password">contraseña a evaluar.</param>
        /// <returns>True si es la misma, caso contrario False.</returns>
        public bool ChequearPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password == this.Password;
        }

        /// <summary>
        /// Obtiene el usuario correspondiente al nombre de usuario y contraseña.
        /// </summary>
        /// <param name="usuario">nnomre de usuario del empleado</param>
        /// <param name="password">contraseña del empleado.</param>
        /// <returns>El empleado correspondiente al nombre de usuario y contraseña, en caso de no encontrar coincidencia,
        /// Lanza una excepcion.</returns>
        /// <exception cref="NullReferenceException">Empleado NULL</exception>
        public static Empleado ObtenerUsuarioParaIngresarAlSistema(string usuario, string password)
        {
            Empleado empleadoAuxiliar;

            if (!string.IsNullOrWhiteSpace(usuario) && !string.IsNullOrWhiteSpace(password))
            {
                for (int i = 0; i < Administrador.Count; i++)
                {
                    empleadoAuxiliar = Administrador.ObtenerUnEmpleadoDeLaListaPorIndice(i);

                    if (empleadoAuxiliar.NombreUsuario.ToLower() == usuario.ToLower() &&
                        empleadoAuxiliar.ChequearPassword(password))
                    {
                        return empleadoAuxiliar;
                    }
                }
            }

            throw new NullReferenceException("Empleado NULL.");
        }

        /// <summary>
        /// Obtiene una cadena con los datos del empleado.
        /// </summary>
        /// <returns>Una cadena con los datos del empleado.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.ToString()}");
            sb.AppendLine($"Id: {this.Id}");
            sb.AppendLine($"Puesto: {this.GetType().Name}");
            sb.AppendLine($"Nombre de usuario: {this.NombreUsuario}");
            sb.AppendFormat("Salario: ${0:0,0.00}{1}", this.Salario, Environment.NewLine);
            sb.AppendLine($"Cantidad de ventas: {this.CantidadVentasConcretadas}");
            sb.AppendFormat("Ganancia total Generada: ${0:0,0.00}{1}", this.GananciasGeneradas, Environment.NewLine);
            sb.AppendFormat("Promedio Ganancias Generadas: ${0:0,0.00}{1}", this.PromedioGananciasGeneradas, Environment.NewLine);

            return sb.ToString();
        }

        /// <summary>
        /// Clona un empleado.
        /// </summary>
        /// <param name="empleado">empleado a clonar.</param>
        /// <returns>Empleado clonado.</returns>
        /// <exception cref="NullReferenceException">Empleado NULL</exception>
        protected static Empleado ClonarEmpleadoIntercambiandoPuesto(Empleado empleado)
        {
            Empleado empleadoAuxiliar;

            if(empleado is not null)
            {
                if (!empleado.EsAdministrador || empleado is Jefe)
                {
                    empleadoAuxiliar = new Administrador(empleado.Id, empleado.Dni, empleado.Nombre, empleado.Apellido, empleado.Salario, empleado.NombreUsuario, empleado.Password, empleado.Activo);
                }
                else
                {
                    empleadoAuxiliar = new Empleado(empleado.Id, empleado.Dni, empleado.Nombre, empleado.Apellido, empleado.Salario, empleado.NombreUsuario, empleado.Password, empleado.Activo);
                }
                return empleadoAuxiliar;
            }
            throw new NullReferenceException("Empleado NULL");
        }

        /// <summary>
        /// Almacena la contraseña del empleado en el comando SQL, para cargarlo en la base de datos.
        /// </summary>
        /// <param name="comando">Objeto de tipo SqlCommand</param>
        internal void SetearPasswordEnComandoSQL(SqlCommand comando)
        {
            if (comando is not null)
            {
                comando.Parameters.AddWithValue("@password", this.Password);
            }
        }

        /// <summary>
        /// Asigna un nuevo Jefe en el sistema.
        /// </summary>
        /// <param name="empleado">Empleado que sera el nuevo jefe.</param>
        /// <returns>Un nuevo Jefe.</returns>
        protected static Jefe AsignarNuevoJefe(Empleado empleado)
        {
            return new Jefe(empleado.Id, empleado.Dni, empleado.Nombre, empleado.Apellido, empleado.Salario, empleado.NombreUsuario, empleado.Password, EstaActivo.Activo);
        }
    }
}
