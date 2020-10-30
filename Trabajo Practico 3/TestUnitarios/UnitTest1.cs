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
        [TestMethod]
        public void Verificar_Instancia_Lista()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Instructores);
            Assert.IsNotNull(uni.Alumnos);
            Assert.IsNotNull(uni.Jornadas);
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void Verificar_AlumnoRepetidoException()
        {
            Universidad uni = new Universidad();

            Alumno a = new Alumno(4, "Tomas", "Perez", "90234123", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            Alumno b = new Alumno(4, "Tomas", "Perez", "90234123", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);

            uni += a;
            uni += b;
        }


        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void Verificar_DNIInvalidoException()
        {
            Alumno a = new Alumno(4, "Tomas", "Perez", "902%4e23", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
        }
    }
}
