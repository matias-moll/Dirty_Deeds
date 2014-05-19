using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using Dominio;

namespace ABMs
{
    class Rubros : ABMEspecifico
    {
        TextBox tbId = new TextBox();
        TextBox tbDescripcion = new TextBox();

        public override DataTable ejecutarBusqueda()
        {
            return null;
        }


        public override void grabarAlta()
        {
            // Creamos el rol y lo mandamos a grabar.
            Rubro unRol = new Rubro(Convert.ToInt32(tbId.Text), tbDescripcion.Text);
            unRol.save();
        }

        public override Panel getPanel(Size tamañoPanel)
        {
            PanelBuilder builder = new PanelBuilder(tamañoPanel, PanelBuilder.Alineacion.Horizontal);
            builder.AddControlWithLabel("Identificador", tbId)
                   .AddControlWithLabel("Descripcion", tbDescripcion)
                   .centrarControlesEnElPanel();

            return builder.getPanel;
        }
    }
}
