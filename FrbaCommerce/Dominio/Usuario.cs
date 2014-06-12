using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Usuario
    {
        //Miembros
        private DataAccessObject<Usuario> daoUsuario;

        // Properties con la convencion del DataAccessObject
        public int campoId { get; set; }
        public string campoUsuario { get; set; }
        public string campoContrasenia { get; set; }
        public int campoIntentosFallidos { get; set; }
        public bool campoDeleted { get; set; }

        #region Constructores
        public Usuario() { daoUsuario = new DataAccessObject<Usuario>(); }

        public Usuario(string usuario, string contrasenia, bool p_deleted) : this()
        {
            campoUsuario = usuario;
            campoContrasenia = contrasenia;
            campoDeleted = p_deleted;
            campoIntentosFallidos = 0;
        }

        public Usuario(string usuario, string contrasenia) : this(usuario, contrasenia, false) { }

        #endregion


        //Metodos publicos

        public void sumateIntentoFallido()
        {
            // Sumamos uno al contador de intentos fallidos y validamos.
            campoIntentosFallidos++;
            if (campoIntentosFallidos >= 3)
            {
                // Si no pasa la validacion => inhabilitamos y lanzamos la excepcion correspondiente.
                this.inhabilitar();
                throw new UsuarioInhabilitadoException("El usuario ha realizado 3 ingresos incorrectos, " +
                "por lo tanto ha sido inhabilitado. Contactese con un alguien que tenga permisos para volver a "+
                "habilitar su usuario.");
            }
        }

        private void inhabilitar()
        {
            campoDeleted = true;
            this.update();
        }

        #region Metodos Persistencia y Recupero
        public static Usuario get(int idClavePrimaria)
        {
            return DataAccessObject<Usuario>.get(idClavePrimaria);
        }

        public static Usuario getByUsername(string strUsuario)
        {
            // La lista siempre devuelve un unico usuario porque el username es unique en la base.
            List<Usuario> usuarios = DataAccessObject<Usuario>.upFullByPrototype(new Usuario(strUsuario, ""));

            // Validamos.
            if (usuarios.Count != 1)
                throw new UsuarioNoEncontradoException(String.Format("El usuario {0} no fue encontrado en la base de datos", strUsuario));

            return usuarios[0];
        }

        public void save()
        {
            daoUsuario.insert(this);
        }

        public void update()
        {
            daoUsuario.update(this);
        }

        public DataTable upFullByPrototype()
        {
            return DataAccessObject<Usuario>.upFullOnTableByPrototype(this);
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<Usuario>.delete(idClavePrimaria);
        }

        public void borradoLogico()
        {
            campoDeleted = !campoDeleted;
            update();
        }

        #endregion

    }
}
