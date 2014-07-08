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
    public class Empresas : ABMEspecifico
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
            unaEmpresa.autoId = unaEmpresa.save();
            Usuario unUsuario = crearUsuario(unaEmpresa);
            unUsuario.autoId = unUsuario.save();
            Usuario_Rol unaRelacionUsuarioRol = crearUsuarioRol(unUsuario);
            unaRelacionUsuarioRol.save();
        }

        public override bool pasaValidacion()
        {
            return (Valid.noEsVacio(teRazonSocial) && (Valid.noEsVacio(ceCuit)));
        }

        public override string mensajeErrorValidacion()
        {
            return "Debe ingresar obligatoriamente los siguiente campos: Razon Social y Cuit";
        }

        private Usuario_Rol crearUsuarioRol(Usuario unUsuario)
        {
            return new Usuario_Rol(unUsuario.autoId, 1);
        }

        private Usuario crearUsuario(Empresa unaEmpresa)
        {
            Usuario usuarioADarDeAlta = new Usuario(unaEmpresa.campoCuit, Hash.getHashSha256("Password"));
            usuarioADarDeAlta.campoIdReferencia = unaEmpresa.autoId;
            usuarioADarDeAlta.campoDiscriminante = "E";
            usuarioADarDeAlta.campoIntentosFallidos = -1;
            return usuarioADarDeAlta;
        }

        protected override void grabarModificacion(int idClaveObjetoAModificar)
        {
            // Obtenemos la empresa a partir de la clave seleccionada por el usuario y lo actualizamos
            Empresa unaEmpresa = Empresa.get(idClaveObjetoAModificar);
            actualizarEmpresaFromCamposGUI(unaEmpresa);

            // Obtenemos la dir a partir de la que tiene la empresa y actualizamos la dir.
            Direccion unaDir = Direccion.get(unaEmpresa.foraneaIdDireccion);
            abmDirecciones.actualizarDireccionFromCamposGUI(unaDir);

            // Validamos que no le haya seleccionado localidad vacia.
            if (unaDir.campoIdLocalidad == 0)
                throw new Exception("No puede modificar el cliente dejandolo sin una localidad.");

            // Actualizamos ambos objetos.
            unaDir.update();
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
        private void actualizarEmpresaFromCamposGUI(Empresa unaEmpresa)
        {
            unaEmpresa.campoRazonSocial = teRazonSocial.Text;
            unaEmpresa.campoCuit = ceCuit.Text;
            unaEmpresa.campoFechaIngreso = dteFechaIngreso.FechaHora;
            unaEmpresa.campoMail = teMail.Text;
            unaEmpresa.campoNombreContacto = teNombreContacto.Text;
            unaEmpresa.campoCiudad = teCiudad.Text;
        }
    }
}
