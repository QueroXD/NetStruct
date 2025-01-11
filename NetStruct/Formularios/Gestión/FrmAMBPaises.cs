using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetStruct.Formularios.Gestión
{
    public partial class FrmAMBPaises : Form
    {
        Char op { get; set; } = '\0';

        private NetStructEntities netStructContext {  get; set; }

        public String pais { get; set; } = "";
        public String continente { get; set; } = "";

        public FrmAMBPaises(Char xop, NetStructEntities xNetStruct)
        {
            InitializeComponent();
            netStructContext = xNetStruct;
            op = xop;
        }

        private void FrmAMBPaises_Load(object sender, EventArgs e)
        {
            omplirComboContinents();

            switch (op)
            {
                case 'A': this.Text = "Alta d'un nou Pais"; break;
                case 'B': this.Text = "Eliminar Pais"; break;
                case 'M': this.Text = "Modificacio d'un Pais"; break;
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

            cbContinente.DataSource = qryContinents.ToList();
            cbContinente.DisplayMember = "nom";
            cbContinente.ValueMember = "id";
            cbContinente.SelectedIndex = 0;
        }

        private void btNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Boolean xb = false;

            if (vDades())
            {
                switch (op)
                {
                    case 'A': xb = addPais(); break;
                    case 'B': xb = delPais(); break;
                    case 'M': xb = updPais(); break;
                }
                if (xb)
                {
                    this.Close();
                }
            }
        }

        private Boolean vDades()
        {
            Boolean xb = true;

            if ((tbPais.Text.Trim().Length == 0) || (cbContinente.SelectedItem == null))
            {
                MessageBox.Show("No es poden deixar dades en blanc", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xb = false;
            }
            return xb;
        }

        private Boolean addPais()
        {
            Boolean xb = false;
            Paises p = new Paises();

            if(vDades())
            {
                p.Nombre = tbPais.Text;
                netStructContext.Paises.Add(p);

                if(ferCanvis())
                {
                    pais = tbPais.Text.Trim();
                    xb = true;
                }
                else
                {
                    pais = "";
                }
            }
            return xb;
        }

        private Boolean updPais()
        {
            Boolean xb = false;
            Paises p = netStructContext.Paises.Find(tbPais.Text.Trim());

            if (p != null)
            {
                p.Nombre = tbPais.Text.Trim();
                xb = ferCanvis();
            }
            return xb;
        }

        private Boolean delPais()
        {
            Boolean xb = false;
            Paises p = netStructContext.Paises.Find(tbPais.Text.Trim());

            if (p != null)
            {
                netStructContext.Paises.Remove(p);
                xb = ferCanvis();
            }
            return xb;
        }

        private Boolean ferCanvis()
        {
            Boolean xb = false;
            try
            {
                netStructContext.SaveChanges();
                xb = true;
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.InnerException.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                foreach (var accio in netStructContext.ChangeTracker.Entries())
                {
                    accio.State = EntityState.Detached;
                }

            }
            return xb;
        }
    }
}
