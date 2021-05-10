using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;

namespace SistemaMAV
{
    /// <summary>
    /// Esta clase define las funcionalidades del menu principal
    /// </summary>
    /// Version 1.0
    /// Fecha de creacion 07 de Marzo 2021
    /// Creador Isaac Librado
    public partial class MenuPrincipal : Form
    {
        //conexion con la base de datos
        public static SqlConnection cn;

        //validar conexion
        bool conectado;

        //usuario actual
        public static string usuarioActual;

        public static string cargoActual;

        //La pantalla que se muestra en el contenedor central
        private Form pantallaActiva = null;

        public MenuPrincipal()
        {
            //inicializamos lo básico
            InitializeComponent();
            PersonalizarDisenio();
            conectado = false;
        }

        #region disenio

        /// <summary>
        /// Metodo para darle un diseño inicial al menu
        /// </summary>
        /// Version 1.0
        /// Fecha de creacion 7 de Marzo del 2021
        /// Creador Isaac Librado
        private void PersonalizarDisenio()
        {
            //hacemos invisibles a los sub menus
            panelAdminSubMenu.Visible = false;
            panelPrestamosSubMenu.Visible = false;
            panelBecaSubMenu.Visible = false;

            //Inicializamos textos
            lblMensajes.Text = " ";
            lblTitulo.Text = "";

            //Ocultamos los botones
            panelSideMenu.Visible = false;

            //evitamos que se pueda cambiar el tamaño
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MaximizeBox = false;

            this.FormBorderStyle = FormBorderStyle.None;
        }


        /// <summary>
        /// Obtiene la direccion ip del dispositivo actual
        /// </summary>
        /// Version 1.0
        /// Fecha de creacion 07 de Marzo del 2021
        /// Creador Isaac Librado
        private void ObtenerDireccionIp()
        {
            //lo marca como obsoleto porque utiliza ipv4
            var ip = Dns.GetHostByName(Dns.GetHostName()).AddressList[0];

            ////version ipv6
            //var ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];

            lblIp.Text = ip.ToString();
        }

        /// <summary>
        /// Obtiene la hora actual cada tick del timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 7 de Marzo de 2021
        /// Creador Isaac Librado
        private void horaFecha_Tick(object sender, EventArgs e)
        {
            //asigna las fechas y horas a sus respectivos labels
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }


        #endregion

       

        #region funcionalidades


        /// <summary>
        /// Obtiene los datos del user que ha iniciado sesión
        /// </summary>
        /// <param name="pUserName">el username del usuario</param>
        /// Version 1.0
        /// Fecha de creacion 13/03/21
        /// Creador Isaac Librado
        public static void ValidarLogIn(string pUserName, string pCargo)
        {
            MenuPrincipal formActual = (MenuPrincipal)ActiveForm;

            MenuPrincipal.usuarioActual = pUserName;
            MenuPrincipal.cargoActual = pCargo;
            //colocamos los datos del usuario
            formActual.lblUserName.Text = pUserName;
            formActual.lblCargo.Text = pCargo;

            //mostramos datos en el menú
            formActual.panelSideMenu.Visible = true;
            formActual.ObtenerDireccionIp();

            formActual.pbLogoTemp.Visible = false;

            //validamos el tipo de usuario para saber qué mostrar
            if(pCargo=="Jefe")
            {
                formActual.btnSMUsuarios.Visible = false;
                formActual.btnSMTiposUsuario.Visible = false;
                formActual.btnSMEstados.Visible = false;
                formActual.btnSMTiposSolicitante.Visible = false;
                formActual.panelAdminSubMenu.Height = 129;

                formActual.btnSMPrestar.Visible = false;
                formActual.btnSMDevolver.Visible = false;
                formActual.panelPrestamosSubMenu.Height = 66;
            }
            else if(pCargo=="Becario" || pCargo=="Solicitante")
            {
                formActual.btnAdmin.Visible = false;
                formActual.btnSMRegistros.Visible = false;

                if(pCargo=="Solicitante")
                {
                    formActual.btnHorasBeca.Visible = false;
                    formActual.btnSMPrestar.Visible = false;
                    formActual.btnSMDevolver.Visible = false;
                    formActual.panelPrestamosSubMenu.Height = 66;
                }
            }
            else if(pCargo=="Visitante")
            {
                formActual.btnAdmin.Visible = false;
                formActual.btnHorasBeca.Visible = false;
                formActual.btnSMPrestar.Visible = false;
                formActual.btnSMDevolver.Visible = false;
                formActual.btnSMConsPres.Visible = false;
                formActual.panelPrestamosSubMenu.Height = 34;
            }

            MenuPrincipal.AsignarTitulo("Inicio");
        }


