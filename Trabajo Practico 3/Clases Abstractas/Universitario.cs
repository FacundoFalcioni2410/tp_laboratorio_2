using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores
        /// <summary>
        /// Inicializa objeto universitario con valores default
        /// </summary>
        public Universitario()
        {
        }

        /// <summary>
        /// Inicializa un objeto universitario
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        //Agrego propiedad para que pueda guardarse el atributo legajo con la deserializacion del XML ya que
        //su atributo es privado.

        #region Propiedades

        /// <summary>
        /// Propiedad de lectura y escritura del atributo legajo
        /// </summary>
        public int Legajo
        {
            get
            {
                return this.legajo;
            }
            set
            {
                this.legajo = value;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo abstracto
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();


        /// <summary>
        /// Muestra los datos del universitario
        /// </summary>
        /// <returns>String con los datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendFormat("LEGAJO NUMERO: {0}\n",this.legajo);

            return sb.ToString();
        }

        #endregion

        #region Sobrecarga de metodos

        /// <summary>
        /// Sobrecarga del equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Returna true si obj es universitario y si el legajo o dni de ambos son 
        /// iguales, caso contrario retorna false</returns>
        public override bool Equals(object obj)
        {
            return (obj is Universitario) && this == (Universitario)obj;
        }

        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Compara dos objetos universitarios
        /// </summary>
        /// <param name="pg1">Objeto universitario</param>
        /// <param name="pg2">Objeto universitario</param>
        /// <returns>Returna true si el legajo o dni de ambos son iguales, caso contrario retorna false</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool iguales = false;

            if((object)pg1 != null && (object)pg2 != null)
            {
                if(pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
                {
                    iguales = true;
                }
            }

            return iguales;
        }

        /// <summary>
        /// Compara dos objetos universitarios
        /// </summary>
        /// <param name="pg1">Objeto universitario</param>
        /// <param name="pg2">Objeto universitario</param>
        /// <returns>Returna false si el legajo o dni de ambos son iguales, caso contrario retorna true</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    }
}
