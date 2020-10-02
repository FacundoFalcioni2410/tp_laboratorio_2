using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        #region Propiedades
        /// <summary>
        /// Las motos son chicas
        /// </summary>
        public override ETamanio Tamanio //sobreescribo la propiedad abstracta de la clase Vehiculo
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion

        #region Constructor
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color) : base(chasis,marca,color)
        {
        }
        #endregion

        #region Metodo
        public override sealed string Mostrar() //sobreescribo el metodo Mostrar de la clase Vehiculo
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendFormat(base.Mostrar()); //llamo al metodo base para obtener los datos del vehiculo
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
