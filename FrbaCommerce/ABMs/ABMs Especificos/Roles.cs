using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Dominio;
using System.Drawing;
using TNGS.NetControls;

namespace ABMs
{
    class Roles : ABMEspecifico
    {
        TextEdit teNombre = new TextEdit();

        public override DataTable ejecutarBusqueda()
        {
            // Creamos el rol y lo mandamos a buscar.
            Rol unRol = new Rol(teNombre.Text);
            return unRol.upFullByPrototype();
        }

        public override void cargarTusDatos(int idClavePrimaria)
        {
            Rol unRol = Rol.get(idClavePrimaria);
            teNombre.Text = unRol.campoNombre;
        }

        protected override void grabarAlta()
        {
            // Creamos el rol y lo mandamos a grabar.
            Rol unRol = new Rol(teNombre.Text);
            unRol.save();
        }

        protected override void grabarModificacion()
        {

        }

        protected override void baja(int idClavePrimaria)
        {
            Rol.delete(idClavePrimaria);
        }

        public override Panel getPanel(Size tamañoPanel)
        {
            PanelBuilder builder = new PanelBuilder(tamañoPanel, PanelBuilder.Alineacion.Horizontal);
            builder.AddControlWithLabel("Nombre", teNombre)
                   .centrarControlesEnElPanel();

            return builder.getPanel;
        }
    }
}
