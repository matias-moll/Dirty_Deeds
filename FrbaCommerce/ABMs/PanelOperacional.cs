using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ABMs
{
    public partial class PanelOperacional : Form
    {
        public PanelOperacional()
        {
            InitializeComponent();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            ABMGenerico abmRoles = new ABMGenerico(new Roles());
            abmRoles.Show(this);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ABMGenerico abmClientes = new ABMGenerico(new Clientes());
            abmClientes.Show(this);
        }

        private void btnVisibilidades_Click(object sender, EventArgs e)
        {
            ABMGenerico abmVisibilidades = new ABMGenerico(new Visibilidades());
            abmVisibilidades.Show(this);
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            ABMGenerico abmEmpresas = new ABMGenerico(new Empresas());
            abmEmpresas.Show(this);
        }

        private void btnRubros_Click(object sender, EventArgs e)
        {
            ABMGenerico abmRubros = new ABMGenerico(new Rubros());
            abmRubros.Show(this);
        }

        private void btnLocalidades_Click(object sender, EventArgs e)
        {
            ABMGenerico abmLocalidades = new ABMGenerico(new Localidades());
            abmLocalidades.Show(this);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            ABMGenerico manejoUsuarios = new ABMGenerico(new Usuarios(), ABMGenerico.modoPantalla.bajaLogicaYRecupero);
            manejoUsuarios.Show(this);
        }

    }
}
