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
    public class UsuariosEmpresas : ABMEspecifico
    {
        // Campos para la empresa
        TextEdit teRazonSocial = new TextEdit();
        CuitEdit ceCuit = new CuitEdit();
        DateTimeEdit dteFechaIngreso = new DateTimeEdit();
        TextEdit teMail = new TextEdit();
        TextEdit teNombreContacto = new TextEdit();
        TextEdit teCiudad = new TextEdit();
        TextEdit teUsuario = new TextEdit();
        TextEdit teContrasenia = new TextEdit();
        ComboBox cbRoles = new ComboBox();

        Direcciones abmDirecciones;

        public UsuariosEmpresas()
        {
            abmDirecciones = new Direcciones();

            cbRoles.DataSource = Rol.upFull();
            cbRoles.DisplayMember = "campoNombre";
            cbRoles.ValueMember = "autoId";
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
            int idEmpresa = unaEmpresa.save();
            // Grabamos el usuario creado.
            Usuario unUsuario = crearUsuarioFromCamposGUI(idEmpresa);
            int idUsuario = unUsuario.save();
            // Grabamos la relacion usuario_rol
            grabarUsuarioRol(idUsuario);
        }

        private void grabarUsuarioRol(int idUsuarioGrabado)
        {
            Usuario_Rol relacionUsuarioRol = new Usuario_Rol();
            relacionUsuarioRol.campoIdUsuario = idUsuarioGrabado;
            relacionUsuarioRol.campoIdRol = Convert.ToInt32(cbRoles.SelectedValue);
            relacionUsuarioRol.save();
        }

        private Usuario crearUsuarioFromCamposGUI(int idReferencia)
        {
            Usuario usuarioADarDeAlta = new Usuario(teUsuario.Text, Hash.getHashSha256(teContrasenia.Text));
            usuarioADarDeAlta.campoIdReferencia = idReferencia;
            usuarioADarDeAlta.campoDiscriminante = "E";
            return usuarioADarDeAlta;
        }

        public override Panel getPanel(Size tamañoPanel)
        {
            PanelBuilder builder = new PanelBuilder(tamañoPanel, PanelBuilder.Alineacion.Horizontal);
            builder.AddControlWithLabel("Usuario", teUsuario)
                   .AddControlWithLabel("Contraseña", teContrasenia)
                   .AddControlWithLabel("Rol", cbRoles)
                   .AddControlWithLabel("Razón Social", teRazonSocial)
                   .AddControlWithLabel("Cuit", ceCuit)
                   .AddControlWithLabel("Fecha Ingreso", dteFechaIngreso)
                   .AddControlWithLabel("Mail", teMail)
                   .AddControlWithLabel("Contacto", teNombreContacto)
                   .AddControlWithLabel("Ciudad", teCiudad);

            abmDirecciones.agregaTusControles(builder);

            builder.centrarControlesEnElPanel();

            return builder.getPanel;
        }

        public override bool pasaValidacion()
        {
            return (noEsVacio(teUsuario) && noEsVacio(teContrasenia) && noEsVacio(teRazonSocial) &&
                    (noEsVacio(ceCuit)));
        }

        public override string mensajeErrorValidacion()
        {
            return "Debe ingresar obligatoriamente los siguiente campos: Usuario, Contraseña, Razon Social y Cuit";
        }

        private bool noEsVacio(CuitEdit cuitEdit)
        {
            return cuitEdit.Text.Trim() != "";
        }

        private bool noEsVacio(TextEdit textEdit)
        {
            return textEdit.Text.Trim() != "";
        }

        private Empresa crearEmpresaFromCamposGUI()
        {
            return new Empresa(teRazonSocial.Text, ceCuit.Text, dteFechaIngreso.FechaHora,
                                            teMail.Text, teNombreContacto.Text, teCiudad.Text);
        }

        // UsuariosEmpresas solo se usa para altas, estos metodos nunca seran llamados pero el contrato nos obliga a hacerles override.
        public override void cargarTusDatos(int idClavePrimaria) { }
        protected override void bajaLogica(int idClave) { }
        protected override void grabarModificacion(int idClaveObjeto) { }
        protected override void baja(int idClavePrimaria) { }
        public override DataTable ejecutarBusqueda() { return null; }

    }
}
