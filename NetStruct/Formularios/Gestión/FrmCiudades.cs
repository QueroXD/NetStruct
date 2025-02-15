﻿using System;
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
    public partial class FrmCiudades : Form
    {
        private NetStructEntities NetStructContext { get; set; }
        
        FrmAMBCiudades fAMBCiudades = null;

        public FrmCiudades(NetStructEntities netStructContext)
        {
            InitializeComponent();
            NetStructContext = netStructContext;
        }

        private void FrmCiudades_Load(object sender, EventArgs e)
        {
            getDades();
            iniDgrid();
        }

        private void FrmCiudades_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((FrmMain)this.MdiParent).tancarForm(this);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            fAMBCiudades = new FrmAMBCiudades('A', NetStructContext);
            fAMBCiudades.ShowDialog();

            getDades();

            if (fAMBCiudades.id != "")
            {
                seleccionarFila(fAMBCiudades.id);
            }
            fAMBCiudades = null;
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (dgDadesCiudades.Rows.Count > 0)
            {
                fAMBCiudades = new FrmAMBCiudades('B', NetStructContext);

                fAMBCiudades.id = dgDadesCiudades.SelectedRows[0].Cells["id"].Value.ToString();
                fAMBCiudades.nombre = dgDadesCiudades.SelectedRows[0].Cells["ciudad"].Value.ToString();
                fAMBCiudades.idPais = (int)dgDadesCiudades.SelectedRows[0].Cells["idPais"].Value;

                fAMBCiudades.ShowDialog();

                getDades();

                fAMBCiudades = null;
            }
            else
            {
                MessageBox.Show("No has seleccionado ninguna fila", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgDadesCiudades_DoubleClick(object sender, EventArgs e)
        {
            fAMBCiudades = new FrmAMBCiudades('M', NetStructContext);

            fAMBCiudades.id = dgDadesCiudades.SelectedRows[0].Cells["id"].Value.ToString();
            fAMBCiudades.nombre = dgDadesCiudades.SelectedRows[0].Cells["ciudad"].Value.ToString();
            fAMBCiudades.idPais = (int)dgDadesCiudades.SelectedRows[0].Cells["idPais"].Value;

            fAMBCiudades.ShowDialog();

            getDades();

            if (fAMBCiudades.id != "")
            {
                getDades();
                seleccionarFila(fAMBCiudades.id);
            }

            fAMBCiudades = null;
        }

        private void getDades()
        {
            var qryCiudades = from c in NetStructContext.Ciudades
                              join p in NetStructContext.Paises on c.idPais equals p.idPais
                              join co in NetStructContext.Continente on p.idContinente equals co.idContinente
                              orderby c.idPais
                              select new
                              {
                                  id = c.idCiudad,
                                  ciudad = c.Nombre,
                                  pais = p.Nombre,
                                  continente = co.Nombre,
                                  idPais = p.idPais
                              };

            dgDadesCiudades.DataSource = qryCiudades.ToList();
        }

        private void iniDgrid()
        {
            dgDadesCiudades.Columns["ciudad"].HeaderText = "Ciudad";
            dgDadesCiudades.Columns["pais"].HeaderText = "País";
            dgDadesCiudades.Columns["continente"].HeaderText = "Continente";
            dgDadesCiudades.Columns["id"].Visible = false;
            dgDadesCiudades.Columns["idPais"].Visible = false;
        }

        private void seleccionarFila(string id)
        {
            int i = -1;
            Boolean xbTrobat = false;

            while (!xbTrobat && i < dgDadesCiudades.Rows.Count)
            {
                i++;
                xbTrobat = (dgDadesCiudades.Rows[i].Cells["id"].Value.ToString() == id);
            }
            if (dgDadesCiudades.Rows.Count > 0)
            {
                dgDadesCiudades.Rows[i].Selected = true;
                dgDadesCiudades.FirstDisplayedScrollingRowIndex = i;
            }
        }
    }
}
