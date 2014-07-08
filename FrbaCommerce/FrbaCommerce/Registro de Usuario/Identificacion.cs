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
    public partial class Identificacion : Form
    {
        public int idRolUsuario { get; set; }

        public Identificacion()
        {
            InitializeComponent();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            (new UsuariosClientes()).alta(this);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            (new UsuariosEmpresas()).alta(this);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
