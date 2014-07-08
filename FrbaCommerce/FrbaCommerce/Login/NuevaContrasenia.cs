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
    public partial class NuevaContrasenia : Form
    {
        Usuario usuarioActualizado;

        public NuevaContrasenia(Usuario usuarioACambiarClave)
        {
            InitializeComponent();
            usuarioActualizado = usuarioACambiarClave;
        }

        private void gbAceptar_Click(object sender, EventArgs e)
        {
            if (teContrasenia.Text.Trim() == "")
            {
                MessageBox.Show("No se puede ingresar una contraseña vacia");
                return;
            }

            usuarioActualizado.campoContrasenia = Hash.getHashSha256(teContrasenia.Text.Trim());
            usuarioActualizado.campoIntentosFallidos = 0;
            usuarioActualizado.update();
            MessageBox.Show("Su contraseña fue actualizada exitosamente! Ahora podrá pasar el proceso login con su nueva contraseña");
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
