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
    public partial class ABMGenerico : Form
    {
        ABMEspecifico resolver;
        Panel pnFiltros;

        public ABMGenerico(ABMEspecifico resolverEspecifico)
        {
            InitializeComponent();
            resolver = resolverEspecifico;
        }

        private void ABMGenerico_Load(object sender, EventArgs e)
        {
            // Cargamos el titulo y el panel especificos para completar nuestro form de ABM
            this.Text = resolver.GetType().Name.ToString();
            pnFiltros = resolver.getPanel();
            this.gbFiltros.Controls.Add(pnFiltros);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiamos el texto de todos los textbox del agrupador de filtros. Y luego la grilla.
            foreach(Control unControl in gbFiltros.Controls)
            {
                if (unControl.GetType() == typeof(TextBox))
                    unControl.Text = "";
            }
            dgvGrilla.DataSource = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvGrilla.DataSource = resolver.ejecutarBusqueda();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            resolver.alta(this);
            this.gbFiltros.Controls.Remove(pnFiltros);
            pnFiltros = resolver.getPanel();
            this.gbFiltros.Controls.Add(pnFiltros);
        }


    }
}
