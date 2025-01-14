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
        private NetStructEntities netStructContext { get; set; }

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
            getDades((int)cbContinents.SelectedValue);
            iniDGrid();
            bFirst = false;
        }

        private void cbContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bFirst && cbContinents.SelectedValue != null)
            {
                getDades((int)cbContinents.SelectedValue);
            }
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            cbContinents.Enabled = !chkTodos.Checked;
            if (chkTodos.Checked)
            {
                getDadesSinFiltro();
            }
            else
            {
                getDades((int)cbContinents.SelectedValue);
            }
        }

        private void FrmPaises_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((FrmMain)this.MdiParent).tancarForm(this);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            fAMBPaises = new FrmAMBPaises('A', netStructContext);
            fAMBPaises.ShowDialog();

            if (chkTodos.Checked)
            {
                getDadesSinFiltro();
            }
            else
            {
                getDades((int)cbContinents.SelectedValue);
            }

            if (fAMBPaises.idPais != "")
            {
                seleccionarFila(fAMBPaises.idPais);
            }

            fAMBPaises = null;
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (dgDadesPaises.Rows.Count > 0)
            {
                fAMBPaises = new FrmAMBPaises('B', netStructContext);

                fAMBPaises.idPais = dgDadesPaises.SelectedRows[0].Cells["idPais"].Value.ToString().Trim();
                fAMBPaises.continente = dgDadesPaises.SelectedRows[0].Cells["nomContinent"].Value.ToString();
                fAMBPaises.idContinente = (int)dgDadesPaises.SelectedRows[0].Cells["idContinent"].Value;

                fAMBPaises.ShowDialog();

                if (chkTodos.Checked)
                {
                    getDadesSinFiltro();
                }
                else
                {
                    getDades((int)cbContinents.SelectedValue);
                }
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

            fAMBPaises.idPais = dgDadesPaises.SelectedRows[0].Cells["idPais"].Value.ToString();
            fAMBPaises.continente = dgDadesPaises.SelectedRows[0].Cells["nomContinent"].Value.ToString();
            fAMBPaises.idContinente = (int)dgDadesPaises.SelectedRows[0].Cells["idContinent"].Value;

            fAMBPaises.ShowDialog();

            if (chkTodos.Checked)
            {
                getDadesSinFiltro();
            }
            else
            {
                getDades((int)cbContinents.SelectedValue);
            }

            if (fAMBPaises.idPais != "")
            {
                seleccionarFila(fAMBPaises.idPais);
            }

            fAMBPaises = null;
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
                                idPais = p.idPais,
                                pais = p.Nombre,
                                idContinent = c.idContinente,
                                nomContinent = c.Nombre
                            };

            dgDadesPaises.DataSource = qryPaises.ToList();
        }

        private void getDadesSinFiltro()
        {
            var qryPaises = from c in netStructContext.Continente
                            join p in netStructContext.Paises
                            on c.idContinente equals p.idContinente
                            orderby c.idContinente
                            select new
                            {
                                idPais = p.idPais,
                                pais = p.Nombre,
                                idContinent = c.idContinente,
                                nomContinent = c.Nombre
                            };

            dgDadesPaises.DataSource = qryPaises.ToList();
        }

        private void iniDGrid()
        {
            dgDadesPaises.Columns["pais"].HeaderText = "Pais";
            dgDadesPaises.Columns["nomContinent"].HeaderText = "Continent";
            dgDadesPaises.Columns["idPais"].Visible = false;
            dgDadesPaises.Columns["idContinent"].Visible = false;
        }

        private void omplirComboContinents()
        {
            var qryContinents = from c in netStructContext.Continente
                                orderby c.idContinente
                                select new
                                {
                                    idContinent = c.idContinente,
                                    continente = c.Nombre
                                };

            cbContinents.DataSource = qryContinents.ToList();
            cbContinents.DisplayMember = "continente";
            cbContinents.ValueMember = "idContinent";
            cbContinents.SelectedIndex = 0;
        }

        private void seleccionarFila(string id)
        {
            int i = -1;
            Boolean xbTrobat = false;

            while (!xbTrobat && i<dgDadesPaises.Rows.Count)
            {
                i++;
                xbTrobat = (dgDadesPaises.Rows[i].Cells["idPais"].Value.ToString() == id);
            }
            if (dgDadesPaises.Rows.Count > 0)
            {
                dgDadesPaises.Rows[i].Selected = true;
                dgDadesPaises.FirstDisplayedScrollingRowIndex = i;
            }
        }
    }
}
