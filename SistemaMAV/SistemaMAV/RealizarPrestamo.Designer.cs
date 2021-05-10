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
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgVistaSolicitantes = new System.Windows.Forms.DataGridView();
            this.dgVistaMaterial = new System.Windows.Forms.DataGridView();
            this.txbBusquedaMaterial = new System.Windows.Forms.TextBox();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.txbNombreMaterial = new System.Windows.Forms.TextBox();
            this.txbEtiqueta = new System.Windows.Forms.TextBox();
            this.txbSolicitante = new System.Windows.Forms.TextBox();
            this.txbMaterial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgVistaPrestamo = new System.Windows.Forms.DataGridView();
            this.txbId_Prestamo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBecario = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaSolicitantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaPrestamo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImage = global::SistemaMAV.Properties.Resources.Done1;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(226, 311);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(39, 35);
            this.btnGuardar.TabIndex = 50;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txbBusquedaSolicitante
            // 
            this.txbBusquedaSolicitante.Location = new System.Drawing.Point(409, 5);
            this.txbBusquedaSolicitante.Name = "txbBusquedaSolicitante";
            this.txbBusquedaSolicitante.Size = new System.Drawing.Size(100, 20);
            this.txbBusquedaSolicitante.TabIndex = 49;
            this.txbBusquedaSolicitante.TextChanged += new System.EventHandler(this.txbBusquedaSolicitante_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(25, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 47;
            this.label6.Text = "Material";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(25, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 46;
            this.label2.Text = "Solicitante";
            // 
            // dgVistaSolicitantes
            // 
            this.dgVistaSolicitantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVistaSolicitantes.Location = new System.Drawing.Point(226, 31);
            this.dgVistaSolicitantes.Name = "dgVistaSolicitantes";
            this.dgVistaSolicitantes.ReadOnly = true;
            this.dgVistaSolicitantes.Size = new System.Drawing.Size(283, 68);
            this.dgVistaSolicitantes.TabIndex = 45;
            this.dgVistaSolicitantes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVistaSolicitantes_CellClick);
            // 
            // dgVistaMaterial
            // 
            this.dgVistaMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVistaMaterial.Location = new System.Drawing.Point(226, 130);
            this.dgVistaMaterial.Name = "dgVistaMaterial";
            this.dgVistaMaterial.ReadOnly = true;
            this.dgVistaMaterial.Size = new System.Drawing.Size(283, 68);
            this.dgVistaMaterial.TabIndex = 53;
            this.dgVistaMaterial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVistaMaterial_CellContentClick);
            // 
            // txbBusquedaMaterial
            // 
            this.txbBusquedaMaterial.Location = new System.Drawing.Point(409, 104);
            this.txbBusquedaMaterial.Name = "txbBusquedaMaterial";
            this.txbBusquedaMaterial.Size = new System.Drawing.Size(100, 20);
            this.txbBusquedaMaterial.TabIndex = 54;
            this.txbBusquedaMaterial.TextChanged += new System.EventHandler(this.txbBusquedaMaterial_TextChanged);
            // 
            // txbNombre
            // 
            this.txbNombre.Enabled = false;
            this.txbNombre.Location = new System.Drawing.Point(113, 69);
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(100, 20);
            this.txbNombre.TabIndex = 55;
            // 
            // txbNombreMaterial
            // 
            this.txbNombreMaterial.Enabled = false;
            this.txbNombreMaterial.Location = new System.Drawing.Point(113, 168);
            this.txbNombreMaterial.Name = "txbNombreMaterial";
            this.txbNombreMaterial.Size = new System.Drawing.Size(100, 20);
            this.txbNombreMaterial.TabIndex = 56;
            // 
            // txbEtiqueta
            // 
            this.txbEtiqueta.Enabled = false;
            this.txbEtiqueta.Location = new System.Drawing.Point(7, 169);
            this.txbEtiqueta.Name = "txbEtiqueta";
            this.txbEtiqueta.Size = new System.Drawing.Size(100, 20);
            this.txbEtiqueta.TabIndex = 57;
            // 
            // txbSolicitante
            // 
            this.txbSolicitante.Enabled = false;
            this.txbSolicitante.Location = new System.Drawing.Point(113, 31);
            this.txbSolicitante.Name = "txbSolicitante";
            this.txbSolicitante.Size = new System.Drawing.Size(100, 20);
            this.txbSolicitante.TabIndex = 58;
            // 
            // txbMaterial
            // 
            this.txbMaterial.Enabled = false;
            this.txbMaterial.Location = new System.Drawing.Point(113, 130);
            this.txbMaterial.Name = "txbMaterial";
            this.txbMaterial.Size = new System.Drawing.Size(100, 20);
            this.txbMaterial.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(25, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 60;
            this.label1.Text = "Prestamo";
            // 
            // dgVistaPrestamo
            // 
            this.dgVistaPrestamo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVistaPrestamo.Location = new System.Drawing.Point(226, 214);
            this.dgVistaPrestamo.Name = "dgVistaPrestamo";
            this.dgVistaPrestamo.ReadOnly = true;
            this.dgVistaPrestamo.Size = new System.Drawing.Size(283, 68);
            this.dgVistaPrestamo.TabIndex = 61;
            this.dgVistaPrestamo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVistaPrestamo_CellContentClick);
            // 
            // txbId_Prestamo
            // 
            this.txbId_Prestamo.Location = new System.Drawing.Point(113, 214);
            this.txbId_Prestamo.Name = "txbId_Prestamo";
            this.txbId_Prestamo.Size = new System.Drawing.Size(100, 20);
            this.txbId_Prestamo.TabIndex = 62;
            this.txbId_Prestamo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbId_Prestamo_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(25, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 63;
            this.label3.Text = "Becario";
            // 
            // cmbBecario
            // 
            this.cmbBecario.FormattingEnabled = true;
            this.cmbBecario.Location = new System.Drawing.Point(92, 289);
            this.cmbBecario.Name = "cmbBecario";
            this.cmbBecario.Size = new System.Drawing.Size(121, 21);
            this.cmbBecario.TabIndex = 64;
            // 
            // RealizarPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(521, 346);
            this.Controls.Add(this.cmbBecario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbId_Prestamo);
            this.Controls.Add(this.dgVistaPrestamo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbMaterial);
            this.Controls.Add(this.txbSolicitante);
            this.Controls.Add(this.txbEtiqueta);
            this.Controls.Add(this.txbNombreMaterial);
            this.Controls.Add(this.txbNombre);
            this.Controls.Add(this.txbBusquedaMaterial);
            this.Controls.Add(this.dgVistaMaterial);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txbBusquedaSolicitante);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgVistaSolicitantes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RealizarPrestamo";
            this.Text = "RealizarPrestamo";
            this.Load += new System.EventHandler(this.RealizarPrestamo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaSolicitantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaPrestamo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txbBusquedaSolicitante;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgVistaSolicitantes;
        private System.Windows.Forms.DataGridView dgVistaMaterial;
        private System.Windows.Forms.TextBox txbBusquedaMaterial;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.TextBox txbNombreMaterial;
        private System.Windows.Forms.TextBox txbEtiqueta;
        private System.Windows.Forms.TextBox txbSolicitante;
        private System.Windows.Forms.TextBox txbMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgVistaPrestamo;
        private System.Windows.Forms.TextBox txbId_Prestamo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBecario;
    }
}