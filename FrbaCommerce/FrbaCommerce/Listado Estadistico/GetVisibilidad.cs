using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;

namespace FrbaCommerce
{
    public partial class GetVisibilidad : Form
    {
        public int idVisibilidad { get; set; }

        public GetVisibilidad()
        {
            InitializeComponent();

            List<Visibilidad> visibilidad = new List<Visibilidad>();
            visibilidad = Visibilidad.upFull();
            cbVisibilidad.DataSource = visibilidad;
            cbVisibilidad.DisplayMember = "campoDescripcion";
            cbVisibilidad.ValueMember = "autoId";
        }

        private void gbAceptar_Click(object sender, EventArgs e)
        {
            idVisibilidad = (int)cbVisibilidad.SelectedValue;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void gbCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
