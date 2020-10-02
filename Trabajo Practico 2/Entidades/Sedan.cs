using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        ETipo tipo;

        #region Propiedades
        /// <summary>
        /// Los automoviles son medianos
        /// </summary>

        public override ETamanio Tamanio //sobreescribo la propiedad abstracta de la clase Vehiculo
        {
            get
            {
                return ETamanio.Mediano;
            }

        }
        #endregion

        #region Constructores

        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            tipo = ETipo.CuatroPuertas;
        }

        public Sedan(EMarca marca, string chasis, ConsoleColor color,ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Metodo
        public override sealed string Mostrar() //sobreescribo el metodo Mostrar de la clase Vehiculo
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar()); //llamo al metodo base para obtener los datos del vehiculo
            sb.AppendFormat("TAMAÑO : {0}\n", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

        #region Enumerado
        public enum ETipo 
        { 
            CuatroPuertas, CincoPuertas
        }
        #endregion
    }
}
