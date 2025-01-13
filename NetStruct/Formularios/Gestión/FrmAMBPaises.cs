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

        private NetStructEntities NetStructContext {  get; set; }

        public String idPais { get; set; } = "";
        public String continente { get; set; } = "";
        public int idContinente { get; set; }

        public FrmAMBPaises(Char xop, NetStructEntities xnet)
        {
            InitializeComponent();
            NetStructContext = xnet;
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

            tbPais.Text = idPais;
            if (op == 'A')
            {
                cbContinente.SelectedIndex = 0;
            }
            else
            {
                cbContinente.SelectedValue = idContinente;
            }

            tbPais.Enabled = (op != 'B');
            cbContinente.Enabled = (op != 'B');
        }

        private void omplirComboContinents()
        {
            var qryContinents = from c in NetStructContext.Continente
                                orderby c.idContinente
                                select new
                                {
                                    idContinent = c.idContinente,
                                    Contienente = c.Nombre
                                };

            cbContinente.DataSource = qryContinents.ToList();
            cbContinente.DisplayMember = "Contienente";
            cbContinente.ValueMember = "idContinent";
            cbContinente.SelectedIndex = 0;
            if (cbContinente.Items.Count > 0)
            {
                cbContinente.SelectedIndex = 0;
            }
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
                MessageBox.Show("No se pueden dejar datos en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                NetStructContext.Paises.Add(p);

                if(ferCanvis())
                {
                    idPais = tbPais.Text.Trim();
                    xb = true;
                }
                else
                {
                    idPais = "";
                }
            }
            return xb;
        }

        private Boolean updPais()
        {
            Boolean xb = false;
            Paises p = NetStructContext.Paises.Find(tbPais.Text.Trim());

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
            Paises p = NetStructContext.Paises.Find(tbPais.Text.Trim());

            if (p != null)
            {
                NetStructContext.Paises.Remove(p);
                xb = ferCanvis();
            }
            return xb;
        }

        private Boolean ferCanvis()
        {
            Boolean xb = false;
            try
            {
                NetStructContext.SaveChanges();
                xb = true;
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.InnerException.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                foreach (var accio in NetStructContext.ChangeTracker.Entries())
                {
                    accio.State = EntityState.Detached;
                }

            }
            return xb;
        }
    }
}
