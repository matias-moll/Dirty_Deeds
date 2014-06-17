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
    public partial class DatosParaFactura : Form
    {
        public int cantidadPublicaciones { get; set; }
        public int idFormaDePago { get; set; }

        public DatosParaFactura()
        {
            InitializeComponent();

            // Cargamos la combo de forma de pago.
            cbFormaDePago.DataSource = FormaPago.upFull();
            cbFormaDePago.DisplayMember = "campoDescripcion";
            cbFormaDePago.ValueMember = "autoId";
        }

        private void gbAceptar_Click(object sender, EventArgs e)
        {
            cantidadPublicaciones = neCantPublicaciones.Numero;
            idFormaDePago = (int)cbFormaDePago.SelectedValue;

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
