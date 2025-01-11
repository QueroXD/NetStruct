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
                case 'A': this.Text = "Alta de Ciudad"; break;
                case 'M': this.Text = "Modificación de Ciudad"; break;
                case 'B': this.Text = "Baja de Ciudad"; break;
            }
        }

        private void llenarComboPaises()
        {
            // declarem una consulta dels Territoris de la Regió seleccionada
            var qryPaises = from p in NetStructContext.Paises
                            select new { p.idPais, p.Nombre };

            // omplim el combo amb els resultats de la consulta
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
                    case 'A': xb = addTerritori(); break;
                    case 'B': xb = delTerritori(); break;
                    case 'M': xb = updTerritori(); break;
                }
                if (xb)
                {
                    this.Close();
                }
            }
        }

        private bool updTerritori()
        {
            throw new NotImplementedException();
        }

        private Boolean delTerritori()
        {
            Boolean xb = false;
            Ciudades c = NetStructContext.Ciudades.Find(idPais);

            if (c != null)
            {
                NetStructContext.Ciudades.Remove(c);
                xb = ferCanvis();
            }

            return xb;
        }

        private Boolean addTerritori()
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


        // verifiquem les dades introduïdes
        private Boolean vDades()
        {
            Boolean xb = true;

            if ((tbCiudad.Text.Trim().Length == 0) || (cbPais.SelectedItem == null))
            {
                MessageBox.Show("No es poden deixar dades en blanc", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Hauríem de posar un missatge que sigui més entenedor per a l'usuari ja que el missatge de l'excepció és molt tècnic
                // Aquí ho fem així perquè estem fent exemples de desenvolupament i, per a tu, és més interessant veure l'error des d'aquest punt de vista tècnic
                MessageBox.Show(excp.InnerException.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Eliminem l'acció que volíem realitzar perquè, si no ho fem, en el pròxim SaveChanges() es tornarà a provar de fer
                // Això passa perquè les accions es van posant en una cua i no s'eliminen de la cua si no es fa efectiu el canvi.
                // Es pot comprovar que passa això comentant aquestes línies del for, fent una alta d'un ID ja existent i després posar un ID correcte.
                foreach (var accio in NetStructContext.ChangeTracker.Entries())
                {
                    accio.State = EntityState.Detached;
                }

            }
            return xb;
        }
    }
}
