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
            this.btRemove = new System.Windows.Forms.PictureBox();
            this.btAdd = new System.Windows.Forms.PictureBox();
            this.dgDadesInfra = new System.Windows.Forms.DataGridView();
            this.gbFiltres = new System.Windows.Forms.GroupBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.lbCategoria = new System.Windows.Forms.Label();
            this.cbPaises = new System.Windows.Forms.ComboBox();
            this.lbPaises = new System.Windows.Forms.Label();
            this.cbContinents = new System.Windows.Forms.ComboBox();
            this.lbContinents = new System.Windows.Forms.Label();
            this.ckbFiltres = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.btRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDadesInfra)).BeginInit();
            this.gbFiltres.SuspendLayout();
            this.SuspendLayout();
            // 
            // btRemove
            // 
            this.btRemove.Image = global::NetStruct.Properties.Resources.cancel50;
            this.btRemove.Location = new System.Drawing.Point(1299, 580);
            this.btRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(50, 50);
            this.btRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btRemove.TabIndex = 17;
            this.btRemove.TabStop = false;
            // 
            // btAdd
            // 
            this.btAdd.Image = global::NetStruct.Properties.Resources.add50;
            this.btAdd.Location = new System.Drawing.Point(1226, 580);
            this.btAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(50, 50);
            this.btAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btAdd.TabIndex = 16;
            this.btAdd.TabStop = false;
            // 
            // dgDadesInfra
            // 
            this.dgDadesInfra.AllowUserToAddRows = false;
            this.dgDadesInfra.AllowUserToDeleteRows = false;
            this.dgDadesInfra.AllowUserToOrderColumns = true;
            this.dgDadesInfra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgDadesInfra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDadesInfra.Location = new System.Drawing.Point(12, 65);
            this.dgDadesInfra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgDadesInfra.Name = "dgDadesInfra";
            this.dgDadesInfra.RowHeadersWidth = 51;
            this.dgDadesInfra.RowTemplate.Height = 24;
            this.dgDadesInfra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDadesInfra.Size = new System.Drawing.Size(1337, 500);
            this.dgDadesInfra.TabIndex = 14;
            // 
            // gbFiltres
            // 
            this.gbFiltres.Controls.Add(this.ckbFiltres);
            this.gbFiltres.Controls.Add(this.cbCategoria);
            this.gbFiltres.Controls.Add(this.lbCategoria);
            this.gbFiltres.Controls.Add(this.cbPaises);
            this.gbFiltres.Controls.Add(this.lbPaises);
            this.gbFiltres.Controls.Add(this.cbContinents);
            this.gbFiltres.Controls.Add(this.lbContinents);
            this.gbFiltres.Location = new System.Drawing.Point(12, 2);
            this.gbFiltres.Name = "gbFiltres";
            this.gbFiltres.Size = new System.Drawing.Size(1337, 58);
            this.gbFiltres.TabIndex = 25;
            this.gbFiltres.TabStop = false;
            // 
            // cbCategoria
            // 
            this.cbCategoria.Enabled = false;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(912, 17);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(308, 24);
            this.cbCategoria.TabIndex = 29;
            this.cbCategoria.SelectedIndexChanged += new System.EventHandler(this.cbCategoria_SelectedIndexChanged);
            // 
            // lbCategoria
            // 
            this.lbCategoria.AutoSize = true;
            this.lbCategoria.BackColor = System.Drawing.Color.Coral;
            this.lbCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategoria.ForeColor = System.Drawing.Color.Black;
            this.lbCategoria.Location = new System.Drawing.Point(805, 17);
            this.lbCategoria.Name = "lbCategoria";
            this.lbCategoria.Size = new System.Drawing.Size(90, 24);
            this.lbCategoria.TabIndex = 28;
            this.lbCategoria.Text = "Categoria";
            // 
            // cbPaises
            // 
            this.cbPaises.Enabled = false;
            this.cbPaises.FormattingEnabled = true;
            this.cbPaises.Location = new System.Drawing.Point(501, 17);
            this.cbPaises.Name = "cbPaises";
            this.cbPaises.Size = new System.Drawing.Size(245, 24);
            this.cbPaises.TabIndex = 27;
            this.cbPaises.SelectedIndexChanged += new System.EventHandler(this.cbPaises_SelectedIndexChanged);
            // 
            // lbPaises
            // 
            this.lbPaises.AutoSize = true;
            this.lbPaises.BackColor = System.Drawing.Color.Coral;
            this.lbPaises.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPaises.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaises.ForeColor = System.Drawing.Color.Black;
            this.lbPaises.Location = new System.Drawing.Point(420, 17);
            this.lbPaises.Name = "lbPaises";
            this.lbPaises.Size = new System.Drawing.Size(66, 24);
            this.lbPaises.TabIndex = 26;
            this.lbPaises.Text = "Paises";
            // 
            // cbContinents
            // 
            this.cbContinents.Enabled = false;
            this.cbContinents.FormattingEnabled = true;
            this.cbContinents.Location = new System.Drawing.Point(137, 17);
            this.cbContinents.Name = "cbContinents";
            this.cbContinents.Size = new System.Drawing.Size(238, 24);
            this.cbContinents.TabIndex = 25;
            this.cbContinents.SelectedIndexChanged += new System.EventHandler(this.cbContinents_SelectedIndexChanged);
            // 
            // lbContinents
            // 
            this.lbContinents.AutoSize = true;
            this.lbContinents.BackColor = System.Drawing.Color.Coral;
            this.lbContinents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbContinents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContinents.ForeColor = System.Drawing.Color.Black;
            this.lbContinents.Location = new System.Drawing.Point(16, 17);
            this.lbContinents.Name = "lbContinents";
            this.lbContinents.Size = new System.Drawing.Size(98, 24);
            this.lbContinents.TabIndex = 24;
            this.lbContinents.Text = "Continents";
            // 
            // ckbFiltres
            // 
            this.ckbFiltres.AutoSize = true;
            this.ckbFiltres.Checked = true;
            this.ckbFiltres.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbFiltres.Location = new System.Drawing.Point(1236, 19);
            this.ckbFiltres.Name = "ckbFiltres";
            this.ckbFiltres.Size = new System.Drawing.Size(95, 20);
            this.ckbFiltres.TabIndex = 30;
            this.ckbFiltres.Text = "Sense filtre";
            this.ckbFiltres.UseVisualStyleBackColor = true;
            this.ckbFiltres.CheckedChanged += new System.EventHandler(this.ckbFiltres_CheckedChanged);
            // 
            // FrmInfraestructuras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 641);
            this.Controls.Add(this.gbFiltres);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.dgDadesInfra);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmInfraestructuras";
            this.Text = "FrmInfraestructuras";
            this.Load += new System.EventHandler(this.FrmInfraestructuras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDadesInfra)).EndInit();
            this.gbFiltres.ResumeLayout(false);
            this.gbFiltres.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox btRemove;
        private System.Windows.Forms.PictureBox btAdd;
        private System.Windows.Forms.DataGridView dgDadesInfra;
        private System.Windows.Forms.GroupBox gbFiltres;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.Label lbCategoria;
        private System.Windows.Forms.ComboBox cbPaises;
        private System.Windows.Forms.Label lbPaises;
        private System.Windows.Forms.ComboBox cbContinents;
        private System.Windows.Forms.Label lbContinents;
        private System.Windows.Forms.CheckBox ckbFiltres;
    }
}