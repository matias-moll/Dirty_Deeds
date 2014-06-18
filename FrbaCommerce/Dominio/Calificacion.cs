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
        public int campoIdCompra { get; set; }

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


        public static DataTable getVendedoresConMayoresCalificaciones(int anio, int mesInicio, int mesFin)
        {
            DataTable dtVendedores = StaticDataAccess.executeSPDeListadoEstadistico(
                                                    "DIRTYDEEDS.VendedoresCalificaciones", anio, mesInicio, mesFin);
            if (dtVendedores.Rows.Count < 1)
                throw new Exception("No se encontraron vendedores con calificaciones para los parametros especficados");
            else
                return dtVendedores;
        }

        public static DataTable getComprasYOfertasConCalificacionPendiente(int idUsuario)
        {
            DataTable dtCalificacionesPendientes = StaticDataAccess.executeSPConParametroUsuarioLoggeado("DIRTYDEEDS.ComprasYOfertasConCalificacionPendiente", idUsuario);
            if (dtCalificacionesPendientes.Rows.Count < 1)
                throw new Exception("No cuenta con ninguna compra / oferta ganadora pendiente de calificación");
            else
                return dtCalificacionesPendientes;
        }


        //Metodos publicos
        public void save()
        {
            // Obtenemos la clave que nos corresponde y grabamos.
            this.campoCodigo = StaticDataAccess.executeIntFunction("GetSiguienteCodigoCalificacion");
            if (this.campoCodigo == 0)
                throw new Exception("Error al intentar obtener el siguiente código de calificacion");
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
