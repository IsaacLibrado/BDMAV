﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaMAV
{
    public partial class ConsultarMateriales : Form
    {
        DataTable dt;

        public ConsultarMateriales()
        {
            InitializeComponent();

            string cargo = MenuPrincipal.cargoActual;

            if (cargo != "Administrador" && cargo != "Jefe")
            {
                btnRegresar.Visible = false;
            }
        }

        private void ConsultarMateriales_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        //Metodo para cargar la tabla del data grid
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

            if (MenuPrincipal.cargoActual == "Visitante" || MenuPrincipal.cargoActual == "Solicitante")
            {
                dgVistaTabla.Columns[0].Visible = false;
                dgVistaTabla.Columns[2].Visible = false;
                dgVistaTabla.Columns[4].Visible = false;
                dgVistaTabla.Columns[5].Visible = false;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            MenuPrincipal.AsignarTitulo("ABC Materiales");
            MenuPrincipal.abrirPantallas(new ABCMateriales());
        }

        //Metodo para consultar en tiempo real la tabla
        private void ConsultarTabla(object sender, EventArgs e)
        {
            if (MenuPrincipal.ValidarPalabrasProhibidas(txbNombre.Text))
            {
                //hacemos la consulta por nombre 
                SqlCommand consulta = MenuPrincipal.DefinirConsultaSPar("sp_Buscar_Material_Por_Nombre", "@pNombre", txbNombre.Text, SqlDbType.VarChar, MenuPrincipal.cn);
                SqlDataReader respuesta = consulta.ExecuteReader();
                dt = new DataTable();

                //cargamos la data table
                dt.Load(respuesta);

                //colocamos el datatable en el datagrid 
                dgVistaTabla.DataSource = dt;

                //cerramos el reader
                respuesta.Close();

                if (MenuPrincipal.cargoActual == "Visitante" || MenuPrincipal.cargoActual == "Solicitante")
                {
                    dgVistaTabla.Columns[0].Visible = false;
                    dgVistaTabla.Columns[2].Visible = false;
                    dgVistaTabla.Columns[4].Visible = false;
                    dgVistaTabla.Columns[5].Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Valores incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbNombre.Text = "";
            }
        }
    }
}
