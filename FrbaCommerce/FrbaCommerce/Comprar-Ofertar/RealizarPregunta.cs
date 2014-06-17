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
    public partial class RealizarPregunta : Form
    {
        Publicacion_Pregunta pregunta;

        public RealizarPregunta(int codPublicacion)
        {
            InitializeComponent();
            // Inicializamos la pregunta.
            pregunta = new Publicacion_Pregunta(codPublicacion);
            pregunta.campoNumPregunta = pregunta.getSiguienteNroPreguntaFromPrototype();
        }

        private void gbAceptar_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text.Trim() == "")
            {
                MessageBox.Show("No puede realizar una pregunta vacía");
                return;
            }

            pregunta.campoPregunta = textEdit1.Text;
            pregunta.save();

            MessageBox.Show("Su pregunta fue enviada al vendedor exitosamente!");

            this.Close();
        }

        private void gbCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
