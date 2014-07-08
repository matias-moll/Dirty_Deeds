using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Dominio;
using System.Drawing;
using TNGS.NetControls;

namespace FrbaCommerce
{
    class Direcciones
    {
        // Campos para la direccion
        TextEdit teDomicilio = new TextEdit();
        NumberEdit neNroCalle = new NumberEdit();
        NumberEdit nePiso = new NumberEdit();
        NumberEdit neCodPostal = new NumberEdit();
        TextEdit teDepto = new TextEdit();
        ComboBox cbLocalidades = new ComboBox();

        public Direcciones()
        {
            List<Localidad> localidades = Localidad.upFull();
            Localidad localidadVacia = new Localidad("");
            localidadVacia.autoId = 0;
            localidades.Add(localidadVacia);
            // Cargamos la lista de localidades.
            cbLocalidades.DataSource = localidades;
            cbLocalidades.DisplayMember = "campoNombre";
            cbLocalidades.ValueMember = "autoId";

            cbLocalidades.SelectedItem = localidadVacia;

            // Solo lectura.
            cbLocalidades.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        internal void cargarTusDatos(Direccion unaDireccion)
        {
            teDomicilio.Text = unaDireccion.campoDomicilio;
            neNroCalle.Numero = unaDireccion.campoNumeroCalle;
            nePiso.Numero = unaDireccion.campoPiso;
            teDepto.Text = unaDireccion.campoDepto;
            neCodPostal.Numero = unaDireccion.campoCodPostal;
            cbLocalidades.SelectedValue = unaDireccion.campoIdLocalidad;
        }

        internal Direccion crearDireccionFromCamposGUI()
        {
            int idLocalidadSelected = (int)Soporte.notNull(cbLocalidades.SelectedValue, 0);
            return new Direccion(teDomicilio.Text, neNroCalle.Numero, nePiso.Numero,
                                 teDepto.Text, idLocalidadSelected,neCodPostal.Numero);
        }

        internal void agregaTusControles(PanelBuilder builder)
        {
            cbLocalidades.SelectedValue = 0;

            builder.AddControlWithLabel("Domicilio", teDomicilio)
                   .AddControlWithLabel("Nro. Calle", neNroCalle)
                   .AddControlWithLabel("Piso", nePiso)
                   .AddControlWithLabel("Departamento", teDepto)
                   .AddControlWithLabel("Código Postal", neCodPostal)
                   .AddControlWithLabel("Localidad", cbLocalidades);
        }

        internal void actualizarDireccionFromCamposGUI(Direccion unaDir)
        {
            unaDir.campoDomicilio = teDomicilio.Text;
            unaDir.campoNumeroCalle = neNroCalle.Numero;
            unaDir.campoPiso = nePiso.Numero;
            unaDir.campoDepto = teDepto.Text;
            unaDir.campoCodPostal = neCodPostal.Numero;
            unaDir.campoIdLocalidad = (int)Soporte.notNull(cbLocalidades.SelectedValue, 0);
        }
    }
}
