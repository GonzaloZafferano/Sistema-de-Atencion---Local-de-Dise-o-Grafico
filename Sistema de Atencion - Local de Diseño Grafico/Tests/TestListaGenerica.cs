using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Tests
{
    [TestClass]
    public class TestListaGenerica
    {
        [TestMethod]
        public void CargarElementoAlSistema_CuandoAunNoExisteElElementoCargado_DeberiaRetornarTrue()
        {
            //ARRANGE
            ListaGenerica<Empleado> empleados = new ListaGenerica<Empleado>();
            bool actual;

            Empleado empleadoA = new Empleado("Z", "G", 1111111, 987, "abcd");

            //ACT
            actual = empleados.CargarElementoAlSistema(empleadoA);            

            //ASSERT
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CargarElementoAlSistema_CuandoYaExisteElElementoCargado_DeberiaRetornarFalse()
        {
            //ARRANGE
            ListaGenerica<Empleado> empleados = new ListaGenerica<Empleado>();
            bool actual = true;

            Empleado empleadoA = new Empleado("Z", "G", 1111111, 987, "abcd");

            Empleado empleadoB = new Empleado("Z", "G", 1111111, 987, "abcd");

            //ACT
            if (empleados.CargarElementoAlSistema(empleadoA))
            {
                actual = empleados.CargarElementoAlSistema(empleadoB);
            }

            //ASSERT
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ExisteElementoPorIdentificador_CuandoElElementoEstaCargadoEnElSistema_DeberiaRetornarTrue()
        {
            //ARRANGE
            ListaGenerica<Empleado> empleados = new ListaGenerica<Empleado>();
            bool actual = false;

            Empleado empleadoA = new Empleado("Z", "G", 1111111, 987, "abcd");

            //ACT
            if (empleados.CargarElementoAlSistema(empleadoA))
            {
                actual = empleados.ExisteElementoPorIdentificador(empleadoA.Dni);
            }

            //ASSERT
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ExisteElementoPorIdentificador_CuandoElElementoNoEstaCargado_DeberiaRetornarFalse()
        {
            //ARRANGE
            ListaGenerica<Empleado> empleados = new ListaGenerica<Empleado>();
            bool actual;

            Empleado empleadoA = new Empleado("Z", "G", 1111111, 987, "abcd");

            //ACT
            actual = empleados.ExisteElementoPorIdentificador(empleadoA.Dni);          

            //ASSERT
            Assert.IsFalse(actual);
        }
    }
}
