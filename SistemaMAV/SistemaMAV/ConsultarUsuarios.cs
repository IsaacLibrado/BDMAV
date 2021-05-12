using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaMAV
{
    public partial class ConsultarUsuarios : Form
    {
        DataTable dt;

        public ConsultarUsuarios()
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
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Usuario_Por_Nombre", "@pNombre", " ", SqlDbType.VarChar, MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            //cargamos la data table
            dt.Load(respuesta);

            //colocamos el datatable en el datagrid 
            dgVistaTabla.DataSource = dt;

            dgVistaTabla.Columns[1].Width = 200;
            dgVistaTabla.Columns[2].Width = 120;

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
            MenuPrincipal.AsignarTitulo("ABC Usuarios");
            MenuPrincipal.abrirPantallas(new ABCUsuarios());
        }

        //Metodo para consultar en tiempo real la tabla
        private void ConsultarTabla(object sender, EventArgs e)
        {
            //hacemos la consulta por nombre 
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Usuario_Por_Nombre", "@pNombre", txbNombre.Text, SqlDbType.VarChar, MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            //cargamos la data table
            dt.Load(respuesta);

            //colocamos el datatable en el datagrid 
            dgVistaTabla.DataSource = dt;

            dgVistaTabla.Columns[1].Width = 200;
            dgVistaTabla.Columns[2].Width = 120;

            //cerramos el reader
            respuesta.Close();
        }
    }
}
