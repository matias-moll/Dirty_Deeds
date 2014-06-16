using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Rubro
    {
        private DataAccessObject<Rubro> daoRubro;

        public int autoId { get; set; }
        public string campoDescripcion { get; set; }
        public bool campoDeleted { get; set; }

        #region Constructores

        public Rubro() { daoRubro = new DataAccessObject<Rubro>(); }

        public Rubro(string descripcion, bool p_deleted) : this()
        {
            campoDescripcion = descripcion;
            campoDeleted = p_deleted;
        }

        public Rubro(string descripcion) : this(descripcion, false) { }

        #endregion

        //Metodos publicos
        public void save()
        {
            daoRubro.insert(this);
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<Rubro>.delete(idClavePrimaria);
        }

        public void borradoLogico()
        {
            campoDeleted = !campoDeleted;
            update();
        }

        public static List<Rubro> upFull()
        {
            return DataAccessObject<Rubro>.upFull();
        }

        public void update()
        {
            daoRubro.update(this);
        }

        public DataTable upFullByPrototype()
        {
            return DataAccessObject<Rubro>.upFullOnTableByPrototype(this);
        }

        public static Rubro get(int idClavePrimaria)
        {
            return DataAccessObject<Rubro>.get(idClavePrimaria);
        }
    }
}
