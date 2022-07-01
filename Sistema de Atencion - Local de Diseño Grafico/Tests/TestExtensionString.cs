using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Tests
{
    [TestClass]
    public class TestExtensionString
    {
        [TestMethod]
        public void DarFormatoDeNombre_CuandoSeEjecutaSobreUnString_DeberiaRetornarLaPrimeraLetraDeCadaPalabraEnMayusculas_UnEspacioEntrePalabras_ElRestoEnMinusculas()
        {
            //ARRANGE
            string esperado = "Gonzalo Fabian Zafferano";
            string actual;

            //ACT
            actual = "          gOnZaLo          faBIAN       zaffERAno               ".DarFormatoDeNombre();

            //ASSERT
            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void EsFormatoTelefonico_CuandoSeEnviaUnFormatoErroneo_DeberiaRetornarFalse()
        {
            //ARRANGE
            string telefono = "11-98769874";
            bool actual;

            //ACT
            actual = telefono.EsFormatoTelefonico();

            //ASSERT
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void EsFormatoTelefonico_CuandoSeEnviaUnFormatoCorrecto_DeberiaRetornarTrue()
        {
            //ARRANGE
            string telefono = "11-9876-9874";
            bool actual;

            //ACT
            actual = telefono.EsFormatoTelefonico();

            //ASSERT
            Assert.IsTrue(actual);
        }
    }
}
