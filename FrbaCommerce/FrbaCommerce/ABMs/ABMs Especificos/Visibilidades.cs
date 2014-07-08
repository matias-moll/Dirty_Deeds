using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using Dominio;
using TNGS.NetControls;

namespace FrbaCommerce
{
    class Visibilidades : ABMEspecifico
    {
        TextEdit teCodigo = new TextEdit();
        TextEdit teDescripcion = new TextEdit();
        DecimalEdit dcePrecio = new DecimalEdit();
        DecimalEdit dcePorcentaje = new DecimalEdit();
        NumberEdit neDiasActiva = new NumberEdit();

        public override DataTable ejecutarBusqueda()
        {
            // Creamos el rol y lo mandamos a grabar.
            Visibilidad unRol = crearVisibilidadFromControlesGUI();
            return unRol.upFullByPrototype();
        }

        private Visibilidad crearVisibilidadFromControlesGUI()
        {
            return new Visibilidad(teCodigo.Text, teDescripcion.Text, dcePrecio.Decimal, dcePorcentaje.Decimal, neDiasActiva.Numero);
        }

        public override bool pasaValidacion()
        {
            return (Valid.noEsVacio(teDescripcion));
        }

        public override string mensajeErrorValidacion()
        {
            return "Debe ingresar obligatoriamente la descripción";
        }

        public override void cargarTusDatos(int idClavePrimaria)
        {
            Visibilidad unaVisibilidad = Visibilidad.get(idClavePrimaria);
            teCodigo.Text = unaVisibilidad.campoCodigo;
            teDescripcion.Text = unaVisibilidad.campoDescripcion;
            dcePrecio.Decimal = unaVisibilidad.campoPrecio;
            dcePorcentaje.Decimal = unaVisibilidad.campoPorcentaje;
            neDiasActiva.Numero = unaVisibilidad.campoDiasActiva;
        }

        protected override void grabarAlta()
        {
            // Creamos el rol y lo mandamos a grabar.
            Visibilidad unaVisibilidad = crearVisibilidadFromControlesGUI();
            unaVisibilidad.save();
        }

        protected override void grabarModificacion(int idClaveObjetoAModificar)
        {
            Visibilidad unaVisibilidad = crearVisibilidadFromControlesGUI();
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
            builder.AddControlWithLabel("Código", teCodigo)
                   .AddControlWithLabel("Descripcion", teDescripcion)
                   .AddControlWithLabel("Precio", dcePrecio)
                   .AddControlWithLabel("Porcentaje", dcePorcentaje)
                   .AddControlWithLabel("Dias Activa", neDiasActiva)
                   .centrarControlesEnElPanel();

            return builder.getPanel;
        }
    }
}
