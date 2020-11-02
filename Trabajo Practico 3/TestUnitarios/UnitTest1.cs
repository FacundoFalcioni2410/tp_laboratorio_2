using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using EntidadesInstanciables;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Comprueba que las listas de Universidad se instancien correctamente
        /// </summary>
        [TestMethod]
        public void Verificar_Instancia_Lista()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Instructores);
            Assert.IsNotNull(uni.Alumnos);
            Assert.IsNotNull(uni.Jornadas);
        }

        /// <summary>
        /// Comprueba que se lance la excepcion AlumnoRepetidoException al agregar dos alumnos iguales
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void Verificar_AlumnoRepetidoException()
        {
            Universidad uni = new Universidad();

            Alumno a = new Alumno(4, "Tomas", "Perez", "90234123", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            Alumno b = new Alumno(6, "Julian", "Diaz", "90234123", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);

            uni += a;
            uni += b;
        }

        /// <summary>
        /// Comprueba que se lance la excepcion DniInvalidoException si el formato no es el correcto
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void Verificar_DNIInvalidoException()
        {
            Alumno a = new Alumno(4, "Tomas", "Perez", "902%4e23", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
        }
    }
}
