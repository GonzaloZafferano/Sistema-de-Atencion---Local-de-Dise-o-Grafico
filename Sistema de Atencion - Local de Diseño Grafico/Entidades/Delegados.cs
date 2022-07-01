using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public delegate void CargarParametrosSQL(SqlCommand comando);

    public delegate bool LeerSqlData(SqlDataReader sqlLector);

    public delegate void CargarProgresoDeLecturaHandler(int porcentajeDeProgreso);

    public delegate void LecturaDeDatosHandler(string lecturaDeDatos);
}
