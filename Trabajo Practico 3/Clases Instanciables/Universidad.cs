using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }

        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;

        #region Propiedades

        /// <summary>
        /// Lectura: Devuelve la lista de alumnos de la universidad
        /// Escritura: Asigna una lista de alumnos a la universidad
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Lectura: Devuelve la lista de profesores de la universidad
        /// Escritura: Asigna una lista de profesores a la universidad
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Lectura: Devuelve la lista de jornadas de la universidad
        /// Escritura: Asigna una lista de jornadas a la universidad
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Lectura: Devuelve una jornada en el indice especificado, comprobando que sea valido
        /// Escritura: Asigna una jornada en el indice especificado, comprobando que sea valido
        /// </summary>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    return this.jornada[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    this.jornada[i] = value;
                }
                else if (i == this.Jornadas.Count)
                {
                    this.Jornadas.Add(value);
                }
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Universidad
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Serializa en formato XML los atributos del objeto universidad
        /// </summary>
        /// <param name="uni">Objeto Universidad</param>
        /// <returns>Retorna true si pudo serializar el objeto</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> u = new Xml<Universidad>();
            return u.Guardar("Universidad.xml", uni);
        }

        /// <summary>
        /// Lee archivo XML y lo graba en un objeto Universidad
        /// </summary>
        /// <returns>Objeto Universidad</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> u = new Xml<Universidad>();
            Universidad uni = new Universidad();

            u.Leer("Universidad.xml", out uni);

            return uni;
        }

        #endregion

        #region Sobrecarga de Metodos

        /// <summary>
        /// Retorna un string con los atributos de los objetos de la lista jornadas
        /// </summary>
        /// <param name="uni">Objeto Universidad</param>
        /// <returns>Un string con los datos de la universidad</returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada auxJ in uni.jornada)
            {
                sb.Append(auxJ.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Retorna un string con los atributos de los objetos de la lista jornadas
        /// </summary>
        /// <returns>String con los datos de la universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Compara un objeto Universidad con un objeto Alumno
        /// </summary>
        /// <param name="g">Objeto Universidad</param>
        /// <param name="a">Objeto Alumno</param>
        /// <returns>Retorna true si el objeto Alumno pertenece a la lista alumnos del objeto Universidad, caso contrario retorna false</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool iguales = false;

            foreach (Alumno auxA in g.alumnos)
            {
                if (auxA.Equals(a))
                {
                    iguales = true;
                    break;
                }
            }
            return iguales;
        }

        /// <summary>
        /// Compara un objeto Universidad con un objeto Alumno
        /// </summary>
        /// <param name="g">Objeto Universidad</param>
        /// <param name="a">Objeto Alumno</param>
        /// <returns>Retorna false si el objeto Alumno pertenece a la lista alumnos del objeto Universidad, caso contrario retorna false</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Compara un objeto Universidad con un objeto Profesor
        /// </summary>
        /// <param name="g">Objeto Universidad</param>
        /// <param name="i">Objeto Profesor</param>
        /// <returns>Retorna true si el objeto Profesor pertenece a la lista alumnos del objeto Universidad, caso contrario retorna false</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool iguales = false;

            foreach (Profesor auxP in g.profesores)
            {
                if (auxP.Equals(i))
                {
                    iguales = true;
                    break;
                }
            }
            return iguales;
        }


        /// <summary>
        /// Compara un objeto Universidad con un objeto Profesor
        /// </summary>
        /// <param name="g">Objeto Universidad</param>
        /// <param name="i">Objeto Profesor</param>
        /// <returns>Retorna true si el objeto Profesor no pertenece a la lista alumnos del objeto Universidad, caso contrario retorna false</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Compara un objeto Universidad con un Enum EClase
        /// </summary>
        /// <param name="u">Objeto universidad</param>
        /// <param name="clase">Enumerado</param>
        /// <returns>Devuelve el primer objeto Profesor de la lista profesores con la EClase clase
        /// en su atributo clasesDelDia, si no hay Proofesor lanza SinProfesorException </returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor profesor = null;

            foreach (Profesor auxP in u.profesores)
            {
                if (auxP == clase)
                {
                    profesor = auxP;
                    break;
                }
            }
            if (profesor is null)
            {
                throw new SinProfesorException("No hay profesor para la clase");
            }
            return profesor;
        }

        /// <summary>
        /// Compara un objeto Universidad con un Enum EClase
        /// </summary>
        /// <param name="u">Objeto universidad</param>
        /// <param name="clase">Enumerado</param>
        /// <returns>Devuelve el primer objeto Profesor de la lista profesores que no tenga el EClase clase
        /// en su atributo clasesDelDia, si no hay Profesor lanza SinProfesorException</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profesor = null;

            foreach (Jornada auxJ in u.jornada)
            {
                if (auxJ.Clase != clase)
                {
                    profesor = auxJ.Instructor;
                    break;
                }
            }
            if (profesor is null)
            {

                throw new SinProfesorException("Todos los profesores pueden dar la clase");

            }
            return profesor;
        }

        /// <summary>
        /// Agrega un objeto Alumno a la lista alumnos del objeto Universidad
        /// </summary>
        /// <param name="u">Objeto Universidad</param>
        /// <param name="a">Objeto Alumno</param>
        /// <returns>Devuelve el objeto Universidad con el Alumno agregado a la lista si no esta repetido
        /// caso contrario tira AlumnoRepetidoException</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno Repetido");
            }

            return u;
        }

        /// <summary>
        /// Agrega un objeto Profesor a la lista alumnos del objeto Universidad
        /// </summary>
        /// <param name="u">Objeto Universidad</param>
        /// <param name="i">Objeto Alumno</param>
        /// <returns>Devuelve el objeto Universidad con el Profesor agregado a la lista si no esta repetido</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }

            return u;
        }

        /// <summary>
        /// Genera un nuevo objeto Jornada en la lista jornadas del objeto Universidad con la EClase provista, 
        /// su atributo instructor sera un objeto Profesor de la lista y los objetos Alumnos seran los que tengan
        /// esa EClase en la lista alumnos del objeto Universidad
        /// </summary>
        /// <param name="g">Objeto Universidad</param>
        /// <param name="clase">Eclase clase</param>
        /// <returns>Devuelve el objeto Universidad con un nuevo objeto Jornada en su lista conteniendo la EClase provista</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor prof = g == clase;
            Jornada jornada = new Jornada(clase, prof);

            foreach (Alumno auxA in g.alumnos)
            {
                jornada += auxA;
            }

            g.jornada.Add(jornada);
            return g;
        }

        #endregion

    }
}
