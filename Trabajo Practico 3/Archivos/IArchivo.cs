using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface IArchivo<T>
    {
        bool Guardar(string archivo, T datos);

        bool Leer(string archivo, out T datos);
    }
}
