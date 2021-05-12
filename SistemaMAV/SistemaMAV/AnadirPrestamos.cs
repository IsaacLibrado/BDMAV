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
    public partial class AnadirPrestamos : Form
    {
        //data tables para la info
        DataTable dt;

        /// <summary>
        /// Constructor para crear los objetos
        /// </summary>
        public AnadirPrestamos()
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
            SqlCommand consulta = MenuPrincipal.DefinirConsulta("sp_Obtener_Prestamo_Reciente", MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            respuesta.Read();

            //obtenemos los datos de la base de datos
            txbIDPres.Text = respuesta["ID_Prestamo"].ToString();

            //cerramos el reader
            respuesta.Close();
        }

        /// <summary>
        /// Metodo para actualizar el datagrid cada vez que se cambia el combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbBusqueda_TextChanged(object sender, EventArgs e)
        {
            ///obtenemos los datos del stored proccedure
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Material_Por_Nombre_Simple_Disponible", "@pNombre", txbBusqueda.Text, SqlDbType.VarChar, MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            dt.Load(respuesta);

            dgVistaTabla.DataSource = dt;
            respuesta.Close();
        }

        /// <summary>
        /// Metodo para llevar al usuario a la pantalla de consultas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConsulta_Click(object sender, EventArgs e)
        {
            MenuPrincipal.AsignarTitulo("Consultar materiales");
            MenuPrincipal.abrirPantallas(new ConsultarMateriales());
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
                //obtenemos el id
                string pID;
                pID = dgVistaTabla.CurrentRow.Cells[0].Value.ToString();

                //hacemos la consulta con la matricula
                SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Obtener_Datos_Material", "@pId", pID, SqlDbType.Int, MenuPrincipal.cn);
                SqlDataReader respuesta = consulta.ExecuteReader();
                respuesta.Read();

                //obtenemos los datos de la base de datos
                txbId.Text = respuesta["ID_Material"].ToString();
                txbNombre.Text = respuesta["Nombre"].ToString();
                txbEtiqueta.Text = respuesta["Etiqueta"].ToString();

                //cerramos el reader
                respuesta.Close();

            }
        }

        /// <summary>
        /// Este metodo ejecuta cada opción al momento de confirmar los cambios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ValidarRegistros();
            MenuPrincipal.abrirPantallas(new RealizarPrestamo());
        }

        /// <summary>
        /// Se crea un nuevo registro con sus debidos datos
        /// </summary>
        private void ValidarRegistros()
        {
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("EliminarSolos", "@pId", txbIDPres.Text, SqlDbType.SmallInt, MenuPrincipal.cn);

            try
            {
                consulta.ExecuteNonQuery();
                VaciarCampos();
            }
            catch
            {
                MessageBox.Show("No se pudo eliminar el material", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se crea un nuevo registro con sus debidos datos
        /// </summary>
        private void AnadirMaterial()
        {
            List<string> parametros = new List<string>();
            parametros.Add("@pID_Prestamo");
            parametros.Add("@pID_Material");

            List<string> valores = new List<string>();
            valores.Add(txbIDPres.Text);
            valores.Add(txbId.Text);

            List<SqlDbType> tipos = new List<SqlDbType>();
            tipos.Add(SqlDbType.Int);
            tipos.Add(SqlDbType.SmallInt);


            if (MenuPrincipal.ValidarCamposVacios(valores))
            {
                SqlCommand consulta = MenuPrincipal.DefinirConsultaNPar("sp_Anadir_Material_Prestamo", parametros, valores, tipos, MenuPrincipal.cn);

                try
                {
                    consulta.ExecuteNonQuery();
                    VaciarCampos();
                }
                catch
                {
                    MessageBox.Show("No se pudo agregar el material", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Material_Por_Nombre_Simple_Disponible", "@pNombre", "", SqlDbType.VarChar, MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            //cargamos la data table
            dt.Load(respuesta);

            //colocamos el datatable en el datagrid 
            dgVistaTabla.DataSource = dt;

            //cerramos el reader
            respuesta.Close();

            if (txbIDPres.Text != string.Empty)
            {

                consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Materiales_Por_Prestamo", "@pID", txbIDPres.Text, SqlDbType.SmallInt, MenuPrincipal.cn);
                respuesta = consulta.ExecuteReader();
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
        /// Este metodo permite los ajustes para ingresar los datos a registrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AnadirMaterial();
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
            txbEtiqueta.Text = "";
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
