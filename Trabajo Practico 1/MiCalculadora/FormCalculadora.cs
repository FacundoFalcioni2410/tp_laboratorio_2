using Entidades;
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

        private void btnLimpiar_Click(object sender, EventArgs e)
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDecimalABinario_Click(object sender, EventArgs e)
        {
            string numeroBinario = label1.Text;
            double numeroAConvertir = Convert.ToDouble(label1.Text);
            numeroBinario = Numero.DecimalBinario(numeroAConvertir);

            label1.Text = numeroBinario;
        }

        private void btnOperar_Click(object sender, EventArgs e)
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

        private void btnBinarioADecimal_Click(object sender, EventArgs e)
        {
            string numero = label1.Text;
            double numeroConvertido;

            numeroConvertido = Numero.BinarioDecimal(numero);

            label1.Text = Convert.ToString(numeroConvertido);
        }
    }
}
