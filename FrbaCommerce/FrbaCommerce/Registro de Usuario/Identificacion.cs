using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using ABMs;

namespace FrbaCommerce
{
    public partial class Identificacion : Form
    {
        Usuario usuario;

        public int idRolUsuario { get; set; }

        public Identificacion(Usuario usuarioACrear)
        {
            InitializeComponent();
            usuario = usuarioACrear;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            ABMGenerico seleccion = new ABMGenerico(new Clientes(), ABMGenerico.modoPantalla.seleccion);
            procesoAltaUsuario(seleccion, 'C');
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            ABMGenerico seleccion = new ABMGenerico(new Empresas(), ABMGenerico.modoPantalla.seleccion);
            procesoAltaUsuario(seleccion, 'E');
        }

        private void procesoAltaUsuario(ABMGenerico seleccion, char tipoUsuario)
        {
            seleccion.ShowDialog(this);

            if (seleccion.DialogResult == DialogResult.OK)
            {
                // Si ya existe un usuario para ese cliente/empresa elegido, entonces le cargamos el auto id para que luego
                // se actualice en vez de darse de alta.
                Usuario usuarioParaVerificarExistencia = Usuario.checkAndGetUserByIdReferencia(seleccion.idClavePrimariaObjetoSeleccionado, tipoUsuario);
                if (usuarioParaVerificarExistencia != null)
                    usuario.autoId = usuarioParaVerificarExistencia.autoId;

                AltaUsuario altaUsuario = new AltaUsuario(usuario, seleccion.idClavePrimariaObjetoSeleccionado, tipoUsuario);
                altaUsuario.ShowDialog(this);

                if (altaUsuario.DialogResult == DialogResult.OK)
                {
                    idRolUsuario = altaUsuario.idRolUsuarioAlta;

                    MessageBox.Show("Su usuario ha sido dado de alta exitosamente! Ahora podrá ingresar al sistema");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
