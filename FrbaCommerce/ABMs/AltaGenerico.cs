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
        private int idClaveObjeto;

        public AltaGenerico(ABMEspecifico p_resolver, int idClaveObjetoModificacion)
        {
            InitializeComponent();
            resolver = p_resolver;
            idClaveObjeto = idClaveObjetoModificacion;
        }

        private void AltaGenerico_Load(object sender, EventArgs e)
        {
            this.Text = resolver.GetType().Name.ToString();
            gbDatos.Controls.Add(resolver.getPanelAlta());
            if (idClaveObjeto != 0)
                resolver.cargarTusDatos(idClaveObjeto);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
