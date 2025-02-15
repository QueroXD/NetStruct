﻿using System;
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
    public partial class FrmAMBCiudades : Form
    {
        Char op { get; set; } = '\0';

        private NetStructEntities NetStructContext { get; set; }
        public String id { get; set; } = "";
        public String nombre { get; set; } = "";
        public int idPais { get; set; }

        public FrmAMBCiudades(Char xop, NetStructEntities xnet)
        {
            InitializeComponent();
            NetStructContext = xnet;
            op = xop;
        }

        private void FrmAMBCiudades_Load(object sender, EventArgs e)
        {
            llenarComboPaises();
            switch (op)
            {
                case 'A': this.Text = "Dar de alta una Ciudad"; break;
                case 'M': this.Text = "Editar informacion de una Ciudad"; break;
                case 'B': this.Text = "Dar de baja una Ciudad"; break;
            }

            if(op != 'A')
            {
                tbCiudad.Text = nombre;
                cbPais.SelectedValue = idPais;
            }

            if (op == 'B')
            {
                tbCiudad.Enabled = false;
                cbPais.Enabled = false;
            }
        }

        private void llenarComboPaises()
        {
            var qryPaises = from p in NetStructContext.Paises
                            select new { p.idPais, p.Nombre };

            cbPais.DataSource = qryPaises.ToList();
            cbPais.DisplayMember = "nombre";
            cbPais.ValueMember = "idPais";
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Boolean xb = false;
            if (vDades())
            {
                switch (op)
                {
                    case 'A': xb = addCiudad(); break;
                    case 'B': xb = delCiudad(); break;
                    case 'M': xb = updCiudad(); break;
                }
                if (xb)
                {
                    this.Close();
                }
            }
        }

        private Boolean updCiudad()
        {
            Boolean xb = false;
            Ciudades c = NetStructContext.Ciudades.Find(Convert.ToInt32(id));

            if (c != null)
            {
                c.Nombre = tbCiudad.Text.Trim();
                c.idPais = (int)cbPais.SelectedValue;
                xb = ferCanvis();
            }
            return xb;
        }

        private Boolean delCiudad()
        {
            Boolean xb = false;
            Ciudades c = NetStructContext.Ciudades.Find(Convert.ToInt32(id));

            if (c != null)
            {
                NetStructContext.Ciudades.Remove(c);
                xb = ferCanvis();
            }

            return xb;
        }

        private Boolean addCiudad()
        {
            Boolean xb = false;
            Ciudades c = new Ciudades();

            if (vDades())
            {
                c.Nombre = tbCiudad.Text.Trim();
                c.idPais = (int)cbPais.SelectedValue;
                NetStructContext.Ciudades.Add(c);

                if (ferCanvis())
                {
                    id = c.idCiudad.ToString();
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

            if ((tbCiudad.Text.Trim().Length == 0) || (cbPais.SelectedItem == null))
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
