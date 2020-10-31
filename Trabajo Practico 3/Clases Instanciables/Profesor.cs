using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static EntidadesInstanciables.Universidad;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public class Profesor : Universitario
    {
        private Queue<EClases> clasesDelDia;
        private static Random random;


        #region Constructores

        /// <summary>
        /// Inicializa la Queue con sus clases random
        /// </summary>
        public Profesor()
        {
            this.clasesDelDia = new Queue<EClases>();

            _randomClases();
            _randomClases();
        }

        /// <summary>
        /// Inicializa un objeto de tipo Random
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }


        /// <summary>
        /// Inicializa un objeto profesor con sus respectivos atributos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id,nombre,apellido,dni,nacionalidad)
        {
            Profesor aux = new Profesor();
            this.clasesDelDia = aux.clasesDelDia;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Agrega una clase random a la Queue
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((EClases)Enum.Parse(typeof(EClases),random.Next(0,3).ToString()));
        }

        #endregion

        #region Sobrecarga de metodos

        /// <summary>
        /// Muestra las clases que da el profesor en el dia
        /// </summary>
        /// <returns>Retorna string con las clases que da el profesor en el dia</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");

            foreach (Universidad.EClases auxC in this.clasesDelDia)
            {
                sb.AppendLine(auxC.ToString());
            }

            return sb.ToString();
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve los datos del profesor
        /// </summary>
        /// <returns>String con los datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Compara un profesor con una clase
        /// </summary>
        /// <param name="i">Objeto profesor</param>
        /// <param name="clase">Enumerado EClases</param>
        /// <returns>Retorna true si el profesor da esa clase, false si no lo hace</returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool iguales = false;

            if((object)i != null && (object)clase != null)
            {
                foreach(EClases auxC in i.clasesDelDia)
                {
                    if(auxC == clase)
                    {
                        iguales = true;
                        break;
                    }
                }
            }

            return iguales;
        }

        /// <summary>
        /// Compara un profesor con una clase
        /// </summary>
        /// <param name="i">Objeto profesor</param>
        /// <param name="clase">Enumerado EClases</param>
        /// <returns>Retorna false si el profesor no da esa clase, true si lo hace</returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        #endregion

        
    }
}
