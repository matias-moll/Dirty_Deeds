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
    public partial class SeleccionRol : Form
    {
        public Rol rolElegido { get; set; }

        public SeleccionRol(List<Rol> rolesPosibles)
        {
            InitializeComponent();

            // Cargamos la lista de roles.
            cbRoles.DataSource = rolesPosibles;
            cbRoles.DisplayMember = "campoNombre";
            cbRoles.ValueMember = "autoId";
        }

        private void gbAceptar_Click(object sender, EventArgs e)
        {
            // Cargamos el rol elegido, resultado exitoso y cerramos la ventana.
            this.DialogResult = DialogResult.OK;
            rolElegido = (Rol)cbRoles.SelectedItem;
            this.Close();
        }

        private void gbCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }



    }
}
