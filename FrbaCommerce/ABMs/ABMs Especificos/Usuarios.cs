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
    class Usuarios : ABMEspecifico
    {
        TextEdit teUsuario = new TextEdit();
        NumberEdit neIntentosFallidos = new NumberEdit();

        public override DataTable ejecutarBusqueda()
        {
            // Creamos el rol y lo mandamos a grabar.
            Usuario unUsuario = new Usuario(teUsuario.Text, neIntentosFallidos.Numero);
            return unUsuario.upFullByPrototype();
        }

        protected override void bajaLogica(int idClavePrimaria)
        {
            Usuario unUsuario = Usuario.get(idClavePrimaria);
            unUsuario.borradoLogico();
        }

        public override Panel getPanel(Size tamañoPanel)
        {
            PanelBuilder builder = new PanelBuilder(tamañoPanel, PanelBuilder.Alineacion.Horizontal);
            builder.AddControlWithLabel("Usuario", teUsuario)
                   .AddControlWithLabel("Intentos Fallidos", neIntentosFallidos)
                   .centrarControlesEnElPanel();

            return builder.getPanel;
        }

        // Usuarios solo se usa para bajas logicas, estos metodos nunca seran llamados pero el contrato nos obliga a hacerles override.
        public override void cargarTusDatos(int idClavePrimaria) { }
        protected override void grabarAlta() { }
        protected override void grabarModificacion(int idClaveObjeto){}
        protected override void baja(int idClavePrimaria) { }
    }
}
