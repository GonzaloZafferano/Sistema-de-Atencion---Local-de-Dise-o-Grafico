using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class InteraccionConBaseDeDatos
    {
        private static readonly string cadenaDeConexion;
        private CargarParametrosSQL metodoCargaDeParametrosSql;
        private SqlCommand comando;
        private SqlConnection conexion;
        private int filasAfectadas;
        private int filasTotales;
        private int filasLeidasConExito;
        private int filasConError;

        /// <summary>
        /// Constructor estatico. Asigna la cadena de conexion con la Base de datos.
        /// </summary>
        static InteraccionConBaseDeDatos()
        {
            InteraccionConBaseDeDatos.cadenaDeConexion = "Server = .; Database = ZAFFERANO_GONZALO_TP4_2C; Trusted_Connection = True";
        }

        /// <summary>
        /// Constructor de instancia. Crea una conexion SQL y un SQL command, para interactual con la Base de Datos.
        /// </summary>
        public InteraccionConBaseDeDatos()
        {
            this.conexion = new SqlConnection(InteraccionConBaseDeDatos.cadenaDeConexion);
            this.comando = new SqlCommand();

            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.Connection = this.conexion;

            this.metodoCargaDeParametrosSql = null;
        }

        /// <summary>
        /// Asigna un metodo Delegado (void (SqlCommand)) para Cargar parametros a la consulta de tipo 'SELECT'.
        /// </summary>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        private CargarParametrosSQL MetodoCargaDeParametrosSql
        {
            get
            {
                return this.metodoCargaDeParametrosSql;
            }
            set
            {
                if (value is not null)
                {
                    this.metodoCargaDeParametrosSql = value;
                }
                else
                {
                    throw new ArgumentNullException("El metodo de carga de parametros para la consulta 'SELECT' es NULL");
                }
            }
        }

        /// <summary>
        /// Retorna las filas afectadas por una consulta de tipo Insert, Update o Delete.
        /// </summary>
        public int FilasAfectadas
        {
            get
            {
                return this.filasAfectadas;
            }
        }

        /// <summary>
        /// Retorna las filas totales obtenidas por una consulta de tipo Select.
        /// </summary>
        public int FilasTotales
        {
            get
            {
                return this.filasTotales;
            }
        }

        /// <summary>
        /// Retorna las filas leidas con exito por una consulta de tipo Select.
        /// </summary>
        public int FilasLeidasConExito
        {
            get
            {
                return this.filasLeidasConExito;
            }
        }

        /// <summary>
        /// Retorna las filas que tuvieron error al intentar leerse por una consulta de tipo Select.
        /// </summary>
        public int FilasConError
        {
            get
            {
                return this.filasConError;
            }
        }

        /// <summary>
        /// Ejecuta una Consulta de tipo 'SELECT' para Leer Registros de la Base de datos.
        /// IMPLEMENTACION DELEGADOS Y BASE DE DATOS.
        /// </summary>
        /// <param name="consultaSql">Consulta de tipo 'SELECT'.</param>
        /// <param name="metodoLecturaSql">Metodo que leera los datos obtenidos de la consulta.</param>
        /// <param name="tieneParametros">Booleano. Indica si la consulta 'SELECT' tiene parametros para cargar.</param>
        /// <returns>Una cadena que indica cuantas filas se han leido y cuantas tienen error.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        private string EjecutarConsultaDeLecturaDeRegistros(string consultaSql, LeerSqlData metodoLecturaSql, bool tieneParametros)
        {
            this.filasTotales = 0;
            this.filasLeidasConExito = 0;
            this.filasConError = 0;

            try
            {
                if (!string.IsNullOrWhiteSpace(consultaSql) && metodoLecturaSql is not null)
                {
                    this.conexion.Open();

                    this.comando.CommandText = consultaSql;

                    if (tieneParametros && this.MetodoCargaDeParametrosSql is not null)
                    {
                        this.MetodoCargaDeParametrosSql(this.comando);

                        this.metodoCargaDeParametrosSql = null;
                    }

                    using (SqlDataReader sqlLector = this.comando.ExecuteReader())
                    {
                        while (sqlLector.Read())
                        {
                            this.filasTotales++;

                            try
                            {
                                metodoLecturaSql(sqlLector);

                                this.filasLeidasConExito++;
                            }
                            catch (Exception)
                            {
                                this.filasConError++;
                            }
                        }
                    }
                    return $"Se leyeron exitosamente {this.filasLeidasConExito} / {this.filasTotales} filas. Filas con error: {this.filasConError}";
                }

                throw new ArgumentNullException("Argumentos recibidos son NULL");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (this.conexion is not null && this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.comando.Parameters.Clear();
                    this.conexion.Close();
                }
            }
        }

        /// <summary>
        /// Ejecuta una Consulta de tipo 'SELECT' para Leer Registros de la Base de datos.
        /// IMPLEMENTACION DELEGADOS Y BASE DE DATOS.
        /// </summary>
        /// <param name="consultaSql">Consulta de tipo 'SELECT'.</param>
        /// <param name="metodoLecturaSql">Metodo que leera los datos obtenidos de la consulta.</param>
        /// <returns>Una cadena que indica cuantas filas se han leido y cuantas tienen error.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        public string EjecutarConsultaDeLecturaDeRegistros(string consultaSql, LeerSqlData metodoLecturaSql)
        {
            return this.EjecutarConsultaDeLecturaDeRegistros(consultaSql, metodoLecturaSql, false);
        }

        /// <summary>
        /// Ejecuta una Consulta de tipo 'SELECT-parametrizada' para Leer Registros de la Base de datos.
        /// IMPLEMENTACION DELEGADOS Y BASE DE DATOS.
        /// </summary>
        /// <param name="consultaSql">Consulta de tipo 'SELECT'.</param>
        /// <param name="metodoLecturaSql">Metodo que leera los datos obtenidos de la consulta.</param>
        /// <param name="metodoCargaDeParametrosSql">Metodo para cargar parametros en la consulta 'SELECT'</param>
        /// <returns>Una cadena que indica cuantas filas se han leido y cuantas tienen error.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        public string EjecutarConsultaDeLecturaDeRegistros(string consultaSql, LeerSqlData metodoLecturaSql, CargarParametrosSQL metodoCargaDeParametrosSql)
        {
            this.MetodoCargaDeParametrosSql = metodoCargaDeParametrosSql;

            return this.EjecutarConsultaDeLecturaDeRegistros(consultaSql, metodoLecturaSql, true);
        }

        /// <summary>
        /// Ejecuta una Consulta de tipo 'INSERT-UPDATE-DELETE' para modificar Registros de la Base de datos.
        /// IMPLEMENTACION DELEGADOS Y BASE DE DATOS.
        /// </summary>
        /// <param name="consultaSql">Consulta de tipo 'INSERT-UPDATE-DELETE'.</param>
        /// <param name="metodoCargaDeParametrosSql">Metodo para cargar parametros en la consulta 'INSERT-UPDATE-DELETE'</param>
        /// <returns>Una cadena con la cantidad de filas afectadas.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        public string EjecutarConsultaDeModificacionDeRegistros(string consultaSql, CargarParametrosSQL metodoCargaDeParametrosSql)
        {
            this.filasAfectadas = 0;

            try
            {
                if (!string.IsNullOrWhiteSpace(consultaSql) && metodoCargaDeParametrosSql is not null)
                {
                    this.conexion.Open();
                    this.comando.CommandText = consultaSql;

                    metodoCargaDeParametrosSql(this.comando);

                    this.filasAfectadas = this.comando.ExecuteNonQuery();

                    return $"Se han modificado {this.filasAfectadas} filas";
                }

                throw new ArgumentNullException("Argumentos recibidos son NULL");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (this.conexion is not null && this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.comando.Parameters.Clear();
                    this.conexion.Close();
                }
            }
        }
    }
}
