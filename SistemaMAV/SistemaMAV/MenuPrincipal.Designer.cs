
namespace SistemaMAV
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.panelUsuario = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblIp = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pbPerfil = new System.Windows.Forms.PictureBox();
            this.panelSubMenus = new System.Windows.Forms.Panel();
            this.panelBecaSubMenu = new System.Windows.Forms.Panel();
            this.btnSMConsReg = new System.Windows.Forms.Button();
            this.btnSMRegistros = new System.Windows.Forms.Button();
            this.btnHorasBeca = new System.Windows.Forms.Button();
            this.panelPrestamosSubMenu = new System.Windows.Forms.Panel();
            this.btnSMDevolver = new System.Windows.Forms.Button();
            this.btnSMPrestar = new System.Windows.Forms.Button();
            this.btnSMConsPres = new System.Windows.Forms.Button();
            this.btnSMConsMat = new System.Windows.Forms.Button();
            this.btnPrestamos = new System.Windows.Forms.Button();
            this.panelAdminSubMenu = new System.Windows.Forms.Panel();
            this.btnSMTiposUsuario = new System.Windows.Forms.Button();
            this.btnSMUsuarios = new System.Windows.Forms.Button();
            this.btnSMMateriales = new System.Windows.Forms.Button();
            this.btnSMMarcas = new System.Windows.Forms.Button();
            this.btnSMEstados = new System.Windows.Forms.Button();
            this.btnSMTiposSolicitante = new System.Windows.Forms.Button();
            this.btnSMSolicitantes = new System.Windows.Forms.Button();
            this.btnSMBecarios = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.panelBase = new System.Windows.Forms.Panel();
            this.lblMensajes = new System.Windows.Forms.Label();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.btnConectar = new System.Windows.Forms.Button();
            this.txbServer = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.horaFecha = new System.Windows.Forms.Timer(this.components);
            this.panelDatos = new System.Windows.Forms.Panel();
            this.pbLogoTemp = new System.Windows.Forms.PictureBox();
            this.panelFecha = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.panelSideMenu.SuspendLayout();
            this.panelUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).BeginInit();
            this.panelSubMenus.SuspendLayout();
            this.panelBecaSubMenu.SuspendLayout();
            this.panelPrestamosSubMenu.SuspendLayout();
            this.panelAdminSubMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.panelBase.SuspendLayout();
            this.panelTitulo.SuspendLayout();
            this.panelContenedor.SuspendLayout();
            this.panelDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoTemp)).BeginInit();
            this.panelFecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.Black;
            this.panelSideMenu.Controls.Add(this.panelUsuario);
            this.panelSideMenu.Controls.Add(this.panelSubMenus);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(242, 588);
            this.panelSideMenu.TabIndex = 0;
            // 
            // panelUsuario
            // 
            this.panelUsuario.BackColor = System.Drawing.Color.Black;
            this.panelUsuario.Controls.Add(this.btnSalir);
            this.panelUsuario.Controls.Add(this.lblIp);
            this.panelUsuario.Controls.Add(this.lblCargo);
            this.panelUsuario.Controls.Add(this.lblUserName);
            this.panelUsuario.Controls.Add(this.pbPerfil);
            this.panelUsuario.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUsuario.Location = new System.Drawing.Point(0, 490);
            this.panelUsuario.Name = "panelUsuario";
            this.panelUsuario.Size = new System.Drawing.Size(242, 98);
            this.panelUsuario.TabIndex = 4;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Black;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(169, 62);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSalir.Size = new System.Drawing.Size(58, 29);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblIp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblIp.Location = new System.Drawing.Point(0, 81);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(83, 17);
            this.lblIp.TabIndex = 3;
            this.lblIp.Text = "Dirección IP";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.ForeColor = System.Drawing.Color.White;
            this.lblCargo.Location = new System.Drawing.Point(69, 54);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(46, 17);
            this.lblCargo.TabIndex = 2;
            this.lblCargo.Text = "Cargo";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(70, 18);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(75, 17);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "UserName";
            // 
            // pbPerfil
            // 
            this.pbPerfil.Image = global::SistemaMAV.Properties.Resources._149071;
            this.pbPerfil.Location = new System.Drawing.Point(4, 18);
            this.pbPerfil.Name = "pbPerfil";
            this.pbPerfil.Size = new System.Drawing.Size(59, 53);
            this.pbPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPerfil.TabIndex = 0;
            this.pbPerfil.TabStop = false;
            // 
            // panelSubMenus
            // 
            this.panelSubMenus.AutoScroll = true;
            this.panelSubMenus.BackColor = System.Drawing.Color.Black;
            this.panelSubMenus.Controls.Add(this.panelBecaSubMenu);
            this.panelSubMenus.Controls.Add(this.btnHorasBeca);
            this.panelSubMenus.Controls.Add(this.panelPrestamosSubMenu);
            this.panelSubMenus.Controls.Add(this.btnPrestamos);
            this.panelSubMenus.Controls.Add(this.panelAdminSubMenu);
            this.panelSubMenus.Controls.Add(this.btnAdmin);
            this.panelSubMenus.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenus.Location = new System.Drawing.Point(0, 100);
            this.panelSubMenus.Name = "panelSubMenus";
            this.panelSubMenus.Size = new System.Drawing.Size(242, 384);
            this.panelSubMenus.TabIndex = 3;
            // 
            // panelBecaSubMenu
            // 
            this.panelBecaSubMenu.BackColor = System.Drawing.Color.Black;
            this.panelBecaSubMenu.Controls.Add(this.btnSMConsReg);
            this.panelBecaSubMenu.Controls.Add(this.btnSMRegistros);
            this.panelBecaSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBecaSubMenu.Location = new System.Drawing.Point(0, 524);
            this.panelBecaSubMenu.Name = "panelBecaSubMenu";
            this.panelBecaSubMenu.Size = new System.Drawing.Size(225, 66);
            this.panelBecaSubMenu.TabIndex = 10;
            // 
            // btnSMConsReg
            // 
            this.btnSMConsReg.BackColor = System.Drawing.Color.White;
            this.btnSMConsReg.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSMConsReg.FlatAppearance.BorderSize = 0;
            this.btnSMConsReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSMConsReg.ForeColor = System.Drawing.Color.Black;
            this.btnSMConsReg.Location = new System.Drawing.Point(0, 32);
            this.btnSMConsReg.Name = "btnSMConsReg";
            this.btnSMConsReg.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSMConsReg.Size = new System.Drawing.Size(225, 32);
            this.btnSMConsReg.TabIndex = 2;
            this.btnSMConsReg.Text = "Consultar Registros";
            this.btnSMConsReg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSMConsReg.UseVisualStyleBackColor = false;
            this.btnSMConsReg.Click += new System.EventHandler(this.btnSMConsReg_Click);
            // 
            // btnSMRegistros
            // 
            this.btnSMRegistros.BackColor = System.Drawing.Color.White;
            this.btnSMRegistros.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSMRegistros.FlatAppearance.BorderSize = 0;
            this.btnSMRegistros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSMRegistros.ForeColor = System.Drawing.Color.Black;
            this.btnSMRegistros.Location = new System.Drawing.Point(0, 0);
            this.btnSMRegistros.Name = "btnSMRegistros";
            this.btnSMRegistros.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSMRegistros.Size = new System.Drawing.Size(225, 32);
            this.btnSMRegistros.TabIndex = 1;
            this.btnSMRegistros.Text = "Registrar";
            this.btnSMRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSMRegistros.UseVisualStyleBackColor = false;
            this.btnSMRegistros.Click += new System.EventHandler(this.btnSMRegistros_Click);
            // 
            // btnHorasBeca
            // 
            this.btnHorasBeca.BackColor = System.Drawing.Color.Black;
            this.btnHorasBeca.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHorasBeca.FlatAppearance.BorderSize = 0;
            this.btnHorasBeca.ForeColor = System.Drawing.Color.White;
            this.btnHorasBeca.Location = new System.Drawing.Point(0, 479);
            this.btnHorasBeca.Name = "btnHorasBeca";
            this.btnHorasBeca.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHorasBeca.Size = new System.Drawing.Size(225, 45);
            this.btnHorasBeca.TabIndex = 9;
            this.btnHorasBeca.Text = "Horas Beca";
            this.btnHorasBeca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHorasBeca.UseVisualStyleBackColor = false;
            this.btnHorasBeca.Click += new System.EventHandler(this.btnHorasBeca_Click);
            // 
            // panelPrestamosSubMenu
            // 
            this.panelPrestamosSubMenu.BackColor = System.Drawing.Color.Black;
            this.panelPrestamosSubMenu.Controls.Add(this.btnSMDevolver);
            this.panelPrestamosSubMenu.Controls.Add(this.btnSMPrestar);
            this.panelPrestamosSubMenu.Controls.Add(this.btnSMConsPres);
            this.panelPrestamosSubMenu.Controls.Add(this.btnSMConsMat);
            this.panelPrestamosSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPrestamosSubMenu.Location = new System.Drawing.Point(0, 343);
            this.panelPrestamosSubMenu.Name = "panelPrestamosSubMenu";
            this.panelPrestamosSubMenu.Size = new System.Drawing.Size(225, 136);
            this.panelPrestamosSubMenu.TabIndex = 8;
            // 
            // btnSMDevolver
            // 
            this.btnSMDevolver.BackColor = System.Drawing.Color.White;
            this.btnSMDevolver.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSMDevolver.FlatAppearance.BorderSize = 0;
            this.btnSMDevolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSMDevolver.ForeColor = System.Drawing.Color.Black;
            this.btnSMDevolver.Location = new System.Drawing.Point(0, 96);
            this.btnSMDevolver.Name = "btnSMDevolver";
            this.btnSMDevolver.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSMDevolver.Size = new System.Drawing.Size(225, 32);
            this.btnSMDevolver.TabIndex = 3;
            this.btnSMDevolver.Text = "Devolver Prestamo";
            this.btnSMDevolver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSMDevolver.UseVisualStyleBackColor = false;
            this.btnSMDevolver.Click += new System.EventHandler(this.btnSMDevolver_Click);
            // 
            // btnSMPrestar
            // 
            this.btnSMPrestar.BackColor = System.Drawing.Color.White;
            this.btnSMPrestar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSMPrestar.FlatAppearance.BorderSize = 0;
            this.btnSMPrestar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSMPrestar.ForeColor = System.Drawing.Color.Black;
            this.btnSMPrestar.Location = new System.Drawing.Point(0, 64);
            this.btnSMPrestar.Name = "btnSMPrestar";
            this.btnSMPrestar.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSMPrestar.Size = new System.Drawing.Size(225, 32);
            this.btnSMPrestar.TabIndex = 2;
            this.btnSMPrestar.Text = "Realizar Prestamo";
            this.btnSMPrestar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSMPrestar.UseVisualStyleBackColor = false;
            this.btnSMPrestar.Click += new System.EventHandler(this.btnSMPrestar_Click);
            // 
            // btnSMConsPres
            // 
            this.btnSMConsPres.BackColor = System.Drawing.Color.White;
            this.btnSMConsPres.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSMConsPres.FlatAppearance.BorderSize = 0;
            this.btnSMConsPres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSMConsPres.ForeColor = System.Drawing.Color.Black;
            this.btnSMConsPres.Location = new System.Drawing.Point(0, 32);
            this.btnSMConsPres.Name = "btnSMConsPres";
            this.btnSMConsPres.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSMConsPres.Size = new System.Drawing.Size(225, 32);
            this.btnSMConsPres.TabIndex = 1;
            this.btnSMConsPres.Text = "Consultar Prestamos";
            this.btnSMConsPres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSMConsPres.UseVisualStyleBackColor = false;
            this.btnSMConsPres.Click += new System.EventHandler(this.btnSMConsPres_Click);
            // 
            // btnSMConsMat
            // 
            this.btnSMConsMat.BackColor = System.Drawing.Color.White;
            this.btnSMConsMat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSMConsMat.FlatAppearance.BorderSize = 0;
            this.btnSMConsMat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSMConsMat.ForeColor = System.Drawing.Color.Black;
            this.btnSMConsMat.Location = new System.Drawing.Point(0, 0);
            this.btnSMConsMat.Name = "btnSMConsMat";
            this.btnSMConsMat.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSMConsMat.Size = new System.Drawing.Size(225, 32);
            this.btnSMConsMat.TabIndex = 0;
            this.btnSMConsMat.Text = "Consultar Materiales";
            this.btnSMConsMat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSMConsMat.UseVisualStyleBackColor = false;
            this.btnSMConsMat.Click += new System.EventHandler(this.btnSMConsMat_Click);
            // 
            // btnPrestamos
            // 
            this.btnPrestamos.BackColor = System.Drawing.Color.Black;
            this.btnPrestamos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPrestamos.FlatAppearance.BorderSize = 0;
            this.btnPrestamos.ForeColor = System.Drawing.Color.White;
            this.btnPrestamos.Location = new System.Drawing.Point(0, 298);
            this.btnPrestamos.Name = "btnPrestamos";
            this.btnPrestamos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnPrestamos.Size = new System.Drawing.Size(225, 45);
            this.btnPrestamos.TabIndex = 7;
            this.btnPrestamos.Text = "Prestamos";
            this.btnPrestamos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrestamos.UseVisualStyleBackColor = false;
            this.btnPrestamos.Click += new System.EventHandler(this.btnPrestamos_Click);
            // 
            // panelAdminSubMenu
            // 
            this.panelAdminSubMenu.BackColor = System.Drawing.Color.Black;
            this.panelAdminSubMenu.Controls.Add(this.btnSMTiposUsuario);
            this.panelAdminSubMenu.Controls.Add(this.btnSMUsuarios);
            this.panelAdminSubMenu.Controls.Add(this.btnSMMateriales);
            this.panelAdminSubMenu.Controls.Add(this.btnSMMarcas);
            this.panelAdminSubMenu.Controls.Add(this.btnSMEstados);
            this.panelAdminSubMenu.Controls.Add(this.btnSMTiposSolicitante);
            this.panelAdminSubMenu.Controls.Add(this.btnSMSolicitantes);
            this.panelAdminSubMenu.Controls.Add(this.btnSMBecarios);
            this.panelAdminSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAdminSubMenu.Location = new System.Drawing.Point(0, 45);
            this.panelAdminSubMenu.Name = "panelAdminSubMenu";
            this.panelAdminSubMenu.Size = new System.Drawing.Size(225, 253);
            this.panelAdminSubMenu.TabIndex = 2;
            // 
            // btnSMTiposUsuario
            // 
            this.btnSMTiposUsuario.BackColor = System.Drawing.Color.White;
            this.btnSMTiposUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSMTiposUsuario.FlatAppearance.BorderSize = 0;
            this.btnSMTiposUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSMTiposUsuario.ForeColor = System.Drawing.Color.Black;
            this.btnSMTiposUsuario.Location = new System.Drawing.Point(0, 224);
            this.btnSMTiposUsuario.Name = "btnSMTiposUsuario";
            this.btnSMTiposUsuario.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSMTiposUsuario.Size = new System.Drawing.Size(225, 32);
            this.btnSMTiposUsuario.TabIndex = 7;
            this.btnSMTiposUsuario.Text = "Tipos de Usuarios";
            this.btnSMTiposUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSMTiposUsuario.UseVisualStyleBackColor = false;
            this.btnSMTiposUsuario.Click += new System.EventHandler(this.btnSMTiposUsuario_Click);
            // 
            // btnSMUsuarios
            // 
            this.btnSMUsuarios.BackColor = System.Drawing.Color.White;
            this.btnSMUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSMUsuarios.FlatAppearance.BorderSize = 0;
            this.btnSMUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSMUsuarios.ForeColor = System.Drawing.Color.Black;
            this.btnSMUsuarios.Location = new System.Drawing.Point(0, 192);
            this.btnSMUsuarios.Name = "btnSMUsuarios";
            this.btnSMUsuarios.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSMUsuarios.Size = new System.Drawing.Size(225, 32);
            this.btnSMUsuarios.TabIndex = 6;
            this.btnSMUsuarios.Text = "Usuarios";
            this.btnSMUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSMUsuarios.UseVisualStyleBackColor = false;
            this.btnSMUsuarios.Click += new System.EventHandler(this.btnSMUsuarios_Click);
            // 
            // btnSMMateriales
            // 
            this.btnSMMateriales.BackColor = System.Drawing.Color.White;
            this.btnSMMateriales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSMMateriales.FlatAppearance.BorderSize = 0;
            this.btnSMMateriales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSMMateriales.ForeColor = System.Drawing.Color.Black;
            this.btnSMMateriales.Location = new System.Drawing.Point(0, 160);
            this.btnSMMateriales.Name = "btnSMMateriales";
            this.btnSMMateriales.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSMMateriales.Size = new System.Drawing.Size(225, 32);
            this.btnSMMateriales.TabIndex = 5;
            this.btnSMMateriales.Text = "Materiales";
            this.btnSMMateriales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSMMateriales.UseVisualStyleBackColor = false;
            this.btnSMMateriales.Click += new System.EventHandler(this.btnSMMateriales_Click);
            // 
            // btnSMMarcas
            // 
            this.btnSMMarcas.BackColor = System.Drawing.Color.White;
            this.btnSMMarcas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSMMarcas.FlatAppearance.BorderSize = 0;
            this.btnSMMarcas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSMMarcas.ForeColor = System.Drawing.Color.Black;
            this.btnSMMarcas.Location = new System.Drawing.Point(0, 128);
            this.btnSMMarcas.Name = "btnSMMarcas";
            this.btnSMMarcas.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSMMarcas.Size = new System.Drawing.Size(225, 32);
            this.btnSMMarcas.TabIndex = 4;
            this.btnSMMarcas.Text = "Marcas";
            this.btnSMMarcas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSMMarcas.UseVisualStyleBackColor = false;
            this.btnSMMarcas.Click += new System.EventHandler(this.btnSMMarcas_Click);
            // 
            // btnSMEstados
            // 
            this.btnSMEstados.BackColor = System.Drawing.Color.White;
            this.btnSMEstados.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSMEstados.FlatAppearance.BorderSize = 0;
            this.btnSMEstados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSMEstados.ForeColor = System.Drawing.Color.Black;
            this.btnSMEstados.Location = new System.Drawing.Point(0, 96);
            this.btnSMEstados.Name = "btnSMEstados";
            this.btnSMEstados.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSMEstados.Size = new System.Drawing.Size(225, 32);
            this.btnSMEstados.TabIndex = 3;
            this.btnSMEstados.Text = "Estados";
            this.btnSMEstados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSMEstados.UseVisualStyleBackColor = false;
            this.btnSMEstados.Click += new System.EventHandler(this.btnSMEstados_Click);
            // 
            // btnSMTiposSolicitante
            // 
            this.btnSMTiposSolicitante.BackColor = System.Drawing.Color.White;
            this.btnSMTiposSolicitante.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSMTiposSolicitante.FlatAppearance.BorderSize = 0;
            this.btnSMTiposSolicitante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSMTiposSolicitante.ForeColor = System.Drawing.Color.Black;
            this.btnSMTiposSolicitante.Location = new System.Drawing.Point(0, 64);
            this.btnSMTiposSolicitante.Name = "btnSMTiposSolicitante";
            this.btnSMTiposSolicitante.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSMTiposSolicitante.Size = new System.Drawing.Size(225, 32);
            this.btnSMTiposSolicitante.TabIndex = 2;
            this.btnSMTiposSolicitante.Text = "Tipos de Solicitantes";
            this.btnSMTiposSolicitante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSMTiposSolicitante.UseVisualStyleBackColor = false;
            this.btnSMTiposSolicitante.Click += new System.EventHandler(this.btnSMTiposSolicitante_Click);
            // 
            // btnSMSolicitantes
            // 
            this.btnSMSolicitantes.BackColor = System.Drawing.Color.White;
            this.btnSMSolicitantes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSMSolicitantes.FlatAppearance.BorderSize = 0;
            this.btnSMSolicitantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSMSolicitantes.ForeColor = System.Drawing.Color.Black;
            this.btnSMSolicitantes.Location = new System.Drawing.Point(0, 32);
            this.btnSMSolicitantes.Name = "btnSMSolicitantes";
            this.btnSMSolicitantes.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSMSolicitantes.Size = new System.Drawing.Size(225, 32);
            this.btnSMSolicitantes.TabIndex = 1;
            this.btnSMSolicitantes.Text = "Solicitantes";
            this.btnSMSolicitantes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSMSolicitantes.UseVisualStyleBackColor = false;
            this.btnSMSolicitantes.Click += new System.EventHandler(this.btnSMSolicitantes_Click);
            // 
            // btnSMBecarios
            // 
            this.btnSMBecarios.BackColor = System.Drawing.Color.White;
            this.btnSMBecarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSMBecarios.FlatAppearance.BorderSize = 0;
            this.btnSMBecarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSMBecarios.ForeColor = System.Drawing.Color.Black;
            this.btnSMBecarios.Location = new System.Drawing.Point(0, 0);
            this.btnSMBecarios.Name = "btnSMBecarios";
            this.btnSMBecarios.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSMBecarios.Size = new System.Drawing.Size(225, 32);
            this.btnSMBecarios.TabIndex = 0;
            this.btnSMBecarios.Text = "Becarios";
            this.btnSMBecarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSMBecarios.UseVisualStyleBackColor = false;
            this.btnSMBecarios.Click += new System.EventHandler(this.btnSMBecarios_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.Black;
            this.btnAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(177)))), ((int)(((byte)(0)))));
            this.btnAdmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(177)))), ((int)(((byte)(0)))));
            this.btnAdmin.ForeColor = System.Drawing.Color.White;
            this.btnAdmin.Location = new System.Drawing.Point(0, 0);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAdmin.Size = new System.Drawing.Size(225, 45);
            this.btnAdmin.TabIndex = 1;
            this.btnAdmin.Text = "Administracion";
            this.btnAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(177)))), ((int)(((byte)(0)))));
            this.panelLogo.Controls.Add(this.pbLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(242, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Black;
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLogo.Image = global::SistemaMAV.Properties.Resources.LogoPNGAscendantProyects;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(242, 100);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // panelBase
            // 
            this.panelBase.BackColor = System.Drawing.Color.White;
            this.panelBase.Controls.Add(this.lblMensajes);
            this.panelBase.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBase.Location = new System.Drawing.Point(242, 558);
            this.panelBase.Name = "panelBase";
            this.panelBase.Size = new System.Drawing.Size(717, 30);
            this.panelBase.TabIndex = 2;
            // 
            // lblMensajes
            // 
            this.lblMensajes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajes.ForeColor = System.Drawing.Color.Red;
            this.lblMensajes.Location = new System.Drawing.Point(0, 0);
            this.lblMensajes.Name = "lblMensajes";
            this.lblMensajes.Size = new System.Drawing.Size(714, 27);
            this.lblMensajes.TabIndex = 1;
            this.lblMensajes.Text = "MSJ0";
            this.lblMensajes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.White;
            this.panelTitulo.Controls.Add(this.lblTitulo);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(242, 100);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(717, 26);
            this.panelTitulo.TabIndex = 3;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Blue;
            this.lblTitulo.Location = new System.Drawing.Point(29, 1);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(667, 27);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "PantallaActiva";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelContenedor.Controls.Add(this.btnConectar);
            this.panelContenedor.Controls.Add(this.txbServer);
            this.panelContenedor.Controls.Add(this.lblServer);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(242, 126);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(717, 432);
            this.panelContenedor.TabIndex = 4;
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.Color.Black;
            this.btnConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnConectar.Location = new System.Drawing.Point(427, 204);
            this.btnConectar.Margin = new System.Windows.Forms.Padding(4);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(147, 42);
            this.btnConectar.TabIndex = 6;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // txbServer
            // 
            this.txbServer.Location = new System.Drawing.Point(405, 140);
            this.txbServer.Margin = new System.Windows.Forms.Padding(4);
            this.txbServer.Name = "txbServer";
            this.txbServer.Size = new System.Drawing.Size(193, 23);
            this.txbServer.TabIndex = 5;
            this.txbServer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbServer_KeyDown);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblServer.Location = new System.Drawing.Point(306, 137);
            this.lblServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(70, 25);
            this.lblServer.TabIndex = 4;
            this.lblServer.Text = "Server";
            // 
            // horaFecha
            // 
            this.horaFecha.Enabled = true;
            this.horaFecha.Tick += new System.EventHandler(this.horaFecha_Tick);
            // 
            // panelDatos
            // 
            this.panelDatos.BackColor = System.Drawing.Color.Transparent;
            this.panelDatos.BackgroundImage = global::SistemaMAV.Properties.Resources.mavbanner;
            this.panelDatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelDatos.Controls.Add(this.pbLogoTemp);
            this.panelDatos.Controls.Add(this.panelFecha);
            this.panelDatos.Controls.Add(this.lblNombre);
            this.panelDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDatos.Location = new System.Drawing.Point(242, 0);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(717, 100);
            this.panelDatos.TabIndex = 1;
            // 
            // pbLogoTemp
            // 
            this.pbLogoTemp.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogoTemp.Image = global::SistemaMAV.Properties.Resources.LogoPNGAscendantProyects;
            this.pbLogoTemp.Location = new System.Drawing.Point(0, 0);
            this.pbLogoTemp.Name = "pbLogoTemp";
            this.pbLogoTemp.Size = new System.Drawing.Size(142, 100);
            this.pbLogoTemp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogoTemp.TabIndex = 2;
            this.pbLogoTemp.TabStop = false;
            // 
            // panelFecha
            // 
            this.panelFecha.Controls.Add(this.lblFecha);
            this.panelFecha.Controls.Add(this.lblHora);
            this.panelFecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelFecha.Location = new System.Drawing.Point(570, 0);
            this.panelFecha.Name = "panelFecha";
            this.panelFecha.Size = new System.Drawing.Size(147, 100);
            this.panelFecha.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFecha.Location = new System.Drawing.Point(0, 50);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(67, 25);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.SystemColors.Control;
            this.lblHora.Location = new System.Drawing.Point(0, 75);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(54, 25);
            this.lblHora.TabIndex = 0;
            this.lblHora.Text = "Hora";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblNombre.Location = new System.Drawing.Point(187, 50);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(307, 36);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Medios Audiovisuales";
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 588);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.panelBase);
            this.Controls.Add(this.panelDatos);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "MenuPrincipal";
            this.Text = "SIstema Administrador Zootopia";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelUsuario.ResumeLayout(false);
            this.panelUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).EndInit();
            this.panelSubMenus.ResumeLayout(false);
            this.panelBecaSubMenu.ResumeLayout(false);
            this.panelPrestamosSubMenu.ResumeLayout(false);
            this.panelAdminSubMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.panelBase.ResumeLayout(false);
            this.panelTitulo.ResumeLayout(false);
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.panelDatos.ResumeLayout(false);
            this.panelDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoTemp)).EndInit();
            this.panelFecha.ResumeLayout(false);
            this.panelFecha.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelAdminSubMenu;
        private System.Windows.Forms.Button btnSMEstados;
        private System.Windows.Forms.Button btnSMTiposSolicitante;
        private System.Windows.Forms.Button btnSMSolicitantes;
        private System.Windows.Forms.Button btnSMBecarios;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelDatos;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel panelBase;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel panelSubMenus;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMensajes;
        private System.Windows.Forms.Panel panelUsuario;
        private System.Windows.Forms.PictureBox pbPerfil;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Panel panelFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Timer horaFecha;
        private System.Windows.Forms.Panel panelPrestamosSubMenu;
        private System.Windows.Forms.Button btnSMConsMat;
        private System.Windows.Forms.Button btnPrestamos;
        private System.Windows.Forms.PictureBox pbLogoTemp;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.TextBox txbServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Button btnSMMarcas;
        private System.Windows.Forms.Button btnSMTiposUsuario;
        private System.Windows.Forms.Button btnSMUsuarios;
        private System.Windows.Forms.Button btnSMMateriales;
        private System.Windows.Forms.Button btnSMDevolver;
        private System.Windows.Forms.Button btnSMPrestar;
        private System.Windows.Forms.Button btnSMConsPres;
        private System.Windows.Forms.Button btnHorasBeca;
        private System.Windows.Forms.Panel panelBecaSubMenu;
        private System.Windows.Forms.Button btnSMRegistros;
        private System.Windows.Forms.Button btnSMConsReg;
    }
}

