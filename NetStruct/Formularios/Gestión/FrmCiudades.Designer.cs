namespace NetStruct.Formularios.Gestión
{
    partial class FrmCiudades
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
            this.dgDadesCiudades.Location = new System.Drawing.Point(12, 49);
            this.dgDadesCiudades.Name = "dgDadesCiudades";
            this.dgDadesCiudades.RowHeadersWidth = 51;
            this.dgDadesCiudades.RowTemplate.Height = 24;
            this.dgDadesCiudades.Size = new System.Drawing.Size(493, 338);
            this.dgDadesCiudades.TabIndex = 13;
            // 
            // btRemove
            // 
            this.btRemove.Image = global::NetStruct.Properties.Resources.cancel50;
            this.btRemove.Location = new System.Drawing.Point(444, 393);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(50, 50);
            this.btRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btRemove.TabIndex = 15;
            this.btRemove.TabStop = false;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btAdd
            // 
            this.btAdd.Image = global::NetStruct.Properties.Resources.add50;
            this.btAdd.Location = new System.Drawing.Point(374, 393);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(50, 50);
            this.btAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btAdd.TabIndex = 14;
            this.btAdd.TabStop = false;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // FrmCiudades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 450);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.dgDadesCiudades);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCiudades";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCiudades_FormClosing);
            this.Load += new System.EventHandler(this.FrmCiudades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDadesCiudades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btRemove;
        private System.Windows.Forms.PictureBox btAdd;
        private System.Windows.Forms.DataGridView dgDadesCiudades;
    }
}