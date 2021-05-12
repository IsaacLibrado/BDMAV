using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaMAV
{
    /// <summary>
    /// Pantalla que permite la administracion de material 
    /// Autor: Oscar Arturo Villegas Rojas
    /// Codigo reciclado de Isaac Librado Almada
    /// Fecha: 08/05/2021
    /// Version: 1.0
    /// Ultima modificación: 09/05/2021
    /// </summary>
    public partial class DevolverPrestamo : Form
    {
        //data tables para la info
        DataTable dt;
        public DevolverPrestamo()
        {
            InitializeComponent();
            dt = new DataTable();
        }

        /// <summary>
        /// Metodo para cargar los datos al inicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ABCMateriales_Load(object sender, EventArgs e)
        {
            CargarTabla();

        }

        /// <summary>
        /// Metodo para actualizar el datagrid cada vez que se cambia el combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbBusqueda_TextChanged(object sender, EventArgs e)
        {
            ///obtenemos los datos del stored proccedure
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Prestamos_Sin_Devolver", "@pNombre", txbBusqueda.Text, SqlDbType.VarChar, MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            dt.Load(respuesta);

            dgVistaTabla.DataSource = dt;
            respuesta.Close();
        }

        /// <summary>
        /// Metodos para obtener los datos del datagrid en los textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgVistaTabla_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //si el elegido no es null
            if (dgVistaTabla.CurrentRow.Cells[0].Value.ToString() != string.Empty)
            {

                //obtenemos los datos de la base de datos
                txbId.Text = dgVistaTabla.CurrentRow.Cells[0].Value.ToString();
                txbNombre.Text = dgVistaTabla.CurrentRow.Cells[1].Value.ToString();
                txbFecha.Text = dgVistaTabla.CurrentRow.Cells[2].Value.ToString();

                SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Materiales_Por_Prestamo", "@pID", txbId.Text, SqlDbType.SmallInt, MenuPrincipal.cn);
                SqlDataReader respuesta = consulta.ExecuteReader();
                dt = new DataTable();

                //cargamos la data table
                dt.Load(respuesta);

                //colocamos el datatable en el datagrid 
                dgVistaAnadidos.DataSource = dt;

                //cerramos el reader
                respuesta.Close();

                dgVistaAnadidos.Columns[0].Visible = false;
            }
        }

        /// <summary>
        /// Este metodo ejecuta cada opción al momento de confirmar los cambios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Devolver();
        }

        /// <summary>
        /// Se crea un nuevo registro con sus debidos datos
        /// </summary>
        private void Devolver()
        {
            DateTime fecha = DateTime.Now;

            // definimos los nombres de los parametros
            List<string> parametros = new List<string>();
            parametros.Add("@pID");
            parametros.Add("@pFechaReg");

            //definimos los valores de los parametros
            List<string> valores = new List<string>();
            valores.Add(txbId.Text);
            valores.Add(string.Format("{0}/{1}/{2} {3}:{4}:{5}", fecha.Day.ToString(), fecha.Month.ToString(), fecha.Year.ToString(), fecha.Hour.ToString(), fecha.Minute.ToString(), fecha.Second.ToString()));


            //definimos los tipos de los parametros
            List<SqlDbType> tipos = new List<SqlDbType>();
            tipos.Add(SqlDbType.SmallInt);
            tipos.Add(SqlDbType.SmallDateTime);

            if (MenuPrincipal.ValidarCamposVacios(txbId.Text))
            {
                SqlCommand consulta = MenuPrincipal.DefinirConsultaNPar("sp_Devolver_Prestamo", parametros, valores, tipos, MenuPrincipal.cn);

                try
                {
                    consulta.ExecuteNonQuery();
                    VaciarCampos();
                }
                catch
                {
                    MessageBox.Show("No se pudo devolver el material", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CargarTabla();
            }
            else
            {
                MessageBox.Show("Faltan valores en los campos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Metodo para mostrar los datos en el datagrid
        /// </summary>
        private void CargarTabla()
        {
            //hacemos la consulta por nombre vacio
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Prestamos_Sin_Devolver", "@pNombre", "", SqlDbType.VarChar, MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            //cargamos la data table
            dt.Load(respuesta);

            //colocamos el datatable en el datagrid 
            dgVistaTabla.DataSource = dt;

            //cerramos el reader
            respuesta.Close();

            dgVistaTabla.Columns[1].Width = 200;
            dgVistaTabla.Columns[2].Width = 200;

            //consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Materiales_Por_Prestamo", "@pID", txbId.Text, SqlDbType.SmallInt, MenuPrincipal.cn);
            //respuesta = consulta.ExecuteReader();
            //dt = new DataTable();

            ////cargamos la data table
            //dt.Load(respuesta);

            ////colocamos el datatable en el datagrid 
            //dgVistaAnadidos.DataSource = dt;

            ////cerramos el reader
            //respuesta.Close();

            //dgVistaAnadidos.Columns[0].Visible = false;
        }

        /// <summary>
        /// Este metodo permite los ajustes para ingresar los datos a registrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Devolver();
        }


        /// <summary>
        /// Metodo para validar que sólo se acepten numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Metodo para vaciar los campos
        /// </summary>
        private void VaciarCampos()
        {
            //vaciamos los campos
            txbId.Text = "";
            txbNombre.Text = "";
            txbFecha.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txbNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void txbId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txbEtiqueta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
