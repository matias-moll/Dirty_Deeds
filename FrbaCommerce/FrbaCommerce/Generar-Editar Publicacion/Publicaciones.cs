using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using Dominio;
using TNGS.NetControls;
using ABMs;

namespace FrbaCommerce
{
    class Publicaciones : ABMEspecifico
    {
        TextEdit teDescripcion = new TextEdit();
        DateTimeEdit dteFecha = new DateTimeEdit();
        DecimalEdit dcePrecio = new DecimalEdit();
        NumberEdit neStock = new NumberEdit();
        ComboBox cbTipos = new ComboBox();

        private int idUsuario;

        public Publicaciones(Dominio.Usuario usuarioLoggeado)
        {
            TipoPublicacion.cargarComboTipos(cbTipos);
            idUsuario = usuarioLoggeado.autoId;
        }

        public override DataTable ejecutarBusqueda()
        {
            Dominio.Publicacion unaPublicacion = new Dominio.Publicacion(0,teDescripcion.Text, neStock.Numero,
                                                    dteFecha.FechaHora, dcePrecio.Decimal, (char)cbTipos.SelectedValue, false);

            unaPublicacion.foraneaIdUsuario = idUsuario;
            return unaPublicacion.upFullByPrototype();
        }

        public override Panel getPanel(Size tamañoPanel)
        {
            PanelBuilder builder = new PanelBuilder(tamañoPanel, PanelBuilder.Alineacion.Horizontal);
            builder.AddControlWithLabel("Descripción", teDescripcion)
                   .AddControlWithLabel("Stock", neStock)
                   .AddControlWithLabel("Fecha", dteFecha)
                   .AddControlWithLabel("Precio", dcePrecio)
                   .AddControlWithLabel("Tipo", cbTipos)
                   .centrarControlesEnElPanel();

            return builder.getPanel;
        }

        // Publicaciones solo se usa para seleccion, estos metodos nunca seran llamados pero el contrato nos obliga a hacerles override.
        public override void cargarTusDatos(int idClavePrimaria) { }
        protected override void grabarAlta() { }
        protected override void grabarModificacion(int idClaveObjeto){}
        protected override void baja(int idClavePrimaria) { }
        protected override void bajaLogica(int idClavePrimaria) { }
    }
}