        /// <summary>
        /// Metodo para ocultar los submenus
        /// </summary>
        /// Version 1.0
        /// Fecha de creacion 7 de Marzo del 2021
        /// Creador Isaac Librado
        private void ocultarSubMenu()
        {
            panelAdminSubMenu.Visible = false;
            panelPrestamosSubMenu.Visible = false;
            panelBecaSubMenu.Visible = false;
        }

        /// <summary>
        /// Metodo para mostrar los submenus dependiendo el panel
        /// </summary>
        /// <param name="subMenu">El panel a mostrar con los botones del sub menu</param>
        /// Version 1.0
        /// Fecha de creacion 7 de Marzo del 2021
        /// Creador Isaac Librado
        private void mostrarSubMenu(Panel subMenu)
        {
            //alterna entre visible y no visible dependiendo el estado actual del submenu
            if (subMenu.Visible == false)
            {
                ocultarSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        /// <summary>
        /// Metodo para mostrar las pantallas en el panel contenedor
        /// </summary>
        /// <param name="pPantalla">Es la pantalla a mostrar</param>
        /// Version 1.0
        /// Fecha de creacion 7 de Marzo del 2021
        /// Creador Isaac Librado
        public static void abrirPantallas(Form pPantalla)
        {
            //obtenemos la pantalla del menu principal
            MenuPrincipal formActual = (MenuPrincipal)ActiveForm;

            //obtenemos la pantalla activa en el contenedor
            Form pantallaActiva = formActual.pantallaActiva;

            //obtenemos la instancia del contenedor
            Panel panelContenedor = formActual.panelContenedor;

            //si tenemos una pantalla activa la cerramos
            if (pantallaActiva != null)
                pantallaActiva.Close();

            panelContenedor.Controls.Clear();

            //asignamos la pantalla activa 
            pantallaActiva = pPantalla;
            //le indicamos que no es la principal
            pantallaActiva.TopLevel = false;
            //le quitamos el borde
            pantallaActiva.FormBorderStyle = FormBorderStyle.None;
            //que cubra todo el contenedor
            pantallaActiva.Dock = DockStyle.Fill;
            //lo añadimos a los controles del contenedor
            panelContenedor.Controls.Add(pantallaActiva);
            //lo asignamos al tag de contenedor
            panelContenedor.Tag = pPantalla;
            //traemos la pantalla activa al frente
            pantallaActiva.BringToFront();

            //mostramos la pantalla activa
            pantallaActiva.Show();

            MostrarMensaje(string.Empty);
        }

        /// <summary>
        /// Metodo para asignar el titulo de la pantalla actual
        /// </summary>
        /// <param name="pTitulo">Titulo a colocar</param>
        /// Version 1.0
        /// Fecha de creacion 7 de Marzo del 2021
        /// Creador Isaac Librado
        public static void AsignarTitulo(string pTitulo)
        {
            //obtenemos las instancias necesarias del menu y el label del titulo
            MenuPrincipal formActual = (MenuPrincipal)ActiveForm;
            Panel panelTitulo = formActual.panelTitulo;
            Label lblTitulo = formActual.lblTitulo;

            //colocamos el texto
            lblTitulo.Text = pTitulo;

            //obtenemos el centro del panel para colocar en esa posicion al label
            int panelX = (panelTitulo.Size.Width - lblTitulo.Size.Width) / 2;
            lblTitulo.Location = new Point(panelX, lblTitulo.Location.Y);
        }

        /// <summary>
        /// Metodo para mostrar los mensajes en la pantalla
        /// </summary>
        /// <param name="pMensaje">El mensaje a mostrar</param>
        /// Version 1.0
        /// Fecha de creacion 7 de Marzo del 2021
        /// Creador Isaac Librado
        public static void MostrarMensaje(string pMensaje)
        {
            //obtenemos la instancia del menu principal para colocar el texto en su control
            MenuPrincipal formActual = (MenuPrincipal)ActiveForm;

            formActual.lblMensajes.Text = pMensaje;
        }

        /// <summary>
        /// Metodo para mostrar al cargar el cu_05
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 23/03/21
        /// Creador Isaac Librado
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            txbServer.Focus();
        }


        #endregion

        #region conexionsql

        /// <summary>
        /// Valida que la conexión haya sido exitosa
        /// </summary>
        /// <returns>True si se hizo la apertura de la conexion</returns>
        /// Version 1.0
        /// Fecha de creacion 06/05/21
        /// Creador Isaac Librado
        private bool validarConexion(string pServer)
        {
            //String de conexion
            cn = new SqlConnection(string.Format("SERVER={0};DATABASE=DB.MAVDatos;integrated security=true", pServer));
            try
            {
                cn.Open();
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Metodo para conectar al servidor
        /// </summary>
        /// Version 1.0
        /// Fecha de creacion 25/03/21
        /// Creador Isaac Librado
        private void Conectar()
        {
            string nombreServer = txbServer.Text;

            if (validarConexion(nombreServer))
            {
                conectado= true;
                abrirPantallas(new LogIn(cn));
            }
            else
            {
                MessageBox.Show("No se pudo realizar la conexión al servidor", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metodo para conectar al servidor al presionar el boton enter en el textbox del server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Creador Isaac Librado
        private void txbServer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Conectar();
            }
        }

        /// <summary>
        /// Metodo que se ejecuta cuando se da click en entrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 20/03/21
        /// Creador Isaac Librado
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Conectar();
        }

        #endregion

        #region consultas
        /// <summary>
        /// Metodo para ejecutar un stored proccedure con un parametro dado
        /// </summary>
        /// <param name="pNombreProcedimiento">Nombe del stored proccedure</param>
        /// <param name="pNombreParam">Nombre del parametro del sp</param>
        /// <param name="pValorParam">Valor que se introduce en el parametro</param>
        /// <param name="pSqlDbType">tipo de dato del parametro</param>
        /// <param name="pCn">instancia de la conexion al servidor</param>
        /// <returns>Regresa el comando de sql definido</returns>
        public static SqlCommand DefinirConsultaSPar(string pNombreProcedimiento, string pNombreParam, string pValorParam, SqlDbType pSqlDbType, SqlConnection pCn)
        {
            //comando~query
            //definimos la consulta como un stored procedure
            SqlCommand tempcmdSPar = DefinirConsulta(pNombreProcedimiento, pCn);

            //añadimos parametros al stored procedure
            tempcmdSPar.Parameters.AddWithValue(pNombreParam, pSqlDbType).Value = pValorParam;

            //regresamos el sqlcommand
            return tempcmdSPar;
        }


        /// <summary>
        /// Metodo para ejecutar un stored proccedure sin parametros
        /// </summary>
        /// <param name="pNombreProcedimiento">El nombre del stored proccedure</param>
        /// <param name="pCn">Conexion a la base de datos</param>
        /// <returns>El comando definido</returns>
        public static SqlCommand DefinirConsulta(string pNombreProcedimiento, SqlConnection pCn)
        {
            //comando~query
            //creamos la instancia del comando de sql, lleva la cadena del comando a ejecutrar y la conexion de la base de datos
            SqlCommand tempcmd = new SqlCommand(pNombreProcedimiento, pCn);

            //especificamos que la cadena del comando es un stored procedure
            tempcmd.CommandType = CommandType.StoredProcedure;

            //regresamos el sqlcommand
            return tempcmd;
        }

        /// <summary>
        /// Metodo para ejecutar un stored proccedure con varios parametros
        /// </summary>
        /// <param name="pNombreProcedimiento">El nombre del stored proccedure</param>
        /// <param name="pNombreParam">Lista de los nombres de los parametros a introducir</param>
        /// <param name="pValorParam">Lista de los valores de los parametros</param>
        /// <param name="pSqlDbType">Lista de los tipos de dato de cada parametro</param>
        /// <param name="pCn">La conexion de la base de datos</param>
        /// <returns>El comando definido</returns>
        public static SqlCommand DefinirConsultaNPar(string pNombreProcedimiento, List<string> pNombreParam, List<string> pValorParam, List<SqlDbType> pSqlDbType, SqlConnection pCn)
        {
            //comando~query
            //definimos la consulta como un stored procedure
            SqlCommand tempcmdSPar = DefinirConsulta(pNombreProcedimiento, pCn);

            //realizamos el añadido las veces que sean necesarias
            for (int n = 0; n < pNombreParam.Count; n++)
            {
                //añadimos parametros al stored procedure
                tempcmdSPar.Parameters.AddWithValue(pNombreParam.ElementAt(n), pSqlDbType.ElementAt(n)).Value = pValorParam.ElementAt(n);
            }
            //regresamos el sqlcommand
            return tempcmdSPar;
        }

        #endregion
        #region botones

        /// <summary>
        /// Evento que se realizar al presionar el boton ventas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 07 de Marzo 2021
        /// Creador Isaac Librado
        private void btnVentas_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelAdminSubMenu);
        }

        /// <summary>
        /// Evento que se realizar al presionar el boton abrir cajas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 07 de Marzo 2021
        /// Creador Isaac Librado
        private void btnSMBecarios_Click(object sender, EventArgs e)
        {
            //Ocultamos el submenu y mostramos la pantalla con su respectivo titulo
            ocultarSubMenu();
            AsignarTitulo("ABC Becarios");
        }

        /// <summary>
        /// Metodo para el boton salir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 23/03/21
        /// Creador Isaac Librado
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Metodo para mostrar el submenu de prestamos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 08/05/21
        /// Creador Isaac Librado
        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelPrestamosSubMenu);
        }

