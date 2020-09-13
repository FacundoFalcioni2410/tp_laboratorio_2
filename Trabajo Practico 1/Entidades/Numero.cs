using System;
using System.Runtime.CompilerServices;

namespace Entidades
{
    public class Numero
    {

        private double numero;

        private double ValidarNumero(string strNumero)
        {
            double numero;

            double.TryParse(strNumero, out numero);

            return numero;
        }

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }

        }


        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            this.SetNumero = numero;
        }

        public static double operator +(Numero numero1, Numero numero2)
        {
            double resultado;

            resultado = numero1.numero + numero2.numero;

            return resultado;
        }

        public static double operator -(Numero numero1, Numero numero2)
        {
            double resultado;

            resultado = numero1.numero - numero2.numero;

            return resultado;
        }

        public static double operator *(Numero numero1, Numero numero2)
        {
            double resultado;

            resultado = numero1.numero * numero2.numero;

            return resultado;
        }

        public static double operator /(Numero numero1, Numero numero2)
        {
            double resultado;

            if(numero2.numero != 0)
            {
                resultado = numero1.numero / numero2.numero;
            }
            else
            {
                resultado = double.MinValue;
            }

            return resultado;
        }

        public static string DecimalBinario(double numero)
        {
            string cadena = "Valor invalido";

            long entero = (long)numero;

            if(entero > 0)
            {
                cadena = Convert.ToString(entero, 2);
            }
            
            return cadena;
         }

        public static double BinarioDecimal(string binario)
        {
            char[] array = binario.ToCharArray();
            Array.Reverse(array);
            double suma = 0;

            if(EsBinario(array))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        suma += Math.Pow(2, i);
                    }
                }
            }
            else
            {
                suma = -1;
            }

            return suma;
        }

        private static bool EsBinario(char[] binario)
        {
            bool valido = true;

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '1' && binario[i] != '0')
                {
                    valido = false;
                    break;
                }
            }
            return valido;
        }
    }
}
