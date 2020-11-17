using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsForms
{
    public delegate void DelegadoHilo();

    public partial class FrmDatos : Form
    {
        private DataTable tabla;
        private SqlDataAdapter dA;
        private SqlConnection conexion;
        private Thread hiloSecundario;
        private Vendedora vendedora;

        public event DelegadoHilo Iniciar;

        public FrmDatos()
        {

            this.vendedora = new Vendedora();
            this.hiloSecundario = new Thread(this.ComprobarLista);
            this.Iniciar += IniciarHilo;
            InitializeComponent();
            if (!this.ConfigurarDataAdapter())
            {
                MessageBox.Show("ERROR AL CONFIGURAR EL DATA ADAPTER!!!");
            }
            ConfigurarDataTable();
            this.ConfigurarGrilla();

            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void ConfigurarDataTable()
        {
            this.tabla = new DataTable("historialVentas");

            this.tabla.Columns.Add("idVenta", typeof(int));

            this.tabla.PrimaryKey = new DataColumn[] { this.tabla.Columns[0] };

            this.tabla.Columns[0].AutoIncrement = true;
            this.tabla.Columns[0].AutoIncrementSeed = 1;
            this.tabla.Columns[0].AutoIncrementStep = 1;
        }

        public bool ConfigurarDataAdapter()
        {
            bool todoOk = true;

            this.dA = new SqlDataAdapter();
            try
            {
                this.conexion = new SqlConnection(Properties.Settings.Default.conexionBD);

                this.dA.SelectCommand = new SqlCommand("SELECT * FROM [BaseTP4].[dbo].[historialVentas] ", this.conexion);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                todoOk = false;
            }

            return todoOk;
        }

        private void ConfigurarGrilla()
        {
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Teal;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Teal;
            this.dataGridView1.BackgroundColor = Color.LightSalmon;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.GridColor = Color.LightSalmon;
            this.dataGridView1.ReadOnly = false;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.Black;
            this.dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            this.dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.AllowUserToAddRows = false;
        }

        private void fmrDatos_Load(object sender, EventArgs e)
        {
            try
            {
                this.dA.Fill(this.tabla);
                this.dataGridView1.DataSource = this.tabla;
                this.Iniciar.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.dA.Update(this.tabla);
                MessageBox.Show("Datos actualizados con exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnAlta_Click(object sender, EventArgs e)
        {
            FrmProducto frm = new FrmProducto();

            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow fila = this.tabla.NewRow();

                fila["producto"] = frm.Producto.NombreProducto;
                fila["marca"] = frm.Producto.Marca;
                fila["tipo"] = frm.Producto.Tipo;
                fila["precio"] = frm.Producto.Precio;

                this.tabla.Rows.Add(fila);
            }
        }


        private void btnGuardarTexto_Click(object sender, EventArgs e)
        {
            vendedora.Guardar("Vendedora.txt", this.vendedora.ToString());
        }

        private void btnLeerTexto_Click(object sender, EventArgs e)
        {
            string datos;

            vendedora.Leer("Vendedora.txt", out datos);

            MessageBox.Show(datos);
        }

        /// <summary>
        /// Guarda en un archivo XML la lista de productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarXml_Click(object sender, EventArgs e)
        {
            if (Vendedora.GuardarXml(this.vendedora))
            {
                MessageBox.Show("ARCHIVO GUARDADO CON EXITO");
            }
        }

        private void FrmDatos_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("¿Seguro que quiere salir del sistema? Si no realizo el UPDATE perdera los datos.", "Consulta",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true; //Cancela el cerrado del formulario
            }
            else
            {
                try
                {
                    if (this.hiloSecundario.IsAlive)
                    {
                        hiloSecundario.Abort();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void ComprobarLista()
        {
            do
            {
                Thread.Sleep(2000);

                if (this.vendedora.ListaDeProductos.Count != this.dataGridView1.Rows.Count)
                {
                    if (this.labelInforma.InvokeRequired)
                    {
                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            this.labelInforma.Text = "LISTA ACTUALIZADA";
                        }
                        );
                    }
                    this.CargarLista();
                }
                else
                {
                    if (this.labelInforma.InvokeRequired)
                    {
                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            this.labelInforma.Text = "LOS DATOS YA ESTAN SINCRONIZADOS";
                        }
                        );
                    }
                }
            } while (this.hiloSecundario.IsAlive);

        }

        private void IniciarHilo()
        {
            if (!this.hiloSecundario.IsAlive)
            {
                this.hiloSecundario.Start();
            }
            else
            {
                this.hiloSecundario.Abort();
            }
        }

        private void CargarLista()
        {
            Producto p = default;

            try
            {
                foreach (DataRow fila in this.tabla.Rows)
                {
                    if (fila["tipo"].ToString() == "Tecnologia")
                    {
                        p = new Tecnologia(int.Parse(fila["idVenta"].ToString()),
                                                        fila["producto"].ToString(),
                                                        float.Parse(fila["precio"].ToString()),
                                                        fila["marca"].ToString());
                    }
                    else
                    {
                        p = new Accesorio(int.Parse(fila["idVenta"].ToString()),
                                                fila["producto"].ToString(),
                                                float.Parse(fila["precio"].ToString()),
                                                fila["marca"].ToString());
                    }

                    this.vendedora += p;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}