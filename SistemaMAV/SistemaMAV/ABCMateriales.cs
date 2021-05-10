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
        int tipoOp; //0.Nada 1.Alta 2.Baja 3.Cambio

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
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Material_Por_Nombre_Simple", "@pNombre", txbBusqueda.Text, SqlDbType.VarChar, MenuPrincipal.cn);
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
            }
        }
        
        /// <summary>
        /// Este metodo ejecuta cada opción al momento de confirmar los cambios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Codigo de seguridad. EL usuario debe ingresar cada campo si desea guardar una acción
            if (txbId.Text != "" || txbNombre.Text != "" || txbEtiqueta.Text != "" || txbModelo.Text != "" || txbNumSerie.Text != "")
            {
                switch (tipoOp)
                {
                    case 1:
                        AnadirMaterial();
                        break;
                    case 2:
                        EliminarMaterial();
                        break;
                    case 3:
                        EditarMaterial();
                        break;
                }
            }
            else MessageBox.Show("Porfavor, complete los campos necesarios", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            SqlCommand consulta = MenuPrincipal.DefinirConsultaNPar("sp_Anadir_Material", parametros, valores, tipos, MenuPrincipal.cn);

            try
            {
                consulta.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("No se pudo agregar el material", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarTabla();
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

            SqlCommand consulta = MenuPrincipal.DefinirConsultaNPar("sp_Eliminar_Material", parametros, valores, tipos, MenuPrincipal.cn);

            try
            {
                consulta.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("No se pudo eliminar el material", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarTabla();
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

            SqlCommand consulta = MenuPrincipal.DefinirConsultaNPar("sp_Editar_Material", parametros, valores, tipos, MenuPrincipal.cn);

            try
            {
                consulta.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("No se pudo editar el material", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarTabla();
        }


        /// <summary>
        /// Metodo para mostrar los datos en el datagrid
        /// </summary>
        private void CargarTabla()
        {
            //hacemos la consulta por nombre vacio
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Material_Por_Nombre_Simple", "@pNombre", "", SqlDbType.VarChar, MenuPrincipal.cn);
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
            txbId.Enabled = true;
            txbNombre.Enabled = true;
            txbEtiqueta.Enabled = true;
            cmbMarca.Enabled = true;
            txbModelo.Enabled = true;
            txbNumSerie.Enabled = true;
            cmbEstado.Enabled = true;

            tipoOp = 1;
        }

        /// <summary>
        /// Este metodo ajusta los campos para poder editar un registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //El id no se puede modificar pues será con el que se sabra que registro editar
            txbId.Enabled = false;
            txbNombre.Enabled = true;
            txbEtiqueta.Enabled = true;
            cmbMarca.Enabled = true;
            txbModelo.Enabled = true;
            txbNumSerie.Enabled = true;
            cmbEstado.Enabled = true;

            txbId.Clear();
            txbNombre.Clear();
            txbEtiqueta.Clear();
            cmbMarca.Text = "";
            txbModelo.Clear();
            txbNumSerie.Clear();
            cmbEstado.Text = "";

            tipoOp = 3;
        }

        /// <summary>
        /// Este metodo bloquea los campos para evitar cambios inesperados antes de borrar un registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Se bloquean y borran los campos para obligar al usuario a seleccionar un campo del datagrid y asi evitar errores humanos
            txbId.Enabled = false;
            txbNombre.Enabled = false;
            txbEtiqueta.Enabled = false;
            cmbMarca.Enabled = false;
            txbModelo.Enabled = false;
            txbNumSerie.Enabled = false;
            cmbEstado.Enabled = false;

            txbId.Clear();
            txbNombre.Clear();
            txbEtiqueta.Clear();
            cmbMarca.Text="";
            txbModelo.Clear();
            txbNumSerie.Clear();
            cmbEstado.Text="";

            tipoOp = 2;
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
    }
}
