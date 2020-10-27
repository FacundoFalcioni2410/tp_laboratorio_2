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
        public bool Guardar(string archivo, T datos)
        {
            bool guardado = false;

            XmlTextWriter writer = new XmlTextWriter(archivo,Encoding.UTF8);

            if(writer != null)
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));

                if(ser != null)
                {
                    ser.Serialize(writer, datos);
                    guardado = true;
                }

            }
            else
            {
                throw new ArchivosException();
            }

            return guardado;
        }

        public bool Leer(string archivo, out T datos)
        {
            bool leido = false;
            datos = default;

            XmlTextReader reader = new XmlTextReader(archivo);

            if (reader != null)
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                if(ser != null)
                {
                    datos = (T)ser.Deserialize(reader);
                    leido = true;
                }
                else
                {
                    throw new ArchivosException();
                }

            }
            else
            {
                throw new ArchivosException();
            }    

            return leido;
        }
    }
}