        /// <summary>
        /// Metodo para mostrar el submenu de becas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 08/05/21
        /// Creador Isaac Librado
        private void btnHorasBeca_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelBecaSubMenu);
        }


        #endregion

        /// <summary>
        /// Evento que se realizar al presionar el boton solicitantes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 07 de Marzo 2021
        /// Creador Isaac Librado
        private void btnSMSolicitantes_Click(object sender, EventArgs e)
        {
            //Ocultamos el submenu y mostramos la pantalla con su respectivo titulo
            ocultarSubMenu();
            AsignarTitulo("ABC Solicitantes");
        }

        /// <summary>
        /// Evento que se realizar al presionar el boton tipos de solicitantes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 07 de Marzo 2021
        /// Creador Isaac Librado
        private void btnSMTiposSolicitante_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AsignarTitulo("ABC Tipos de Solicitantes");
        }

        /// <summary>
        /// Evento que se realizar al presionar el boton tipos de estados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 07 de Marzo 2021
        /// Creador Isaac Librado
        private void btnSMEstados_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AsignarTitulo("ABC Estados");
            abrirPantallas(new ABCEstados());
        }

        /// <summary>
        /// Evento que se realizar al presionar el boton  marcas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 07 de Marzo 2021
        /// Creador Isaac Librado
        private void btnSMMarcas_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AsignarTitulo("ABC Marcas");
        }

        /// <summary>
        /// Evento que se realizar al presionar el boton materiales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 07 de Marzo 2021
        /// Creador Isaac Librado
        private void btnSMMateriales_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AsignarTitulo("ABC Materiales");
            abrirPantallas(new ABCMateriales());
        }

        /// <summary>
        /// Evento que se realizar al presionar el boton usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 07 de Marzo 2021
        /// Creador Isaac Librado
        private void btnSMUsuarios_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AsignarTitulo("ABC Usuarios");
            abrirPantallas(new ABCUsuarios());
        }

        /// <summary>
        /// Evento que se realizar al presionar el boton tipos de usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 07 de Marzo 2021
        /// Creador Isaac Librado
        private void btnSMTiposUsuario_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AsignarTitulo("ABC Tipos Usuarios");
            abrirPantallas(new ABCTiposUsuario());
        }

        /// <summary>
        /// Evento que se realizar al presionar el boton COnsulta materiales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 07 de Marzo 2021
        /// Creador Isaac Librado
        private void btnSMConsMat_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AsignarTitulo("Consultar Materiales");
            abrirPantallas(new ConsultarMateriales());
        }

        /// <summary>
        /// Evento que se realizar al presionar el boton Consulta prestamos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 07 de Marzo 2021
        /// Creador Isaac Librado
        private void btnSMConsPres_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AsignarTitulo("Consultar Prestamos");
        }

        /// <summary>
        /// Evento que se realizar al presionar el boton realizar prestamo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 07 de Marzo 2021
        /// Creador Isaac Librado
        private void btnSMPrestar_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AsignarTitulo("Realizar Prestamo");
            abrirPantallas(new RealizarPrestamo());
        }

        /// <summary>
        /// Evento que se realizar al presionar el boton devolver prestamo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 07 de Marzo 2021
        /// Creador Isaac Librado
        private void btnSMDevolver_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AsignarTitulo("Devolver Prestamo");
        }

        /// <summary>
        /// Evento que se realizar al presionar el boton registrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 07 de Marzo 2021
        /// Creador Isaac Librado
        private void btnSMRegistros_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AsignarTitulo("Registro de horas");
        }

        /// <summary>
        /// Evento que se realizar al presionar el boton consultar registros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 07 de Marzo 2021
        /// Creador Isaac Librado
        private void btnSMConsReg_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AsignarTitulo("Consulta de registros");
        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conectado)
            {
                cn.Close();
            }
        }
    }
}
