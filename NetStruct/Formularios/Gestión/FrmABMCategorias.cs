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
    public partial class FrmABMCategorias : Form
    {
        Char op { get; set; } = '\0';

        private NetStructEntities NetStructContext { get; set; }
        public String id { get; set; } = "";
        public String nombre { get; set; } = "";

        public FrmABMCategorias(Char xop, NetStructEntities xnet)
        {
            InitializeComponent();
            NetStructContext = xnet;
            op = xop;
        }

        private void FrmABMCategorias_Load(object sender, EventArgs e)
        {
            switch (op)
            {
                case 'A': this.Text = "Dar de alta una Categoria"; break;
                case 'M': this.Text = "Editar informacion de una Categoria"; break;
                case 'B': this.Text = "Dar de baja una Categoria"; break;
            }

            if (op != 'A')
            {
                tbCategoria.Text = nombre;
            }

            if (op == 'B')
            {
                tbCategoria.Enabled = false;
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Boolean xb = false;
            if (vDades())
            {
                switch (op)
                {
                    case 'A': xb = addCategoria(); break;
                    case 'B': xb = delCategoria(); break;
                    case 'M': xb = updCategoria(); break;
                }
                if (xb)
                {
                    this.Close();
                }
            }
        }

        private Boolean updCategoria()
        {
            Boolean xb = false;
            CategoriaTipo ct = NetStructContext.CategoriaTipo.Find(Convert.ToInt32(id));

            if (ct != null)
            {
                ct.Nombre = tbCategoria.Text.Trim();
                xb = ferCanvis();
            }

            return xb;
        }

        private Boolean delCategoria()
        {
            Boolean xb = false;
            CategoriaTipo ct = NetStructContext.CategoriaTipo.Find(Convert.ToInt32(id));

            if (ct != null)
            {
                NetStructContext.CategoriaTipo.Remove(ct);
                xb = ferCanvis();
            }

            return xb;
        }

        private Boolean addCategoria()
        {
            Boolean xb = false;
            CategoriaTipo ct = new CategoriaTipo();

            if (vDades())
            {
                ct.Nombre = tbCategoria.Text.Trim();
                NetStructContext.CategoriaTipo.Add(ct);

                if (ferCanvis())
                {
                    id = ct.idCategoria.ToString();
                    xb = true;
                }
                else 
                {
                    id = "";
                }
            }

            return xb;
        }

        private Boolean vDades()
        {
            Boolean xb = true;

            if ((tbCategoria.Text.Trim().Length == 0))
            {
                MessageBox.Show("No se pueden dejar espacios en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xb = false;
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

        private void btNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
