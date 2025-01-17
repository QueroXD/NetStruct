using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetStruct.Formularios
{
    public partial class FrmGaleria : Form
    {
        private NetStructEntities netStructContext { get; set; }

        public FrmGaleria(NetStructEntities xnet)
        {
            InitializeComponent();
            netStructContext = xnet;
        }

        private void FrmGaleria_Load(object sender, EventArgs e)
        {
            // Configuración inicial
            LlenarComboBox(); // Muestra todas las imágenes al cargar el formulario
            CargarImagenes(); // Carga las infraestructuras en el ComboBox

            // Configurar eventos del CheckBox y ComboBox
            chkTodos.CheckedChanged += chkTodos_CheckedChanged;
            cbInfraestructuras.SelectedIndexChanged += cbInfraestructuras_SelectedIndexChanged;
        }

        private void LlenarComboBox()
        {
            var qryInfraestru = from infra in netStructContext.Infraestructura
                                orderby infra.idInfraestructura
                                select new
                                {
                                    idInfraestructura = infra.idInfraestructura,
                                    nombre = infra.Nombre
                                };
            cbInfraestructuras.DataSource = qryInfraestru.ToList();
            cbInfraestructuras.DisplayMember = "nombre";
            cbInfraestructuras.ValueMember = "idInfraestructura";
            cbInfraestructuras.SelectedIndex = 0;
        }

        private void CargarImagenes(int? idInfraestructura = null)
        {
            // Limpiar el FlowLayoutPanel antes de agregar nuevas imágenes
            flowLayoutPanel1.Controls.Clear();

            // Usar el contexto existente
            var context = netStructContext;

            var qryImagenes = from img in context.GaleriaDeImagenes
                              where idInfraestructura == null || img.idInfraestructura == idInfraestructura
                              select img.Imagen;

            var imagenes = qryImagenes.ToList();

            // Crear y mostrar cada imagen en el FlowLayoutPanel
            foreach (var base64String in imagenes)
            {
                try
                {
                    byte[] imageBytes = Convert.FromBase64String(base64String);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        Image img = Image.FromStream(ms);

                        PictureBox pictureBox = new PictureBox
                        {
                            Image = img,
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Size = new Size(200, 200),
                            Margin = new Padding(10),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        flowLayoutPanel1.Controls.Add(pictureBox);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al procesar una imagen: {ex.Message}");
                }
            }
        }





        private void cbInfraestructuras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbInfraestructuras.SelectedValue != null && !chkTodos.Checked)
            {
                int idInfra = Convert.ToInt32(cbInfraestructuras.SelectedValue);
                CargarImagenes(idInfra); // Filtrar por infraestructura seleccionada
            }
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                // Mostrar todas las imágenes y deshabilitar el ComboBox
                cbInfraestructuras.Enabled = false;
                CargarImagenes(); // Sin filtrar
            }
            else
            {
                // Habilitar el ComboBox para filtrar por infraestructura
                cbInfraestructuras.Enabled = true;

                // Si hay una infraestructura seleccionada, mostrar sus imágenes
                if (cbInfraestructuras.SelectedValue != null)
                {
                    int idInfra = Convert.ToInt32(cbInfraestructuras.SelectedValue);
                    CargarImagenes(idInfra);
                }
            }
        }
    }
}
