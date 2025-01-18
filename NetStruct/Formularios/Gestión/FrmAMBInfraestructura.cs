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
        public String idInfraestructura { get; set; } = "1";

        public int awaitTime = 2500;

        private List<string> listaTemporalDeImagenes = new List<string>();
        
        public FrmAMBInfraestructura(Char xop, NetStructEntities xnet)
        {
            InitializeComponent();
            NetStructContext = xnet;
            op = xop;
        }

        private void FrmAMBInfraestructura_Load(object sender, EventArgs e)
        {
            omplirComboContinents();
            omplirComboPaises((int)cbContinents.SelectedValue);
            omplirComboCategoria();
            omplirComboCiudad((int)cbPaises.SelectedValue);

            switch (op)
            {
                case 'A':
                    this.Text = "Alta d'una nova infraestructua"; break;
                case 'B':
                    this.Text = "Eliminar Infraestructura"; break;
                case 'M':
                    this.Text = "Modificacio d'una Infraestructura"; break;
                case 'C':
                    this.Text = "Consultar Infraestructura"; break;
            }

            if (op != 'A')
            {
                getDades(Convert.ToInt32(idInfraestructura));
                CargarListaGaleria();
            }

            if (op == 'C')
            {
                omplirComboInfraestructura();
                modoLectura();
                tbNom.Visible = false;
                cbInfraestructura.Visible = true;
                cbInfraestructura.Enabled = true;
            }

        }

        private void modoLectura()
        {
            // Abrir el formulario maximizado
            this.WindowState = FormWindowState.Maximized;

            // Ocultar los botones de confirmar y cancelar
            btConfirmar.Visible = false;
            btCancelar.Visible = false;

            // Desactivar todos los lbl, tb, cb, nup y pb
            foreach (Control c in this.Controls)
            {
                if (c is Label || c is TextBox || c is ComboBox || c is NumericUpDown || c is PictureBox)
                {
                    c.Enabled = false;
                }
            }
        }

        private void getDades(int id)
        {
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
                                          MiniaturaWeb = i.MiniaturaWeb,
                                          Ciudad = i.Ciudades.Nombre,
                                          Pais = i.Ciudades.Paises.Nombre,
                                          Continente = i.Ciudades.Paises.Continente.Nombre,
                                          idCiudad = i.idCiudad,
                                          idPais = i.Ciudades.idPais,
                                          idContinente = i.Ciudades.Paises.idContinente
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
                cbPaises.SelectedValue = qryInfraestructura.idPais;
                cbContinents.SelectedValue = qryInfraestructura.idContinente;
                cbCiutat.SelectedValue = qryInfraestructura.idCiudad;
                tbDireccio.Text = qryInfraestructura.Direccion;
                nupValoracio.Value = (decimal)qryInfraestructura.Valoracion;
                tbTelefon.Text = qryInfraestructura.TelefonoContacto;
                tbEmail.Text = qryInfraestructura.EmailContacto;
                tbHorari.Text = qryInfraestructura.Horario;
                tbLatitud.Text = qryInfraestructura.Cordenadas.Split(',')[0];
                tbLongitud.Text = qryInfraestructura.Cordenadas.Split(',')[1];
                pbWeb.Image = Base64ToImage(qryInfraestructura.MiniaturaWeb);
            }

            var qryGaleria = (from g in NetStructContext.GaleriaDeImagenes
                              where g.idInfraestructura == id
                              select new
                              {
                                  Imagen = g.Imagen
                              }).FirstOrDefault();

            if (qryGaleria != null) 
            {
                base64Infra = qryGaleria.Imagen;
                pbFoto.Image = Base64ToImage(base64Infra);
                pbFoto.SizeMode = PictureBoxSizeMode.StretchImage;
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
            }
        }

        // convertir base64 a imagen
        private Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes);
            Image image = Image.FromStream(ms);
            return image;
        }

        // convertir imagen a base64
        private string ImageToBase64(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                return Convert.ToBase64String(imageBytes);
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
                    pbWeb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbWeb.Image = captureBitmap;
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
                Infraestructura infra = new Infraestructura
                {
                    Nombre = tbNom.Text,
                    Reseña = tbReseña.Text,
                    Direccion = tbDireccio.Text,
                    UrlWeb = tbWeb.Text,
                    EmailContacto = tbEmail.Text,
                    TelefonoContacto = tbTelefon.Text,
                    Horario = tbHorari.Text,
                    Valoracion = (decimal)nupValoracio.Value,
                    Cordenadas = tbLatitud.Text + "," + tbLongitud.Text,
                    MiniaturaWeb = miniaturaWeb,
                    idCiudad = (int)cbCiutat.SelectedValue
                };

                NetStructContext.Infraestructura.Add(infra);
                ferCanvis();

                int idInfraestructura = infra.idInfraestructura;

                if (!string.IsNullOrEmpty(base64Infra))
                {
                    GaleriaDeImagenes galeriaBase64Infra = new GaleriaDeImagenes
                    {
                        Imagen = base64Infra,
                        idInfraestructura = idInfraestructura
                    };
                    NetStructContext.GaleriaDeImagenes.Add(galeriaBase64Infra);
                }

                foreach (string base64Image in listaTemporalDeImagenes)
                {
                    GaleriaDeImagenes galeria = new GaleriaDeImagenes
                    {
                        Imagen = base64Image,
                        idInfraestructura = idInfraestructura
                    };
                    NetStructContext.GaleriaDeImagenes.Add(galeria);
                }

                ferCanvis();

                listaTemporalDeImagenes.Clear();

                xb = true;
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.InnerException?.ToString() ?? excp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return xb;
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

            try
            {

                Infraestructura infra = NetStructContext.Infraestructura.Find(Convert.ToInt32(idInfraestructura));
                GaleriaDeImagenes galeria = NetStructContext.GaleriaDeImagenes.Where(g => g.idInfraestructura == infra.idInfraestructura).FirstOrDefault();

                if (infra != null)
                {
                    infra.Nombre = tbNom.Text;
                    infra.Reseña = tbReseña.Text;
                    infra.MiniaturaWeb = ImageToBase64(pbWeb.Image);
                    infra.Direccion = tbDireccio.Text;
                    infra.UrlWeb = tbWeb.Text;
                    infra.EmailContacto = tbEmail.Text;
                    infra.TelefonoContacto = tbTelefon.Text;
                    infra.Valoracion = (decimal)nupValoracio.Value;
                    infra.Horario = tbHorari.Text;
                    infra.Cordenadas = tbLatitud.Text + "," + tbLongitud.Text;
                    infra.idCiudad = (int)cbCiutat.SelectedValue;

                    if (galeria != null)
                    {
                        galeria.Imagen = base64Infra;
                    }

                    var imagenesExistentes = NetStructContext.GaleriaDeImagenes.Where(g => g.idInfraestructura == infra.idInfraestructura && g != galeria).ToList();

                    NetStructContext.GaleriaDeImagenes.RemoveRange(imagenesExistentes);


                    foreach (string base64Image in listaTemporalDeImagenes)
                    {
                        GaleriaDeImagenes nuevaImagen = new GaleriaDeImagenes
                        {
                            Imagen = base64Image,
                            idInfraestructura = infra.idInfraestructura
                        };

                        NetStructContext.GaleriaDeImagenes.Add(nuevaImagen);
                    }

                    xb = ferCanvis();
                    listaTemporalDeImagenes.Clear();
                }
            } catch (Exception excp)
            {
                MessageBox.Show(excp.InnerException?.ToString() ?? excp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void omplirComboPaises(int idContinente)
        {
            var qryPaises = from p in NetStructContext.Paises
                            where p.idContinente == idContinente
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

        private void omplirComboCiudad(int idPais)
        {
            var qryCiudad = from c in NetStructContext.Ciudades
                            where c.idPais == idPais
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

        private void omplirComboInfraestructura()
        {
            cbInfraestructura.SelectedIndexChanged -= cbInfraestructura_SelectedIndexChanged; // Desactivar evento

            var qryInfraestructura = from i in NetStructContext.Infraestructura
                                     orderby i.idInfraestructura
                                     select new
                                     {
                                         idInfraestructura = i.idInfraestructura,
                                         nombre = i.Nombre
                                     };

            cbInfraestructura.DataSource = qryInfraestructura.ToList();
            cbInfraestructura.DisplayMember = "nombre";
            cbInfraestructura.ValueMember = "idInfraestructura";
            cbInfraestructura.SelectedIndex = 0;

            cbInfraestructura.SelectedIndexChanged += cbInfraestructura_SelectedIndexChanged; // Reactivar evento
        }

        private void cbContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbContinents.SelectedValue != null && int.TryParse(cbContinents.SelectedValue.ToString(), out int idContinente))
            {
                omplirComboPaises(idContinente);
            }
        }
        private void cbPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPaises.SelectedValue != null && int.TryParse(cbPaises.SelectedValue.ToString(), out int idPais))
            {
                omplirComboCiudad(idPais);
            }
        }

        private void btCargarGaleria_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                Multiselect = true 
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in openFileDialog.FileNames)
                {
                    try
                    {
                        Bitmap image = new Bitmap(filePath);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            image.Save(ms, ImageFormat.Jpeg);
                            byte[] imageBytes = ms.ToArray();
                            string base64Image = Convert.ToBase64String(imageBytes);

                           listaTemporalDeImagenes.Add(base64Image);

                           actualizarGaleriaVisual(base64Image);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MessageBox.Show("Imágenes cargadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void actualizarGaleriaVisual(string base64Image)
        {
            PictureBox pictureBox = new PictureBox
            {
                Image = Base64ToImage(base64Image),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 100,
                Height = 100,
                Margin = new Padding(5)
            };

            flpGaleria.Controls.Add(pictureBox);
        }

        private void CargarListaGaleria()
        {
            try
            {
                listaTemporalDeImagenes.Clear();

                int id = Convert.ToInt32(idInfraestructura);

                var imagenesGaleria = (from g in NetStructContext.GaleriaDeImagenes
                                       where g.idInfraestructura == id
                                       orderby g.idImagen
                                       select g.Imagen)
                                      .Skip(1) // Filtra a partir de la segunda imagen
                                      .ToList();

                listaTemporalDeImagenes.AddRange(imagenesGaleria);

                foreach (string base64Image in imagenesGaleria)
                {
                    actualizarGaleriaVisual(base64Image);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la galería de imágenes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbInfraestructura_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cbInfraestructura.SelectedValue);
            idInfraestructura = id.ToString();
            getDades(id);

            flpGaleria.Controls.Clear();
            listaTemporalDeImagenes.Clear();
            CargarListaGaleria();
        }
    }
}