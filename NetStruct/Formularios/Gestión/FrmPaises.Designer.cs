namespace NetStruct.Formularios.Gestión
{
    partial class FrmPaises
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
            this.dgDadesPaises = new System.Windows.Forms.DataGridView();
            this.lbContinents = new System.Windows.Forms.Label();
            this.cbContinents = new System.Windows.Forms.ComboBox();
            this.btAdd = new System.Windows.Forms.PictureBox();
            this.btRemove = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgDadesPaises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btRemove)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDadesPaises
            // 
            this.dgDadesPaises.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDadesPaises.Location = new System.Drawing.Point(12, 49);
            this.dgDadesPaises.Name = "dgDadesPaises";
            this.dgDadesPaises.RowHeadersWidth = 51;
            this.dgDadesPaises.RowTemplate.Height = 24;
            this.dgDadesPaises.Size = new System.Drawing.Size(493, 338);
            this.dgDadesPaises.TabIndex = 0;
            this.dgDadesPaises.DoubleClick += new System.EventHandler(this.dgDadesPaises_DoubleClick);
            // 
            // lbContinents
            // 
            this.lbContinents.AutoSize = true;
            this.lbContinents.BackColor = System.Drawing.Color.Coral;
            this.lbContinents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbContinents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContinents.ForeColor = System.Drawing.Color.Black;
            this.lbContinents.Location = new System.Drawing.Point(12, 19);
            this.lbContinents.Name = "lbContinents";
            this.lbContinents.Size = new System.Drawing.Size(98, 24);
            this.lbContinents.TabIndex = 1;
            this.lbContinents.Text = "Continents";
            // 
            // cbContinents
            // 
            this.cbContinents.FormattingEnabled = true;
            this.cbContinents.Location = new System.Drawing.Point(116, 19);
            this.cbContinents.Name = "cbContinents";
            this.cbContinents.Size = new System.Drawing.Size(308, 24);
            this.cbContinents.TabIndex = 2;
            this.cbContinents.SelectedIndexChanged += new System.EventHandler(this.cbContinents_SelectedIndexChanged);
            // 
            // btAdd
            // 
            this.btAdd.Image = global::NetStruct.Properties.Resources.add50;
            this.btAdd.Location = new System.Drawing.Point(374, 393);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(50, 50);
            this.btAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btAdd.TabIndex = 11;
            this.btAdd.TabStop = false;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btRemove
            // 
            this.btRemove.Image = global::NetStruct.Properties.Resources.cancel50;
            this.btRemove.Location = new System.Drawing.Point(444, 393);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(50, 50);
            this.btRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btRemove.TabIndex = 12;
            this.btRemove.TabStop = false;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // FrmPaises
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 450);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.cbContinents);
            this.Controls.Add(this.lbContinents);
            this.Controls.Add(this.dgDadesPaises);
            this.Name = "FrmPaises";
            this.Text = "FrmPaises";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPaises_FormClosing);
            this.Load += new System.EventHandler(this.FrmPaises_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDadesPaises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btRemove)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDadesPaises;
        private System.Windows.Forms.Label lbContinents;
        private System.Windows.Forms.ComboBox cbContinents;
        private System.Windows.Forms.PictureBox btAdd;
        private System.Windows.Forms.PictureBox btRemove;
    }
}