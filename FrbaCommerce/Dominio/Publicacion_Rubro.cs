using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Publicacion_Rubro
    {
        private DataAccessObject<Publicacion_Rubro> daoPublicacion_Rubro;

        public int campoCodPublicacion { get; set; }
        public int campoIdRubro { get; set; }

        #region Constructores

        public Publicacion_Rubro() { daoPublicacion_Rubro = new DataAccessObject<Publicacion_Rubro>(); }

        public Publicacion_Rubro(int codPublicacion) : this()
        {
            campoCodPublicacion = codPublicacion;
        }

        public Publicacion_Rubro(int codPublicacion, int idRubro)
            : this()
        {
            campoCodPublicacion = codPublicacion;
            campoIdRubro = idRubro;
        }


        #endregion

        //Metodos publicos
        public void save()
        {
            daoPublicacion_Rubro.insert(this);
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<Publicacion_Rubro>.delete(idClavePrimaria, "CodPublicacion");
        }

        public void update()
        {
            daoPublicacion_Rubro.update(this);
        }


        public List<Publicacion_Rubro> getListByPrototype()
        {
            return DataAccessObject<Publicacion_Rubro>.upFullByPrototype(this);
        }

        public DataTable upFullByPrototype()
        {
            return DataAccessObject<Publicacion_Rubro>.upFullOnTableByPrototype(this);
        }

        public static List<Publicacion_Rubro> upFull()
        {
            return DataAccessObject<Publicacion_Rubro>.upFull();
        }

        public static Publicacion_Rubro get(int idClavePrimaria)
        {
            return DataAccessObject<Publicacion_Rubro>.get(idClavePrimaria);
        }
    }
}
