using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using Dominio;
using TNGS.NetControls;

namespace ABMs
{
    class Visibilidades : ABMEspecifico
    {
        TextEdit teDescripcion = new TextEdit();
        DecimalEdit dcePrecio = new DecimalEdit();
        NumberEdit nePorcentaje = new NumberEdit();

        public override DataTable ejecutarBusqueda()
        {
            // Creamos el rol y lo mandamos a grabar.
            Visibilidad unRol = new Visibilidad(teDescripcion.Text, dcePrecio.Decimal, nePorcentaje.Numero);
            return unRol.upFullByPrototype();
        }

        public override void grabarAlta()
        {
            // Creamos el rol y lo mandamos a grabar.
            Visibilidad unRol = new Visibilidad(teDescripcion.Text, dcePrecio.Decimal, nePorcentaje.Numero);
            unRol.save();
        }

        public override Panel getPanel(Size tamañoPanel)
        {
            PanelBuilder builder = new PanelBuilder(tamañoPanel, PanelBuilder.Alineacion.Horizontal);
            builder.AddControlWithLabel("Descripcion", teDescripcion)
                   .AddControlWithLabel("Precio", dcePrecio)
                   .AddControlWithLabel("Porcentaje", nePorcentaje)
                   .centrarControlesEnElPanel();

            return builder.getPanel;
        }
    }
}
