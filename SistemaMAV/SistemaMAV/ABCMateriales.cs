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
    /// Pantalla que permite la administracion de material 
    /// Autor: Oscar Arturo Villegas Rojas
    /// Codigo reciclado de Isaac Librado Almada
    /// Fecha: 08/05/2021
    /// Version: 1.0
    /// Ultima modificación: 09/05/2021
    /// </summary>
    public partial class ABCMateriales : Form
    {
        //data tables para la info
        DataTable dt;
        DataTable indtu;
        int tipoOp; //0.Nada 1.Alta 2.Cambio

        /// <summary>
        /// Constructor para crear los objetos
        /// </summary>
        public ABCMateriales()
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
        private void ABCMateriales_Load(object sender, EventArgs e)
        {
            CargarTabla();

            //obtenemos los datos de la tabla de tipos de estados
            SqlCommand consulta = MenuPrincipal.DefinirConsulta("sp_Cargar_Estados", MenuPrincipal.cn);
            SqlDataReader respuesta = consulta.ExecuteReader();
            indtu = new DataTable();
            indtu.Load(respuesta);

            //cargamos el combo box con la tabla
            cmbEstado.DataSource = indtu;
            cmbEstado.DisplayMember = "Estado";
            cmbEstado.ValueMember = "ID_Estado";

            //obtenemos los datos de la tabla de tipos de marca
            consulta = MenuPrincipal.DefinirConsulta("sp_Cargar_Marcas", MenuPrincipal.cn);
            respuesta = consulta.ExecuteReader();
            indtu = new DataTable();
            indtu.Load(respuesta);

            //cargamos el combo box con la tabla
            cmbMarca.DataSource = indtu;
            cmbMarca.DisplayMember = "Marca";
            cmbMarca.ValueMember = "ID_Marca";
        }
        
        /// <summary>
        /// Metodo para actualizar el datagrid cada vez que se cambia el combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbBusqueda_TextChanged(object sender, EventArgs e)
        {
            ///obtenemos los datos del stored proccedure
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Material_Por_Nombre", "@pNombre", txbBusqueda.Text, SqlDbType.VarChar, MenuPrincipal.cn);
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
                txbModelo.Text = respuesta["Modelo"].ToString();
                txbNumSerie.Text = respuesta["Num_Serie"].ToString();

                //obtenemos el indice que corresponde
                cmbEstado.SelectedIndex = Convert.ToInt32(respuesta["ID_Estado"]) - 1;
                cmbMarca.SelectedIndex = Convert.ToInt32(respuesta["ID_Marca"]) - 1;

                //cerramos el reader
                respuesta.Close();

                respuesta.Close();
                DesactivarCampos();
                tipoOp = 0;
            }
        }
        
        /// <summary>
        /// Este metodo ejecuta cada opción al momento de confirmar los cambios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (tipoOp)
            {
                case 1:
                    AnadirMaterial();
                    break;
                case 2:
                    EditarMaterial();
                    break;
            }
        }
        
        /// <summary>
        /// Se crea un nuevo registro con sus debidos datos
        /// </summary>
        private void AnadirMaterial()
        {
            List<string> parametros = new List<string>();
            parametros.Add("@pID_Material");
            parametros.Add("@pNombre");
            parametros.Add("@pEtiqueta");
            parametros.Add("@pID_Marca");
            parametros.Add("@pModelo");
            parametros.Add("@pNum_Serie");
            parametros.Add("@pID_Estado");

            List<string> valores = new List<string>();
            valores.Add(txbId.Text);
            valores.Add(txbNombre.Text);
            valores.Add(txbEtiqueta.Text);
            valores.Add(cmbMarca.SelectedValue.ToString());
            valores.Add(txbModelo.Text);
            valores.Add(txbNumSerie.Text);
            valores.Add(cmbEstado.SelectedValue.ToString());

            List<SqlDbType> tipos = new List<SqlDbType>();
            tipos.Add(SqlDbType.SmallInt);
            tipos.Add(SqlDbType.VarChar);
            tipos.Add(SqlDbType.VarChar);
            tipos.Add(SqlDbType.TinyInt);
            tipos.Add(SqlDbType.VarChar);
            tipos.Add(SqlDbType.VarChar);
            tipos.Add(SqlDbType.TinyInt);

            if (ValidarCamposVacios(valores))
            {
                SqlCommand consulta = MenuPrincipal.DefinirConsultaNPar("sp_Anadir_Material", parametros, valores, tipos, MenuPrincipal.cn);

                try
                {
                    consulta.ExecuteNonQuery();
                    VaciarCampos();
                    DesactivarCampos();
                    tipoOp = 0;
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
        /// Se elimina un registro verificando los datos ingresados
        /// </summary>
        private void EliminarMaterial()
        {
            List<string> parametros = new List<string>();
            parametros.Add("@pID_Material");
            parametros.Add("@pNombre");
            parametros.Add("@pEtiqueta");
            parametros.Add("@pID_Marca");
            parametros.Add("@pModelo");
            parametros.Add("@pNum_Serie");
            parametros.Add("@pID_Estado");

            List<string> valores = new List<string>();
            valores.Add(txbId.Text);
            valores.Add(txbNombre.Text);
            valores.Add(txbEtiqueta.Text);
            valores.Add(cmbMarca.SelectedValue.ToString());
            valores.Add(txbModelo.Text);
            valores.Add(txbNumSerie.Text);
            valores.Add(cmbEstado.SelectedValue.ToString());

            List<SqlDbType> tipos = new List<SqlDbType>();
            tipos.Add(SqlDbType.SmallInt);
            tipos.Add(SqlDbType.VarChar);
            tipos.Add(SqlDbType.VarChar);
            tipos.Add(SqlDbType.TinyInt);
            tipos.Add(SqlDbType.VarChar);
            tipos.Add(SqlDbType.VarChar);
            tipos.Add(SqlDbType.TinyInt);

            if (ValidarCamposVacios(valores))
            {
                SqlCommand consulta = MenuPrincipal.DefinirConsultaNPar("sp_Eliminar_Material", parametros, valores, tipos, MenuPrincipal.cn);

                try
                {
                    consulta.ExecuteNonQuery();
                    VaciarCampos();
                    DesactivarCampos();
                    tipoOp = 0;
                }
                catch
                {
                    MessageBox.Show("No se pudo eliminar el material", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CargarTabla();
            }
            else
            {
                MessageBox.Show("Faltan valores en los campos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se edita un registro con el id seleccionado
        /// </summary>
        private void EditarMaterial()
        {
            List<string> parametros = new List<string>();
            parametros.Add("@pID_Material");
            parametros.Add("@pNombre");
            parametros.Add("@pEtiqueta");
            parametros.Add("@pID_Marca");
            parametros.Add("@pModelo");
            parametros.Add("@pNum_Serie");
            parametros.Add("@pID_Estado");

            List<string> valores = new List<string>();
            valores.Add(txbId.Text);
            valores.Add(txbNombre.Text);
            valores.Add(txbEtiqueta.Text);
            valores.Add(cmbMarca.SelectedValue.ToString());
            valores.Add(txbModelo.Text);
            valores.Add(txbNumSerie.Text);
            valores.Add(cmbEstado.SelectedValue.ToString());

            List<SqlDbType> tipos = new List<SqlDbType>();
            tipos.Add(SqlDbType.SmallInt);
            tipos.Add(SqlDbType.VarChar);
            tipos.Add(SqlDbType.VarChar);
            tipos.Add(SqlDbType.TinyInt);
            tipos.Add(SqlDbType.VarChar);
            tipos.Add(SqlDbType.VarChar);
            tipos.Add(SqlDbType.TinyInt);

            if (ValidarCamposVacios(valores))
            {
                SqlCommand consulta = MenuPrincipal.DefinirConsultaNPar("sp_Editar_Material", parametros, valores, tipos, MenuPrincipal.cn);

                try
                {
                    consulta.ExecuteNonQuery();
                    VaciarCampos();
                    DesactivarCampos();
                    tipoOp = 0;
                }
                catch
                {
                    MessageBox.Show("No se pudo editar el material", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Material_Por_Nombre", "@pNombre", "", SqlDbType.VarChar, MenuPrincipal.cn);
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
        /// Este metodo permite los ajustes para ingresar los datos a registrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            VaciarCampos();
            ActivarCampos();

            tipoOp = 1;
        }

        /// <summary>
        /// Este metodo ajusta los campos para poder editar un registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tipoOp == 1 || txbId.Text=="")
            {
                MessageBox.Show("Debes seleccionar un material existente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //activamos todos los controles
                ActivarCampos();

                //cambiamos a operacion de agregacon
                tipoOp = 2;

                //El id no se puede modificar pues será con el que se sabra que registro editar
                txbId.Enabled = false;
            }
        }

        /// <summary>
        /// Este metodo bloquea los campos para evitar cambios inesperados antes de borrar un registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tipoOp != 1 && txbId.Text != "")
            {
                DialogResult confirmar;

                confirmar = MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (confirmar == DialogResult.Yes)
                {
                    EliminarMaterial();
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un usuario existente para eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// metodo para activar los campos
        /// </summary>
        private void ActivarCampos()
        {
            txbId.Enabled = true;
            txbNombre.Enabled = true;
            txbEtiqueta.Enabled = true;
            cmbMarca.Enabled = true;
            txbModelo.Enabled = true;
            txbNumSerie.Enabled = true;
            cmbEstado.Enabled = true;
        }

        /// <summary>
        /// metodo para desactivar los campos
        /// </summary>
        private void DesactivarCampos()
        {
            txbId.Enabled = false;
            txbNombre.Enabled = false;
            txbEtiqueta.Enabled = false;
            cmbMarca.Enabled = false;
            txbModelo.Enabled = false;
            txbNumSerie.Enabled = false;
            cmbEstado.Enabled = false;
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
            txbModelo.Text = "";
            txbNumSerie.Text = "";
        }

        /// <summary>
        /// Metodo para validar que todos los datos estén rellenos
        /// </summary>
        /// <param name="pValores"></param>
        /// <returns>false si falta alguno</returns>
        private bool ValidarCamposVacios(List<string> pValores)
        {
            foreach (string valor in pValores)
            {
                if (valor == "")
                    return false;
            }

            return true;
        }
    }
}
