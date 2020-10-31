using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor por default
        /// </summary>
        public AlumnoRepetidoException() : base()
        {
        }
        /// <summary>
        /// Constructor que le pasa un mensaje al constructor base
        /// </summary>
        /// <param name="mensaje">Mensaje de error de la excepcion</param>
        public AlumnoRepetidoException(string mensaje) : base(mensaje)
        {
        }
    }
}
