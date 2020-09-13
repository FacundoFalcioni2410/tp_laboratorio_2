using Microsoft.Win32.SafeHandles;
using System;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(char operador)
        {
            switch (operador)
            {
                case '-':
                    break;
                case '*':
                    break;
                case '/':
                    break;
                default:
                    operador = '+';
                    break;
            }

            return operador.ToString();
        }

        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;
            char cOperador;
            if(operador.Length > 0)
            {
                cOperador = operador[0];
                
                operador = ValidarOperador(cOperador);

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
            }

            return resultado;
        }
    }
}
