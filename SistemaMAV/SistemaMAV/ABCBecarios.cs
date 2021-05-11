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
    public partial class ABCBecarios : Form
    {   
        //data tables para la info
        DataTable dt;
        DataTable indtu;
        int tipoOp; //0.Nada 1.Alta 2.Cambio

        public ABCBecarios()
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
            SqlCommand consulta = MenuPrincipal.DefinirConsulta("sp_Cargar_Usuarios_Becarios", MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            indtu = new DataTable();
            indtu.Load(respuesta);


            //cargamos el combo box con la tabla
            cmbMatricula.DataSource = indtu;
            cmbMatricula.DisplayMember = "Matricula";
            cmbMatricula.ValueMember = "Matricula";


        }

        /// <summary>
        /// Metodo para actualizar el datagrid cada vez que se cambia el combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbBusqueda_TextChanged(object sender, EventArgs e)
        {
            ///obtenemos los datos del stored proccedure
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Becario_PorNombre_Reduc", "@pNombre", txbBusqueda.Text, SqlDbType.VarChar, MenuPrincipal.cn);
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
                //obtenemos la matricula
                string pMatricula;
                pMatricula = dgVistaTabla.CurrentRow.Cells[0].Value.ToString();

                //hacemos la consulta con la matricula
                SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Obtener_Datos_Becario", "@pID", pMatricula, SqlDbType.TinyInt, MenuPrincipal.cn);
                SqlDataReader respuesta = consulta.ExecuteReader();
                respuesta.Read();

                //obtenemos los datos de la base de datos
                txbID.Text = respuesta["ID_Becario"].ToString();
                txbHorasT.Text = respuesta["Horas_Totales"].ToString();
                txbHorasR.Text = respuesta["Horas_Realizadas"].ToString();


                cmbMatricula.SelectedIndex = Convert.ToInt32(respuesta["ID_Becario"]) - 1;

                //cerramos el reader
                respuesta.Close();
                DesactivarCampos();
                tipoOp = 0;
            }
        }

        /// <summary>
        /// Metodo para guardar los cambios realizados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //dependiendo el tipo de operacion realiza un stored procceudre
            switch (tipoOp)
            {
                case 1:
                    AnadirUsuario();
                    break;
                case 2:
                    EditarUsuario();
                    break;
            }
        }

        /// <summary>
        /// Metodo para realizar el añadido de usuario
        /// </summary>
        private void AnadirUsuario()
        {
            //definimos los nombres de los parametros
            List<string> parametros = new List<string>();
            parametros.Add("@pMatricula");
            parametros.Add("@pHorasT");
            parametros.Add("@pHorasR");

            //definimos los valores de los parametros
            List<string> valores = new List<string>();

            valores.Add(cmbMatricula.SelectedValue.ToString());
            valores.Add(txbHorasT.Text);
            valores.Add(txbHorasR.Text);

            //definimos los tipos de los parametros
            List<SqlDbType> tipos = new List<SqlDbType>();
            tipos.Add(SqlDbType.Int);
            tipos.Add(SqlDbType.SmallInt);
            tipos.Add(SqlDbType.SmallInt);

            if (MenuPrincipal.ValidarCamposVacios(valores))
            {
                //hacemos la consulta
                SqlCommand consulta = MenuPrincipal.DefinirConsultaNPar("sp_Anadir_Becario", parametros, valores, tipos, MenuPrincipal.cn);

                //ejecutamos el query y atrapamos errores
                try
                {
                    consulta.ExecuteNonQuery();
                    VaciarCampos();
                    DesactivarCampos();
                    tipoOp = 0;
                }
                catch
                {
                    MessageBox.Show("No se pudo agregar al becario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CargarTabla();
            }
            else
            {
                MessageBox.Show("Valores incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metodo para realizar el editado de usuario
        /// </summary>
        private void EditarUsuario()
        {
            //definimos los nombres de los parametros
            List<string> parametros = new List<string>();
            parametros.Add("@pID_Becario");
            parametros.Add("@pHorasT");
            parametros.Add("@pHorasR");

            //definimos los valores de los parametros
            List<string> valores = new List<string>();
            valores.Add(txbID.Text);
            valores.Add(txbHorasT.Text);
            valores.Add(txbHorasR.Text);

            //definimos los tipos de los parametros
            List<SqlDbType> tipos = new List<SqlDbType>();
            tipos.Add(SqlDbType.TinyInt);
            tipos.Add(SqlDbType.SmallInt);
            tipos.Add(SqlDbType.SmallInt);

            if (MenuPrincipal.ValidarCamposVacios(valores))
            {
                //hacemos la consulta
                SqlCommand consulta = MenuPrincipal.DefinirConsultaNPar("sp_Editar_Becario", parametros, valores, tipos, MenuPrincipal.cn);

                //ejecutamos el query y atrapamos errores
                try
                {
                    consulta.ExecuteNonQuery();
                    VaciarCampos();
                    DesactivarCampos();
                    tipoOp = 0;
                }
                catch
                {
                    MessageBox.Show("No se pudo editar al becario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CargarTabla();
            }
            else
            {
                MessageBox.Show("Valores incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metodo para realizar el editado de usuario
        /// </summary>
        private void EliminarUsuario()
        {
            //hacemos la consulta
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Eliminar_Becario", "@pID_Becario", txbID.Text, SqlDbType.TinyInt, MenuPrincipal.cn);

            //ejecutamos el query y atrapamos errores
            try
            {
                consulta.ExecuteNonQuery();
                VaciarCampos();
                DesactivarCampos();
                tipoOp = 0;
            }
            catch
            {
                MessageBox.Show("No se pudo eliminar al becario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarTabla();
        }

        //Metodo para cargar la tabla del data grid
        private void CargarTabla()
        {
            //hacemos la consulta por nombre vacio
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Becario_Por_Nombre_Reduc", "@pNombre", " ", SqlDbType.VarChar, MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            dt = new DataTable();

            //cargamos la data table
            dt.Load(respuesta);

            //colocamos el datatable en el datagrid 
            dgVistaTabla.DataSource = dt;

            dgVistaTabla.Columns[1].Width = 200;

            //cerramos el reader
            respuesta.Close();


        }

        /// <summary>
        /// Metodo para activar los controles necesarios para añadir un usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //activamos todos los controles
            VaciarCampos();
            ActivarCampos();

            //cambiamos a operacion de agregacon
            tipoOp = 1;
        }

        /// <summary>
        /// Metodo para vaciar los campos
        /// </summary>
        private void VaciarCampos()
        {
            //vaciamos los campos
            txbID.Text = "";
            txbHorasR.Text = "";
            txbHorasT.Text = "";
        }

        /// <summary>
        /// metodo para activar los campos
        /// </summary>
        private void ActivarCampos()
        {
            txbHorasR.Enabled = true;
            txbHorasT.Enabled = true;
            cmbMatricula.Enabled = true;
        }

        /// <summary>
        /// metodo para desactivar los campos
        /// </summary>
        private void DesactivarCampos()
        {
            txbID.Enabled = false;
            txbHorasR.Enabled = false;
            txbHorasT.Enabled = false;
            cmbMatricula.Enabled = false;
        }



        /// <summary>
        /// metodo para realizar la edicion de usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tipoOp == 1 || txbID.Text == "")
            {
                MessageBox.Show("Debes seleccionar un becario existente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //activamos todos los controles
                ActivarCampos();

                //cambiamos a operacion de agregacon
                tipoOp = 2;

                //desactivamos el control de la matricula
                txbID.Enabled = false;

                cmbMatricula.Enabled = false;
            }
        }

        /// <summary>
        /// metodo para eliminar un usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tipoOp != 1 && txbID.Text != "")
            {
                DialogResult confirmar;

                confirmar = MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (confirmar == DialogResult.Yes)
                {
                    EliminarUsuario();
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un becario existente para eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metodo para llevar al usuario a la pantalla de consultas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConsulta_Click(object sender, EventArgs e)
        {
            MenuPrincipal.AsignarTitulo("Consultar Usuarios");
            MenuPrincipal.abrirPantallas(new ConsultarUsuarios());
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
    }
}
