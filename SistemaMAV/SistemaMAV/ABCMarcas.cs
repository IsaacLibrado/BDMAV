using System;
using System.Collections.Generic;
using System.Data;
//Usamos la libreria de sqlClient
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaMAV
{
    public partial class ABCMarcas : Form
    {
        DataTable dt;
        DataTable indtu;
        //0.Nada 1.Alta 2.Cambio
        int tipoOp;
        public ABCMarcas()
        {
            tipoOp = 0;
            InitializeComponent();
            dt = new DataTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            VaciarCampos();
            ActivarCampos();

            tipoOp = 1;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tipoOp != 1 && txbID.Text != "")
            {
                DialogResult confirmar;

                confirmar = MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (confirmar == DialogResult.Yes)
                {
                    EliminarMarca();
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar una marca existente para eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tipoOp == 1 || txbID.Text == "")
            {
                MessageBox.Show("Debes seleccionar una marca existente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //activamos todos los controles
                ActivarCampos();

                //cambiamos a operacion de agregacion
                tipoOp = 2;

                //El id no se puede modificar pues será con el que se sabra que registro editar
                txbID.Enabled = false;
            }
        }

        private void EliminarMarca()
        {
            List<string> parametros = new List<string>();
            parametros.Add("@pID_Marca");
            parametros.Add("@pNombreMarca");


            List<string> valores = new List<string>();
            valores.Add(txbID.Text);
            valores.Add(txbNombreMarca.Text);

            List<SqlDbType> tipos = new List<SqlDbType>();
            tipos.Add(SqlDbType.SmallInt);
            tipos.Add(SqlDbType.VarChar);

            if (MenuPrincipal.ValidarCamposVacios(valores))
            {
                SqlCommand consulta = MenuPrincipal.DefinirConsultaNPar("sp_Eliminar_Marca", parametros, valores, tipos, MenuPrincipal.cn);

                try
                {
                    consulta.ExecuteNonQuery();
                    VaciarCampos();
                    DesactivarCampos();
                    tipoOp = 0;
                }
                catch
                {
                    MessageBox.Show("No se pudo eliminar la marca", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CargarTabla();
            }
            else
            {
                MessageBox.Show("Faltan valores en los campos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTabla()
        {
            //hacemos la consulta por nombre vacio
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Marca_Por_Nombre", "@pMarca", "", SqlDbType.VarChar, MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            //cargamos la data table
            dt.Load(respuesta);

            //colocamos el datatable en el datagrid 
            dgVistaTabla.DataSource = dt;

            //cerramos el reader
            respuesta.Close();

            dgVistaTabla.Columns[0].Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (tipoOp)
            {
                case 1:
                    AnadirMarca();
                    break;
                case 2:
                    EditarMarca();
                    break;
            }
        }

        private void AnadirMarca()
        {
            List<string> parametros = new List<string>();
            parametros.Add("@pNombreMarca");


            List<string> valores = new List<string>();
            valores.Add(txbNombreMarca.Text);

            List<SqlDbType> tipos = new List<SqlDbType>();
            tipos.Add(SqlDbType.VarChar);


            if (MenuPrincipal.ValidarCamposVacios(valores))
            {
                SqlCommand consulta = MenuPrincipal.DefinirConsultaNPar("sp_Anadir_Marca", parametros, valores, tipos, MenuPrincipal.cn);

                try
                {
                    consulta.ExecuteNonQuery();
                    VaciarCampos();
                    DesactivarCampos();
                    tipoOp = 0;
                }
                catch
                {
                    MessageBox.Show("No se pudo agregar la marca", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CargarTabla();
            }
            else
            {
                MessageBox.Show("Faltan valores en los campos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarMarca()
        {
            List<string> parametros = new List<string>();
            parametros.Add("@pID_Marca");
            parametros.Add("@pNombreMarca");


            List<string> valores = new List<string>();
            valores.Add(txbID.Text);
            valores.Add(txbNombreMarca.Text);

            List<SqlDbType> tipos = new List<SqlDbType>();
            tipos.Add(SqlDbType.SmallInt);
            tipos.Add(SqlDbType.VarChar);


            if (MenuPrincipal.ValidarCamposVacios(valores))
            {
                SqlCommand consulta = MenuPrincipal.DefinirConsultaNPar("sp_Editar_Marca", parametros, valores, tipos, MenuPrincipal.cn);

                try
                {
                    consulta.ExecuteNonQuery();
                    VaciarCampos();
                    DesactivarCampos();
                    tipoOp = 0;
                }
                catch
                {
                    MessageBox.Show("No se pudo editar la marca", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CargarTabla();
            }
            else
            {
                MessageBox.Show("Faltan valores en los campos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txbBusqueda_TextChanged(object sender, EventArgs e)
        {
            ///obtenemos los datos del stored proccedure
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Marca_PorNombre", "@pMarca", txbBusqueda.Text, SqlDbType.VarChar, MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            dt.Load(respuesta);

            dgVistaTabla.DataSource = dt;
            respuesta.Close();
        }

        private void ABCMarcas_Load(object sender, EventArgs e)
        {
            CargarTabla();

            //obtenemos los datos de la tabla de tipos de marca
            SqlCommand consulta = MenuPrincipal.DefinirConsulta("sp_Cargar_Marcas", MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            indtu = new DataTable();
            indtu.Load(respuesta);
        }

        private void dgVistaTabla_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //si el elegido no es null
            if (dgVistaTabla.CurrentRow.Cells[0].Value.ToString() != string.Empty)
            {
                //obtenemos el id
                string pID;
                pID = dgVistaTabla.CurrentRow.Cells[0].Value.ToString();

                //hacemos la consulta con la matricula
                SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Obtener_Datos_Marca", "@pID", pID, SqlDbType.Int, MenuPrincipal.cn);
                SqlDataReader respuesta = consulta.ExecuteReader();
                respuesta.Read();

                //obtenemos los datos de la base de datos
                txbID.Text = respuesta["ID_Marca"].ToString();
                txbNombreMarca.Text = respuesta["Marca"].ToString();

                //cerramos el reader
                respuesta.Close();

                respuesta.Close();
                DesactivarCampos();
                tipoOp = 0;
            }
        }

        /// <summary>
        /// Metodo para vaciar los campos
        /// </summary>
        private void VaciarCampos()
        {
            //vaciamos los campos
            txbID.Text = "";
            txbNombreMarca.Text = "";
        }

        /// <summary>
        /// metodo para activar los campos
        /// </summary>
        private void ActivarCampos()
        {
            txbNombreMarca.Enabled = true;
        }

        /// <summary>
        /// metodo para desactivar los campos
        /// </summary>
        private void DesactivarCampos()
        {
            txbID.Enabled = false;
            txbNombreMarca.Enabled = false;
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            MenuPrincipal.AsignarTitulo("Consultar Marcas");
            MenuPrincipal.abrirPantallas(new ConsultarMarcas());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
