using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor que llama al constructor base
        /// </summary>
        public ArchivosException() : base()
        {
        }

        /// <summary>
        /// Constructor que llama al constructor base y le pasa una excepcion
        /// </summary>
        /// <param name="innerException">excepcion</param>
        public ArchivosException(Exception innerException) : base(innerException.Message)
        {
        }

        /// <summary>
        /// Constructor que le pasa un mensaje al constructor base
        /// </summary>
        /// <param name="mensaje">Mensaje de error de la excepcion</param>
        public ArchivosException(string mensaje) : base(mensaje)
        {
        }
    }
}
