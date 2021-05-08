using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaMAV
{
    /// <summary>
    /// Clase que define a la pantalla de usuarios
    /// </summary>
    public partial class ABCUsuarios : Form
    {
        //data tables para la info
        DataTable dt;
        DataTable indtu;
        int tipoOp; //0.Nada 1.Alta 2.Baja 3.Cambio

        /// <summary>
        /// Constructor para crear los objetos
        /// </summary>
        public ABCUsuarios()
        {
            tipoOp = 0;
            InitializeComponent();
            dt = new DataTable();
        }

        /// <summary>
        /// Metodo para cargar los datos al inicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ABCUsuarios_Load(object sender, EventArgs e)
        {
            CargarTabla();

            //obtenemos los datos de la tabla de tipos de usuario
            SqlCommand consulta = MenuPrincipal.DefinirConsulta("sp_Cargar_Tipos_Usuario",  MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            indtu = new DataTable();
            indtu.Load(respuesta);

            //cargamos el combo box con la tabla
            cmbTipoUsuario.DataSource = indtu;
            cmbTipoUsuario.DisplayMember ="Tipo_Usuario";
            cmbTipoUsuario.ValueMember = "ID_Tipo_Usuario";
        }

        /// <summary>
        /// Metodo para actualizar el datagrid cada vez que se cambia el combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbBusqueda_TextChanged(object sender, EventArgs e)
        {
            ///obtenemos los datos del stored proccedure
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Usuario_Por_Nombre", "@pNombre", txbBusqueda.Text, SqlDbType.VarChar, MenuPrincipal.cn);
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
            if (dgVistaTabla.CurrentRow != null)
            {
                //obtenemos la matricula
                string pMatricula;
                pMatricula = dgVistaTabla.CurrentRow.Cells[0].Value.ToString();

                //hacemos la consulta con la matricula
                SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Obtener_Datos_Usuario", "@pMatricula", pMatricula, SqlDbType.Int, MenuPrincipal.cn);
                SqlDataReader respuesta = consulta.ExecuteReader();
                respuesta.Read();

                //obtenemos los datos de la base de datos
                txbMatricula.Text= respuesta["Matricula"].ToString();
                txbNombre.Text = respuesta["Nombre"].ToString();
                txbApPat.Text = respuesta["ApPat"].ToString();
                txbApMat.Text = respuesta["ApMat"].ToString();
                txbEmail.Text = respuesta["Email"].ToString();
                txbTelefono.Text = respuesta["Telefono"].ToString();
                txbContra.Text = respuesta["Contrasenia"].ToString();

                //obtenemos el indice que corresponde
                cmbTipoUsuario.SelectedIndex = Convert.ToInt32(respuesta["ID_Tipo_Usuario"])-1;

                //desencriptamos la contraseña para mostrarla
                txbContra.Text = Encriptacion.DesEncriptar(txbContra.Text);

                //cerramos el reader
                respuesta.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch(tipoOp)
            {
                case 1:
                    AnadirUsuario();
                    break;
            }
        }

        private void AnadirUsuario()
        {
            List<string> parametros = new List<string>();
            parametros.Add("@pMatricula");
            parametros.Add("@pNombre");
            parametros.Add("@pApPat");
            parametros.Add("@pApMat");
            parametros.Add("@pEmail");
            parametros.Add("@pTelefono");
            parametros.Add("@pID_Tipo_Usuario"); 
            parametros.Add("@pContrasenia");

            List<string> valores = new List<string>();
            valores.Add(txbMatricula.Text);
            valores.Add(txbNombre.Text);
            valores.Add(txbApPat.Text);
            valores.Add(txbApMat.Text);
            valores.Add(txbEmail.Text);
            valores.Add(txbTelefono.Text);
            valores.Add(cmbTipoUsuario.SelectedValue.ToString());
            valores.Add(Encriptacion.Encriptar(txbContra.Text));

            List<SqlDbType> tipos = new List<SqlDbType>();
            tipos.Add(SqlDbType.Int);
            tipos.Add(SqlDbType.VarChar);
            tipos.Add(SqlDbType.VarChar);
            tipos.Add(SqlDbType.VarChar);
            tipos.Add(SqlDbType.VarChar);
            tipos.Add(SqlDbType.BigInt);
            tipos.Add(SqlDbType.TinyInt);
            tipos.Add(SqlDbType.VarChar);

            SqlCommand consulta = MenuPrincipal.DefinirConsultaNPar("sp_Anadir_Usuario", parametros, valores, tipos, MenuPrincipal.cn);
            
            try
            {
                consulta.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("No se pudo agregar al usuario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarTabla();
        }

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

            //cerramos el reader
            respuesta.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txbMatricula.Enabled = true;
            txbNombre.Enabled = true;
            txbApPat.Enabled = true;
            txbApMat.Enabled = true;
            txbEmail.Enabled = true;
            txbTelefono.Enabled = true;
            cmbTipoUsuario.Enabled = true;
            txbContra.Enabled = true;

            tipoOp = 1;
        }
    }
}
