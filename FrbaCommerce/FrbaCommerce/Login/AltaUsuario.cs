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
    public partial class AltaUsuario : Form
    {
        public int idRolUsuarioAlta { get; set; }
        private int idUsuario;

        public AltaUsuario(Usuario usuarioADarDeAlta, int idUsuarioAGrabar)
        {
            InitializeComponent();
            idUsuario = idUsuarioAGrabar;

            // En caso de que ya haya cargado usuario y contrasenia evitamos que tenga que repetirlos.
            teUsuario.Text = usuarioADarDeAlta.campoUsuario;
            teContrasenia.Text = usuarioADarDeAlta.campoContrasenia;

            cbRoles.DataSource = Rol.upFull();
            cbRoles.DisplayMember = "campoNombre";
            cbRoles.ValueMember = "autoId";
        }

        private void gbAceptar_Click(object sender, EventArgs e)
        {
            // Grabamos el usuario y la relacion con el rol.
            Usuario usuarioADarDeAlta = new Usuario(teUsuario.Text, teContrasenia.Text);
            usuarioADarDeAlta.campoId = idUsuario;
            usuarioADarDeAlta.save();

            Usuario_Rol relacionUsuarioRol = new Usuario_Rol();
            relacionUsuarioRol.campoIdUsuario = usuarioADarDeAlta.campoId;
            relacionUsuarioRol.campoIdRol = Convert.ToInt32(cbRoles.SelectedValue);
            relacionUsuarioRol.save();

            idRolUsuarioAlta = relacionUsuarioRol.campoIdRol;

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
