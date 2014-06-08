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
        CheckBox cbBorrado = new CheckBox();

        public override DataTable ejecutarBusqueda()
        {
            // Creamos el rol y lo mandamos a buscar.
            Rol unRol = new Rol(teNombre.Text, cbBorrado.Checked);
            return unRol.upFullByPrototype();
        }

        protected override void grabarAlta()
        {
            // Creamos el rol y lo mandamos a grabar.
            Rol unRol = new Rol(teNombre.Text, cbBorrado.Checked);
            unRol.save();
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
