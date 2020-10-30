using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool guardado = false; ;

            if((object)archivo != null && (object)datos != null)
            {
                StreamWriter sw = new StreamWriter(archivo);

                if (sw != null)
                {
                    sw.Write(datos);
                    guardado = true;
                    sw.Close();
                }
                else
                {
                    throw new ArchivosException();
                }
            }
            
            return guardado;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool leido;

            StreamReader sr = new StreamReader(archivo);

            if (sr != null)
            {
                datos = sr.ReadToEnd();
                leido = true;
                sr.Close();
            }
            else
            {
                throw new ArchivosException();
            }

            return leido;
        }
    }
}
