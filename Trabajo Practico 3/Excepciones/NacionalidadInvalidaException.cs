using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor que le pasa un mensaje al constructor base
        /// </summary>
        /// <param name="mensaje">Mensaje de error de la excepcion</param>
        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        {
        }
        
        /// <summary>
        /// Constructor que llama al constructor base
        /// </summary>
        public NacionalidadInvalidaException() : base()
        {
        }
    }
}
