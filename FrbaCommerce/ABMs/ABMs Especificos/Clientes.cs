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
    public class Clientes : ABMEspecifico
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
            unCliente.prototipoDireccion = abmDirecciones.crearDireccionFromCamposGUI();
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
            Direccion unaDir = abmDirecciones.crearDireccionFromCamposGUI();
            if (unaDir.campoIdLocalidad == 0)
                throw new Exception("No puede darse el alta sin elegir una localidad.");
            Cliente unCliente = crearClienteFromCamposGUI();
            // Los mandamos a grabar, linqueando la dir al cliente a partir del id que nos devuelve el grabado.
            unCliente.foraneaIdDireccion = unaDir.save();
            unCliente.save();
        }

        protected override void grabarModificacion(int idClaveObjetoAModificar)
        {
            // Obtenemos el cliente a partir de la clave seleccionada por el usuario y lo actualizamos
            Cliente unCliente = Cliente.get(idClaveObjetoAModificar);
            actualizarClienteFromCamposGUI(unCliente);

            // Obtenemos la dir a partir de la que tiene el cliente y actualizamos la dir.
            Direccion unaDir = Direccion.get(unCliente.foraneaIdDireccion);
            abmDirecciones.actualizarDireccionFromCamposGUI(unaDir);

            // Validamos que no le haya seleccionado localidad vacia.
            if (unaDir.campoIdLocalidad == 0)
                throw new Exception("No puede modificar el cliente dejandolo sin una localidad.");

            // Actualizamos ambos objetos.
            unaDir.update();
            unCliente.update();
        }



        protected override void baja(int idClavePrimaria)
        {
            // La baja borra al cliente y la direccion.
            Cliente unCliente = Cliente.get(idClavePrimaria);
            Direccion unaDir = Direccion.get(unCliente.foraneaIdDireccion);
            Cliente.delete(idClavePrimaria);
            Direccion.delete(unaDir.autoId);
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

        private void actualizarClienteFromCamposGUI(Cliente unCliente)
        {
            unCliente.campoApellido = teApellido.Text;
            unCliente.campoNombre = teNombre.Text;
            unCliente.campoTipoDocumento = teTipoDocumento.Text;
            unCliente.campoDocumento = neDocumento.Numero;
            unCliente.campoFechaNacimiento = deFechaNacimiento.Fecha;
            unCliente.campoMail = teMail.Text;
            unCliente.campoTelefono = teTelefono.Text;
        }

    }
}
