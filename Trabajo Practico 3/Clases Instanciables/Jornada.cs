using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        /// <summary>
        /// Constructor privado que inicializa la lista de Alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor que inicializa los atributos de la clase jornada
        /// </summary>
        /// <param name="clase">Enumerado</param>
        /// <param name="instructor">objeto profesor</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        /// <summary>
        /// Guarda los datos de la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">Objeto jornada</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();

            return texto.Guardar("Jornada.txt", jornada.ToString());
        }


        /// <summary>
        /// Lee el archivo de texto jornada
        /// </summary>
        /// <returns>retorna el contenido del archivo</returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            string salida;

            texto.Leer("Jornada.txt", out salida);

            return salida;           
        }

        /// <summary>
        /// Compara un alumno con la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Retorna true si el alumno pertenece a la jornada, false en caso contrario</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool iguales = false;

            if(a == j.clase)
            {
                iguales = true;
            }

            return iguales;
        }


        /// <summary>
        /// Compara un alumno con la jornada
        /// </summary>
        /// <param name="j">Objeto jornada</param>
        /// <param name="a">objeto alumno</param>
        /// <returns>Retorna false si el alumno pertenece a la jornada, true en caso contrario</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega a un alumno a la jornada siempre y cuando este no pertenezca en un primer momento
        /// </summary>
        /// <param name="j">Objeto jornada</param>
        /// <param name="a">Objeto alumno</param>
        /// <returns>Retorna un elemento de tipo jornada con la lista actualizada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool flag = false;

            if((object)j != null)
            {
                foreach(Alumno auxA in j.alumnos)
                {
                    if(auxA.Equals(a))
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag && a == j.clase)
                {
                    j.alumnos.Add(a);
                }
            }

            return j;
        }

        /// <summary>
        /// Crea un string con los datos de la jornada
        /// </summary>
        /// <returns>Retorna los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            sb.AppendFormat("CLASE DE {0} POR {1}\n",this.clase.ToString(),this.instructor.ToString());

            sb.AppendLine("ALUMNOS:");
            foreach (Alumno auxA in this.alumnos)
            {
                sb.Append(auxA.ToString());
            }
            return sb.ToString();
        }
    }
}
