namespace NetStruct.Formularios.Gestión
{
    partial class FrmAMBPaises
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
            this.lbPais = new System.Windows.Forms.Label();
            this.tbPais = new System.Windows.Forms.TextBox();
            this.lbContinente = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.btNo = new System.Windows.Forms.Button();
            this.cbContinente = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbPais
            // 
            this.lbPais.AutoSize = true;
            this.lbPais.BackColor = System.Drawing.Color.SaddleBrown;
            this.lbPais.ForeColor = System.Drawing.Color.White;
            this.lbPais.Location = new System.Drawing.Point(12, 23);
            this.lbPais.MinimumSize = new System.Drawing.Size(100, 0);
            this.lbPais.Name = "lbPais";
            this.lbPais.Padding = new System.Windows.Forms.Padding(3);
            this.lbPais.Size = new System.Drawing.Size(100, 22);
            this.lbPais.TabIndex = 18;
            this.lbPais.Text = "Pais";
            // 
            // tbPais
            // 
            this.tbPais.Location = new System.Drawing.Point(118, 23);
            this.tbPais.MaxLength = 50;
            this.tbPais.Name = "tbPais";
            this.tbPais.Size = new System.Drawing.Size(268, 22);
            this.tbPais.TabIndex = 19;
            // 
            // lbContinente
            // 
            this.lbContinente.AutoSize = true;
            this.lbContinente.BackColor = System.Drawing.Color.SaddleBrown;
            this.lbContinente.ForeColor = System.Drawing.Color.White;
            this.lbContinente.Location = new System.Drawing.Point(12, 59);
            this.lbContinente.MinimumSize = new System.Drawing.Size(100, 0);
            this.lbContinente.Name = "lbContinente";
            this.lbContinente.Padding = new System.Windows.Forms.Padding(3);
            this.lbContinente.Size = new System.Drawing.Size(100, 22);
            this.lbContinente.TabIndex = 21;
            this.lbContinente.Text = "Continente";
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.Green;
            this.btOK.ForeColor = System.Drawing.Color.White;
            this.btOK.Location = new System.Drawing.Point(118, 104);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(114, 42);
            this.btOK.TabIndex = 23;
            this.btOK.Text = "&Acceptar";
            this.btOK.UseVisualStyleBackColor = false;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btNo
            // 
            this.btNo.BackColor = System.Drawing.Color.Red;
            this.btNo.ForeColor = System.Drawing.Color.White;
            this.btNo.Location = new System.Drawing.Point(272, 104);
            this.btNo.Name = "btNo";
            this.btNo.Size = new System.Drawing.Size(114, 42);
            this.btNo.TabIndex = 24;
            this.btNo.Text = "&Cancel·lar";
            this.btNo.UseVisualStyleBackColor = false;
            this.btNo.Click += new System.EventHandler(this.btNo_Click);
            // 
            // cbContinente
            // 
            this.cbContinente.FormattingEnabled = true;
            this.cbContinente.Location = new System.Drawing.Point(118, 59);
            this.cbContinente.Name = "cbContinente";
            this.cbContinente.Size = new System.Drawing.Size(268, 24);
            this.cbContinente.TabIndex = 25;
            // 
            // FrmAMBPaises
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 158);
            this.Controls.Add(this.cbContinente);
            this.Controls.Add(this.btNo);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.lbContinente);
            this.Controls.Add(this.tbPais);
            this.Controls.Add(this.lbPais);
            this.Name = "FrmAMBPaises";
            this.Text = "FrmAMBPaises";
            this.Load += new System.EventHandler(this.FrmAMBPaises_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPais;
        private System.Windows.Forms.TextBox tbPais;
        private System.Windows.Forms.Label lbContinente;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btNo;
        private System.Windows.Forms.ComboBox cbContinente;
    }
}