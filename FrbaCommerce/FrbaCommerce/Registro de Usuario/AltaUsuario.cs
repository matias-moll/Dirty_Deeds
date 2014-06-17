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
        Usuario usuarioADarDeAlta { get; set; }
        public int idRolUsuarioAlta { get; set; }
        private int idReferencia;
        private char tipo;

        public AltaUsuario(Usuario p_usuarioADarDeAlta, int idClienteOEmpresa, char tipoUsuario)
        {
            InitializeComponent();
            idReferencia = idClienteOEmpresa;
            tipo = tipoUsuario;
            usuarioADarDeAlta = p_usuarioADarDeAlta;

            // En caso de que ya haya cargado usuario y contrasenia evitamos que tenga que repetirlos.
            teUsuario.Text = p_usuarioADarDeAlta.campoUsuario;
            teContrasenia.Text = p_usuarioADarDeAlta.campoContrasenia;

            cbRoles.DataSource = Rol.upFull();
            cbRoles.DisplayMember = "campoNombre";
            cbRoles.ValueMember = "autoId";
        }

        private void gbAceptar_Click(object sender, EventArgs e)
        {
            int idUsuarioGrabado;
            // Grabamos el usuario y la relacion con el rol.
            if (usuarioADarDeAlta.autoId == 0) // Si el usuario no existia, lo damos de alta
            {
                usuarioADarDeAlta = new Usuario(teUsuario.Text, Hash.getHashSha256(teContrasenia.Text));
                usuarioADarDeAlta.campoIdReferencia = idReferencia;
                usuarioADarDeAlta.campoDiscriminante = tipo.ToString();
                idUsuarioGrabado = usuarioADarDeAlta.save();
            }
            else
            {
                // Si ya existia es un update con el nombre y la clave nuevos
                usuarioADarDeAlta.campoUsuario = teUsuario.Text;
                usuarioADarDeAlta.campoContrasenia = Hash.getHashSha256(teContrasenia.Text);
                usuarioADarDeAlta.campoIdReferencia = idReferencia;
                usuarioADarDeAlta.campoDiscriminante = tipo.ToString();
                idUsuarioGrabado = usuarioADarDeAlta.autoId;
                usuarioADarDeAlta.update();
            }

            Usuario_Rol relacionUsuarioRol = new Usuario_Rol();
            relacionUsuarioRol.campoIdUsuario = idUsuarioGrabado;
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
