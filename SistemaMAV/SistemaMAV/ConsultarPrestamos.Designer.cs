
namespace SistemaMAV
{
    partial class ConsultarPrestamos
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
            this.txbBusqueda = new System.Windows.Forms.TextBox();
            this.dgVistaTabla = new System.Windows.Forms.DataGridView();
            this.dgVistaAnadidos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaTabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaAnadidos)).BeginInit();
            this.SuspendLayout();
            // 
            // txbBusqueda
            // 
            this.txbBusqueda.Location = new System.Drawing.Point(202, 11);
            this.txbBusqueda.Name = "txbBusqueda";
            this.txbBusqueda.Size = new System.Drawing.Size(100, 20);
            this.txbBusqueda.TabIndex = 39;
            this.txbBusqueda.TextChanged += new System.EventHandler(this.txbBusqueda_TextChanged);
            // 
            // dgVistaTabla
            // 
            this.dgVistaTabla.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgVistaTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVistaTabla.Location = new System.Drawing.Point(12, 35);
            this.dgVistaTabla.Name = "dgVistaTabla";
            this.dgVistaTabla.ReadOnly = true;
            this.dgVistaTabla.Size = new System.Drawing.Size(500, 154);
            this.dgVistaTabla.TabIndex = 22;
            this.dgVistaTabla.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgVistaTabla_CellMouseClick);
            // 
            // dgVistaAnadidos
            // 
            this.dgVistaAnadidos.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgVistaAnadidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVistaAnadidos.Location = new System.Drawing.Point(8, 214);
            this.dgVistaAnadidos.Name = "dgVistaAnadidos";
            this.dgVistaAnadidos.ReadOnly = true;
            this.dgVistaAnadidos.Size = new System.Drawing.Size(500, 121);
            this.dgVistaAnadidos.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(14, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 24);
            this.label2.TabIndex = 43;
            this.label2.Text = "Prestamos ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(13, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 24);
            this.label3.TabIndex = 44;
            this.label3.Text = "Materiales Prestados";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(139, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 45;
            this.label1.Text = "Nombre";
            // 
            // ConsultarPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(521, 346);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgVistaAnadidos);
            this.Controls.Add(this.txbBusqueda);
            this.Controls.Add(this.dgVistaTabla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConsultarPrestamos";
            this.Text = "ABCMateriales";
            this.Load += new System.EventHandler(this.ABCMateriales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaTabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaAnadidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txbBusqueda;
        private System.Windows.Forms.DataGridView dgVistaTabla;
        private System.Windows.Forms.DataGridView dgVistaAnadidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}