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
    public partial class ResponderPregunta : Form
    {
        public string respuestaObtenida { get; set; }

        public ResponderPregunta(string pregunta)
        {
            InitializeComponent();
            tePregunta.Text = pregunta;
        }

        private void gbAceptar_Click(object sender, EventArgs e)
        {
            if (teRespuesta.Text.Trim() == "")
            {
                MessageBox.Show("No puede confirmar con una respuesta vacía");
                return;
            }

            respuestaObtenida = teRespuesta.Text;
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
