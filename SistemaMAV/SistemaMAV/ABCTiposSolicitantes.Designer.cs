
namespace SistemaMAV
{
    partial class ABCTiposSolicitantes
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
            this.dgVistaTabla = new System.Windows.Forms.DataGridView();
            this.txbTipoSolicitante = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txbID = new System.Windows.Forms.TextBox();
            this.Labl = new System.Windows.Forms.Label();
            this.txbBusqueda = new System.Windows.Forms.TextBox();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // dgVistaTabla
            // 
            this.dgVistaTabla.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgVistaTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVistaTabla.Location = new System.Drawing.Point(252, 45);
            this.dgVistaTabla.Name = "dgVistaTabla";
            this.dgVistaTabla.ReadOnly = true;
            this.dgVistaTabla.Size = new System.Drawing.Size(257, 244);
            this.dgVistaTabla.TabIndex = 0;
            this.dgVistaTabla.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgVistaTabla_CellMouseClick);
            // 
            // txbTipoSolicitante
            // 
            this.txbTipoSolicitante.Enabled = false;
            this.txbTipoSolicitante.Location = new System.Drawing.Point(146, 88);
            this.txbTipoSolicitante.MaxLength = 50;
            this.txbTipoSolicitante.Name = "txbTipoSolicitante";
            this.txbTipoSolicitante.Size = new System.Drawing.Size(100, 20);
            this.txbTipoSolicitante.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNombre.Location = new System.Drawing.Point(12, 92);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(120, 16);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Tipo de Solicitante";
            // 
            // txbID
            // 
            this.txbID.Enabled = false;
            this.txbID.Location = new System.Drawing.Point(146, 50);
            this.txbID.MaxLength = 8;
            this.txbID.Name = "txbID";
            this.txbID.Size = new System.Drawing.Size(100, 20);
            this.txbID.TabIndex = 15;
            this.txbID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros);
            // 
            // Labl
            // 
            this.Labl.AutoSize = true;
            this.Labl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Labl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Labl.Location = new System.Drawing.Point(12, 50);
            this.Labl.Name = "Labl";
            this.Labl.Size = new System.Drawing.Size(21, 16);
            this.Labl.TabIndex = 16;
            this.Labl.Text = "ID";
            // 
            // txbBusqueda
            // 
            this.txbBusqueda.Location = new System.Drawing.Point(409, 19);
            this.txbBusqueda.MaxLength = 153;
            this.txbBusqueda.Name = "txbBusqueda";
            this.txbBusqueda.Size = new System.Drawing.Size(100, 20);
            this.txbBusqueda.TabIndex = 17;
            this.txbBusqueda.TextChanged += new System.EventHandler(this.txbBusqueda_TextChanged);
            // 
            // btnConsulta
            // 
            this.btnConsulta.BackgroundImage = global::SistemaMAV.Properties.Resources.Searching;
            this.btnConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsulta.Location = new System.Drawing.Point(252, 7);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(39, 35);
            this.btnConsulta.TabIndex = 22;
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::SistemaMAV.Properties.Resources.Delete;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(470, 299);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(39, 35);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImage = global::SistemaMAV.Properties.Resources.Notebook;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(425, 299);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(39, 35);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::SistemaMAV.Properties.Resources.add;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(380, 299);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(39, 35);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImage = global::SistemaMAV.Properties.Resources.Done1;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(185, 130);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(39, 35);
            this.btnGuardar.TabIndex = 18;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(360, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Nombre";
            // 
            // ABCTiposSolicitantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(521, 346);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txbBusqueda);
            this.Controls.Add(this.Labl);
            this.Controls.Add(this.txbID);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txbTipoSolicitante);
            this.Controls.Add(this.dgVistaTabla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ABCTiposSolicitantes";
            this.Text = "ABCUsuarios";
            this.Load += new System.EventHandler(this.ABCUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgVistaTabla;
        private System.Windows.Forms.TextBox txbTipoSolicitante;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txbID;
        private System.Windows.Forms.Label Labl;
        private System.Windows.Forms.TextBox txbBusqueda;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Label label2;
    }
}