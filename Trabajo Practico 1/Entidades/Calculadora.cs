using Microsoft.Win32.SafeHandles;
using System;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            switch (operador)
            {
                case "-":
                    break;
                case "*":
                    break;
                case "/":
                    break;
                default:
                    operador = "+";
                    break;
            }

            return operador;
        }

        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado;


            operador = ValidarOperador(operador);

            switch (operador)
            {
                case "+":
                    resultado = numero1 + numero2;
                    break;
                case "-":
                    resultado = numero1 - numero2;
                    break;
                case "*":
                    resultado = numero1 * numero2;
                    break;
                default:
                    resultado = numero1 / numero2;
                    break;
            }

            return resultado;
        }
    }
}
