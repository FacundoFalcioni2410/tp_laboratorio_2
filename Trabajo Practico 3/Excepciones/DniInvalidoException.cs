using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor que llama al constructor base
        /// </summary>
        public DniInvalidoException() : base()
        {
        }

        /// <summary>
        /// Constructor que le pasa un mensaje al constructor base
        /// </summary>
        /// <param name="mensaje">Mensaje de error de la excepcion</param>
        public DniInvalidoException(string mensaje) : base(mensaje)
        {
        }

        /// <summary>
        /// Constructor que llama al constructor base y le pasa una excepcion
        /// </summary>
        /// <param name="e">Excepcion</param>
        public DniInvalidoException(Exception e) : base(e.Message)
        {
        }

        /// <summary>
        /// Constructor que llama al constrcutor base y le pasa un mensaje y una excepcion
        /// </summary>
        /// <param name="mensaje">mensaje de error de la excepcion</param>
        /// <param name="e">excepcion</param>
        public DniInvalidoException(string mensaje, Exception e) : base(mensaje,e)
        {
        }
    }
}
