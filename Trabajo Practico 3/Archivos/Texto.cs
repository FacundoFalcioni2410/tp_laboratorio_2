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
        /// <summary>
        /// Guarda datos en un archivo .txt
        /// </summary>
        /// <param name="archivo">path donde se guarda el archivo</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            bool guardado = false; ;

            if((object)archivo != null && (object)datos != null)
            {
                using (StreamWriter sw = new StreamWriter(archivo, true))
                {
                    if (sw != null)
                    {
                        sw.Write(datos);
                        sw.Write("<------------------------------------------------>\n\n");
                        guardado = true;
                        sw.Close();
                    }
                    else
                    {
                        throw new ArchivosException();
                    }
                }
            }
            
            return guardado;
        }

        /// <summary>
        /// lee un archivo .txt
        /// </summary>
        /// <param name="archivo">path donde se lee el archivo</param>
        /// <param name="datos">donde se guardan los datos leidos</param>
        /// <returns></returns>
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
