using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static EntidadesInstanciables.Universidad;

namespace EntidadesInstanciables
{
    public class Alumno : Universitario
    {
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #region Constructores

        /// <summary>
        /// Inicializa un objeto alumno con sus atributos default
        /// </summary>
        public Alumno()
        {
        }

        /// <summary>
        /// Inicializa un objeto alumno con sus respectivos atributos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }


        /// <summary>
        /// Inicializa un objeto alumno con sus respectivos atributos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Sobrecarga de metodos

        /// <summary>
        /// Muestra los datos del alumno
        /// </summary>
        /// <returns>Retorna string con los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta);
            sb.Append(ParticiparEnClase());
            sb.AppendLine();

            return sb.ToString();
        }

        /// <summary>
        /// Muestra la clase que toma el alumno
        /// </summary>
        /// <returns>Retorna un string con la clase que toma el alumno</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("TOMA CLASES DE: {0}", this.claseQueToma);
            sb.AppendLine();

            return sb.ToString();
        }

        /// <summary>
        /// Muestro los datos del alumno
        /// </summary>
        /// <returns>Retorna los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Compara un objeto Alumno con un enumerado EClases
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna true si el alumno toma esa clase y su estado de cuenta no es deudor
        /// caso contrario retorna false</returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            bool iguales = false;

            if((object)a != null && (object)clase != null)
            {
                if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                {
                    iguales = true;
                }
            }

            return iguales;
        }

        /// <summary>
        /// Compara un objeto Alumno con un enumerado EClases
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna false si el alumno no toma esa clase y su estado de cuenta es deudor
        /// caso contrario retorna true</returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            return !(a == clase);
        }

        #endregion
    }
}
