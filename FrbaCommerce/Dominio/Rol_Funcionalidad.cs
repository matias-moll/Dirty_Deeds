using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Rol_Funcionalidad
    {
        //Miembros
        private DataAccessObject<Rol_Funcionalidad> daoRol_Funcionalidad;

        // Properties con la convencion del DataAccessObject
        public int campoIdRol { get; set; }
        public int campoIdFuncionalidad { get; set; }

        #region Constructores
        public Rol_Funcionalidad() { daoRol_Funcionalidad = new DataAccessObject<Rol_Funcionalidad>(); }

        public Rol_Funcionalidad(int idRol, int idFuncionalidad) : this()
        {
            campoIdFuncionalidad = idFuncionalidad;
            campoIdRol = idRol;
        }

        #endregion


        //Metodos publicos

        #region Metodos Persistencia y Recupero

        public static Rol_Funcionalidad get(int idClavePrimaria)
        {
            return DataAccessObject<Rol_Funcionalidad>.get(idClavePrimaria);
        }

        public List<Rol_Funcionalidad> getListByPrototype()
        {
            return DataAccessObject<Rol_Funcionalidad>.upFullByPrototype(this);
        }

        public void save()
        {
            daoRol_Funcionalidad.insert(this);
        }

        public void update()
        {
            daoRol_Funcionalidad.update(this);
        }

        public DataTable upFullByPrototype()
        {
            return DataAccessObject<Rol_Funcionalidad>.upFullOnTableByPrototype(this);
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<Rol_Funcionalidad>.delete(idClavePrimaria, "IdRol");
        }


        #endregion

    }
}
