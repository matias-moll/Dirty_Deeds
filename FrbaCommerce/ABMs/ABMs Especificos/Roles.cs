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

        public override void grabarAlta()
        {
            // Creamos el rol y lo mandamos a grabar.
            Rol unRol = new Rol(Convert.ToInt32(tbId.Text), tbNombre.Text, cbBorrado.Checked);
            unRol.save();
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
