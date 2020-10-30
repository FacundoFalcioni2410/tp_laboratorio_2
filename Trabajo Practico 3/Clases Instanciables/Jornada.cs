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

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }


        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();

            return texto.Guardar("Jornada.txt", jornada.ToString());
        }

        public static string Leer()
        {
            Texto texto = new Texto();
            string salida;

            texto.Leer("Jornada.txt", out salida);

            return salida;           
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool iguales = false;

            if(a == j.clase)
            {
                iguales = true;
            }

            return iguales;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

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
