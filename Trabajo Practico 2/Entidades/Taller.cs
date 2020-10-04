using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// Clase Taller contiene los distintos vehiculos
    /// </summary>
    public sealed class Taller
    {
        List<Vehiculo> vehiculos;
        int espacioDisponible;

        #region "Constructores"
        private Taller() //constructor privado, se encarga de inicializar la lista
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Taller(int espacioDisponible) : this() //inicializa los valores
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in taller.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.SUV:
                        if(v is Suv) //si es tipo SUV, llamo a su respectivo metodo
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Ciclomotor:
                        if (v is Ciclomotor) //si es tipo Ciclomotor, llamo a su respectivo metodo
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Sedan:
                        if (v is Sedan) //si es tipo Sedan, llamo a su respectivo metodo
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    default: // de no ser de ningun tipo especificado arriba, muestra todos
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Sobrecarga de operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            int flag = 0; //variable de control

            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo) //si el vehiculo se encuentra en la lista no lo agrego
                {
                    flag = 1;
                    break;
                }
            }

            if (flag == 0 && taller.espacioDisponible > taller.vehiculos.Count()) 
            {
                //si el vehiculo se encuentra en la lista y el espacio disponible es mayor al de vehiculos
                //contenidos en la lista, lo agrego
                taller.vehiculos.Add(vehiculo);

            }
            return taller;


        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo) // si el vehiculo a eliminar se encuentra en la lista, lo elimino
                {
                    taller.vehiculos.Remove(v); 
                    break;
                }
            }

            return taller;
        }
        #endregion

        #region Enumerado
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }
        #endregion
    }
}
