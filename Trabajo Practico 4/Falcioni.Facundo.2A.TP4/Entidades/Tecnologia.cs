using System.Text;

namespace Entidades
{
    public class Tecnologia : Producto
    {
        /// <summary>
        /// Constructor sin parametros para la serializacion XML
        /// </summary>
        public Tecnologia()
        {
        }

        /// <summary>
        /// Instancia un objeto de tipo Tecnologia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombreProducto"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        public Tecnologia(int id, string nombreProducto, float precio, string marca) : base(id, nombreProducto, precio, marca)
        {
        }

        /// <summary>
        /// Propiedad de lectura que devuelve un string con el valor "Tecnologia"
        /// </summary>
        public override string Tipo
        {
            get
            {
                return "Tecnologia";
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
            sb.AppendFormat("TIPO: {0}\n", this.Tipo);
            return sb.ToString();
        }

        /// <summary>
        /// Se encarga de obtener los datos del producto
        /// </summary>
        /// <returns>Devuelve un string con los datos del producto</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
