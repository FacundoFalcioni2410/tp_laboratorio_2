using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using static Clases_Instanciables.Universidad;

namespace Clases_Instanciables
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

        public Alumno() : base()
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendFormat("ESTADO DE CUENTA: {0}\n",this.estadoCuenta);

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE: " + this.claseQueToma + "\n";
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

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

        public static bool operator !=(Alumno a, EClases clase)
        {
            return !(a == clase);
        }
    }
}
