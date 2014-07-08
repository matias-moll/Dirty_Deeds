using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;

namespace FrbaCommerce
{
    public partial class Login : Form
    {
        public int idRolUsuario { get; set; }
        public Usuario usuarioLoggeado { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void gbAceptar_Click(object sender, EventArgs e)
        {
            // Obtenemos el usuario a partir del nombre de usuario que es unico.
            Usuario unUsuario = Usuario.getByUsername(teUsuario.Text);

            // Obtenemos la lista de roles de dicho usuario
            Usuario_Rol usuarioRol = new Usuario_Rol();
            usuarioRol.campoIdUsuario = unUsuario.autoId;
            List<Usuario_Rol> rolesDelUsuario = usuarioRol.getListByPrototype();

            // Si tiene solo uno disponible, pasamos a validar el login.
            if (rolesDelUsuario.Count == 1)
                validarLogin(unUsuario, Rol.get(rolesDelUsuario[0].campoIdRol), teContrasenia.Text);
            // Si no tiene ninguno es un error.
            else if (rolesDelUsuario.Count == 0) cancelarProcesoLogin("No existe un rol asociado a ese usuario, se cancela el proceso de Login");
            else
            {
                // Si tiene mas de uno, le damos al usuario la opcion de elegir con cual quiere loguearse.
                List<Rol> rolesPosibles = getListaRoles(rolesDelUsuario);
                SeleccionRol elegirRol = new SeleccionRol(rolesPosibles);
                elegirRol.ShowDialog(this);

                if (elegirRol.DialogResult == DialogResult.Cancel)
                    cancelarProcesoLogin("Al cancelar la seleccion de rol se cancela el proceso de Login");

                // Una vez elegido el rol, pasamos a validar el login.
                validarLogin(unUsuario,elegirRol.rolElegido, teContrasenia.Text);
            }
        }

        private void validarLogin(Usuario unUsuario, Rol rol, string contraseniaIngresada)
        {
            unUsuario.validarEstarHabilitado();

            // Validamos la contrasenia mediante el algoritmo Sha256
            if (Hash.getHashSha256(contraseniaIngresada) != unUsuario.campoContrasenia)
            {
                unUsuario.sumateIntentoFallidoYValida();
                throw new ContraseniaIncorrectaException();
            }

            // Validamos que no deba cambiar la contrasenia
            if (unUsuario.campoIntentosFallidos == -1)
            {
                MessageBox.Show("Usted tiene una contraseña asignada automaticamente, debe cambiarla para luego poder loggearse correctamente");
                NuevaContrasenia formNuevaContrasenia = new NuevaContrasenia(unUsuario);
                formNuevaContrasenia.ShowDialog(this);
                throw new EjecutarLoginDeNuevoException();
            }

            usuarioLoggeado = unUsuario;
            usuarioLoggeado.campoIntentosFallidos = 0;
            usuarioLoggeado.update();

            // Paso la validacion exitosamente.
            finalizarLoginExitosamente(rol.autoId);
        }

        private void cancelarProcesoLogin(string mensajeAlUsuario)
        {
            throw new Exception(mensajeAlUsuario);
        }

        private List<Rol> getListaRoles(List<Usuario_Rol> rolesDelUsuario)
        {
            List<Rol> listaRoles = new List<Rol>();

            // Por cada usuarioRol obtenemos el rol de la base y armamos la lista.
            foreach (Usuario_Rol rolDelUsuario in rolesDelUsuario)
                listaRoles.Add(Rol.get(rolDelUsuario.campoIdRol));

            return listaRoles;
        }

        private void gbPrimerIngreso_Click(object sender, EventArgs e)
        {
            Identificacion identificarse = new Identificacion();
            identificarse.ShowDialog(this);

            if (identificarse.DialogResult == DialogResult.OK)
                throw new EjecutarLoginDeNuevoException();

        }

        private void finalizarLoginExitosamente(int idRol)
        {
            idRolUsuario = idRol;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
