using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string dato = Console.ReadLine();

            Console.WriteLine(dato);

            if (dato.Contains('.'))
            {
                dato = dato.Replace(".","");
            }

            Console.WriteLine(dato);

            Console.ReadKey(true);
        }
    }
}
