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

        public int awaitTime = 3500;

        ClWeb web = new ClWeb();

        public FrmAMBInfraestructura(Char xop, NetStructEntities xnet)
        {
            InitializeComponent();
            NetStructContext = xnet;
            op = xop;
        }

        private void FrmAMBInfraestructura_Load(object sender, EventArgs e)
        {
            switch (op)
            {
                case 'A':
                    this.Text = "Alta d'una nova infraestructua"; break;
                case 'B':
                    this.Text = "Eliminar Infraestructura"; break;
                case 'M':
                    this.Text = "Modificacio d'una Infraestructura"; break;
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
            Boolean capturada = false;

            try
            {
                Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);
                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                Size screen = Screen.PrimaryScreen.Bounds.Size;
                Size screen2 = new Size(20000, 15000);

                captureGraphics.CopyFromScreen(0, 0, 0, 0, screen2);

                System.IO.MemoryStream ms = new MemoryStream();
                pbWeb.Image = captureBitmap;
                pbWeb.SizeMode = PictureBoxSizeMode.StretchImage;
                captureBitmap.Save(ms, ImageFormat.Jpeg);
                byte[] byteImage = ms.ToArray();
                miniaturaWeb = Convert.ToBase64String(byteImage);
                capturada = true;
            }
            catch
            {
                MessageBox.Show("No s'ha pogut fer la captura");
            }

            return capturada;
        }

        /* Prueba esto si funciona te dejo la latitud y la longitud para que lo pruebes, es de la sagrada familia se supone que deberia funcionar 41.40411298539085, 2.1749749128010936 */
        private void btMaps_Click(object sender, EventArgs e)
        {
            string baseUrl = "https://maps.google.com/?";
            string lat = nLatitud.Value.ToString().Replace(",", ".");
            string lng = nLongitud.Value.ToString().Replace(",", ".");
            string zoom = "18"; // Ajusta el zoom según lo que necesites (15-20 es un rango razonable)
            string mapType = "k"; // 'k' es el tipo de mapa satélite

            string url = $"{baseUrl}q={lat},{lng}&t={mapType}&z={zoom}";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true // Esto es importante para evitar problemas en .NET Core/Framework
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

            return (xb);
        }

        private Boolean baixaInfraestructura()
        {
            Boolean xb = false;

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
    }
}
