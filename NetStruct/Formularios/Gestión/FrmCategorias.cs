using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetStruct.Formularios.Gestión
{
    public partial class FrmCategorias : Form
    {
        private NetStructEntities NetStructContext { get; set; }
        
        FrmABMCategorias fABMCategorias = null;

        public FrmCategorias(NetStructEntities netStructContext)
        {
            InitializeComponent();
            NetStructContext = netStructContext;
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            getDades();
            iniDgrid();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            fABMCategorias = new FrmABMCategorias('A', NetStructContext);
            fABMCategorias.ShowDialog();

            getDades();

            if (fABMCategorias.id != "")
            {
                seleccionarFila(fABMCategorias.id);
            }
            fABMCategorias = null;
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (dgDadesCategoria.Rows.Count > 0)
            {
                fABMCategorias = new FrmABMCategorias('B', NetStructContext);

                fABMCategorias.id = dgDadesCategoria.SelectedRows[0].Cells["id"].Value.ToString();
                fABMCategorias.nombre = dgDadesCategoria.SelectedRows[0].Cells["categoria"].Value.ToString();

                fABMCategorias.ShowDialog();

                getDades();

                fABMCategorias = null;
            }
            else
            {
                MessageBox.Show("No hay datos para borrar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgDadesCategoria_DoubleClick(object sender, EventArgs e)
        {
            fABMCategorias = new FrmABMCategorias('M', NetStructContext);

            fABMCategorias.id = dgDadesCategoria.SelectedRows[0].Cells["id"].Value.ToString();
            fABMCategorias.nombre = dgDadesCategoria.SelectedRows[0].Cells["categoria"].Value.ToString();

            fABMCategorias.ShowDialog();

            getDades();

            if (fABMCategorias.id != "")
            {
                getDades();
                seleccionarFila(fABMCategorias.id);
            }
        }

        private void iniDgrid()
        {
            dgDadesCategoria.Columns["id"].HeaderText = "Id";
            dgDadesCategoria.Columns["categoria"].HeaderText = "Nombre";
        }

        private void getDades()
        {
            var qryCategorias = from c in NetStructContext.CategoriaTipo
                                select new 
                                { 
                                    id = c.idCategoria, 
                                    categoria = c.Nombre 
                                };

            dgDadesCategoria.DataSource = qryCategorias.ToList();
        }

        private void seleccionarFila(string id)
        {
            int i = -1;
            Boolean xbTrobat = false;

            while (!xbTrobat && i < dgDadesCategoria.Rows.Count)
            {
                i++;
                xbTrobat = (dgDadesCategoria.Rows[i].Cells["id"].Value.ToString() == id);
            }
            if (dgDadesCategoria.Rows.Count > 0) 
            { 
                dgDadesCategoria.Rows[i].Selected = true;
                dgDadesCategoria.FirstDisplayedScrollingRowIndex = i;
            }
        }

        private void FrmCategorias_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((FrmMain)this.MdiParent).tancarForm(this);
        }
    }
}
