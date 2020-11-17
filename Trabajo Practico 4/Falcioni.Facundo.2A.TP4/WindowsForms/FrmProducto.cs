using Entidades;
using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class FrmProducto : Form
    {
        private Producto producto;

        public FrmProducto()
        {
            InitializeComponent();
        }

        #region Propiedad (sólo lectura)
        public Producto Producto
        {
            get
            {
                return this.producto;
            }
        }
        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxMarca.SelectedIndex == 0 || comboBoxMarca.SelectedIndex == 1 || comboBoxMarca.SelectedIndex == 2)
            {
                if (comboBoxTipo.SelectedIndex == 0)
                {
                    this.producto = new Tecnologia(0, comboBoxTeconologia.Text, float.Parse(labelPrecio.Text), comboBoxMarca.Text);
                }
                else
                {
                    this.producto = new Accesorio(0, comboBoxAccesorios.Text, float.Parse(labelPrecio.Text), comboBoxMarca.Text);
                }

                this.DialogResult = DialogResult.OK;
            }
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            this.comboBoxTipo.SelectedIndex = 0;
        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipo.SelectedIndex == 0)
            {
                comboBoxAccesorios.Visible = false;
                comboBoxTeconologia.Visible = true;
                comboBoxTeconologia.SelectedIndex = 0;
            }
            else
            {
                comboBoxTeconologia.Visible = false;
                comboBoxAccesorios.Visible = true;
                comboBoxAccesorios.SelectedIndex = 0;
            }
        }

        private void comboBoxTeconologia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipo.SelectedIndex == 0)
            {
                switch (comboBoxTeconologia.SelectedIndex)
                {
                    case 0:
                        labelPrecio.Text = "175";
                        break;
                    case 1:
                        labelPrecio.Text = "520";
                        break;
                    default:
                        labelPrecio.Text = "200";
                        break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void comboBoxAccesorios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipo.SelectedIndex == 1)
            {
                switch (comboBoxAccesorios.SelectedIndex)
                {
                    case 0:
                        labelPrecio.Text = "160";
                        break;
                    case 1:
                        labelPrecio.Text = "120";
                        break;
                    default:
                        labelPrecio.Text = "100";
                        break;
                }
            }
        }
    }
}
