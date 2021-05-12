using System;
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
    public partial class ConsultarPrestamos : Form
    {
        //data tables para la info
        DataTable dt;

        public ConsultarPrestamos()
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
            ValidarRegistros();
            CargarTabla();

            if (MenuPrincipal.cargoActual == "Solicitante")
            {
                txbBusqueda.Visible = false;
            }
        }

        /// <summary>
        /// Metodo para actualizar el datagrid cada vez que se cambia el combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (MenuPrincipal.ValidarPalabrasProhibidas(txbBusqueda.Text))
            {
                SqlCommand consulta;
                SqlDataReader respuesta;

                if (MenuPrincipal.cargoActual == "Solicitante")
                {
                    consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Prestamos_Sin_Devolver_Solicitante", "@pMatricula", MenuPrincipal.matriculaActual, SqlDbType.SmallInt, MenuPrincipal.cn);
                    respuesta = consulta.ExecuteReader();
                    dt = new DataTable();

                    dt.Load(respuesta);

                    dgVistaTabla.DataSource = dt;
                    respuesta.Close();
                }
                else
                {
                    ///obtenemos los datos del stored proccedure
                    consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Prestamos_Por_Nombre", "@pNombre", txbBusqueda.Text, SqlDbType.VarChar, MenuPrincipal.cn);
                    respuesta = consulta.ExecuteReader();
                    dt = new DataTable();

                    dt.Load(respuesta);

                    dgVistaTabla.DataSource = dt;
                    respuesta.Close();
                }
            }
            else
            {
                MessageBox.Show("Valores incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbBusqueda.Text = "";
            }
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
                SqlCommand consulta;

                if (MenuPrincipal.cargoActual == "Solicitante")
                {
                    consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Materiales_Por_Prestamo", "@pID", dgVistaTabla.CurrentRow.Cells[1].Value.ToString(), SqlDbType.SmallInt, MenuPrincipal.cn);
                }
                else
                {
                    consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Materiales_Por_Prestamo", "@pID", dgVistaTabla.CurrentRow.Cells[0].Value.ToString(), SqlDbType.SmallInt, MenuPrincipal.cn);
                }
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
        /// Se crea un nuevo registro con sus debidos datos
        /// </summary>
        private void ValidarRegistros()
        {
            SqlCommand consulta = MenuPrincipal.DefinirConsulta("EliminarSolos_G", MenuPrincipal.cn);

            try
            {
                consulta.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("No se pudo eliminar el material", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metodo para mostrar los datos en el datagrid
        /// </summary>
        private void CargarTabla()
        {
            SqlCommand consulta;
            SqlDataReader respuesta;
            if (MenuPrincipal.cargoActual == "Solicitante")
            {
                consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Prestamos_Sin_Devolver_Solicitante", "@pMatricula", MenuPrincipal.matriculaActual.ToString(), SqlDbType.SmallInt, MenuPrincipal.cn);
                respuesta = consulta.ExecuteReader();
                dt = new DataTable();

                dt.Load(respuesta);

                dgVistaTabla.DataSource = dt;
                respuesta.Close();
                dgVistaTabla.Columns[0].Visible = false;
                dgVistaTabla.Columns[1].Visible = false;
            }
            else
            {
                ///obtenemos los datos del stored proccedure
                consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Prestamos_Por_Nombre", "@pNombre", " ", SqlDbType.VarChar, MenuPrincipal.cn);
                respuesta = consulta.ExecuteReader();
                dt = new DataTable();

                dt.Load(respuesta);

                dgVistaTabla.DataSource = dt;
                respuesta.Close();

                dgVistaTabla.Columns[0].Width = 30;
                dgVistaTabla.Columns[1].Width = 200;
                dgVistaTabla.Columns[2].Width = 180;
                dgVistaTabla.Columns[3].Width = 180;
            }


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
