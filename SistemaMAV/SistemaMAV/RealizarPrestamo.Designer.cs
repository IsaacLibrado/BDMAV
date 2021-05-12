namespace SistemaMAV
{
    partial class RealizarPrestamo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txbBusquedaSolicitante = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgVistaSolicitantes = new System.Windows.Forms.DataGridView();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.txbSolicitante = new System.Windows.Forms.TextBox();
            this.txbUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbUsuarioNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaSolicitantes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImage = global::SistemaMAV.Properties.Resources.Done1;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(166, 202);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(39, 35);
            this.btnGuardar.TabIndex = 50;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txbBusquedaSolicitante
            // 
            this.txbBusquedaSolicitante.Location = new System.Drawing.Point(302, 18);
            this.txbBusquedaSolicitante.Name = "txbBusquedaSolicitante";
            this.txbBusquedaSolicitante.Size = new System.Drawing.Size(100, 20);
            this.txbBusquedaSolicitante.TabIndex = 49;
            this.txbBusquedaSolicitante.TextChanged += new System.EventHandler(this.txbBusquedaSolicitante_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(17, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 46;
            this.label2.Text = "Solicitante";
            // 
            // dgVistaSolicitantes
            // 
            this.dgVistaSolicitantes.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgVistaSolicitantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVistaSolicitantes.Location = new System.Drawing.Point(218, 39);
            this.dgVistaSolicitantes.Name = "dgVistaSolicitantes";
            this.dgVistaSolicitantes.ReadOnly = true;
            this.dgVistaSolicitantes.Size = new System.Drawing.Size(283, 245);
            this.dgVistaSolicitantes.TabIndex = 45;
            this.dgVistaSolicitantes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVistaSolicitantes_CellClick);
            // 
            // txbNombre
            // 
            this.txbNombre.Enabled = false;
            this.txbNombre.Location = new System.Drawing.Point(106, 77);
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(100, 20);
            this.txbNombre.TabIndex = 55;
            // 
            // txbSolicitante
            // 
            this.txbSolicitante.Enabled = false;
            this.txbSolicitante.Location = new System.Drawing.Point(106, 39);
            this.txbSolicitante.Name = "txbSolicitante";
            this.txbSolicitante.Size = new System.Drawing.Size(100, 20);
            this.txbSolicitante.TabIndex = 58;
            // 
            // txbUsuario
            // 
            this.txbUsuario.Enabled = false;
            this.txbUsuario.Location = new System.Drawing.Point(106, 120);
            this.txbUsuario.Name = "txbUsuario";
            this.txbUsuario.Size = new System.Drawing.Size(100, 20);
            this.txbUsuario.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(17, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 60;
            this.label1.Text = "Becario";
            // 
            // txbUsuarioNombre
            // 
            this.txbUsuarioNombre.Enabled = false;
            this.txbUsuarioNombre.Location = new System.Drawing.Point(106, 165);
            this.txbUsuarioNombre.Name = "txbUsuarioNombre";
            this.txbUsuarioNombre.Size = new System.Drawing.Size(100, 20);
            this.txbUsuarioNombre.TabIndex = 61;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(239, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 62;
            this.label3.Text = "Nombre";
            // 
            // RealizarPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(521, 346);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbUsuarioNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbUsuario);
            this.Controls.Add(this.txbSolicitante);
            this.Controls.Add(this.txbNombre);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txbBusquedaSolicitante);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgVistaSolicitantes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RealizarPrestamo";
            this.Text = "RealizarPrestamo";
            this.Load += new System.EventHandler(this.RealizarPrestamo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaSolicitantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txbBusquedaSolicitante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgVistaSolicitantes;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.TextBox txbSolicitante;
        private System.Windows.Forms.TextBox txbUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbUsuarioNombre;
        private System.Windows.Forms.Label label3;
    }
}