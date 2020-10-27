using Clases_Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Clases_Instanciables.Universidad;

namespace Clases_Instanciables
{
    public class Profesor : Universitario
    {
        private Queue<EClases> clasesDelDia;
        private static Random random;

        public Profesor()
        {
            this.clasesDelDia = new Queue<EClases>();

            _randomClases();
            _randomClases();
        }

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id,nombre,apellido,dni,nacionalidad)
        {
            Profesor aux = new Profesor();
            this.clasesDelDia = aux.clasesDelDia;
        }

        private void _randomClases()
        {
           // for(int i = 0; i < 2; i++)
           // {
                this.clasesDelDia.Enqueue((Universidad.EClases)Enum.Parse(typeof(Universidad.EClases),random.Next(0,3).ToString()));

                /*switch(Profesor.random.Next(1,4))
                {
                    case 1:
                        this.clasesDelDia.Enqueue(EClases.Laboratorio);
                        break;
                    case 2:
                        this.clasesDelDia.Enqueue(EClases.Legislacion);
                        break;
                    case 3:
                        this.clasesDelDia.Enqueue(EClases.Programacion);
                        break;
                    default:
                        this.clasesDelDia.Enqueue(EClases.SPD);
                        break;
                }*/
          //  }
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");

            foreach(Universidad.EClases auxC in this.clasesDelDia)
            {
                sb.AppendLine(auxC.ToString());
            }

            return sb.ToString();
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());

            return sb.ToString();
        }

        public static bool operator ==(Profesor i, EClases clase)
        {
            bool iguales = false;

            if((object)i != null && (object)clase != null)
            {
                foreach(Universidad.EClases auxC in i.clasesDelDia)
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

        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
