using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IObtenerIgualdad
    {
        bool EsMismoElemento<T>(T elemento) where T : class, IObtenerIgualdad;
        bool EsMismoIdentificador(int identificador);
    }
}
