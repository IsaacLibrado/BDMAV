using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaMAV
{
    public partial class RealizarPrestamo : Form
    {

        //data tables para la info
        DataTable dt;

        public RealizarPrestamo()
        {
            InitializeComponent();
            dt = new DataTable();

        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CompletarPrestamo();
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
        private void CompletarPrestamo()
        {
            DateTime fecha = DateTime.Now;

            List<string> parametros = new List<string>();
            parametros.Add("@pMatBecario");
            parametros.Add("@pMatSol");
            parametros.Add("@pFechaPres");

            List<string> valores = new List<string>();
            valores.Add(txbUsuario.Text);
            valores.Add(txbSolicitante.Text);
            valores.Add(string.Format("{0}/{1}/{2} {3}:{4}:{5}", fecha.Day.ToString(), fecha.Month.ToString(), fecha.Year.ToString(), fecha.Hour.ToString(), fecha.Minute.ToString(), fecha.Second.ToString()));

            List<SqlDbType> tipos = new List<SqlDbType>();
            tipos.Add(SqlDbType.Int);
            tipos.Add(SqlDbType.Int);
            tipos.Add(SqlDbType.SmallDateTime);

            if (MenuPrincipal.ValidarCamposVacios(valores))
            {
                SqlCommand consulta = MenuPrincipal.DefinirConsultaNPar("sp_Prestar_Material", parametros, valores, tipos, MenuPrincipal.cn);

                try
                {
                    consulta.ExecuteNonQuery();
                    txbBusquedaSolicitante.Clear();
                    txbNombre.Clear();
                    txbSolicitante.Clear();

                    MenuPrincipal.abrirPantallas(new AnadirPrestamos());
                }
                catch
                {
                    MessageBox.Show("No se puede prestar el material", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CargarTabla();

            }
            else
            {
                MessageBox.Show("Faltan valores en los campos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RealizarPrestamo_Load(object sender, EventArgs e)
        {
            ValidarRegistros();
            CargarTabla();

            txbUsuario.Text = MenuPrincipal.matriculaActual;
            txbUsuarioNombre.Text = MenuPrincipal.usuarioActual;
        }


        /// <summary>
        /// Metodo para mostrar los datos en el datagrid
        /// </summary>
        private void CargarTabla()
        {
            //hacemos la consulta por nombre vacio
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Solicitante_PorNombre_Reduc", "@pNombre", "", SqlDbType.VarChar, MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            //cargamos la data table
            dt.Load(respuesta);

            //colocamos el datatable en el datagrid 
            dgVistaSolicitantes.DataSource = dt;

            //cerramos el reader
            respuesta.Close();

            dgVistaSolicitantes.Columns[1].Width = 200;

        }

        private void dgVistaSolicitantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgVistaSolicitantes.CurrentRow.Cells[0].Value.ToString() != string.Empty)
            {
                //obtenemos el id
                string pID;
                pID = dgVistaSolicitantes.CurrentRow.Cells[0].Value.ToString();

                //hacemos la consulta con la matricula
                SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Obtener_Datos_Solicitante", "@pId", pID, SqlDbType.Int, MenuPrincipal.cn);
                SqlDataReader respuesta = consulta.ExecuteReader();
                respuesta.Read();
                txbNombre.Text = respuesta["Nombre"].ToString();
                txbSolicitante.Text = respuesta["Matricula"].ToString();
                //obtenemos el indice que corresponde
                //cerramos el reader
                respuesta.Close();
            }
        }

        private void txbBusquedaSolicitante_TextChanged(object sender, EventArgs e)
        {
            if (MenuPrincipal.ValidarPalabrasProhibidas(txbBusquedaSolicitante.Text))
            {
                ///obtenemos los datos del stored proccedure
                SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Solicitante_PorNombre_Reduc", "@pNombre", txbBusquedaSolicitante.Text, SqlDbType.VarChar, MenuPrincipal.cn);
                SqlDataReader respuesta = consulta.ExecuteReader();
                dt = new DataTable();

                dt.Load(respuesta);

                dgVistaSolicitantes.DataSource = dt;
                respuesta.Close();
            }
            else
            {
                MessageBox.Show("Valores incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbBusquedaSolicitante.Text = "";
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
    }
}
