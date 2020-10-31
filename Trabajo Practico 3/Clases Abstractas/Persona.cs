using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{
    [XmlInclude(typeof(Universitario))]
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;
    
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region Propiedades

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDNI(this.nacionalidad, value);
            }
        }

        public string StringToDni
        {
            set
            {
                this.dni = ValidarDNI(this.nacionalidad, value);
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa un objeto persona con valores default
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Inicializa un objeto Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.nacionalidad = nacionalidad;
        }


        /// <summary>
        /// Inicializa un objeto persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }


        /// <summary>
        /// inicializa un objeto persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this.StringToDni = dni;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Valida que el DNI este en el rango correspondiente a la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Enumerado ENacionalidad</param>
        /// <param name="dato">entero a validar</param>
        /// <returns>Retorna el DNI validado, caso contrario lanza una excepcion</returns>
        private static int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato > 0 && dato < 90000000)
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no coincide con el número DNI");
                }
            }
            else
            {
                if (dato > 89999999 && dato < 100000000)
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no coincide con el número DNI");
                }
            }
        }


        /// <summary>
        /// Valida que el DNI contenga solo numeros
        /// </summary>
        /// <param name="nacionalidad">Enumerado ENacionalidad</param>
        /// <param name="dato">string a validar</param>
        /// <returns>Devuelve el DNI validado, caso contrario lanza una excepcion</returns>
        private static int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            if (dato.Contains('.'))
            {
                dato = dato.Replace(".", "");
            }

            if (dato.Length >= 1 && dato.Length <= 8)
            {
                for (int i = 0; i < dato.Length; i++)
                {
                    if (!char.IsDigit(dato[i]))
                    {
                        throw new DniInvalidoException("El DNI debe contener solo digitos");
                    }
                }

                return ValidarDNI(nacionalidad, Convert.ToInt32(dato));
            }
            else
            {
                throw new DniInvalidoException();
            }
        }

        /// <summary>
        /// Comprueba que el nombre y apellido sean validos
        /// </summary>
        /// <param name="dato">string a comprobar</param>
        /// <returns>retorna true si es valido, false si no lo es</returns>
        private static string ValidarNombreApellido(string dato)
        {
            bool noLetra = false;

            if(dato.Length == 8)
            for(int i = 0; i < dato.Length; i++)
            {
                if(!char.IsLetter(dato[i]))
                {
                    noLetra = true;
                }

                if(noLetra)
                {
                    dato = "";
                    break;
                }
            }

            return dato;
        }

        #endregion

        #region Sobrecarga de metodos
        /// <summary>
        /// Crea un string con los datos de la persona
        /// </summary>
        /// <returns>String con datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.apellido, this.nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.nacionalidad);

            return sb.ToString();
        }
        #endregion
    }
}
