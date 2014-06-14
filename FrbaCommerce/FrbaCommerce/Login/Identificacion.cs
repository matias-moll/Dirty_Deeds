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
            procesoAltaUsuario(seleccion);
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            ABMGenerico seleccion = new ABMGenerico(new Empresas(), ABMGenerico.modoPantalla.seleccion);
            procesoAltaUsuario(seleccion);
        }

        private void procesoAltaUsuario(ABMGenerico seleccion)
        {
            seleccion.ShowDialog(this);

            if (seleccion.DialogResult == DialogResult.OK)
            {
                AltaUsuario altaUsuario = new AltaUsuario(usuario, seleccion.idClavePrimariaObjetoSeleccionado);
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
