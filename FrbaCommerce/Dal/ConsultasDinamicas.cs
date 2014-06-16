using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Dal
{
    public static class ConsultasDinamicas
    {
        public static DataTable getPrimerasNPublicaciones(int nroFilaInicio, int nroFilaFin, string whereParaElFiltro)
        {
            string camposFinales = "SELECT  subquery.Codigo, subquery.Presentacion, subquery.Stock, subquery.Fecha, subquery.FechaVto, subquery.Precio, subquery.Tipo, subquery.AceptaPreguntas";
            string fromYSubquery = " FROM ( SELECT  Publicacion.Codigo, Publicacion.Presentacion, Publicacion.Stock,  Visibilidad.Precio,Publicacion.Fecha, Publicacion.FechaVto, Publicacion.Tipo, Publicacion.AceptaPreguntas, ROW_NUMBER() OVER (ORDER BY Visibilidad.Precio) AS numero_row, Publicacion_Rubro.IdRubro FROM    DIRTYDEEDS.Publicacion join DIRTYDEEDS.Visibilidad on Publicacion.IdVisibilidad = Visibilidad.Id join DIRTYDEEDS.Estado on Publicacion.IdEstado = Estado.Id  join DIRTYDEEDS.Publicacion_Rubro on Publicacion.Codigo = Publicacion_Rubro.CodPublicacion ";
            string whereSubQuery = " where Publicacion.IdEstado = 1 and Publicacion.Stock > 0 ";
            if (whereParaElFiltro.Trim() != "")
                // Agregamos el where filtros quitandole el and del final.
                whereSubQuery += String.Format(" and {0}", whereParaElFiltro.Substring(0, whereParaElFiltro.Length - 4));
            string finSubquery = " ) subquery ";
            string where = String.Format(" where numero_row between {0} and {1}", nroFilaInicio, nroFilaFin);
            return StaticDataAccess.executeQuery(String.Format("{0}{1}{2}{3}{4}", camposFinales, fromYSubquery, whereSubQuery, finSubquery, where));
        }


        public static int getCantidadPublicacionesSegunFiltro(string whereFiltros)
        {
            string select = "select COUNT(*) FROM DIRTYDEEDS.Publicacion ";
            string joins = " join DIRTYDEEDS.Visibilidad on Publicacion.IdVisibilidad = Visibilidad.Id join DIRTYDEEDS.Estado on Publicacion.IdEstado = Estado.Id join DIRTYDEEDS.Publicacion_Rubro on Publicacion.Codigo = Publicacion_Rubro.CodPublicacion";
            string where = " where Publicacion.IdEstado = 1 and Publicacion.Stock > 0 ";

            if (whereFiltros.Trim() != "")
                // Agregamos el where filtros quitandole el and del final.
                where += String.Format(" and {0}", whereFiltros.Substring(0, whereFiltros.Length - 4));
            DataTable dtConteo = StaticDataAccess.executeQuery(String.Format("{0}{1}{2}", select, joins, where));

            if ((dtConteo == null) || (dtConteo.Rows.Count != 1) || (dtConteo.Rows[0][0].GetType() == typeof(DBNull)))
                return 0;

            return Convert.ToInt32(dtConteo.Rows[0][0]);

        }
    }
}
