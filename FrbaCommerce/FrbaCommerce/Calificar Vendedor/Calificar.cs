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
            Dictionary<int, string> estrellas = new Dictionary<int, string>();
            estrellas.Add(1, "Una (1)");
            estrellas.Add(2, "Dos (2)");
            estrellas.Add(3, "Tres (3)");
            estrellas.Add(4, "Cuatro (4)");
            estrellas.Add(5, "Cinco (5)");

            cbEstrellas.DataSource = estrellas;
            cbEstrellas.DisplayMember = "Value";
            cbEstrellas.ValueMember = "Key";
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
