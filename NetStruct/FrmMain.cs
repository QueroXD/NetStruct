using NetStruct.Formularios.Gestión;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetStruct
{
    public partial class FrmMain : Form
    {
        private NetStructEntities netStructContext {  get; set; } = new NetStructEntities();

        FrmPaises paises = null;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro que quieres salir?", "PREGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void paisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String xnom = "Paises";

            if (!(ja_esta_obert(xnom)))
            {
                paises = new FrmPaises(netStructContext);
                paises.Name = xnom;
                paises.MdiParent = this;
                paises.Show();
            }
            paises.Activate();
        }

        private Boolean ja_esta_obert(String xnom)
        {

            int x1 = 0;
            Boolean xb = false;

            while ((x1 < this.MdiChildren.Length) && (!(xb)))
            {
                xb = (this.MdiChildren[x1].Name == xnom);
                x1++;
            }
            return (xb);
        }

        public void tancarForm(Form xform)
        {
            xform = null;
        }
    }
}
