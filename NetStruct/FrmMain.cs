using NetStruct.Formularios;
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
        private NetStructEntities netStructContext { get; set; } = new NetStructEntities();

        FrmPaises paises = null;
        FrmCiudades ciudades = null;
        FrmCategorias categorias = null;
        FrmInfraestructuras infraestructuras = null;
        FrmGaleria galeria = null;
        FrmAMBInfraestructura fAMBInfraestructura = null;

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
                paises.Text = xnom;
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
                xb = (this.MdiChildren[x1].Text == xnom);
                x1++;
            }
            return (xb);
        }

        public void tancarForm(Form xform)
        {
            xform = null;
        }

        private void ciudadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String xnom = "Ciudades";

            if (!(ja_esta_obert(xnom)))
            {
                ciudades = new FrmCiudades(netStructContext);
                ciudades.Text = xnom;
                ciudades.MdiParent = this;
                ciudades.Show();
            }
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String xnom = "Categorias";
            if (!(ja_esta_obert(xnom)))
            {
                categorias = new FrmCategorias(netStructContext);
                categorias.Text = xnom;
                categorias.MdiParent = this;
                categorias.Show();
            }
        }

        private void infraestructurasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String xnom = "Infraestructuras";
            if (!(ja_esta_obert(xnom)))
            {
                infraestructuras = new FrmInfraestructuras(netStructContext);
                infraestructuras.Text = xnom;
                infraestructuras.MdiParent = this;
                infraestructuras.Show();
            }
        }

        private void galeriaDeImagenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String xnom = "Galeria";
            if (!(ja_esta_obert(xnom)))
            {
                galeria = new FrmGaleria(netStructContext);
                galeria.Text = xnom;
                galeria.MdiParent = this;
                galeria.Show();
            }
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String xnom = "Consultar Infraestructura";
            if (!(ja_esta_obert(xnom)))
            {
                fAMBInfraestructura = new FrmAMBInfraestructura('C', netStructContext);
                fAMBInfraestructura.Text = xnom;
                fAMBInfraestructura.MdiParent = this;
                fAMBInfraestructura.Show();
            }
        }
    }
}
