using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class ClienteDAO : IBaseDeDatos<Cliente>
    {
        private string resultadoDeLecturaDeBBDD;
        private Cliente cliente;
        private InteraccionConBaseDeDatos interaccionConBaseDeDatos;
        private List<Cliente> clientes;

        /// <summary>
        /// Constructor de ClienteDAO. Instancia un objeto que permite interacciones con la BBDD-Tabla Empleados. 
        /// </summary>
        public ClienteDAO()
        {
            this.interaccionConBaseDeDatos = new InteraccionConBaseDeDatos();
            this.clientes = new List<Cliente>();
            this.cliente = null;
            this.resultadoDeLecturaDeBBDD = string.Empty;
        }

        /// <summary>
        /// Retorna una cadena con la cantidad de lineas leidas al realizar una consulta 'SELECT'.
        /// </summary>
        public string ResultadoDeLecturaDeBBDD
        {
            get
            {
                return this.resultadoDeLecturaDeBBDD;
            }
            private set
            {
                this.resultadoDeLecturaDeBBDD = value;
            }
        }

        /// <summary>
        /// Inserta un elemento en la BBDD.
        /// IMPLEMENTACION SQL Y DELEGADOS
        /// </summary>
        /// <param name="cliente">Cliente que se cargara en la BBDD.</param>
        /// <returns>Una cadena con la cantidad de filas afectadas.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        public string InsertarEnBaseDeDatos(Cliente cliente)
        {
            try
            {
                if (cliente is not null)
                {
                    this.cliente = cliente;

                    string consultaSQL =
                        "INSERT INTO Clientes (Dni, Nombre, Apellido, Telefono, Activo) " +
                        "VALUES(@dni, @nombre, @apellido, @telefono, @activo)";

                    return this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consultaSQL, ((IBaseDeDatos<Cliente>)this).CargarParametrosSQLParaInsertarRegistro);
                }

                throw new ArgumentNullException("Cliente es NULL");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Carga los parametros necesarios en el comando SQL para una consulta de tipo 'INSERT', 
        /// para interactuar con la BBDD.
        /// </summary>
        /// <param name="comando">Comando SQL donde se cargaran parametros</param>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        void IBaseDeDatos<Cliente>.CargarParametrosSQLParaInsertarRegistro(SqlCommand comando)
        {
            if (comando is not null && this.cliente is not null)
            {
                comando.Parameters.AddWithValue("@dni", this.cliente.Dni);
                comando.Parameters.AddWithValue("@nombre", this.cliente.Nombre);
                comando.Parameters.AddWithValue("@apellido", this.cliente.Apellido);
                comando.Parameters.AddWithValue("@telefono", this.cliente.Telefono);
                comando.Parameters.AddWithValue("@activo", this.cliente.Activo.ToString());
            }
            else
            {
                throw new ArgumentNullException("Comando o cliente es NULL");
            }
        }

        /// <summary>
        /// Actualiza un elemento en la BBDD.
        /// IMPLEMENTACION SQL Y DELEGADOS
        /// </summary>
        /// <param name="empleado">Cliente que se actualizara</param>
        /// <returns>Una cadena con la cantidad de filas afectadas</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        public string ActualizarEnBaseDeDatos(Cliente cliente)
        {
            try
            {
                if (cliente is not null)
                {
                    this.cliente = cliente;

                    string consultaSQL = "UPDATE Clientes SET Telefono = @telefono WHERE Dni = @dni";

                    return this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consultaSQL, ((IBaseDeDatos<Cliente>)this).CargarParametrosSQLParaModificarRegistros);
                }
                throw new ArgumentNullException("Cliente es NULL");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Carga los parametros necesarios en el comando SQL para una consulta de tipo 'UPDATE', 
        /// para interactuar con la BBDD.
        /// </summary>
        /// <param name="comando">Comando SQL donde se cargaran parametros</param>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        void IBaseDeDatos<Cliente>.CargarParametrosSQLParaModificarRegistros(SqlCommand comando)
        {
            if (comando is not null && this.cliente is not null)
            {
                comando.Parameters.AddWithValue("@telefono", this.cliente.Telefono);
                comando.Parameters.AddWithValue("@dni", this.cliente.Dni);
            }
            else
            {
                throw new ArgumentNullException("Comando o cliente es NULL");
            }
        }

        /// <summary>
        /// Elimina un elemento en la BBDD.
        /// IMPLEMENTACION SQL Y DELEGADOS
        /// </summary>
        /// <param name="cliente">Cliente que se eliminara de la BBDD.</param>
        /// <returns>Una cadena con la cantidad de filas afectadas.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        public string EliminarDeBaseDeDatos(Cliente cliente)
        {
            try
            {
                if (cliente is not null)
                {
                    this.cliente = cliente;

                    string consultaSql = "UPDATE Clientes SET Activo = @activo WHERE Dni = @dni";

                    return this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consultaSql, ((IBaseDeDatos<Cliente>)this).CargarParametrosSQLParaEliminarRegistros);
                }
                throw new ArgumentNullException("Cliente es NULL");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Carga los parametros necesarios en el comando SQL para una consulta de tipo 'DELETE', 
        /// para interactuar con la BBDD.
        /// </summary>
        /// <param name="comando">Comando SQL donde se cargaran parametros</param>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        void IBaseDeDatos<Cliente>.CargarParametrosSQLParaEliminarRegistros(SqlCommand comando)
        {
            if (comando is not null && this.cliente is not null)
            {
                comando.Parameters.AddWithValue("@dni", this.cliente.Dni);
                comando.Parameters.AddWithValue("@activo", Persona.EstaActivo.No_Activo.ToString());
            }
            else
            {
                throw new ArgumentNullException("Comando o cliente es NULL");
            }
        }

        /// <summary>
        /// Lee todos los registros de la Base de datos.
        /// </summary>
        /// <returns>Una lista con todos los registros leidos de la BBDD.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        public List<Cliente> LeerTodosLosRegistrosDeBaseDeDatos()
        {
            try
            {
                this.clientes.Clear();

                string consultaSQL = "SELECT * FROM Clientes WHERE Activo = @activo";

                this.resultadoDeLecturaDeBBDD = this.interaccionConBaseDeDatos.EjecutarConsultaDeLecturaDeRegistros(consultaSQL, ((IBaseDeDatos<Cliente>)this).LeerSqlData,
                    (comandoSQL) => comandoSQL.Parameters.AddWithValue("@activo", Persona.EstaActivo.Activo.ToString()));

                return this.clientes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee todos los datos de un cliente, contenido en el 'SqlDataReader'. 
        /// Posteriormente crea al cliente y lo carga en un lista.
        /// </summary>
        /// <param name="sqlLector">Objeto de tipo SqlDataReader, del cual se leeran los datos.</param>
        /// <returns>True si pudo leer los datos del empleado correctamente. Caso contrario False.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        bool IBaseDeDatos<Cliente>.LeerSqlData(SqlDataReader sqlLector)
        {
            Cliente cliente;

            try
            {
                if (sqlLector is not null)
                {
                    if (int.TryParse(sqlLector["Dni"].ToString(), out int dni) &&
                        Enum.TryParse(sqlLector["Activo"].ToString(), out Persona.EstaActivo estaActivo))
                    {
                        string nombre = sqlLector["Nombre"].ToString();
                        string apellido = sqlLector["Apellido"].ToString();
                        string telefono = sqlLector["Telefono"].ToString();

                        cliente = new Cliente(nombre, apellido, dni, telefono, estaActivo);

                        this.clientes.Add(cliente);

                        return true;
                    }
                }
                throw new BaseDeDatosException("Error al intentar obtener el registro de la Base de datos");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee un unico registro de la BBDD, correspondiente al identificador recibido por parametro.
        /// </summary>
        /// <param name="dni">dni del cliente.</param>
        /// <returns>El empleado correspondiente al ID, NULL si no lo encontro.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="BaseDeDatosException">Error al intentar obtener el registro de la BBDD.</exception>
        public Cliente LeerUnRegistroDeBaseDeDatosPorIdentificador(int dni)
        {
            try
            {
                this.clientes.Clear();

                string consultaSQL = "SELECT * FROM Clientes WHERE Dni = @dni";

                this.resultadoDeLecturaDeBBDD = this.interaccionConBaseDeDatos.EjecutarConsultaDeLecturaDeRegistros
                    (consultaSQL, ((IBaseDeDatos<Cliente>)this).LeerSqlData, comandoSQL => comandoSQL.Parameters.AddWithValue("@dni", dni));

                if (this.clientes.Count == 1)
                {
                    return this.clientes[0];
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo no implementado
        /// </summary>
        /// <returns></returns>
        Cliente IBaseDeDatos<Cliente>.ObtenerUltimoElementoCargadoEnBaseDeDatos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reactiva un cliente que esta No_Activo.
        /// </summary>
        /// <param name="dni">Dni del cliente a reactivar.</param>
        /// <returns>True si encontro el cliente y se pudo reactivar, caso contrario false.</returns>
        /// <exception cref="ArgumentException">Argumento null</exception>
        /// <exception cref="Exception">Error.</exception>
        internal bool ReactivarCliente(int dni)
        {
            try
            {
                string consultaSql = "UPDATE Clientes SET Activo = @activo WHERE Dni = @dni";

                this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consultaSql,
                    sqlCommand =>
                    {
                        sqlCommand.Parameters.AddWithValue("@dni", dni);
                        sqlCommand.Parameters.AddWithValue("@activo", Persona.EstaActivo.Activo.ToString());
                    });

                return this.interaccionConBaseDeDatos.FilasAfectadas == 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
