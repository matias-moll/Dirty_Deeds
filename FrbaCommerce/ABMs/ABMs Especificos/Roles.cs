using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Dominio;
using System.Drawing;

namespace ABMs
{
    class Roles : ABMEspecifico
    {
        TextBox tbId = new TextBox();
        TextBox tbNombre = new TextBox();
        CheckBox cbBorrado = new CheckBox();

        public override DataTable ejecutarBusqueda()
        {
            return null;
        }

        public override void alta(Form parent)
        {
            // Disparamos el form de alta generico pasandole como resolver a nosotros mismos.
            AltaGenerico frmAltaRol = new AltaGenerico(this);
            frmAltaRol.ShowDialog(parent);

            // Si confirmo el alta
            if (frmAltaRol.DialogResult == DialogResult.OK)
            {
                // Creamos el rol y lo mandamos a grabar.
                Rol unRol = new Rol(Convert.ToInt32(tbId.Text), tbNombre.Text, cbBorrado.Checked);
                unRol.save();
                MessageBox.Show("Se ha grabado exitosamente el Rol");
            }
        }
        public override Panel getPanel(Size tamañoPanel)
        {
            PanelBuilder builder = new PanelBuilder(tamañoPanel, PanelBuilder.Alineacion.Horizontal);
            builder.AddControlWithLabel("Identificador", tbId)
                   .AddControlWithLabel("Nombre", tbNombre)
                   .AddControlWithLabel("Borrado", cbBorrado)
                   .centrarControlesEnElPanel();

            return builder.getPanel;
        }
    }
}
