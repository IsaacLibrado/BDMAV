﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaMAV
{
    public partial class ConsultarEstados : Form
    {
        DataTable dt;
        public ConsultarEstados()
        {
            InitializeComponent();
        }

        private void ConsultarUsuarios_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        //Metodo para cargar la tabla del data grid
        private void CargarTabla()
        {
            //hacemos la consulta por nombre vacio
            SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Estado_PorNombre_Reduc", "@pEstado", "", SqlDbType.VarChar, MenuPrincipal.cn);
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
        /// Metodo para regresar a la pantalla de ABC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            MenuPrincipal.AsignarTitulo("ABC Estado");
            MenuPrincipal.abrirPantallas(new ABCEstados());
        }

        //Metodo para consultar en tiempo real la tabla
        private void ConsultarTabla(object sender, EventArgs e)
        {
            if (MenuPrincipal.ValidarPalabrasProhibidas(txbNombre.Text))
            {
                //hacemos la consulta por nombre vacio
                SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Estado_PorNombre_Reduc", "@pEstado", txbNombre.Text, SqlDbType.VarChar, MenuPrincipal.cn);
                SqlDataReader respuesta = consulta.ExecuteReader();
                dt = new DataTable();

                //cargamos la data table
                dt.Load(respuesta);

                //colocamos el datatable en el datagrid 
                dgVistaTabla.DataSource = dt;

                //cerramos el reader
                respuesta.Close();
            }
            else
            {
                MessageBox.Show("Valores incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbNombre.Text = "";
            }
        }
    }
}
