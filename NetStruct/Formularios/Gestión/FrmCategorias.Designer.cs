namespace NetStruct.Formularios.Gestión
{
    partial class FrmCategorias
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
            this.btRemove = new System.Windows.Forms.PictureBox();
            this.btAdd = new System.Windows.Forms.PictureBox();
            this.dgDadesCategoria = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.btRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDadesCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // btRemove
            // 
            this.btRemove.Image = global::NetStruct.Properties.Resources.cancel50;
            this.btRemove.Location = new System.Drawing.Point(333, 310);
            this.btRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(38, 41);
            this.btRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btRemove.TabIndex = 18;
            this.btRemove.TabStop = false;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btAdd
            // 
            this.btAdd.Image = global::NetStruct.Properties.Resources.add50;
            this.btAdd.Location = new System.Drawing.Point(280, 310);
            this.btAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(38, 41);
            this.btAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btAdd.TabIndex = 17;
            this.btAdd.TabStop = false;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // dgDadesCategoria
            // 
            this.dgDadesCategoria.AllowUserToAddRows = false;
            this.dgDadesCategoria.AllowUserToDeleteRows = false;
            this.dgDadesCategoria.AllowUserToOrderColumns = true;
            this.dgDadesCategoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgDadesCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDadesCategoria.Location = new System.Drawing.Point(9, 10);
            this.dgDadesCategoria.Margin = new System.Windows.Forms.Padding(2);
            this.dgDadesCategoria.Name = "dgDadesCategoria";
            this.dgDadesCategoria.RowHeadersWidth = 51;
            this.dgDadesCategoria.RowTemplate.Height = 24;
            this.dgDadesCategoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDadesCategoria.Size = new System.Drawing.Size(370, 295);
            this.dgDadesCategoria.TabIndex = 16;
            this.dgDadesCategoria.DoubleClick += new System.EventHandler(this.dgDadesCategoria_DoubleClick);
            // 
            // FrmCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 356);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.dgDadesCategoria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmCategorias";
            this.Text = "FrmCategorias";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCategorias_FormClosing);
            this.Load += new System.EventHandler(this.FrmCategorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDadesCategoria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btRemove;
        private System.Windows.Forms.PictureBox btAdd;
        private System.Windows.Forms.DataGridView dgDadesCategoria;
    }
}