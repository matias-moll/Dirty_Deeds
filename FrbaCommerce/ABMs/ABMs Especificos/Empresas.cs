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
    class Empresas : ABMEspecifico
    {
        // Campos para la empresa
        TextEdit teRazonSocial = new TextEdit();
        CuitEdit ceCuit = new CuitEdit();
        DateTimeEdit dteFechaIngreso = new DateTimeEdit();
        TextEdit teMail = new TextEdit();
        TextEdit teNombreContacto = new TextEdit();
        TextEdit teCiudad = new TextEdit();

        Direcciones abmDirecciones;

        public Empresas()
        {
            abmDirecciones = new Direcciones();
        }

        public override DataTable ejecutarBusqueda()
        {
            // Creamos el Empresa y lo mandamos a buscar.
            Empresa unaEmpresa = crearEmpresaFromCamposGUI();
            unaEmpresa.prototipoDireccion = abmDirecciones.crearDireccionFromCamposGUI();
            return unaEmpresa.upFullByPrototype();
        }

        public override void cargarTusDatos(int p_idClavePrimaria)
        {
            Empresa unaEmpresa = Empresa.get(p_idClavePrimaria);
            teRazonSocial.Text = unaEmpresa.campoRazonSocial;
            ceCuit.Text = unaEmpresa.campoCuit;
            dteFechaIngreso.FechaHora = unaEmpresa.campoFechaIngreso;
            teMail.Text = unaEmpresa.campoMail;
            teNombreContacto.Text = unaEmpresa.campoNombreContacto;

            Direccion unaDireccion = Direccion.get(unaEmpresa.foraneaIdDireccion);
            abmDirecciones.cargarTusDatos(unaDireccion);
        }

        protected override void grabarAlta()
        {
            // Creamos la direccion y el cliente a partir de los datos ingresados.
            Direccion unaDir = abmDirecciones.crearDireccionFromCamposGUI();
            if (unaDir.campoIdLocalidad == 0)
                throw new Exception("No puede darse el alta sin elegir una localidad.");
            Empresa unaEmpresa = crearEmpresaFromCamposGUI();
            // Los mandamos a grabar, linqueando la dir al cliente a partir del id que nos devuelve el grabado.
            unaEmpresa.foraneaIdDireccion = unaDir.save();
            unaEmpresa.save();
        }

        protected override void grabarModificacion(int idClaveObjetoAModificar)
        {
            // Creamos el Empresa a partir de los datos de la pantalla y el id que tenemos guardado y lo mandamos a actualizar.
            Empresa unaEmpresa = crearEmpresaFromCamposGUI();
            unaEmpresa.autoId = idClaveObjetoAModificar;
            unaEmpresa.update();
        }

        protected override void baja(int idClavePrimaria)
        {
            // La baja borra a la empresa y la direccion.
            Empresa unaEmpresa = Empresa.get(idClavePrimaria);
            Direccion unaDir = Direccion.get(unaEmpresa.foraneaIdDireccion);
            Empresa.delete(idClavePrimaria);
            Direccion.delete(unaDir.autoId);
        }

        protected override void bajaLogica(int idClavePrimaria)
        {
            // La baja logica marca a la empresa y la direccion.
            Empresa unaEmpresa = Empresa.get(idClavePrimaria);
            Direccion unaDir = Direccion.get(unaEmpresa.foraneaIdDireccion);
            unaDir.borradoLogico();
            unaEmpresa.borradoLogico();
        }

        public override Panel getPanel(Size tamañoPanel)
        {
            PanelBuilder builder = new PanelBuilder(tamañoPanel, PanelBuilder.Alineacion.Horizontal);
            builder.AddControlWithLabel("Razón Social", teRazonSocial)
                   .AddControlWithLabel("Cuit", ceCuit)
                   .AddControlWithLabel("Fecha Ingreso", dteFechaIngreso)
                   .AddControlWithLabel("Mail", teMail)
                   .AddControlWithLabel("Contacto", teNombreContacto)
                   .AddControlWithLabel("Ciudad", teCiudad);

            abmDirecciones.agregaTusControles(builder);

            builder.centrarControlesEnElPanel();

            return builder.getPanel;
        }

        private Empresa crearEmpresaFromCamposGUI()
        {
            return new Empresa(teRazonSocial.Text, ceCuit.Text, dteFechaIngreso.FechaHora,
                                            teMail.Text, teNombreContacto.Text, teCiudad.Text);
        }
    }
}
