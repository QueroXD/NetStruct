namespace NetStruct.Formularios.Gestión
{
    partial class FrmInfraestructuras
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
            this.dgDadesCiudades = new System.Windows.Forms.DataGridView();
            this.btRemove = new System.Windows.Forms.PictureBox();
            this.btAdd = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgDadesCiudades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDadesCiudades
            // 
            this.dgDadesCiudades.AllowUserToAddRows = false;
            this.dgDadesCiudades.AllowUserToDeleteRows = false;
            this.dgDadesCiudades.AllowUserToOrderColumns = true;
            this.dgDadesCiudades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgDadesCiudades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDadesCiudades.Location = new System.Drawing.Point(12, 11);
            this.dgDadesCiudades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgDadesCiudades.Name = "dgDadesCiudades";
            this.dgDadesCiudades.RowHeadersWidth = 51;
            this.dgDadesCiudades.RowTemplate.Height = 24;
            this.dgDadesCiudades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDadesCiudades.Size = new System.Drawing.Size(868, 478);
            this.dgDadesCiudades.TabIndex = 14;
            // 
            // btRemove
            // 
            this.btRemove.Image = global::NetStruct.Properties.Resources.cancel50;
            this.btRemove.Location = new System.Drawing.Point(829, 493);
            this.btRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(51, 50);
            this.btRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btRemove.TabIndex = 17;
            this.btRemove.TabStop = false;
            // 
            // btAdd
            // 
            this.btAdd.Image = global::NetStruct.Properties.Resources.add50;
            this.btAdd.Location = new System.Drawing.Point(758, 493);
            this.btAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(51, 50);
            this.btAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btAdd.TabIndex = 16;
            this.btAdd.TabStop = false;
            // 
            // FrmInfraestructuras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 554);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.dgDadesCiudades);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmInfraestructuras";
            this.Text = "FrmInfraestructuras";
            this.Load += new System.EventHandler(this.FrmInfraestructuras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDadesCiudades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDadesCiudades;
        private System.Windows.Forms.PictureBox btRemove;
        private System.Windows.Forms.PictureBox btAdd;
    }
}