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
    class Direcciones
    {
        // Campos para la direccion
        TextEdit teDomicilio = new TextEdit();
        NumberEdit neNroCalle = new NumberEdit();
        NumberEdit nePiso = new NumberEdit();
        TextEdit teDepto = new TextEdit();
        ComboBox cbLocalidades = new ComboBox();

        public Direcciones()
        {
            // Cargamos la lista de localidades.
            cbLocalidades.DataSource = Localidad.upFull();
            cbLocalidades.DisplayMember = "campoNombre";
            cbLocalidades.ValueMember = "autoId";

            // Solo lectura.
            cbLocalidades.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        internal void cargarTusDatos(Direccion unaDireccion)
        {
            teDomicilio.Text = unaDireccion.campoDomicilio;
            neNroCalle.Numero = unaDireccion.campoNumeroCalle;
            nePiso.Numero = unaDireccion.campoPiso;
            teDepto.Text = unaDireccion.campoDepto;
            cbLocalidades.SelectedValue = unaDireccion.campoIdLocalidad;
        }

        internal Direccion crearDireccionFromCamposGUI()
        {
            return new Direccion(teDomicilio.Text, neNroCalle.Numero, nePiso.Numero,
                                 teDepto.Text, (int)Soporte.notNull(cbLocalidades.SelectedValue, 0));
        }

        internal void agregaTusControles(PanelBuilder builder)
        {
            builder.AddControlWithLabel("Dirección", teDomicilio)
                   .AddControlWithLabel("Nro. Calle", neNroCalle)
                   .AddControlWithLabel("Piso", nePiso)
                   .AddControlWithLabel("Departamento", teDepto)
                   .AddControlWithLabel("Localidad", cbLocalidades);
        }
    }
}
