using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa datos a un archivo .xml
        /// </summary>
        /// <param name="archivo">path del archivo</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool guardado = false;

            using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
            {
                if (writer != null)
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    if (ser != null)
                    {
                        ser.Serialize(writer, datos);
                        guardado = true;
                    }

                }
                else
                {
                    throw new ArchivosException("Error al guardar el archivo");
                }
            }

            return guardado;
        }

        /// <summary>
        /// Deserializa un archivo .xml
        /// </summary>
        /// <param name="archivo">path donde leer el archivo</param>
        /// <param name="datos">donde se guardan los datos</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool leido;
            datos = default;

            using (XmlTextReader reader = new XmlTextReader(archivo))
            {
                if (reader != null)
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    if (ser != null)
                    {
                        datos = (T)ser.Deserialize(reader);
                        leido = true;
                    }
                    else
                    {
                        throw new ArchivosException("Error al leer el archivo");
                    }

                }
                else
                {
                    throw new ArchivosException();
                }
            }  

            return leido;
        }
    }
}
