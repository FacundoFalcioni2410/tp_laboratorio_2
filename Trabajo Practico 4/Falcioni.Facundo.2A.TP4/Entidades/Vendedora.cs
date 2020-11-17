using Archivos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Entidades
{
    public sealed class Vendedora
    {
        private List<Producto> listaDeProductos;

        public Vendedora()
        {
            this.listaDeProductos = new List<Producto>();
        }

        public List<Producto> ListaDeProductos
        {
            get
            {
                return this.listaDeProductos;
            }
            set
            {
                this.listaDeProductos = value;
            }
        }

        public float PrecioTotal
        {
            get
            {
                float buffer = 0;

                foreach (Producto auxP in this.listaDeProductos)
                {
                    buffer += auxP.Precio;
                }

                return buffer;
            }
        }

        public static bool operator ==(Vendedora v, Producto p)
        {
            bool iguales = false;

            if ((object)v != null && (object)p != null)
            {
                foreach (Producto auxP in v.listaDeProductos)
                {
                    if (auxP.Equals(p))
                    {
                        iguales = true;
                        break;
                    }
                }
            }

            return iguales;
        }

        public static bool operator !=(Vendedora v, Producto p)
        {
            return !(v == p);
        }

        public static Vendedora operator +(Vendedora v, Producto p)
        {
            if (v != p)
            {
                v.listaDeProductos.Add(p);
            }
            return v;
        }

        /// <summary>
        /// Serializa en formato XML los atributos del objeto Vendedora
        /// </summary>
        /// <param name="uni">Objeto Vendedora</param>
        /// <returns>Retorna true si pudo serializar el objeto</returns>
        public static bool GuardarXml(Vendedora vendedora)
        {
            Serializacion<Vendedora> u = new Serializacion<Vendedora>();
            return u.Guardar("Vendedora.xml", vendedora);
        }

        /// <summary>
        /// Lee archivo XML y lo graba en un objeto Vendedora
        /// </summary>
        /// <returns>Objeto Vendedora</returns>
        public static Vendedora LeerXml()
        {
            Serializacion<Vendedora> u = new Serializacion<Vendedora>();
            Vendedora vendedora = new Vendedora();

            u.Leer("Vendedora.xml", out vendedora);

            return vendedora;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("VENDEDORA:");
            sb.AppendFormat("CANTIDAD: {0}\nPRECIO TOTAL: {1}\n", this.listaDeProductos.Count, this.PrecioTotal);
            foreach (Producto auxP in this.listaDeProductos)
            {
                sb.Append(auxP.ToString());
            }

            return sb.ToString();
        }

        public void ProcesandoCompra(object sender, EventArgs e)
        {
            do
            {

                Thread.Sleep(2000);
            } while (true);

            //this.InformaEstado.Invoke(this, System.EventArgs.Empty);
            //Thread.Sleep(4000);

            //this.estado = EEstado.EnViaje;
            //this.InformaEstado.Invoke(this, System.EventArgs.Empty);
            //Thread.Sleep(4000);

            //this.estado = EEstado.Entregado;
            //this.InformaEstado.Invoke(this, System.EventArgs.Empty);
        }
    }
}
