using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaMAV
{
    public partial class ConsultarTiposUsuario : Form
    {
        DataTable dt;
        public ConsultarTiposUsuario()
        {
            InitializeComponent();
        }
        private void ConsultarUsuarios_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        //Metodo para cargar la tabla del data grid
        private void CargarTabla()
        {
            //hacemos la consulta por nombre vacio
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Tipo_Usuario_PorNombre_Reduc", "@pTipo_Usuario", "", SqlDbType.VarChar, MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            //cargamos la data table
            dt.Load(respuesta);

            //colocamos el datatable en el datagrid 
            dgVistaTabla.DataSource = dt;

            //cerramos el reader
            respuesta.Close();
        }

        /// <summary>
        /// Metodo para regresar a la pantalla de ABC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            MenuPrincipal.AsignarTitulo("ABC Tipos de Usuarios");
            MenuPrincipal.abrirPantallas(new ABCTiposUsuario());
        }

        //Metodo para consultar en tiempo real la tabla
        private void ConsultarTabla(object sender, EventArgs e)
        {
            if (MenuPrincipal.ValidarPalabrasProhibidas(txbNombre.Text))
            {
                //hacemos la consulta por nombre vacio
                    SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Tipo_Usuario_PorNombre_Reduc", "@pTipo_Usuario", txbNombre.Text, SqlDbType.VarChar, MenuPrincipal.cn);
                SqlDataReader respuesta = consulta.ExecuteReader();
                dt = new DataTable();

                //cargamos la data table
                dt.Load(respuesta);

                //colocamos el datatable en el datagrid 
                dgVistaTabla.DataSource = dt;

                //cerramos el reader
                respuesta.Close();
            }
            else
            {
                MessageBox.Show("Valores incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbNombre.Text = "";
            }
        }
    }
}
