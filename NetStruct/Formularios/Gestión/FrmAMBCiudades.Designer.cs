namespace NetStruct.Formularios.Gestión
{
    partial class FrmAMBCiudades
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
            this.cbPais = new System.Windows.Forms.ComboBox();
            this.btNo = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.lbPais = new System.Windows.Forms.Label();
            this.tbCiudad = new System.Windows.Forms.TextBox();
            this.lbCiudad = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbPais
            // 
            this.cbPais.FormattingEnabled = true;
            this.cbPais.Location = new System.Drawing.Point(117, 48);
            this.cbPais.Name = "cbPais";
            this.cbPais.Size = new System.Drawing.Size(268, 24);
            this.cbPais.TabIndex = 31;
            // 
            // btNo
            // 
            this.btNo.BackColor = System.Drawing.Color.Red;
            this.btNo.ForeColor = System.Drawing.Color.White;
            this.btNo.Location = new System.Drawing.Point(200, 85);
            this.btNo.Name = "btNo";
            this.btNo.Size = new System.Drawing.Size(114, 42);
            this.btNo.TabIndex = 30;
            this.btNo.Text = "&Cancel·lar";
            this.btNo.UseVisualStyleBackColor = false;
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.Green;
            this.btOK.ForeColor = System.Drawing.Color.White;
            this.btOK.Location = new System.Drawing.Point(80, 85);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(114, 42);
            this.btOK.TabIndex = 29;
            this.btOK.Text = "&Acceptar";
            this.btOK.UseVisualStyleBackColor = false;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // lbPais
            // 
            this.lbPais.AutoSize = true;
            this.lbPais.BackColor = System.Drawing.Color.SaddleBrown;
            this.lbPais.ForeColor = System.Drawing.Color.White;
            this.lbPais.Location = new System.Drawing.Point(11, 48);
            this.lbPais.MinimumSize = new System.Drawing.Size(100, 0);
            this.lbPais.Name = "lbPais";
            this.lbPais.Padding = new System.Windows.Forms.Padding(3);
            this.lbPais.Size = new System.Drawing.Size(100, 22);
            this.lbPais.TabIndex = 28;
            this.lbPais.Text = "Pais";
            // 
            // tbCiudad
            // 
            this.tbCiudad.Location = new System.Drawing.Point(117, 12);
            this.tbCiudad.MaxLength = 50;
            this.tbCiudad.Name = "tbCiudad";
            this.tbCiudad.Size = new System.Drawing.Size(268, 22);
            this.tbCiudad.TabIndex = 27;
            // 
            // lbCiudad
            // 
            this.lbCiudad.AutoSize = true;
            this.lbCiudad.BackColor = System.Drawing.Color.SaddleBrown;
            this.lbCiudad.ForeColor = System.Drawing.Color.White;
            this.lbCiudad.Location = new System.Drawing.Point(11, 12);
            this.lbCiudad.MinimumSize = new System.Drawing.Size(100, 0);
            this.lbCiudad.Name = "lbCiudad";
            this.lbCiudad.Padding = new System.Windows.Forms.Padding(3);
            this.lbCiudad.Size = new System.Drawing.Size(100, 22);
            this.lbCiudad.TabIndex = 26;
            this.lbCiudad.Text = "Ciudad";
            // 
            // FrmAMBCiudades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 139);
            this.Controls.Add(this.cbPais);
            this.Controls.Add(this.btNo);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.lbPais);
            this.Controls.Add(this.tbCiudad);
            this.Controls.Add(this.lbCiudad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAMBCiudades";
            this.Load += new System.EventHandler(this.FrmAMBCiudades_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPais;
        private System.Windows.Forms.Button btNo;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Label lbPais;
        private System.Windows.Forms.TextBox tbCiudad;
        private System.Windows.Forms.Label lbCiudad;
    }
}