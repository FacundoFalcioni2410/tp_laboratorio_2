﻿using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        private void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboOperador.Text = "";
            label1.Text = "";
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            string resultado = Convert.ToString(Operar(textBox1.Text, textBox2.Text, comboOperador.Text));
            label1.Text = resultado;
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;

            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);


            resultado = Calculadora.Operar(n1, n2,operador);

            return resultado;
        }

        private void BtnDecimalABinario_Click(object sender, EventArgs e)
        {
            double numero = Convert.ToDouble(textBox1.Text);
            string binario;

            binario = Numero.DecimalBinario(numero);

            label1.Text = binario;
        }

        private void BtnBinarioADecimal_Click(object sender, EventArgs e)
        {
            double binario = Numero.BinarioDecimal(textBox1.Text);
            string strBinario;
            strBinario = Convert.ToString(binario);

            label1.Text = strBinario;
        }
    }
}
