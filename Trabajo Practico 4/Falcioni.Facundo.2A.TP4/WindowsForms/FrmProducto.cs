using Entidades;
using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class FrmProducto : Form
    {
        private Producto producto;

        #region Constructor
        /// <summary>
        /// Instancio el FrmProducto
        /// </summary>
        public FrmProducto()
        {
            InitializeComponent();
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Propiedad de solo lectura del producto del formulario
        /// </summary>
        public Producto Producto
        {
            get
            {
                return this.producto;
            }
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Verifico de que tipo es el producto que quiere ingresar el usuario para instanciarlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Al cargar el form el combo box de tipo y marca tienen un valor por default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmProducto_Load(object sender, EventArgs e)
        {
            this.comboBoxTipo.SelectedIndex = 0;
            this.comboBoxMarca.SelectedIndex = 0;
        }
    
        /// <summary>
        /// Si el indice de tipo es 0 muestro el combo box de productos de tipo Tecnologia, caso contrario muestro productos de tipo accesorio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Dependiendo el producto seleccionado especifico el precio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Al presionar el boton asigno un DialogResult.Cancel para que no se agrege el producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Dependiendo el producto seleccionado especifico el precio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        #endregion
    }
}