using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class ProductoDAO : IBaseDeDatos<Producto>
    {
        private string resultadoDeLecturaDeBBDD;
        private Producto producto;
        private InteraccionConBaseDeDatos interaccionConBaseDeDatos;
        private List<Producto> productos;

        /// <summary>
        /// Constructor de ProductoDAO. Instancia un objeto que permite interacciones con la BBDD-Tabla Productos. 
        /// </summary>
        public ProductoDAO()
        {
            this.interaccionConBaseDeDatos = new InteraccionConBaseDeDatos();
            this.productos = new List<Producto>();
            this.producto = null;
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
        /// <param name="producto">Producto que se cargara en la BBDD.</param>
        /// <returns>Una cadena con la cantidad de filas afectadas.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        public string InsertarEnBaseDeDatos(Producto producto)
        {
            try
            {
                if (producto is not null)
                {
                    this.producto = producto;

                    string consultaSQL;

                    if (this.producto is Disenio)
                    {
                        consultaSQL =
                            "INSERT INTO Productos (Nombre_Producto, Descripcion, Precio, Tamanio, Categoria) " +
                            "VALUES(@nombre, @descripcion, @precio, @tamanio, @categoria)";
                    }
                    else
                    {
                        consultaSQL =
                           "INSERT INTO Productos (Nombre_Producto, Descripcion, Precio, Tiene_Color, Categoria) " +
                           "VALUES(@nombre, @descripcion, @precio, @tieneColor, @categoria)";
                    }

                    return this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consultaSQL, ((IBaseDeDatos<Producto>)this).CargarParametrosSQLParaInsertarRegistro);
                }

                throw new ArgumentNullException("Producto es NULL");
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
        void IBaseDeDatos<Producto>.CargarParametrosSQLParaInsertarRegistro(SqlCommand comando)
        {
            if (comando is not null && this.producto is not null)
            {
                comando.Parameters.AddWithValue("@nombre", this.producto.NombreProducto);
                comando.Parameters.AddWithValue("@descripcion", this.producto.DescripcionProducto);
                comando.Parameters.AddWithValue("@precio", this.producto.PrecioProducto);
                comando.Parameters.AddWithValue("@categoria", this.producto.GetType().Name);

                if (this.producto is Disenio disenio)
                {
                    comando.Parameters.AddWithValue("@tamanio", disenio.TamanioDisenio);
                }
                else if (this.producto is Impresion impresion)
                {
                    comando.Parameters.AddWithValue("@tieneColor", impresion.TieneColor);
                }
            }
            else
            {
                throw new ArgumentNullException("Comando o producto es NULL");
            }
        }

        /// <summary>
        /// Actualiza un elemento en la BBDD.
        /// IMPLEMENTACION SQL Y DELEGADOS
        /// </summary>
        /// <param name="producto">Producto que se actualizara</param>
        /// <returns>Una cadena con la cantidad de filas afectadas</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        public string ActualizarEnBaseDeDatos(Producto producto)
        {
            try
            {
                if (producto is not null)
                {
                    this.producto = producto;

                    string consultaSQL = "UPDATE Productos SET Descripcion = @descripcion, Precio = @precio WHERE Id_Producto = @idProducto";

                    return this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consultaSQL, ((IBaseDeDatos<Producto>)this).CargarParametrosSQLParaModificarRegistros);
                }
                throw new ArgumentNullException("Producto es NULL");
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
        void IBaseDeDatos<Producto>.CargarParametrosSQLParaModificarRegistros(SqlCommand comando)
        {
            if (comando is not null && this.producto is not null)
            {
                comando.Parameters.AddWithValue("@descripcion", this.producto.DescripcionProducto);
                comando.Parameters.AddWithValue("@precio", this.producto.PrecioProducto);
                comando.Parameters.AddWithValue("@idProducto", this.producto.IdProducto);
            }
            else
            {
                throw new ArgumentNullException("Comando o Producto es NULL");
            }
        }

        /// <summary>
        /// Elimina un elemento en la BBDD.
        /// IMPLEMENTACION SQL Y DELEGADOS
        /// </summary>
        /// <param name="producto">Producto que se eliminara de la BBDD.</param>
        /// <returns>Una cadena con la cantidad de filas afectadas.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        public string EliminarDeBaseDeDatos(Producto producto)
        {
            try
            {
                if (producto is not null)
                {
                    this.producto = producto;

                    string consulta = "DELETE FROM Productos WHERE Id_Producto = @idProducto";

                    return this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consulta, ((IBaseDeDatos<Producto>)this).CargarParametrosSQLParaEliminarRegistros);

                }
                throw new ArgumentNullException("Producto es NULL");
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
        void IBaseDeDatos<Producto>.CargarParametrosSQLParaEliminarRegistros(SqlCommand comando)
        {
            if (comando is not null && this.producto is not null)
            {
                comando.Parameters.AddWithValue("@idProducto", this.producto.IdProducto);
            }
            else
            {
                throw new ArgumentNullException("Comando o producto es NULL");
            }
        }

        /// <summary>
        /// Lee todos los registros de la Base de datos.
        /// IMPLEMENTACION SQL Y DELEGADOS
        /// </summary>
        /// <returns>Una lista con todos los registros leidos de la BBDD.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        public List<Producto> LeerTodosLosRegistrosDeBaseDeDatos()
        {
            try
            {
                this.productos.Clear();

                string consultaSQL = "SELECT * FROM Productos";

                this.ResultadoDeLecturaDeBBDD = this.interaccionConBaseDeDatos.EjecutarConsultaDeLecturaDeRegistros(consultaSQL, ((IBaseDeDatos<Producto>)this).LeerSqlData);

                return this.productos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee todos los datos de un producto, contenido en el 'SqlDataReader'. 
        /// Posteriormente crea al producto y lo carga en un lista.
        /// </summary>
        /// <param name="sqlLector">Objeto de tipo SqlDataReader, del cual se leeran los datos.</param>
        /// <returns>True si pudo leer los datos del producto correctamente. Caso contrario False.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="BaseDeDatosException">Error al intentar obtener el registro de la BBDD.</exception>
        bool IBaseDeDatos<Producto>.LeerSqlData(SqlDataReader sqlLector)
        {
            Producto producto;

            try
            {
                if (sqlLector is not null)
                {
                    if (int.TryParse(sqlLector["Id_Producto"].ToString(), out int idProducto) &&
                        double.TryParse(sqlLector["Precio"].ToString(), out double precio))
                    {
                        string nombreProducto = sqlLector["Nombre_Producto"].ToString();
                        string descripcion = sqlLector["Descripcion"].ToString();
                        string categoria = sqlLector["Categoria"].ToString();

                        if (categoria == typeof(Disenio).Name)
                        {
                            Enum.TryParse(sqlLector["Tamanio"].ToString(), out Disenio.Tamanio tamanio);

                            producto = new Disenio(nombreProducto, descripcion, precio, tamanio, idProducto);
                        }
                        else
                        {
                            int.TryParse(sqlLector["Tiene_Color"].ToString(), out int esColor);

                            bool tieneColor = esColor == 1 ? true : false;

                            producto = new Impresion(nombreProducto, descripcion, precio, tieneColor, idProducto);
                        }

                        this.productos.Add(producto);

                        return true;
                    }
                }
                throw new BaseDeDatosException("Error al intentar obtener registros de la Base de datos");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee un unico registro de la BBDD, correspondiente al identificador recibido por parametro.
        /// IMPLEMENTACION SQL, LAMBDA Y DELEGADOS.
        /// </summary>
        /// <param name="id">Id del producto.</param>
        /// <returns>El producto correspondiente al ID, NULL si no lo encontro.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        public Producto LeerUnRegistroDeBaseDeDatosPorIdentificador(int identificador)
        {
            try
            {
                this.productos.Clear();

                string consultaSQL = "SELECT * FROM Productos WHERE Id_Productos = @idProducto";

                this.ResultadoDeLecturaDeBBDD = this.interaccionConBaseDeDatos.EjecutarConsultaDeLecturaDeRegistros
                    (consultaSQL, ((IBaseDeDatos<Producto>)this).LeerSqlData, comandoSQL => comandoSQL.Parameters.AddWithValue("@idProducto", identificador));

                if (this.productos.Count == 1)
                {
                    return this.productos[0];
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene el ultimo producto cargado en la Base de datos.
        /// IMPLEMENTACION SQL Y DELEGADOS
        /// </summary>
        /// <returns>El ultimo producto cargado en la Base de datos.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="NullReferenceException">Error al intentar obtener el ultimo elemento de la BBDD.</exception>
        public Producto ObtenerUltimoElementoCargadoEnBaseDeDatos()
        {
            try
            {
                this.productos.Clear();

                string consultaSql = "SELECT * FROM Productos WHERE Id_Producto = (SELECT MAX(Productos.Id_Producto) FROM Productos)";

                this.interaccionConBaseDeDatos.EjecutarConsultaDeLecturaDeRegistros(consultaSql, ((IBaseDeDatos<Producto>)this).LeerSqlData);

                if (this.productos.Count == 1)
                {
                    return this.productos[0];
                }
                throw new NullReferenceException("No se pudo obtener el ultimo producto cargado en la Base de datos");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
