using System.Text;

namespace Entidades
{
    public class Accesorio : Producto
    {
        #region Constructores
        /// <summary>
        /// Constructor sin parametros para la serializacion XML
        /// </summary>
        public Accesorio()
        {
        }

        /// <summary>
        /// Instancia un objeto de tipo Accesorio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombreProducto"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        public Accesorio(int id, string nombreProducto, float precio, string marca) : base(id, nombreProducto, precio, marca)
        {
        }

        #endregion

        #region Propiedad
        /// <summary>
        /// Propiedad de lectura que devuelve un string con el valor "Accesorio"
        /// </summary>
        public override string Tipo
        {
            get
            {
                return "Accesorio";
            }
        }

        #endregion

        #region Metodo
        /// <summary>
        /// Se encarga de obtener los datos del producto
        /// </summary>
        /// <returns>Devuelve un string con los datos del producto</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendFormat("TIPO: {0}\n", this.Tipo);

            return sb.ToString();
        }
        #endregion

        #region Sobrecarga de operadores
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
