using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;

namespace TestConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Vendedora v = new Vendedora();
            DataTable tabla = new DataTable("historialVentas");
            SqlDataAdapter dA = new SqlDataAdapter();
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexionBD);
            Tecnologia t1 = new Tecnologia(1, "Notebook", 520, "Asus");
            Accesorio a1 = new Accesorio(2, "Teclado", 100, "Samsung");
            Accesorio a2 = new Accesorio(1, "Celular", 175, "Apple");
            Tecnologia t2 = new Tecnologia(3, "Notebook", 520, "Asus");
            Accesorio a3 = new Accesorio(4, "Teclado", 100, "Samsung");

            v += t1;
            v += a1;
            
            try
            {
                conexion.Open();

                if(conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    Console.WriteLine("CONEXION REALIZADA CON EXITO");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            try
            {
                tabla.Columns.Add("idVenta", typeof(int));

                tabla.PrimaryKey = new DataColumn[] { tabla.Columns[0] };

                tabla.Columns[0].AutoIncrement = true;
                tabla.Columns[0].AutoIncrementSeed = 1;
                tabla.Columns[0].AutoIncrementStep = 1;

                Console.WriteLine("DATA TABLE CONFIGURADO CON EXITO");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.conexionBD);

                dA.SelectCommand = new SqlCommand("SELECT * FROM [BaseTP4].[dbo].[historialVentas] ", conexion);
                dA.InsertCommand = new SqlCommand("INSERT INTO [BaseTP4].[dbo].[historialVentas] (producto, marca, tipo, precio) VALUES (@producto, @marca, @tipo, @precio)", conexion);

                dA.InsertCommand.Parameters.Add("@producto", SqlDbType.VarChar, 50, "producto");
                dA.InsertCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                dA.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                dA.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");

                Console.WriteLine("DATA ADAPTER CONFIGURADO CON EXITO");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Intento llenar la data table con los datos de la base de datos
            try
            {
                int i = dA.Fill(tabla);
                if (i != 0)
                {
                    Console.WriteLine("SE CARGO EL DATA TABLE CON EXITO");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //INTENTO ACTUALIZAR LA BASE DE DATOS A TRAVES DEL DATA ADAPTER CON LOS DATOS DE LA TABLA

            try
            {
                dA.Update(tabla);

                Console.WriteLine("DATOS ACTUALIZADOS CON EXITO");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //INTENTO LA ESCRITURA Y LECTURA DE ARCHIVOS .TXT Y .XML

            if (v.Guardar("Vendedora.txt", v.ToString()))
            {
                Console.WriteLine("ARCHIVO CREADO CON EXITO");
            }
            else
            {
                Console.WriteLine("ERROR AL CREAR EL ARCHIVO");
            }

            string datos;

            if (v.Leer("Vendedora.txt", out datos))
            {
                Console.WriteLine(datos);
            }
            else
            {
                Console.WriteLine("ERROR AL LEER EL ARCHIVO");
            }

            Console.ReadKey(true);
            Console.Clear();

            if (Vendedora.GuardarXml(v))
            {
                Console.WriteLine("VENDEDORA SERIALIZADA CON EXITO");
            }

            Vendedora v2 = new Vendedora();

            v2 = Vendedora.LeerXml();

            Console.WriteLine(v2.ToString());

            Console.ReadKey(true);
        }
    }
}
