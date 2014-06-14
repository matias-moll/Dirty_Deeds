using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Usuario_Rol
    {
        //Miembros
        private DataAccessObject<Usuario_Rol> daoUsuario_Rol;

        // Properties con la convencion del DataAccessObject
        public int campoIdUsuario { get; set; }
        public int campoIdRol { get; set; }

        #region Constructores
        public Usuario_Rol() { daoUsuario_Rol = new DataAccessObject<Usuario_Rol>(); }

        public Usuario_Rol(int idUsuario, int idRol) : this()
        {
            campoIdUsuario = idUsuario;
            campoIdRol = idRol;
        }

        #endregion


        //Metodos publicos

        #region Metodos Persistencia y Recupero

        public static Usuario_Rol get(int idClavePrimaria)
        {
            return DataAccessObject<Usuario_Rol>.get(idClavePrimaria);
        }

        public List<Usuario_Rol> getListByPrototype()
        {
            return DataAccessObject<Usuario_Rol>.upFullByPrototype(this);
        }

        public void save()
        {
            daoUsuario_Rol.insert(this);
        }

        public void update()
        {
            daoUsuario_Rol.update(this);
        }

        public DataTable upFullByPrototype()
        {
            return DataAccessObject<Usuario_Rol>.upFullOnTableByPrototype(this);
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<Usuario_Rol>.delete(idClavePrimaria);
        }


        #endregion

    }
}
