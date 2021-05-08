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
    public partial class ABCUsuarios : Form
    {
        DataTable dt;
        DataTable indtu;

        public ABCUsuarios()
        {
            InitializeComponent();
            dt = new DataTable();
        }

        private void ABCUsuarios_Load(object sender, EventArgs e)
        {
            SqlCommand consulta=MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Usuario_Por_Nombre", "@pNombre", " ", SqlDbType.VarChar, MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            dt.Load(respuesta);

            dgVistaTabla.DataSource = dt;
            respuesta.Close();


            consulta = MenuPrincipal.DefinirConsulta("sp_Cargar_Tipos_Usuario",  MenuPrincipal.cn);
            respuesta = consulta.ExecuteReader();
            indtu = new DataTable();
            indtu.Load(respuesta);

            cmbTipoUsuario.DataSource = indtu;
            cmbTipoUsuario.DisplayMember ="Tipo_Usuario";
            cmbTipoUsuario.ValueMember = "ID_Tipo_Usuario";
        }

        private void txbBusqueda_TextChanged(object sender, EventArgs e)
        {
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Usuario_Por_Nombre", "@pNombre", txbBusqueda.Text, SqlDbType.VarChar, MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            dt.Load(respuesta);

            dgVistaTabla.DataSource = dt;
            respuesta.Close();
        }

        private void dgVistaTabla_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgVistaTabla.CurrentRow != null)
            {
                string pMatricula;
                pMatricula = dgVistaTabla.CurrentRow.Cells[0].Value.ToString();

                SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Obtener_Datos_Usuario", "@pMatricula", pMatricula, SqlDbType.Int, MenuPrincipal.cn);
                SqlDataReader respuesta = consulta.ExecuteReader();
                respuesta.Read();

                txbMatricula.Text= respuesta["Matricula"].ToString();
                txbNombre.Text = respuesta["Nombre"].ToString();
                txbApPat.Text = respuesta["ApPat"].ToString();
                txbApMat.Text = respuesta["ApMat"].ToString();
                txbEmail.Text = respuesta["Email"].ToString();
                txbTelefono.Text = respuesta["Telefono"].ToString();
                txbContra.Text = respuesta["Contrasenia"].ToString();


                cmbTipoUsuario.SelectedIndex = Convert.ToInt32(respuesta["ID_Tipo_Usuario"])-1;
                cmbTipoUsuario.DisplayMember = cmbTipoUsuario.DisplayMember.ElementAt(cmbTipoUsuario.SelectedIndex).ToString();

                txbContra.Text = Encriptacion.DesEncriptar(txbContra.Text);

                respuesta.Close();
            }
        }
    }
}
