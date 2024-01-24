using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora_MVVM_DGGR.Modelo
{
    public class Mcalculadora
    {
        public decimal PrimerNumero { get; set; }
        public string Operador { get; set; }

        public decimal Calcular(decimal primerNumero, decimal segundoNumero, string operador)
        {
            decimal result = 0;
            if (operador == "+")
            {
                result = primerNumero + segundoNumero;
            }
            else if (operador == "-")
            {
                result = primerNumero - segundoNumero;
            }
            else if (operador == "X")
            {
                result = primerNumero * segundoNumero;
            }
            else if (operador == "÷" && segundoNumero != 0)
            {
                result = primerNumero / segundoNumero;
            }
            return result;
        }
    }
}
