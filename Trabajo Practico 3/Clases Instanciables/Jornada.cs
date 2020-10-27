using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
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

        public Jornada(Universidad.EClases clase, Profesor instructor)
        {
            this.clase = clase;
            this.instructor = instructor;
        }


        public bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();

            return texto.Guardar("Jornada.txt", jornada.ToString());
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

            if((object)j != null && (object)a != null)
            {
                foreach(Alumno auxA in j.alumnos)
                {
                    if(auxA == a)
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

            foreach(Alumno auxA in this.alumnos)
            {
                sb.Append(auxA.ToString());
            }

            sb.AppendLine(this.clase.ToString());
            sb.AppendLine(this.instructor.ToString());


            return sb.ToString();
        }
    }
}
