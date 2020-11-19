using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsForms
{
    public delegate void DelegadoHilo(object sender, EventArgs e);

    public partial class FrmDatos : Form
    {
        private DataTable tabla;
        private SqlDataAdapter dA;
        private SqlConnection conexion;
        private Thread hiloSecundario;
        private Vendedora vendedora;

        public event DelegadoHilo EjecutarHilo;

        #region Constructor
        /// <summary>
        /// Constructor del form datos, dentro se configura el data adapter, data table y se asocia al evento el metodo que inicia el
        /// hilo secundario
        /// </summary>
        public FrmDatos()
        {

            this.vendedora = new Vendedora();
            this.hiloSecundario = new Thread(this.ComprobarLista);
            this.EjecutarHilo += Hilo_EjecutarHilo;
            InitializeComponent();
            this.ConfigurarDataAdapter();
            ConfigurarDataTable();
            this.ConfigurarGrilla();

            this.StartPosition = FormStartPosition.CenterScreen;
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Una vez se cargue el form se llena mediante el fill la data table, e inicia el hilo secundario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fmrDatos_Load(object sender, EventArgs e)
        {
            try
            {
                this.dA.Fill(this.tabla);
                this.dataGridView1.DataSource = this.tabla;
                this.EjecutarHilo.Invoke(this, EventArgs.Empty);
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


        /// <summary>
        /// Se agrega una venta a la data table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Se guarda en un archivo de texto la lista de productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarTexto_Click(object sender, EventArgs e)
        {
            if(vendedora.Guardar("Vendedora.txt", this.vendedora.ToString()))
            {
                MessageBox.Show("ARCHIVO GUARDADO CON EXITO");
            }
        }

        /// <summary>
        /// Se lee el archivo de texto que contiene la lista de productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Al cerrarse el form se pregunta si quiere realizarlo, si presiona que no quiere salir sigue ejecutando el programa sin problemas
        /// caso contrario se cierra y se aborta el hilo secundario si este esta vivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    this.EjecutarHilo.Invoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Metodo encargado de iniciar el hilo comprobando siempre que este muerto antes de iniciarlo, caso contrario realizo el abort
        /// </summary>
        private void Hilo_EjecutarHilo(object sender, EventArgs e)
        {
            if (!this.hiloSecundario.IsAlive)
            {
                this.hiloSecundario.Start(); //SI EL HILO NO ESTA VIVO HAGO EL START
            }
            else
            {
                this.hiloSecundario.Abort(); //SI ESTA VIVO LO ABORTO
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo asociado al hilo, cada 2 segundos comprueba si la lista de productos es distinta a la cantidad de rows en el
        /// datagridview, de ser asi se actualiza la lista de productos con el contenido nuevo.
        /// </summary>
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
                            this.labelInforma.Text = "LISTA ACTUALIZADA"; //INFORMO SI LA LISTA FUE ACTUALIZADA
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
                            this.labelInforma.Text = "LOS DATOS YA ESTAN SINCRONIZADOS"; //INFORMO SI NO HUBO CAMBIOS EN LA LISTA
                        }
                        );
                    }
                }
            } while (this.hiloSecundario.IsAlive);
        }

        /// <summary>
        /// Metodo mediante el cual se carga la lista con los elementos del datagridview
        /// </summary>
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
        #endregion

        #region Configuraciones

        /// <summary>
        /// Se configura el data table.
        /// </summary>
        private void ConfigurarDataTable()
        {
            this.tabla = new DataTable("historialVentas");

            this.tabla.Columns.Add("idVenta", typeof(int));

            this.tabla.PrimaryKey = new DataColumn[] { this.tabla.Columns[0] }; //AGREGO LA COLUMNA COMO PRIMARY KEY

            this.tabla.Columns[0].AutoIncrement = true; //HAGO LA COLUMNA AUTOINCREMENTAL   
            this.tabla.Columns[0].AutoIncrementSeed = 1;
            this.tabla.Columns[0].AutoIncrementStep = 1;
        }

        /// <summary>
        /// se configura el data adapter, la conexion a la base de datos y los comandos de insercion y seleccion
        /// </summary>
        /// <returns>Retorna true si se pudo configurar, caso contrario false</returns>
        private bool ConfigurarDataAdapter()
        {
            bool todoOk = true;

            this.dA = new SqlDataAdapter();
            try
            {
                this.conexion = new SqlConnection(Properties.Settings.Default.conexionBD);
                this.dA.InsertCommand = new SqlCommand("INSERT INTO [BaseTP4].[dbo].[historialVentas] (producto, marca, tipo, precio) VALUES (@producto, @marca, @tipo, @precio)", this.conexion);

                this.dA.InsertCommand.Parameters.Add("@producto", SqlDbType.VarChar, 50, "producto");
                this.dA.InsertCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                this.dA.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.dA.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                this.dA.SelectCommand = new SqlCommand("SELECT * FROM [BaseTP4].[dbo].[historialVentas] ", this.conexion);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                todoOk = false;
            }

            return todoOk;
        }

        /// <summary>
        /// Se configura el datagridview dando un aspeco mas ameno y cambiando algunas caracteristicas para que el usuario
        /// no pueda editar la grilla manualmente, entre otras
        /// </summary>
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

        #endregion
    }
}