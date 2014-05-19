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
    class Visibilidades : ABMEspecifico
    {
        TextBox tbCodigo = new TextBox();
        TextBox tbDescripcion = new TextBox();
        TextBox tbPrecio = new TextBox();
        TextBox tbPorcentaje = new TextBox();

        public override DataTable ejecutarBusqueda()
        {
            return null;
        }

        public override void grabarAlta()
        {
            // Creamos el rol y lo mandamos a grabar.
            Visibilidad unRol = new Visibilidad(Convert.ToInt32(tbCodigo.Text), tbDescripcion.Text, 
                                                Convert.ToDouble(tbPrecio.Text), Convert.ToDouble(tbPorcentaje.Text));
            unRol.save();
        }

        public override Panel getPanel(Size tamañoPanel)
        {
            PanelBuilder builder = new PanelBuilder(tamañoPanel, PanelBuilder.Alineacion.Horizontal);
            builder.AddControlWithLabel("Código", tbCodigo)
                   .AddControlWithLabel("Descripcion", tbDescripcion)
                   .AddControlWithLabel("Precio", tbPrecio)
                   .AddControlWithLabel("Porcentaje", tbPorcentaje)
                   .centrarControlesEnElPanel();

            return builder.getPanel;
        }
    }
}
