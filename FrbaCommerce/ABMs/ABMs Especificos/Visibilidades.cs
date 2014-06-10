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
        DecimalEdit dcePorcentaje = new DecimalEdit();

        public override DataTable ejecutarBusqueda()
        {
            // Creamos el rol y lo mandamos a grabar.
            Visibilidad unRol = new Visibilidad(teDescripcion.Text, dcePrecio.Decimal, dcePorcentaje.Decimal);
            return unRol.upFullByPrototype();
        }

        public override void cargarTusDatos(int idClavePrimaria)
        {
            Visibilidad unaVisibilidad = Visibilidad.get(idClavePrimaria);
            teDescripcion.Text = unaVisibilidad.campoDescripcion;
            dcePrecio.Decimal = unaVisibilidad.campoPrecio;
            dcePorcentaje.Decimal = unaVisibilidad.campoPorcentaje;
        }

        protected override void grabarAlta()
        {
            // Creamos el rol y lo mandamos a grabar.
            Visibilidad unaVisibilidad = new Visibilidad(teDescripcion.Text, dcePrecio.Decimal, dcePorcentaje.Decimal);
            unaVisibilidad.save();
        }

        protected override void grabarModificacion(int idClaveObjetoAModificar)
        {
            Visibilidad unaVisibilidad = new Visibilidad(teDescripcion.Text, dcePrecio.Decimal, dcePorcentaje.Decimal);
            unaVisibilidad.autoId = idClaveObjetoAModificar;
            unaVisibilidad.update();
        }

        protected override void baja(int idClavePrimaria)
        {
            Visibilidad.delete(idClavePrimaria);
        }

        protected override void bajaLogica(int idClavePrimaria)
        {
            Visibilidad unaVisibilidad = Visibilidad.get(idClavePrimaria);
            unaVisibilidad.borradoLogico();
        }

        public override Panel getPanel(Size tamañoPanel)
        {
            dcePrecio.ZeroValid = true;
            dcePorcentaje.ZeroValid = true;
            PanelBuilder builder = new PanelBuilder(tamañoPanel, PanelBuilder.Alineacion.Horizontal);
            builder.AddControlWithLabel("Descripcion", teDescripcion)
                   .AddControlWithLabel("Precio", dcePrecio)
                   .AddControlWithLabel("Porcentaje", dcePorcentaje)
                   .centrarControlesEnElPanel();

            return builder.getPanel;
        }
    }
}
