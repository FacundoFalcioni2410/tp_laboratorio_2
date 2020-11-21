using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pantalla : Producto
    {
        private EResolucion resolucion;
        private EPulgadas pulgadas;

        #region Constructores
        /// <summary>
        /// Constructor sin parametros para la serializacion XML
        /// </summary>
        public Pantalla()
        {
        }

        /// <summary>
        /// Instancia un objeto de tipo Accesorio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombreProducto"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        public Pantalla(int id, string nombreProducto, float precio, string marca,EPulgadas pulgadas, EResolucion resolucion) : base(id, nombreProducto, precio, marca)
        {
            this.resolucion = resolucion;
            this.pulgadas = pulgadas;
        }

        #endregion

        public string Resolucion
        {
            get
            {
                switch (resolucion)
                {
                    case EResolucion.P720:
                        return "720p";
                    default:
                        return "1080p";
                }
            }
        }

        public int Pulgada
        {
            get
            {
                switch (pulgadas)
                {
                    case EPulgadas.P28:
                        return 28;
                    case EPulgadas.P32:
                        return 32;
                    default:
                        return 40;
                }
            }
        }

        #region Metodos

        public static EResolucion MapeoResolucion(string aux)
        {
            switch (aux)
            {
                case "4K":
                    return EResolucion.K4;
                case "1080p":
                    return EResolucion.P1080;
                default:
                    return EResolucion.P720;
            }
        }

        public static EPulgadas MapeoPulgadas(string aux)
        {
            switch (aux)
            {
                case "28":
                    return EPulgadas.P28;
                case "32":
                    return EPulgadas.P32;
                default:
                    return EPulgadas.P40;
            }
        }

        /// <summary>
        /// Se encarga de obtener los datos del producto
        /// </summary>
        /// <returns>Devuelve un string con los datos del producto</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendFormat("RESOLUCION: {0}\nPULGADAS: {1}\n", this.Resolucion, this.Pulgada);
            return sb.ToString();
        }
        #endregion

        #region Sobrecarga de metodos
        /// <summary>
        /// Se encarga de obtener los datos del producto
        /// </summary>
        /// <returns>Devuelve un string con los datos del producto</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
