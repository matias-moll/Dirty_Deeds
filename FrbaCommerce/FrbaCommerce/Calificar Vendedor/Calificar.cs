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
    public partial class Calificar : Form
    {
        public string comentarioObtenido { get; set; }
        public int estrellasObtenidas { get; set; }

        public Calificar()
        {
            InitializeComponent();

            // Armamos el diccionario con las estrellas posibles para llenar la combo.
            List<Estrella> estrellas = new List<Estrella>();
            estrellas.Add(new Estrella(1, "Una (1)"));
            estrellas.Add(new Estrella(2, "Dos (2)"));
            estrellas.Add(new Estrella(3, "Tres (3)"));
            estrellas.Add(new Estrella(4, "Cuatro (4)"));
            estrellas.Add(new Estrella(5, "Cinco (5)"));

            cbEstrellas.DataSource = estrellas;
            cbEstrellas.DisplayMember = "descripcion";
            cbEstrellas.ValueMember = "valor";
        }

        private void gbAceptar_Click(object sender, EventArgs e)
        {
            comentarioObtenido = teComentario.Text;
            estrellasObtenidas = (int)cbEstrellas.SelectedValue;
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
