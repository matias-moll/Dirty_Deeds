using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ABMs
{
    public partial class AltaGenerico : Form
    {
        ABMEspecifico resolver;

        public AltaGenerico(ABMEspecifico p_resolver)
        {
            InitializeComponent();
            resolver = p_resolver;
        }

        private void AltaGenerico_Load(object sender, EventArgs e)
        {
            this.Text = resolver.GetType().Name.ToString();
            gbDatos.Controls.Add(resolver.getPanelAlta());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
