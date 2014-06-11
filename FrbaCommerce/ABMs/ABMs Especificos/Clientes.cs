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
        TextEdit teTelefono= new TextEdit();

        Direcciones abmDirecciones;

        public Clientes()
        {
            abmDirecciones = new Direcciones();
        }


        public override DataTable ejecutarBusqueda()
        {
            // Creamos el Cliente y lo mandamos a buscar.
            Cliente unCliente = crearClienteFromCamposGUI();
            unCliente.prototipoDireccion = crearDireccionFromCamposGUI();
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

            Direccion unaDireccion = Direccion.get(unCliente.foraneaIdDireccion);
            abmDirecciones.cargarTusDatos(unaDireccion);
        }

        protected override void grabarAlta()
        {
            // Creamos la direccion y el cliente a partir de los datos ingresados.
            Direccion unaDir = crearDireccionFromCamposGUI();
            Cliente unCliente = crearClienteFromCamposGUI();
            // Los mandamos a grabar, linqueando la dir al cliente a partir del id que nos devuelve el grabado.
            unCliente.foraneaIdDireccion = unaDir.save();
            unCliente.save();
        }

        private Direccion crearDireccionFromCamposGUI()
        {
            return abmDirecciones.crearDireccionFromCamposGUI();
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
            // La baja borra al cliente y la direccion.
            Cliente unCliente = Cliente.get(idClavePrimaria);
            Direccion unaDir = Direccion.get(unCliente.foraneaIdDireccion);
            Direccion.delete(unaDir.autoId);
            Cliente.delete(idClavePrimaria);
        }

        protected override void bajaLogica(int idClavePrimaria)
        {
            // La baja logica marca al cliente y la direccion.
            Cliente unCliente = Cliente.get(idClavePrimaria);
            Direccion unaDir = Direccion.get(unCliente.foraneaIdDireccion);
            unaDir.borradoLogico();
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
                   .AddControlWithLabel("Teléfono", teTelefono);
            abmDirecciones.agregaTusControles(builder);
            builder.centrarControlesEnElPanel();

            return builder.getPanel;
        }

        private Cliente crearClienteFromCamposGUI()
        {
            return new Cliente(teApellido.Text, teNombre.Text, teTipoDocumento.Text, neDocumento.Numero, 
                               deFechaNacimiento.Fecha, teMail.Text, teTelefono.Text);
        }

    }
}
