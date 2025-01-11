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
    public partial class FrmPaises : Form
    {
        private NetStructEntities netStructContext {  get; set; }
        
        Boolean bFirst = true;

        FrmAMBPaises fAMBPaises = null;

        public FrmPaises(NetStructEntities xNetStruct)
        {
            InitializeComponent();
            netStructContext = xNetStruct;
        }

        private void FrmPaises_Load(object sender, EventArgs e)
        {
            omplirComboContinents();
            
            if (cbContinents.SelectedIndex != -1)
            {
                getDades((int)cbContinents.SelectedValue);
            }

            iniDGrid();
            bFirst = false;
        }

        private void cbContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bFirst && cbContinents.SelectedIndex != null)
            {
                getDades((int)cbContinents.SelectedValue);
            }
        }

        private void omplirComboContinents()
        {
            var qryContinents = from c in netStructContext.Continente
                                orderby c.idContinente
                                select new
                                {
                                    id = c.idContinente,
                                    nom = c.Nombre
                                };
            cbContinents.DataSource = qryContinents.ToList();
            cbContinents.DisplayMember = "nom";
            cbContinents.ValueMember = "id";
            cbContinents.SelectedIndex = 0;
        }

        private void getDades(int idContinent)
        {
            var qryPaises = from c in netStructContext.Continente
                            join p in netStructContext.Paises
                            on c.idContinente equals p.idContinente
                            where c.idContinente == idContinent
                            orderby c.idContinente
                            select new
                            {
                                nom = p.Nombre
                            };

            dgDadesPaises.DataSource = qryPaises.ToList();
        }

        private void iniDGrid()
        {
            dgDadesPaises.Columns["nom"].HeaderText = "Pais";
        }

        private void FrmPaises_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((FrmMain)this.MdiParent).tancarForm(this);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            fAMBPaises = new FrmAMBPaises('A', netStructContext);
            fAMBPaises.ShowDialog();

            fAMBPaises = null;
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (dgDadesPaises.Rows.Count > 0)
            {
                fAMBPaises = new FrmAMBPaises('B', netStructContext);

                fAMBPaises.pais = dgDadesPaises.SelectedRows[0].Cells["nom"].Value.ToString().Trim();
                fAMBPaises.ShowDialog();
                fAMBPaises = null;
            }
            else
            {
                MessageBox.Show("No has seleccionat cap fila", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgDadesPaises_DoubleClick(object sender, EventArgs e)
        {
            fAMBPaises = new FrmAMBPaises('M', netStructContext);
            fAMBPaises.pais = dgDadesPaises.SelectedRows[0].Cells["nom"].Value.ToString().Trim();
            fAMBPaises.ShowDialog();
            fAMBPaises = null;
        }
    }
}
