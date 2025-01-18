namespace NetStruct.Formularios
{
    partial class FrmGaleria
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
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.flwGaleria = new System.Windows.Forms.FlowLayoutPanel();
            this.cbInfraestructuras = new System.Windows.Forms.ComboBox();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // flwGaleria
            // 
            this.flwGaleria.AutoScroll = true;
            this.flwGaleria.Location = new System.Drawing.Point(12, 34);
            this.flwGaleria.Name = "flwGaleria";
            this.flwGaleria.Size = new System.Drawing.Size(1878, 987);
            this.flwGaleria.TabIndex = 0;
            // 
            // cbInfraestructuras
            // 
            this.cbInfraestructuras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInfraestructuras.Enabled = false;
            this.cbInfraestructuras.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbInfraestructuras.FormattingEnabled = true;
            this.cbInfraestructuras.Location = new System.Drawing.Point(12, 4);
            this.cbInfraestructuras.Name = "cbInfraestructuras";
            this.cbInfraestructuras.Size = new System.Drawing.Size(183, 26);
            this.cbInfraestructuras.TabIndex = 1;
            this.cbInfraestructuras.SelectedIndexChanged += new System.EventHandler(this.cbInfraestructuras_SelectedIndexChanged);
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Checked = true;
            this.chkTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTodos.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodos.Location = new System.Drawing.Point(203, 6);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(73, 22);
            this.chkTodos.TabIndex = 2;
            this.chkTodos.Text = "Todas";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // FrmGaleria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.chkTodos);
            this.Controls.Add(this.cbInfraestructuras);
            this.Controls.Add(this.flwGaleria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmGaleria";
            this.Text = "FrmGaleria";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmGaleria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.FlowLayoutPanel flwGaleria;
        private System.Windows.Forms.ComboBox cbInfraestructuras;
        private System.Windows.Forms.CheckBox chkTodos;
    }
}