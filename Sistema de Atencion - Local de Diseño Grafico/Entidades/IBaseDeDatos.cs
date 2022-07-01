using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    interface IBaseDeDatos<T> where T : class
    {
        string ResultadoDeLecturaDeBBDD { get; }
        string InsertarEnBaseDeDatos(T elemento);
        void CargarParametrosSQLParaInsertarRegistro(SqlCommand comando);
        string ActualizarEnBaseDeDatos(T elemento);
        void CargarParametrosSQLParaModificarRegistros(SqlCommand comando);
        string EliminarDeBaseDeDatos(T elemento);
        void CargarParametrosSQLParaEliminarRegistros(SqlCommand comando);
        List<T> LeerTodosLosRegistrosDeBaseDeDatos();
        bool LeerSqlData(SqlDataReader sqlLector);
        T LeerUnRegistroDeBaseDeDatosPorIdentificador(int identificador);
        T ObtenerUltimoElementoCargadoEnBaseDeDatos();
    }
}
