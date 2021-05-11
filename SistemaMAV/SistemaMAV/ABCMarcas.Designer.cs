namespace SistemaMAV
{
    partial class ABCMarcas
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txbBusqueda = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbID = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.dgVistaTabla = new System.Windows.Forms.DataGridView();
            this.txbNombreMarca = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::SistemaMAV.Properties.Resources.Delete;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(470, 302);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(39, 35);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImage = global::SistemaMAV.Properties.Resources.Notebook;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(425, 302);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(39, 35);
            this.btnEdit.TabIndex = 31;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::SistemaMAV.Properties.Resources.add;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(380, 302);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(39, 35);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImage = global::SistemaMAV.Properties.Resources.Done1;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(252, 302);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(39, 35);
            this.btnGuardar.TabIndex = 29;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txbBusqueda
            // 
            this.txbBusqueda.Location = new System.Drawing.Point(409, 22);
            this.txbBusqueda.MaxLength = 153;
            this.txbBusqueda.Name = "txbBusqueda";
            this.txbBusqueda.Size = new System.Drawing.Size(100, 20);
            this.txbBusqueda.TabIndex = 28;
            this.txbBusqueda.TextChanged += new System.EventHandler(this.txbBusqueda_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(13, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 16);
            this.label7.TabIndex = 27;
            this.label7.Text = "ID";
            // 
            // txbID
            // 
            this.txbID.Enabled = false;
            this.txbID.Location = new System.Drawing.Point(127, 110);
            this.txbID.MaxLength = 8;
            this.txbID.Name = "txbID";
            this.txbID.Size = new System.Drawing.Size(100, 20);
            this.txbID.TabIndex = 26;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMarca.Location = new System.Drawing.Point(13, 160);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(46, 16);
            this.lblMarca.TabIndex = 24;
            this.lblMarca.Text = "Marca";
            // 
            // dgVistaTabla
            // 
            this.dgVistaTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVistaTabla.Location = new System.Drawing.Point(252, 48);
            this.dgVistaTabla.Name = "dgVistaTabla";
            this.dgVistaTabla.ReadOnly = true;
            this.dgVistaTabla.Size = new System.Drawing.Size(257, 244);
            this.dgVistaTabla.TabIndex = 23;
            this.dgVistaTabla.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgVistaTabla_CellMouseClick);
            // 
            // txbNombreMarca
            // 
            this.txbNombreMarca.Enabled = false;
            this.txbNombreMarca.Location = new System.Drawing.Point(127, 159);
            this.txbNombreMarca.MaxLength = 8;
            this.txbNombreMarca.Name = "txbNombreMarca";
            this.txbNombreMarca.Size = new System.Drawing.Size(100, 20);
            this.txbNombreMarca.TabIndex = 33;
            // 
            // ABCMarcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(521, 346);
            this.Controls.Add(this.txbNombreMarca);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txbBusqueda);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbID);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.dgVistaTabla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ABCMarcas";
            this.Text = "ABCMarcas";
            this.Load += new System.EventHandler(this.ABCMarcas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txbBusqueda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbID;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.DataGridView dgVistaTabla;
        private System.Windows.Forms.TextBox txbNombreMarca;
    }
}