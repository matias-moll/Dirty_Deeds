using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Localidad
    {
        //Miembros
        private DataAccessObject<Localidad> daoLocalidad;

        // Properties con la convencion del DataAccessObject
        public int autoId { get; set; }
        public int campoCodPostal { get; set; }
        public string campoNombre { get; set; }
        public bool campoDeleted { get; set; }

        #region Constructores
        public Localidad() { daoLocalidad = new DataAccessObject<Localidad>(); }

        public Localidad(int codPostal, string nombre, bool p_deleted) : this()
        {
            campoCodPostal = codPostal;
            campoNombre = nombre;
            campoDeleted = p_deleted;
        }

        public Localidad(int codPostal, string nombre) : this(codPostal,nombre, false) { }

        #endregion


        //Metodos publicos
        public static Localidad get(int idClavePrimaria)
        {
            return DataAccessObject<Localidad>.get(idClavePrimaria);
        }

        public void save()
        {
            daoLocalidad.insert(this);
        }

        public void update()
        {
            daoLocalidad.update(this);
        }

        public DataTable upFullByPrototype()
        {
            return daoLocalidad.upFullOnTableByPrototype(this);
        }

        public static List<Localidad> upFull()
        {
            return DataAccessObject<Localidad>.upFull();
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<Localidad>.delete(idClavePrimaria);
        }

        public void borradoLogico()
        {
            campoDeleted = !campoDeleted;
            update();
        }
    }
}
