using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductoSinMarcaException : Exception
    {
        public ProductoSinMarcaException() : base()
        {
                
        }

        public ProductoSinMarcaException(string mensaje) : base(mensaje)
        {

        }
    }
}
