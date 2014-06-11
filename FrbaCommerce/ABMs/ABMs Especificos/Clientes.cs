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
    class Clientes : ABMEspecifico
    {
        // Campos para el Cliente
        TextEdit teApellido = new TextEdit();
        TextEdit teNombre = new TextEdit();
        TextEdit teTipoDocumento= new TextEdit();
        NumberEdit neDocumento = new NumberEdit();
        DateEdit deFechaNacimiento = new DateEdit();
        TextEdit teMail = new TextEdit();

        // Campos para la direccion
        TextEdit teDomicilio = new TextEdit();
        NumberEdit neNroCalle = new NumberEdit();
        NumberEdit nePiso = new NumberEdit();
        TextEdit teDepto = new TextEdit();
        ComboBox cbLocalidades = new ComboBox();

        public Clientes()
        {
            // Cargamos la lista de localidades.
            cbLocalidades.DataSource = Localidad.upFull();
            cbLocalidades.DisplayMember = "campoNombre";
            cbLocalidades.ValueMember = "autoId";

            // Solo lectura.
            cbLocalidades.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        public override DataTable ejecutarBusqueda()
        {
            if (algunCampoDeDireccionNoEsVacio())
            {
                Direccion unaDireccion = new Direccion(teDomicilio.Text, neNroCalle.Numero, nePiso.Numero,
                                                       teDepto.Text, (int)cbLocalidades.SelectedValue);

            }
            // Creamos el Cliente y lo mandamos a buscar.
            Cliente unCliente = crearClienteFromCamposGUI();
            return unCliente.upFullByPrototype();
        }

        public override void cargarTusDatos(int p_idClavePrimaria)
        {
            Cliente unCliente = Cliente.get(p_idClavePrimaria);
            teApellido.Text = unCliente.campoApellido;
            teNombre.Text = unCliente.campoNombre;
            teTipoDocumento.Text = unCliente.campoTipoDocumento;
            neDocumento.Numero = unCliente.campoDocumento;
            deFechaNacimiento.Fecha = unCliente.campoFechaNacimiento;
            teMail.Text = unCliente.campoMail;

            Direccion unaDireccion = Direccion.get(unCliente.campoIdDireccion);
            teDomicilio.Text = unaDireccion.campoDomicilio;
            neNroCalle.Numero = unaDireccion.campoNumeroCalle;
            nePiso.Numero = unaDireccion.campoPiso;
            teDepto.Text = unaDireccion.campoDepto;
            cbLocalidades.SelectedValue = unaDireccion.campoIdLocalidad;
        }

        protected override void grabarAlta()
        {
            // Creamos el Cliente y lo mandamos a grabar.
            Cliente unCliente = crearClienteFromCamposGUI();
            unCliente.save();
        }

        protected override void grabarModificacion(int idClaveObjetoAModificar)
        {
            // Creamos el Cliente a partir de los datos de la pantalla y el id que tenemos guardado y lo mandamos a actualizar.
            Cliente unCliente = crearClienteFromCamposGUI();
            unCliente.autoId = idClaveObjetoAModificar;
            unCliente.update();
        }

        protected override void baja(int idClavePrimaria)
        {
            Cliente.delete(idClavePrimaria);
        }

        protected override void bajaLogica(int idClavePrimaria)
        {
            Cliente unCliente = Cliente.get(idClavePrimaria);
            unCliente.borradoLogico();
        }

        public override Panel getPanel(Size tamañoPanel)
        {
            teTipoDocumento.MaxLength = 4;
            PanelBuilder builder = new PanelBuilder(tamañoPanel, PanelBuilder.Alineacion.Horizontal);
            builder.AddControlWithLabel("Apellido", teApellido)
                   .AddControlWithLabel("Nombre", teNombre)
                   .AddControlWithLabel("Tipo Doc.", teTipoDocumento)
                   .AddControlWithLabel("Documento", neDocumento)
                   .AddControlWithLabel("F. Nacimiento", deFechaNacimiento)
                   .AddControlWithLabel("Mail", teMail)
                   .AddControlWithLabel("Dirección", teDomicilio)
                   .AddControlWithLabel("Nro. Calle", neNroCalle)
                   .AddControlWithLabel("Piso", nePiso)
                   .AddControlWithLabel("Departamento", teDepto)
                   .AddControlWithLabel("Localidad", cbLocalidades)
                   .centrarControlesEnElPanel();

            return builder.getPanel;
        }

        private Cliente crearClienteFromCamposGUI()
        {
            return new Cliente(teApellido.Text, teNombre.Text, teTipoDocumento.Text, neDocumento.Numero, 
                               deFechaNacimiento.Fecha, teMail.Text);
        }

    }
}
