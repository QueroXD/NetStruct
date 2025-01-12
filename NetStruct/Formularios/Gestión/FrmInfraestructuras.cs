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
        private NetStructEntities NetStructContext { get; set; }

        public FrmInfraestructuras(NetStructEntities netStructContext)
        {
            InitializeComponent();
            NetStructContext = netStructContext;
        }

        private void FrmInfraestructuras_Load(object sender, EventArgs e)
        {

        }
    }
}
