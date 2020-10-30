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

        public Universitario()
        {
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) :base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        protected abstract string ParticiparEnClase();

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendFormat("LEGAJO NUMERO: {0}\n",this.legajo);

            return sb.ToString();
        }

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

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        public override bool Equals(object obj)
        {
            return this == (Universitario)obj;
        }
    }
}
