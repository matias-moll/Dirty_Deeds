using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Calificacion
    {
        private DataAccessObject<Calificacion> daoCalificacion;

        public int campoCodigo { get; set; }
        public int campoCodigoPublicacion { get; set; }
        public int campoIdCalificador { get; set; }
        public int campoIdCalificado { get; set; }
        public string campoDescripcion { get; set; }
        public int campoCantidadEstrellas { get; set; }

        #region Constructores

        public Calificacion() { daoCalificacion = new DataAccessObject<Calificacion>(); }


        #endregion

        public static DataTable getCalificacionesDadasYRecibidas(int idUsuario)
        {
            DataTable dtCalificaciones = StaticDataAccess.executeSPConParametroUsuarioLoggeado("DIRTYDEEDS.Calificaciones", idUsuario);
            if (dtCalificaciones.Rows.Count < 1)
                throw new Exception("No cuenta con ninguna calificación (otorgada ni recibida)");
            else
                return dtCalificaciones;
        }


        //Metodos publicos
        public void save()
        {
            daoCalificacion.insert(this);
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<Calificacion>.delete(idClavePrimaria);
        }

        public static List<Calificacion> upFull()
        {
            return DataAccessObject<Calificacion>.upFull();
        }

        public void update()
        {
            daoCalificacion.update(this);
        }

        public DataTable upFullByPrototype()
        {
            return DataAccessObject<Calificacion>.upFullOnTableByPrototype(this);
        }

        public static Calificacion get(int idClavePrimaria)
        {
            return DataAccessObject<Calificacion>.get(idClavePrimaria);
        }
    }
}
