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
    class Localidades : ABMEspecifico
    {
        NumberEdit neCodPostal = new NumberEdit();
        TextEdit teNombre = new TextEdit();

        public override DataTable ejecutarBusqueda()
        {
            // Creamos el rol y lo mandamos a grabar.
            Localidad unRol = new Localidad(neCodPostal.Numero, teNombre.Text);
            return unRol.upFullByPrototype();
        }

        public override void cargarTusDatos(int idClavePrimaria)
        {
            Localidad unaLocalidad = Localidad.get(idClavePrimaria);
            neCodPostal.Numero = unaLocalidad.campoCodPostal;
            teNombre.Text = unaLocalidad.campoNombre;
        }

        protected override void grabarAlta()
        {
            // Creamos el rol y lo mandamos a grabar.
            Localidad unaLocalidad = new Localidad(neCodPostal.Numero, teNombre.Text);
            unaLocalidad.save();
        }

        protected override void grabarModificacion(int idClaveObjetoAModificar)
        {
            Localidad unaLocalidad = new Localidad(neCodPostal.Numero, teNombre.Text);
            unaLocalidad.autoId = idClaveObjetoAModificar;
            unaLocalidad.update();
        }

        protected override void baja(int idClavePrimaria)
        {
            Localidad.delete(idClavePrimaria);
        }

        protected override void bajaLogica(int idClavePrimaria)
        {
            Localidad unaLocalidad = Localidad.get(idClavePrimaria);
            unaLocalidad.borradoLogico();
        }

        public override Panel getPanel(Size tamañoPanel)
        {
            PanelBuilder builder = new PanelBuilder(tamañoPanel, PanelBuilder.Alineacion.Horizontal);
            builder.AddControlWithLabel("Código Postal", neCodPostal)
                   .AddControlWithLabel("Nombre", teNombre)
                   .centrarControlesEnElPanel();

            return builder.getPanel;
        }
    }
}
