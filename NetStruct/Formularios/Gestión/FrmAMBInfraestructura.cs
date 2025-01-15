using NetStruct.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetStruct.Formularios.Gestión
{
    public partial class FrmAMBInfraestructura : Form
    {
        Char op { get; set; } = '\0';
        private NetStructEntities NetStructContext { get; set; }

        String base64Infra = "";
        private String urlWeb { get; set; } = "";

        private String miniaturaWeb { get; set; } = "";
        public String idInfraestructura { get; set; } = "";

        public int awaitTime = 2500;

        ClWeb web = new ClWeb();

        public FrmAMBInfraestructura(Char xop, NetStructEntities xnet)
        {
            InitializeComponent();
            NetStructContext = xnet;
            op = xop;
        }

        private void FrmAMBInfraestructura_Load(object sender, EventArgs e)
        {
            omplirComboContinents();
            omplirComboPaises();
            omplirComboCategoria();
            omplirComboCiudad();

            switch (op)
            {
                case 'A':
                    this.Text = "Alta d'una nova infraestructua"; break;
                case 'B':
                    this.Text = "Eliminar Infraestructura"; break;
                case 'M':
                    this.Text = "Modificacio d'una Infraestructura"; break;
            }

            if (op != 'A')
            {
                getDades();
            }
        }

        private void getDades()
        {
            int id = Convert.ToInt32(idInfraestructura);

            var qryInfraestructura = (from i in NetStructContext.Infraestructura
                                      where i.idInfraestructura == id
                                      select new
                                      {
                                          Nombre = i.Nombre,
                                          Direccion = i.Direccion,
                                          CategoriaTipo = i.CategoriaTipo,
                                          Cordenadas = i.Cordenadas,
                                          Reseña = i.Reseña,
                                          Horario = i.Horario,
                                          TelefonoContacto = i.TelefonoContacto,
                                          EmailContacto = i.EmailContacto,
                                          UrlWeb = i.UrlWeb,
                                          Valoracion = i.Valoracion,
                                          Ciudad = i.Ciudades.Nombre,
                                          Pais = i.Ciudades.Paises.Nombre,
                                          Continente = i.Ciudades.Paises.Continente.Nombre
                                      }).FirstOrDefault();

            if (qryInfraestructura != null)
            {
                tbNom.Text = qryInfraestructura.Nombre;
                tbReseña.Text = qryInfraestructura.Reseña;
                tbWeb.Text = qryInfraestructura.UrlWeb;
                cbContinents.DisplayMember = qryInfraestructura.Continente;
                cbPaises.DisplayMember = qryInfraestructura.Pais;
                cbCiutat.DisplayMember = qryInfraestructura.Ciudad;
                cbCategoria.SelectedValue = qryInfraestructura.CategoriaTipo;
                tbDireccio.Text = qryInfraestructura.Direccion;
                nupValoracio.Value = (decimal)qryInfraestructura.Valoracion;
                tbTelefon.Text = qryInfraestructura.TelefonoContacto;
                tbEmail.Text = qryInfraestructura.EmailContacto;
                tbHorari.Text = qryInfraestructura.Horario;
                tbLatitud.Text = qryInfraestructura.Cordenadas.Split(',')[0];
                tbLongitud.Text = qryInfraestructura.Cordenadas.Split(',')[1];
            }
        }

        private void btFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pbFoto.Image = new Bitmap(opnfd.FileName);
                pbFoto.SizeMode = PictureBoxSizeMode.StretchImage;

                Bitmap bImage = new Bitmap(opnfd.FileName);
                System.IO.MemoryStream ms = new MemoryStream();
                bImage.Save(ms, ImageFormat.Jpeg);
                byte[] byteImage = ms.ToArray();
                base64Infra = Convert.ToBase64String(byteImage);
            }
        }

        private void loadImage()
        {
            byte[] imageBytes = Convert.FromBase64String(miniaturaWeb);
            pbWeb.Image = Image.FromStream(new MemoryStream(imageBytes));
            pbWeb.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btPrevisualizar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var window = System.Diagnostics.Process.Start(tbWeb.Text);
            Thread.Sleep(awaitTime);
            this.Cursor = Cursors.Default;

            if (CaptureMyScreen())
            {
                this.Activate();
                try
                {
                    window.CloseMainWindow();
                }
                catch
                {
                    window.Close();
                }

                MessageBox.Show("Pantalla capturada");
            }
        }

        private bool CaptureMyScreen()
        {
            bool capturada = false;

            try
            {
                SendKeys.SendWait("{F11}");

                Application.DoEvents();

                Thread.Sleep(1000);

                Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);
                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                Size screen = Screen.PrimaryScreen.Bounds.Size;
                captureGraphics.CopyFromScreen(0, 0, 0, 0, screen);

                using (MemoryStream ms = new MemoryStream())
                {
                    pbWeb.Image = captureBitmap;
                    pbWeb.SizeMode = PictureBoxSizeMode.StretchImage;
                    captureBitmap.Save(ms, ImageFormat.Jpeg);
                    byte[] byteImage = ms.ToArray();
                    miniaturaWeb = Convert.ToBase64String(byteImage);
                }

                capturada = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No s'ha pogut fer la captura: " + ex.Message);
            }
            finally
            {
                SendKeys.SendWait("{F11}");
                Application.DoEvents();
            }

            return capturada;
        }

        private void btMaps_Click(object sender, EventArgs e)
        {
            string baseUrl = "https://maps.google.com/?";
            string lat = tbLatitud.Text.ToString().Replace(",", ".");
            string lng = tbLongitud.Text.ToString().Replace(",", ".");
            string zoom = "18"; // Ajusta el zoom según lo que necesites (15-20 es un rango razonable)
            string mapType = "k"; // 'k' es el tipo de mapa satélite

            string url = $"{baseUrl}q={lat},{lng}&t={mapType}&z={zoom}";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            Boolean xb = false;

            if (vDades())
            {
                switch (op)
                {
                    case 'A': xb = altaInfraestructura(); break;
                    case 'B': xb = baixaInfraestructura(); break;
                    case 'M': xb = modificaInfraestructura(); break;
                }
            }

            if (xb)
            {
                this.Close();
            }
        }

        private Boolean vDades()
        {
            Boolean xb = true;

            if ((tbNom.Text.Trim().Length == 0) || (tbReseña.Text.Trim().Length == 0) || (tbWeb.Text.Trim().Length == 0) || (tbEmail.Text.Trim().Length == 0) || (tbTelefon.Text.Trim().Length == 0) || (tbHorari.Text.Trim().Length == 0))
            {
                MessageBox.Show("No es poden deixar dades en blanc", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xb = false;
            }
            return xb;
        }

        private Boolean altaInfraestructura()
        {
            Boolean xb = false;

            try
            {
                Infraestructura infra = new Infraestructura();
                GaleriaDeImagenes galeria = new GaleriaDeImagenes();
                infra.Nombre = tbNom.Text;
                infra.Reseña = tbReseña.Text;
                infra.Direccion = tbDireccio.Text;
                infra.UrlWeb = tbWeb.Text;
                infra.EmailContacto = tbEmail.Text;
                infra.TelefonoContacto = tbTelefon.Text;
                infra.Horario = tbHorari.Text;
                infra.Cordenadas = tbLatitud.Text + "," + tbLongitud.Text;
                infra.MiniaturaWeb = miniaturaWeb;
                infra.idCiudad = (int)cbCiutat.SelectedValue;
                galeria.Imagen = base64Infra;
                galeria.idInfraestructura = infra.idInfraestructura;

                NetStructContext.Infraestructura.Add(infra);
                NetStructContext.GaleriaDeImagenes.Add(galeria);
                ferCanvis();
                xb = true;
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.InnerException.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return (xb);
        }

        private Boolean baixaInfraestructura()
        {
            Boolean xb = false;
            Infraestructura infra = NetStructContext.Infraestructura.Find(Convert.ToInt32(idInfraestructura));

            GaleriaDeImagenes galeria = NetStructContext.GaleriaDeImagenes.Where(g => g.idInfraestructura == infra.idInfraestructura).FirstOrDefault();

            if (infra != null && galeria != null)
            {
                NetStructContext.Infraestructura.Remove(infra);
                NetStructContext.GaleriaDeImagenes.Remove(galeria);
                xb = ferCanvis();
            }

            return (xb);
        }

        private Boolean modificaInfraestructura()
        {
            Boolean xb = false;

            return (xb);
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

        private void omplirComboContinents()
        {
            var qryContinents = from c in NetStructContext.Continente
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
            var qryPaises = from p in NetStructContext.Paises
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
            var qryCategoria = from c in NetStructContext.CategoriaTipo
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

        private void omplirComboCiudad()
        {
            var qryCiudad = from c in NetStructContext.Ciudades
                            where c.idPais == c.Paises.idPais
                            orderby c.idCiudad
                            select new
                            {
                                idCiudad = c.idCiudad,
                                ciudad = c.Nombre
                            };

            cbCiutat.DataSource = qryCiudad.ToList();
            cbCiutat.DisplayMember = "ciudad";
            cbCiutat.ValueMember = "idCiudad";
            cbCiutat.SelectedIndex = 0;
        }
    }
}
