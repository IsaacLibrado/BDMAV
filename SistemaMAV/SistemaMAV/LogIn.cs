using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace SistemaMAV
{
    /// <summary>
    /// Clase que define a la pantalla de LogIn
    /// </summary>
    public partial class LogIn : Form
    {
        //Objetos de conexion y respuesta a consulta
        SqlConnection cn;
        SqlDataReader respuesta;

        public LogIn()
        {
            InitializeComponent();

            //indicamos el diseño inicial
            DisenioInicial();
        }

        /// <summary>
        /// Constructor de la clase para obtener la conexion
        /// </summary>
        /// <param name="pCN">La instancia de la conexion al servidor</param>
        public LogIn(SqlConnection pCN)
        {
            InitializeComponent();

            //indicamos el diseño inicial
            DisenioInicial();

            //obtenemos la conexion
            cn = pCN;
        }

        /// <summary>
        /// Metodo para poner el diesño inicial al form
        /// </summary>
        /// Version 1.0
        /// Fecha de creacion 20/03/21
        /// Creador Isaac Librado
        private void DisenioInicial()
        {
            txbContra.PasswordChar = '*';
            txbContra.MaxLength = 25;
            txbUsuario.MaxLength = 8;
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
            Entrar();
        }


        /// <summary>
        /// Metodo para validar cuando se presione enter en el campo de contrasenia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 25/03/21
        /// Creador Isaac Librado
        private void txbContra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Entrar();
            }
        }

        /// <summary>
        /// Metodo para validar la entrada al sistema despues del login
        /// </summary>
        /// Version 1.0
        /// Fecha de creacion 25/03/21
        /// Creador Isaac Librado
        private void Entrar()
        {
            bool validado = false;
            //Variables para obtener los datos de login
            string user = txbUsuario.Text;
            string password = Encriptacion.Encriptar(txbContra.Text);

            //si la casilla de user está vacía no se hace la consulta
            if (user != string.Empty)
            {

                //Ejemplo para realizar consulta de varios parametros

                //List<string> parametros = new List<string>();
                //parametros.Add("@pMatricula");
                //parametros.Add("@pID_Tipo_Usuario");

                //List<string> valores = new List<string>();
                //valores.Add("20060067");
                //valores.Add("2");

                //List<SqlDbType> tipos = new List<SqlDbType>();
                //tipos.Add(SqlDbType.Int);
                //tipos.Add(SqlDbType.TinyInt);

                //SqlCommand consulta = MenuPrincipal.DefinirConsultaNPar("sp_Prueba", parametros, valores, tipos, cn);
                //respuesta = consulta.ExecuteReader();
                //respuesta.Read();

                //MenuPrincipal.MostrarMensaje(respuesta["Nombre"].ToString());

                //creamos la consulta a la base de datos
                SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Login", "@pMatricula", user, SqlDbType.Int, cn);
                respuesta = consulta.ExecuteReader();

                //si la respuesta tiene registros se hace la validación
                if (respuesta.HasRows)
                {
                    //leemos el registro
                    respuesta.Read();

                    //si la contrasenia en la base de datos corresponde a la introducida se da paso al menu 
                    if (password == respuesta["Contrasenia"].ToString())
                    {
                        validado = true;
                        MenuPrincipal.ValidarLogIn(respuesta["Nombre"].ToString(), respuesta["Tipo_Usuario"].ToString());
                        MenuPrincipal.abrirPantallas(new Inicio());
                    }
                }

                if (!validado)
                {
                    //cerramos el dataread y mostramos mensajes de error si no es valido el login
                    MessageBox.Show("Usuario o contraseña incorrecta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            else
            {
                MessageBox.Show("Ingresa un usuario válido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            respuesta.Close();
        }

        

        /// <summary>
        /// Cambia al passwordbox después de dar enter en el textbox del usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 23/04/21
        /// Creador Isaac Librado
        private void txbUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbContra.Focus();
            }
        }

        /// <summary>
        /// Metodo para colocar al usuario directamente en el textbox del usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Version 1.0
        /// Fecha de creacion 23/04/21
        /// Creador Isaac Librado
        private void LogIn_Load(object sender, EventArgs e)
        {
            txbUsuario.Focus();
        }

        private void txbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        
    }
    public static class Encriptacion
    {
        /// <summary>
        /// Metodo para encriptar un valor
        /// </summary>
        /// <param name="pCadenaAencriptar">la cadena a encriptar</param>
        /// <returns>la cadena encriptada</returns>
        public static string Encriptar(this string pCadenaAencriptar)
        {
            string result = string.Empty;
            
            //obtenemos cada byte de la cadena
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(pCadenaAencriptar);
            
            //lo encriptamos en base 64
            result = Convert.ToBase64String(encryted);
            return result;
        }

       
        /// <summary>
        /// Desencripta una cadena
        /// </summary>
        /// <param name="pCadenaAdesencriptar">La cadena a desencriptar</param>
        /// <returns>la cadena desencriptada</returns>
        public static string DesEncriptar(this string pCadenaAdesencriptar)
        {
            string result = string.Empty;

            //obtenemos cada byte de la cadena desencriptada
            byte[] decryted = Convert.FromBase64String(pCadenaAdesencriptar);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        
    }
}
