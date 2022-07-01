using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class EmpleadoDAO : IBaseDeDatos<Empleado>
    {
        private string resultadoDeLecturaDeBBDD;
        private Empleado empleado;
        private InteraccionConBaseDeDatos interaccionConBaseDeDatos;
        private List<Empleado> empleados;

        /// <summary>
        /// Constructor de EmpleadoDAO. Instancia un objeto que permite interacciones con la BBDD-Tabla Empleados. 
        /// </summary>
        public EmpleadoDAO()
        {
            this.interaccionConBaseDeDatos = new InteraccionConBaseDeDatos();
            this.empleados = new List<Empleado>();
            this.empleado = null;
            this.ResultadoDeLecturaDeBBDD = string.Empty;
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
        /// </summary>
        /// <param name="empleado">Empleado que se cargara en la BBDD.</param>
        /// <returns>Una cadena con la cantidad de filas afectadas.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        public string InsertarEnBaseDeDatos(Empleado empleado)
        {
            try
            {
                if (empleado is not null)
                {
                    this.empleado = empleado;

                    string consultaSQL =
                        "INSERT INTO Empleados (Dni, Nombre, Apellido, Puesto, Salario, NombreUsuario, Password, Activo) " +
                        "VALUES(@dni, @nombre, @apellido, @puesto, @salario, @nombreUsuario, @password, @activo)";

                    return this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consultaSQL, ((IBaseDeDatos<Empleado>)this).CargarParametrosSQLParaInsertarRegistro);
                }

                throw new ArgumentNullException("Empleado es NULL");
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
        void IBaseDeDatos<Empleado>.CargarParametrosSQLParaInsertarRegistro(SqlCommand comando)
        {
            if (comando is not null && this.empleado is not null)
            {
                comando.Parameters.AddWithValue("@dni", this.empleado.Dni);
                comando.Parameters.AddWithValue("@nombre", this.empleado.Nombre);
                comando.Parameters.AddWithValue("@apellido", this.empleado.Apellido);
                comando.Parameters.AddWithValue("@puesto", this.empleado.Puesto.ToString());
                comando.Parameters.AddWithValue("@salario", this.empleado.Salario);
                comando.Parameters.AddWithValue("@nombreUsuario", this.empleado.NombreUsuario);
                comando.Parameters.AddWithValue("@activo", this.empleado.Activo.ToString());
                this.empleado.SetearPasswordEnComandoSQL(comando);
            }
            else
            {
                throw new ArgumentNullException("Comando o empleado es NULL");
            }
        }

        /// <summary>
        /// Actualiza un elemento en la BBDD.
        /// </summary>
        /// <param name="empleado">Empleado que se actualizara</param>
        /// <returns>Una cadena con la cantidad de filas afectadas</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        public string ActualizarEnBaseDeDatos(Empleado empleado)
        {
            try
            {
                if (empleado is not null)
                {
                    this.empleado = empleado;

                    string consultaSQL = "UPDATE Empleados SET Puesto = @puesto, Salario = @salario WHERE Id = @id";

                    return this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consultaSQL, ((IBaseDeDatos<Empleado>)this).CargarParametrosSQLParaModificarRegistros);
                }
                throw new ArgumentNullException("Empleado es NULL");
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
        void IBaseDeDatos<Empleado>.CargarParametrosSQLParaModificarRegistros(SqlCommand comando)
        {
            if (comando is not null && this.empleado is not null)
            {
                comando.Parameters.AddWithValue("@puesto", this.empleado.Puesto.ToString());
                comando.Parameters.AddWithValue("@id", this.empleado.Id);
                comando.Parameters.AddWithValue("@salario", this.empleado.Salario);
            }
            else
            {
                throw new ArgumentNullException("Comando o empleado es NULL");
            }
        }

        /// <summary>
        /// Elimina un elemento en la BBDD.
        /// </summary>
        /// <param name="empleado">Empleado que se eliminara de la BBDD.</param>
        /// <returns>Una cadena con la cantidad de filas afectadas.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        public string EliminarDeBaseDeDatos(Empleado empleado)
        {
            try
            {
                if (empleado is not null)
                {
                    this.empleado = empleado;

                    string consultaSql = "UPDATE Empleados SET Activo = @activo WHERE Id = @id";

                    return this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consultaSql, ((IBaseDeDatos<Empleado>)this).CargarParametrosSQLParaEliminarRegistros);
                }
                throw new ArgumentNullException("Empleado es NULL");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Carga los parametros necesarios  en el comando SQL para una consulta de tipo 'DELETE', 
        /// para interactuar con la BBDD.
        /// </summary>
        /// <param name="comando">Comando SQL donde se cargaran parametros</param>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        void IBaseDeDatos<Empleado>.CargarParametrosSQLParaEliminarRegistros(SqlCommand comando)
        {
            if (comando is not null && this.empleado is not null)
            {
                comando.Parameters.AddWithValue("@id", this.empleado.Id);
                comando.Parameters.AddWithValue("@activo", Empleado.EstaActivo.No_Activo.ToString());
            }
            else
            {
                throw new ArgumentNullException("Comando o empleado es NULL");
            }
        }

        /// <summary>
        /// Actualiza la contraseña de un empleado en la BBDD.
        /// </summary>
        /// <param name="empleado">Empleado cuya contraseña se actualizara</param>
        /// <returns>Una cadena con la cantidad de filas afectadas</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        internal string ActualizarPasswordDeEmpleadoEnBaseDeDatos(Empleado empleado)
        {
            try
            {
                if (empleado is not null)
                {
                    this.empleado = empleado;

                    string consultaSQL = "UPDATE Empleados SET Password = @password WHERE Id = @id";

                    return this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consultaSQL, 
                        (comando) =>
                        {
                            empleado.SetearPasswordEnComandoSQL(comando);
                            comando.Parameters.AddWithValue("@id", empleado.Id);
                        });
                }
                throw new ArgumentNullException("Empleado es NULL");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee todos los registros de la Base de datos.
        /// </summary>
        /// <returns>Una lista con todos los registros leidos de la BBDD.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        public List<Empleado> LeerTodosLosRegistrosDeBaseDeDatos()
        {
            try
            {
                this.empleados.Clear();

                string consultaSQL = "SELECT * FROM Empleados WHERE Activo = @activo";

                this.ResultadoDeLecturaDeBBDD = this.interaccionConBaseDeDatos.EjecutarConsultaDeLecturaDeRegistros(consultaSQL, ((IBaseDeDatos<Empleado>)this).LeerSqlData,
                    (comando) => comando.Parameters.AddWithValue("@activo", Empleado.EstaActivo.Activo.ToString()));
                
                return this.empleados;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee todos los datos de un empleado, contenido en el 'SqlDataReader'. 
        /// Posteriormente crea al empleado y lo carga en un lista.
        /// </summary>
        /// <param name="sqlLector">Objeto de tipo SqlDataReader, del cual se leeran los datos.</param>
        /// <returns>True si pudo leer los datos del empleado correctamente. Caso contrario False.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="BaseDeDatosException">Error al intentar obtener el registro de la BBDD.</exception>
        bool IBaseDeDatos<Empleado>.LeerSqlData(SqlDataReader sqlLector)
        {
            Empleado empleado;

            try
            {
                if (sqlLector is not null)
                {
                    if (int.TryParse(sqlLector["Id"].ToString(), out int id) && int.TryParse(sqlLector["Dni"].ToString(), out int dni) &&
                        double.TryParse(sqlLector["Salario"].ToString(), out double salario)
                        && Enum.TryParse(sqlLector["Puesto"].ToString(), out Empleado.Rol puesto)
                        && Enum.TryParse(sqlLector["Activo"].ToString(), out Empleado.EstaActivo estaActivo))
                    {
                        string nombre = sqlLector["Nombre"].ToString();
                        string apellido = sqlLector["Apellido"].ToString();
                        string nombreUsuario = sqlLector["NombreUsuario"].ToString();
                        string password = sqlLector["Password"].ToString();

                        if (puesto == Empleado.Rol.Jefe)
                        {
                            empleado = new Jefe(id, dni, nombre, apellido, salario, nombreUsuario, password, estaActivo);
                        }
                        else if (puesto == Empleado.Rol.Administrador)
                        {
                            empleado = new Administrador(id, dni, nombre, apellido, salario, nombreUsuario, password, estaActivo);
                        }
                        else
                        {
                            empleado = new Empleado(id, dni, nombre, apellido, salario, nombreUsuario, password, estaActivo);
                        }

                        this.empleados.Add(empleado);

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
        /// IMPLEMENTACION SQL, LAMBDA Y DELEGADOS
        /// </summary>
        /// <param name="id">Id del empleado.</param>
        /// <returns>El empleado correspondiente al ID, NULL si no lo encontro.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        public Empleado LeerUnRegistroDeBaseDeDatosPorIdentificador(int id)
        {
            try
            {
                this.empleados.Clear();

                string consultaSQL = "SELECT * FROM Empleados WHERE Id = @id";

                this.ResultadoDeLecturaDeBBDD = this.interaccionConBaseDeDatos.EjecutarConsultaDeLecturaDeRegistros
                    (consultaSQL, ((IBaseDeDatos<Empleado>)this).LeerSqlData, comandoSQL => comandoSQL.Parameters.AddWithValue("@id", id));

                if (this.empleados.Count == 1)
                {
                    return this.empleados[0];
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee un unico registro de la BBDD, correspondiente al dni recibido por parametro.
        /// IMPLEMENTACION SQL, LAMBDA Y DELEGADOS
        /// </summary>
        /// <param name="dni">Dni del empleado.</param>
        /// <returns>El empleado correspondiente al dni, NULL si no lo encontro.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        public Empleado LeerUnRegistroDeBaseDeDatosPorDni(int dni)
        {
            try
            {
                this.empleados.Clear();

                string consultaSQL = "SELECT * FROM Empleados WHERE Dni = @dni";

                this.ResultadoDeLecturaDeBBDD = this.interaccionConBaseDeDatos.EjecutarConsultaDeLecturaDeRegistros
                    (consultaSQL, ((IBaseDeDatos<Empleado>)this).LeerSqlData, comandoSQL => comandoSQL.Parameters.AddWithValue("@dni", dni));

                if (this.empleados.Count == 1)
                {
                    return this.empleados[0];
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee un unico registro de la BBDD, correspondiente al nombre de usuario recibido por parametro.
        /// IMPLEMENTACION SQL, LAMBDA Y DELEGADOS
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario del empleado.</param>
        /// <returns>El empleado correspondiente al nombre de usuario, NULL si no lo encontro.</returns>
        /// <exception cref="BaseDeDatosException">Error al intentar leer desde la BBDD.</exception>
        public Empleado LeerUnRegistroDeBaseDeDatosPorNombreDeUsuario(string nombreUsuario)
        {
            try
            {
                this.empleados.Clear();

                string consultaSQL = "SELECT * FROM Empleados WHERE NombreUsuario = @nombreUsuario";

                this.ResultadoDeLecturaDeBBDD = this.interaccionConBaseDeDatos.EjecutarConsultaDeLecturaDeRegistros
                    (consultaSQL, ((IBaseDeDatos<Empleado>)this).LeerSqlData, 
                    comandoSQL => comandoSQL.Parameters.AddWithValue("@nombreUsuario", nombreUsuario));

                if (this.empleados.Count == 1)
                {
                    return this.empleados[0];
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new BaseDeDatosException("Error al intentar leer un empleado desde la Base de datos. Revisar InnerException", ex);
            }
        }

        /// <summary>
        /// Obtiene el ultimo empleado cargado en la Base de datos.
        /// IMPLEMENTACION SQL Y DELEGADOS
        /// </summary>
        /// <returns>El ultimo empleado cargado en la Base de datos.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="NullReferenceException">Error al intentar obtener el ultimo elemento de la BBDD.</exception>
        public Empleado ObtenerUltimoElementoCargadoEnBaseDeDatos()
        {
            try
            {
                this.empleados.Clear();

                string consultaSql = "SELECT * FROM Empleados WHERE Empleados.Id = (SELECT MAX(Empleados.Id) FROM Empleados)";

                this.interaccionConBaseDeDatos.EjecutarConsultaDeLecturaDeRegistros(consultaSql, ((IBaseDeDatos<Empleado>)this).LeerSqlData);

                if (this.empleados.Count == 1)
                {
                    return this.empleados[0];
                }
                throw new NullReferenceException("No se pudo obtener el ultimo empleado cargado en la Base de datos");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Reactiva un empleado que esta No_Activo.
        /// </summary>
        /// <param name="dni">Dni del empleado a reactivar.</param>
        /// <returns>True si encontro el empleado y se pudo reactivar, caso contrario false.</returns>
        /// <exception cref="ArgumentException">Argumento null</exception>
        /// <exception cref="Exception">Error.</exception>
        internal bool ReactivarEmpleado(int dni)
        {
            try
            {
                string consultaSql = "UPDATE Empleados SET Activo = @activo WHERE Dni = @dni";

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
