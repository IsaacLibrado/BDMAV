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
    public partial class RealizarPrestamo : Form
    {

        //data tables para la info
        DataTable dt;
        DataTable indtu;

        public RealizarPrestamo()
        {
            InitializeComponent();
            dt = new DataTable();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txbMaterial.Text != "" || txbSolicitante.Text != "")
            {
                CompletarPrestamo();
            }
            else
                MessageBox.Show("Seleccione los datos necesarios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CompletarPrestamo()
        {
            List<string> parametros = new List<string>();
            parametros.Add("@pID_Material");
            parametros.Add("@pID_Solicitante");
            parametros.Add("@pID_Prestamo");
            parametros.Add("@pID_Becario");

            List<string> valores = new List<string>();
            valores.Add(txbMaterial.Text);
            valores.Add(txbSolicitante.Text);
            valores.Add(txbId_Prestamo.Text);
            valores.Add(cmbBecario.SelectedValue.ToString());

            List<SqlDbType> tipos = new List<SqlDbType>();
            tipos.Add(SqlDbType.SmallInt);
            tipos.Add(SqlDbType.SmallInt);
            tipos.Add(SqlDbType.SmallInt);
            tipos.Add(SqlDbType.TinyInt);

            SqlCommand consulta = MenuPrincipal.DefinirConsultaNPar("sp_Prestar_Material", parametros, valores, tipos, MenuPrincipal.cn);

            try
            {
                consulta.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("No se puede prestar el material", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarTabla();
            txbBusquedaMaterial.Clear();
            txbBusquedaSolicitante.Clear();
            txbEtiqueta.Clear();
            txbId_Prestamo.Clear();
            txbMaterial.Clear();
            txbNombre.Clear();
            txbNombreMaterial.Clear();
            txbSolicitante.Clear();
        }

        private void RealizarPrestamo_Load(object sender, EventArgs e)
        {
            CargarTabla();
            //obtenemos los datos de la tabla de tipos de estados
            SqlCommand consulta = MenuPrincipal.DefinirConsulta("sp_Cargar_Becarios", MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            indtu = new DataTable();
            indtu.Load(respuesta);

            //cargamos el combo box con la tabla
            cmbBecario.DataSource = indtu;
            cmbBecario.DisplayMember = "Matricula";
            cmbBecario.ValueMember = "ID_Becario";
        }


        /// <summary>
        /// Metodo para mostrar los datos en el datagrid
        /// </summary>
        private void CargarTabla()
        {
            //hacemos la consulta por nombre vacio
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Solicitante_NoDeudor_Por_Nombre", "@pNombre", "", SqlDbType.VarChar, MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            //cargamos la data table
            dt.Load(respuesta);

            //colocamos el datatable en el datagrid 
            dgVistaSolicitantes.DataSource = dt;

            //cerramos el reader
            respuesta.Close();

            //hacemos la consulta por nombre vacio
            consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Material_Disponible_Por_Nombre", "@pNombre", "", SqlDbType.VarChar, MenuPrincipal.cn);
            respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            //cargamos la data table
            dt.Load(respuesta);

            //colocamos el datatable en el datagrid 
            dgVistaMaterial.DataSource = dt;

            //cerramos el reader
            respuesta.Close();

            //hacemos la consulta por nombre vacio
            consulta = MenuPrincipal.DefinirConsulta("sp_Buscar_Prestamo", MenuPrincipal.cn);
            respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            //cargamos la data table
            dt.Load(respuesta);

            //colocamos el datatable en el datagrid 
            dgVistaPrestamo.DataSource = dt;

            //cerramos el reader
            respuesta.Close();
        }

        private void dgVistaSolicitantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //si el elegido no es null
            if (dgVistaSolicitantes.CurrentRow != null)
            {
                //obtenemos el id
                string pID;
                pID = dgVistaSolicitantes.CurrentRow.Cells[0].Value.ToString();

                //hacemos la consulta con la matricula
                SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Obtener_Datos_Solicitante", "@pId", pID, SqlDbType.SmallInt, MenuPrincipal.cn);
                SqlDataReader respuesta = consulta.ExecuteReader();
                respuesta.Read();
                txbNombre.Text = respuesta["Matricula"].ToString();
                txbSolicitante.Text = respuesta["ID_Solicitante"].ToString();
                //obtenemos el indice que corresponde
                //cerramos el reader
                respuesta.Close();
            }
        }

        private void txbBusquedaSolicitante_TextChanged(object sender, EventArgs e)
        {
            ///obtenemos los datos del stored proccedure
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Solicitante_NoDeudor_Por_Nombre", "@pNombre", txbBusquedaSolicitante.Text, SqlDbType.VarChar, MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            dt.Load(respuesta);

            dgVistaSolicitantes.DataSource = dt;
            respuesta.Close();
        }

        private void txbBusquedaMaterial_TextChanged(object sender, EventArgs e)
        {
            ///obtenemos los datos del stored proccedure
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Material_Disponible_Por_Nombre", "@pNombre", txbBusquedaMaterial.Text, SqlDbType.VarChar, MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            dt.Load(respuesta);

            dgVistaMaterial.DataSource = dt;
            respuesta.Close();
        }

        private void dgVistaMaterial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //si el elegido no es null
            if (dgVistaMaterial.CurrentRow != null)
            {
                //obtenemos el id
                string pID;
                pID = dgVistaMaterial.CurrentRow.Cells[0].Value.ToString();

                //hacemos la consulta con la matricula
                SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Obtener_Datos_Material", "@pId", pID, SqlDbType.SmallInt, MenuPrincipal.cn);
                SqlDataReader respuesta = consulta.ExecuteReader();
                respuesta.Read();
                txbMaterial.Text = respuesta["ID_Material"].ToString();
                txbNombreMaterial.Text = respuesta["Nombre"].ToString();
                txbEtiqueta.Text = respuesta["Etiqueta"].ToString();
                //cerramos el reader
                respuesta.Close();
            }
        }

        private void txbId_Prestamo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dgVistaPrestamo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //si el elegido no es null
            if (dgVistaPrestamo.CurrentRow != null)
            {
                //obtenemos el id
                string pID;
                pID = dgVistaPrestamo.CurrentRow.Cells[0].Value.ToString();

                //hacemos la consulta con la matricula
                SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Obtener_Datos_Material", "@pId", pID, SqlDbType.SmallInt, MenuPrincipal.cn);
                SqlDataReader respuesta = consulta.ExecuteReader();
                respuesta.Read();
                txbMaterial.Text = respuesta["ID_Material"].ToString();
                txbNombreMaterial.Text = respuesta["Nombre"].ToString();
                txbEtiqueta.Text = respuesta["Etiqueta"].ToString();
                //cerramos el reader
                respuesta.Close();
            }
        }
    }
}
