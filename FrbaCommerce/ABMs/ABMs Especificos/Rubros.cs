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
    class Rubros : ABMEspecifico
    {
        TextEdit teDescripcion = new TextEdit();

        public override DataTable ejecutarBusqueda()
        {
            // Creamos el rol y lo mandamos a grabar.
            Rubro unRol = new Rubro(teDescripcion.Text);
            return unRol.upFullByPrototype();
        }

        public override void cargarTusDatos(int idClavePrimaria)
        {
            Rubro unRubro = Rubro.get(idClavePrimaria);
            teDescripcion.Text = unRubro.campoDescripcion;
        }

        protected override void grabarAlta()
        {
            // Creamos el rol y lo mandamos a grabar.
            Rubro unRol = new Rubro(teDescripcion.Text);
            unRol.save();
        }

        protected override void grabarModificacion()
        {

        }

        protected override void baja(int idClavePrimaria)
        {
            Rubro.delete(idClavePrimaria);
        }

        public override Panel getPanel(Size tamañoPanel)
        {
            PanelBuilder builder = new PanelBuilder(tamañoPanel, PanelBuilder.Alineacion.Horizontal);
            builder.AddControlWithLabel("Descripcion", teDescripcion)
                   .centrarControlesEnElPanel();

            return builder.getPanel;
        }
    }
}
