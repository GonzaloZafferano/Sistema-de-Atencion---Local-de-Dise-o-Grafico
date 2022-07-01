using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class CompraDAO : IBaseDeDatos<Compra>
    {
        private string resultadoDeLecturaDeBBDD;
        private Compra compra;
        private InteraccionConBaseDeDatos interaccionConBaseDeDatos;
        private List<Compra> compras;

        /// <summary>
        /// Constructor de CompraDAO. Instancia un objeto que permite interacciones con la BBDD-Tabla Compras. 
        /// </summary>
        public CompraDAO()
        {
            this.interaccionConBaseDeDatos = new InteraccionConBaseDeDatos();
            this.compras = new List<Compra>();
            this.compra = null;
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
        /// IMPLEMENTACION SQL Y DELEGADOS
        /// </summary>
        /// <param name="compra">Compra que se cargara en la BBDD.</param>
        /// <returns>Una cadena con la cantidad de filas afectadas.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        public string InsertarEnBaseDeDatos(Compra compra)
        {
            try
            {
                if (compra is not null)
                {
                    this.compra = compra;

                    string consultaSQL =
                        "INSERT INTO Compras (Dni_Cliente, Descuento, Precio_Final_Acumulado_Con_Descuento, Id_Usuario, Medio_De_Pago, Fecha_Compra, Detalles_Compra) " +
                        "VALUES(@dniCliente, @descuento, @precioFinal, @idUsuario, @medioDePago, @fechaCompra, @detallesCompra)";

                    return this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consultaSQL, ((IBaseDeDatos<Compra>)this).CargarParametrosSQLParaInsertarRegistro);
                }

                throw new ArgumentNullException("Compra es NULL");
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
        void IBaseDeDatos<Compra>.CargarParametrosSQLParaInsertarRegistro(SqlCommand comando)
        {
            if (comando is not null && this.compra is not null)
            {
                comando.Parameters.AddWithValue("@dniCliente", this.compra.DniCliente);
                comando.Parameters.AddWithValue("@descuento", this.compra.Descuento);
                comando.Parameters.AddWithValue("@precioFinal", this.compra.PrecioTotal);
                comando.Parameters.AddWithValue("@idUsuario", this.compra.IdUsuario);
                comando.Parameters.AddWithValue("@medioDePago", this.compra.MedioDePagoUtilizado);
                comando.Parameters.AddWithValue("@fechaCompra", this.compra.FechaCompra);
                comando.Parameters.AddWithValue("@detallesCompra", this.compra.ProductosComprados);
            }
            else
            {
                throw new ArgumentNullException("Comando o compra es NULL");
            }
        }

        /// <summary>
        /// Lee todos los registros de la Base de datos.
        /// IMPLEMENTACION SQL Y DELEGADOS
        /// </summary>
        /// <returns>Una lista con todos los registros leidos de la BBDD.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        public List<Compra> LeerTodosLosRegistrosDeBaseDeDatos()
        {
            try
            {
                this.compras.Clear();

                string consultaSQL = "SELECT * FROM Compras";

                this.ResultadoDeLecturaDeBBDD = this.interaccionConBaseDeDatos.EjecutarConsultaDeLecturaDeRegistros(consultaSQL, ((IBaseDeDatos<Compra>)this).LeerSqlData);

                return this.compras;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee todos los datos de una compra, contenida en el 'SqlDataReader'. 
        /// Posteriormente recrea la compra y la carga en un lista.
        /// </summary>
        /// <param name="sqlLector">Objeto de tipo SqlDataReader, del cual se leeran los datos.</param>
        /// <returns>True si pudo leer los datos de la compra correctamente. Caso contrario False.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="BaseDeDatosException">Error al intentar obtener el registro de la BBDD.</exception>
        bool IBaseDeDatos<Compra>.LeerSqlData(SqlDataReader sqlLector)
        {
            Compra compra;

            try
            {
                if (sqlLector is not null)
                {
                    if (int.TryParse(sqlLector["Id_Compra"].ToString(), out int idCompra) &&
                        int.TryParse(sqlLector["Dni_Cliente"].ToString(), out int dniCliente) &&
                        double.TryParse(sqlLector["Descuento"].ToString(), out double descuento) &&
                        double.TryParse(sqlLector["Precio_Final_Acumulado_Con_Descuento"].ToString(), out double precioFinal) &&
                        int.TryParse(sqlLector["Id_Usuario"].ToString(), out int idUsuario) &&
                        Enum.TryParse(sqlLector["Medio_De_Pago"].ToString(), out Compra.MedioDePago medioDePago) &&
                        DateTime.TryParse(sqlLector["Fecha_Compra"].ToString(), out DateTime fechaCompra))
                    {
                        string detallesCompra = sqlLector["Detalles_Compra"].ToString();

                        compra = new Compra(dniCliente, idUsuario, medioDePago, fechaCompra, descuento, precioFinal, detallesCompra, idCompra);

                        this.compras.Add(compra);

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
        /// Obtiene la ultima compra cargada en la Base de datos.
        /// IMPLEMENTACION SQL Y DELEGADOS
        /// </summary>
        /// <returns>La ultima compra cargada en la Base de datos.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="NullReferenceException">Error al intentar obtener el ultimo elemento de la BBDD.</exception>
        public Compra ObtenerUltimoElementoCargadoEnBaseDeDatos()
        {
            try
            {
                this.compras.Clear();

                string consultaSql = "SELECT * FROM Compras WHERE Compras.Id_Compra = (SELECT MAX(Compras.Id_Compra) FROM Compras)";

                this.interaccionConBaseDeDatos.EjecutarConsultaDeLecturaDeRegistros(consultaSql, ((IBaseDeDatos<Compra>)this).LeerSqlData);

                if (this.compras.Count == 1)
                {
                    return this.compras[0];
                }
                throw new NullReferenceException("No se pudo obtener la ultima compra cargada en la Base de datos");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo no implementado.
        /// </summary>
        /// <param name="compra"></param>
        /// <returns></returns>
        string IBaseDeDatos<Compra>.ActualizarEnBaseDeDatos(Compra compra)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo no implementado.
        /// </summary>
        /// <param name="comando"></param>
        void IBaseDeDatos<Compra>.CargarParametrosSQLParaModificarRegistros(SqlCommand comando)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo no implementado.
        /// </summary>
        /// <param name="compra"></param>
        /// <returns></returns>
        string IBaseDeDatos<Compra>.EliminarDeBaseDeDatos(Compra compra)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo no implementado.
        /// </summary>
        /// <param name="comando"></param>
        void IBaseDeDatos<Compra>.CargarParametrosSQLParaEliminarRegistros(SqlCommand comando)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo no implementado.
        /// </summary>
        /// <param name="identificador"></param>
        /// <returns></returns>
        Compra IBaseDeDatos<Compra>.LeerUnRegistroDeBaseDeDatosPorIdentificador(int identificador)
        {
            throw new NotImplementedException();
        }
    }
}
