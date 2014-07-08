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
    public class UsuariosClientes : ABMEspecifico
    {
        private int idRolElegido;

        // Campos para el Cliente
        TextEdit teApellido = new TextEdit();
        TextEdit teNombre = new TextEdit();
        TextEdit teTipoDocumento= new TextEdit();
        NumberEdit neDocumento = new NumberEdit();
        DateEdit deFechaNacimiento = new DateEdit();
        TextEdit teMail = new TextEdit();
        TextEdit teTelefono= new TextEdit();
        TextEdit teUsuario = new TextEdit();
        TextEdit teContrasenia = new TextEdit();
        ComboBox cbRoles = new ComboBox();

        Direcciones abmDirecciones;

        public UsuariosClientes()
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
            Cliente unCliente = crearClienteFromCamposGUI();
            // Los mandamos a grabar, linqueando la dir al cliente a partir del id que nos devuelve el grabado.
            unCliente.foraneaIdDireccion = unaDir.save();
            int idCliente = unCliente.save();
            // Grabamos el usuario creado.
            Usuario unUsuario = crearUsuarioFromCamposGUI(idCliente);
            int idUsuario = unUsuario.save();
            // Grabamos la relacion usuario_rol
            grabarUsuarioRol(idUsuario);
        }

        public override bool pasaValidacion()
        {
            return (Valid.noEsVacio(teUsuario) && Valid.noEsVacio(teContrasenia) && Valid.noEsVacio(teApellido) && 
                    (Valid.noEsVacio(neDocumento)));
        }

        public override string mensajeErrorValidacion()
        {
            return "Debe ingresar obligatoriamente los siguiente campos: Usuario, Contraseña, Apellido y Nro. Documento";
        }
        

        private void grabarUsuarioRol(int idUsuarioGrabado)
        {
            Usuario_Rol relacionUsuarioRol = new Usuario_Rol();
            relacionUsuarioRol.campoIdUsuario = idUsuarioGrabado;
            relacionUsuarioRol.campoIdRol = Convert.ToInt32(cbRoles.SelectedValue);
            relacionUsuarioRol.save();
            idRolElegido = relacionUsuarioRol.campoIdRol;
        }

        private Usuario crearUsuarioFromCamposGUI(int idReferencia)
        {
            Usuario usuarioADarDeAlta = new Usuario(teUsuario.Text, Hash.getHashSha256(teContrasenia.Text));
            usuarioADarDeAlta.campoIdReferencia = idReferencia;
            usuarioADarDeAlta.campoDiscriminante = "C";
            return usuarioADarDeAlta;
        }

        public override Panel getPanel(Size tamañoPanel)
        {
            teTipoDocumento.MaxLength = 4;
            PanelBuilder builder = new PanelBuilder(tamañoPanel, PanelBuilder.Alineacion.Horizontal);
            builder.AddControlWithLabel("Usuario", teUsuario)
                   .AddControlWithLabel("Contraseña", teContrasenia)
                   .AddControlWithLabel("Rol", cbRoles)
                   .AddControlWithLabel("Apellido", teApellido)
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

        // UsuariosClientes solo se usa para altas, estos metodos nunca seran llamados pero el contrato nos obliga a hacerles override.
        public override void cargarTusDatos(int idClavePrimaria) { }
        protected override void bajaLogica(int idClave) { }
        protected override void grabarModificacion(int idClaveObjeto) { }
        protected override void baja(int idClavePrimaria) { }
        public override DataTable ejecutarBusqueda() { return null; }

    }
}
