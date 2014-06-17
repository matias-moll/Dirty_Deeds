using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce
{
    public partial class RealizarOferta : Form
    {
        decimal ofertaMinima;
        public decimal ofertaRealizada { get; set; }

        public RealizarOferta(decimal valorActual)
        {
            InitializeComponent();
            ofertaMinima = Decimal.Add(valorActual, 0.1M);
        }

        private void gbAceptar_Click(object sender, EventArgs e)
        {
            if (dceOferta.Decimal < ofertaMinima)
            {
                MessageBox.Show("No se puede ofertar menos del valor actual de la subasta");
                return;
            }

            ofertaRealizada = dceOferta.Decimal;
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
