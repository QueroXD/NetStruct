using NetStruct;
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
    public partial class FrmInfraestructuras : Form
    {
        private NetStructEntities netStructContext { get; set; }

        FrmAMBInfraestructura fAMBInfraestructura = null;

        Boolean bFirst = true;

        public FrmInfraestructuras(NetStructEntities xnet)
        {
            InitializeComponent();
            netStructContext = xnet;
        }

        private void FrmInfraestructuras_Load(object sender, EventArgs e)
        {
            omplirComboContinents();
            omplirComboPaises();
            omplirComboCategoria();
            getDadesSenseFiltre();
            iniDgrid();

            bFirst = false;
        }

        private void ckbFiltres_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFiltres.Checked)
            {
                cbContinents.Enabled = false;
                cbPaises.Enabled = false;
                cbCategoria.Enabled = false;
                getDadesSenseFiltre();
            }
            else
            {
                cbContinents.Enabled = true;
                cbPaises.Enabled = true;
                cbCategoria.Enabled = true;

                if (cbContinents.SelectedIndex != -1)
                {
                    getDadesAmbFiltre((int)cbContinents.SelectedValue,(int)cbPaises.SelectedValue,(int)cbCategoria.SelectedValue);
                }
            }
        }

        private void cbContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bFirst && cbContinents.SelectedIndex != null)
            {
                getDadesAmbFiltre((int)cbContinents.SelectedValue, (int)cbPaises.SelectedValue, (int)cbCategoria.SelectedValue);
            }
        }

        private void cbPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bFirst && cbPaises.SelectedIndex != null)
            {
                getDadesAmbFiltre((int)cbContinents.SelectedValue, (int)cbPaises.SelectedValue, (int)cbCategoria.SelectedValue);
            }
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bFirst && cbCategoria.SelectedIndex != null)
            {
                getDadesAmbFiltre((int)cbContinents.SelectedValue, (int)cbPaises.SelectedValue, (int)cbCategoria.SelectedValue);
            }
        }

        private void getDadesSenseFiltre()
        {
            var qrySenseFiltre = from i in netStructContext.Infraestructura
                                 orderby i.idInfraestructura
                                 select new
                                 {
                                     idInfaestructura = i.idInfraestructura,
                                     nombre = i.Nombre,
                                     direccion = i.Direccion,
                                     coordenadas = i.Cordenadas,
                                     reseña = i.Reseña,
                                     horario = i.Horario,
                                     telefonoContacto = i.TelefonoContacto,
                                     emailContacto = i.EmailContacto,
                                     urlWeb = i.UrlWeb,
                                     valoracion = i.Valoracion,
                                     //categoria = i.CategoriaTipo.Nombre,
                                     ciudad = i.Ciudades.Nombre,
                                     pais = i.Ciudades.Paises.Nombre,
                                     continente = i.Ciudades.Paises.Continente.Nombre
                                 };
            dgDadesInfra.DataSource = qrySenseFiltre.ToList();
        }

        private void getDadesAmbFiltre(int idContinente, int idPaises, int idCategoria)
        {
            var qryAmbFiltre = from i in netStructContext.Infraestructura
                               where i.Ciudades.Paises.idPais == idPaises
                               //where i.CategoriaTipo.idCategoria == idCategoria
                               where i.Ciudades.Paises.Continente.idContinente == idContinente
                               orderby i.idInfraestructura
                               select new
                               {
                                   idInfaestructura = i.idInfraestructura,
                                   nombre = i.Nombre,
                                   direccion = i.Direccion,
                                   coordenadas = i.Cordenadas,
                                   reseña = i.Reseña,
                                   horario = i.Horario,
                                   telefonoContacto = i.TelefonoContacto,
                                   emailContacto = i.EmailContacto,
                                   urlWeb = i.UrlWeb,
                                   valoracion = i.Valoracion,
                                   //categoria = i.CategoriaTipo.Nombre,
                                   ciudad = i.Ciudades.Nombre,
                                   pais = i.Ciudades.Paises.Nombre,
                                   continente = i.Ciudades.Paises.Continente.Nombre
                               };
        }

        private void iniDgrid()
        {
            dgDadesInfra.Columns["idInfaestructura"].Visible = false;
            dgDadesInfra.Columns["nombre"].HeaderText = "Nombre";
            dgDadesInfra.Columns["direccion"].HeaderText = "Direccion";
            dgDadesInfra.Columns["coordenadas"].HeaderText = "Coordenadas";
            dgDadesInfra.Columns["reseña"].HeaderText = "Reseña";
            dgDadesInfra.Columns["horario"].HeaderText = "Horario";
            dgDadesInfra.Columns["telefonoContacto"].HeaderText = "Telefono Contacto";
            dgDadesInfra.Columns["emailContacto"].HeaderText = "Email Contacto";
            dgDadesInfra.Columns["urlWeb"].HeaderText = "Url Web";
            dgDadesInfra.Columns["valoracion"].HeaderText = "Valoracion";
            //dgDadesInfra.Columns["categoria"].HeaderText = "Categoria Tipo";
            dgDadesInfra.Columns["ciudad"].HeaderText = "Ciudad";
            dgDadesInfra.Columns["pais"].HeaderText = "Pais";
            dgDadesInfra.Columns["continente"].HeaderText = "Continente";
        }

        private void omplirComboContinents()
        {
            var qryContinents = from c in netStructContext.Continente
                                orderby c.idContinente
                                select new
                                {
                                    idContinente = c.idContinente,
                                    continente = c.Nombre
                                };

            cbContinents.DataSource = qryContinents.ToList();
            cbContinents.DisplayMember = "continente";
            cbContinents.ValueMember = "idContinente";
            cbContinents.SelectedIndex = 0;
        }

        private void omplirComboPaises()
        {
            var qryPaises = from p in netStructContext.Paises
                            where p.idContinente == p.Continente.idContinente
                            orderby p.idPais
                            select new
                            {
                                idPais = p.idPais,
                                pais = p.Nombre
                            };

            cbPaises.DataSource = qryPaises.ToList();
            cbPaises.DisplayMember = "pais";
            cbPaises.ValueMember = "idPais";
            cbPaises.SelectedIndex = 0;
        }

        private void omplirComboCategoria()
        {
            var qryCategoria = from c in netStructContext.CategoriaTipo
                               orderby c.idCategoria
                               select new
                               {
                                   idCategoria = c.idCategoria,
                                   categoria = c.Nombre
                               };
            
            cbCategoria.DataSource = qryCategoria.ToList();
            cbCategoria.DisplayMember = "categoria";
            cbCategoria.ValueMember = "idCategoria";
            cbCategoria.SelectedIndex = 0;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            fAMBInfraestructura = new FrmAMBInfraestructura('A', netStructContext);
            fAMBInfraestructura.ShowDialog();

            if (ckbFiltres.Checked)
            {
                getDadesSenseFiltre();
            }
            else
            {
                getDadesAmbFiltre((int)cbContinents.SelectedValue, (int)cbPaises.SelectedValue, (int)cbCategoria.SelectedValue);
            }

            if (fAMBInfraestructura.idInfraestructura != "") 
            {
                seleccionarFila(fAMBInfraestructura.idInfraestructura);
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            fAMBInfraestructura = new FrmAMBInfraestructura('B', netStructContext);
            fAMBInfraestructura.idInfraestructura = dgDadesInfra.SelectedRows[0].Cells["idInfaestructura"].Value.ToString();
            fAMBInfraestructura.ShowDialog();

            if (ckbFiltres.Checked)
            {
                getDadesSenseFiltre();
            }
            else
            {
                getDadesAmbFiltre((int)cbContinents.SelectedValue, (int)cbPaises.SelectedValue, (int)cbCategoria.SelectedValue);
            }

            if (fAMBInfraestructura.idInfraestructura != "")
            {
                seleccionarFila(fAMBInfraestructura.idInfraestructura);
            }
        }

        private void dgDadesInfra_DoubleClick(object sender, EventArgs e)
        {
            fAMBInfraestructura = new FrmAMBInfraestructura('M', netStructContext);

            fAMBInfraestructura.idInfraestructura = dgDadesInfra.SelectedRows[0].Cells["idInfaestructura"].Value.ToString();

            fAMBInfraestructura.ShowDialog();

            if (ckbFiltres.Checked)
            {
                getDadesSenseFiltre();
            }
            else
            {
                getDadesAmbFiltre((int)cbContinents.SelectedValue, (int)cbPaises.SelectedValue, (int)cbCategoria.SelectedValue);
            }

            if (fAMBInfraestructura.idInfraestructura != "")
            {
                seleccionarFila(fAMBInfraestructura.idInfraestructura);
            }


            fAMBInfraestructura = null;
        }


        private void seleccionarFila(string id)
        {
            int i = -1;
            Boolean xbTrobat = false;

            while (!xbTrobat && i < dgDadesInfra.Rows.Count)
            {
                i++;
                xbTrobat = (dgDadesInfra.Rows[i].Cells["idInfaestructura"].Value.ToString() == id);
            }
            if (dgDadesInfra.Rows.Count > 0)
            {
                dgDadesInfra.Rows[i].Selected = true;
                dgDadesInfra.FirstDisplayedScrollingRowIndex = i;
            }
        }
    }
}
