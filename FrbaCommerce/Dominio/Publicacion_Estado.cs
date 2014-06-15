using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Publicacion_Estado
    {
        private DataAccessObject<Publicacion_Estado> daoPublicacion_Estado;

        public int autoId { get; set; }
        public string campoDescripcion { get; set; }

        #region Constructores

        public Publicacion_Estado() { daoPublicacion_Estado = new DataAccessObject<Publicacion_Estado>(); }

        public Publicacion_Estado(string descripcion) : this()
        {
            campoDescripcion = descripcion;
        }


        #endregion

        //Metodos publicos
        public void save()
        {
            daoPublicacion_Estado.insert(this);
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<Publicacion_Estado>.delete(idClavePrimaria);
        }

        public void update()
        {
            daoPublicacion_Estado.update(this);
        }

        public DataTable upFullByPrototype()
        {
            return DataAccessObject<Publicacion_Estado>.upFullOnTableByPrototype(this);
        }

        public static Publicacion_Estado get(int idClavePrimaria)
        {
            return DataAccessObject<Publicacion_Estado>.get(idClavePrimaria);
        }
    }
}
