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
        public static DataTable getPrimerasNPublicaciones(int nroFilaInicio, int nroFilaFin, 
                                                          string whereRubros, string whereDescripcion)
        {
            string armaTablaTemporal = "";
            // Obtenemos la tabla temporal necesaria para validar los rubros.
            armaTablaTemporal = getTablaTemporalRubros(whereRubros, armaTablaTemporal);

            string camposFinales = "SELECT  subquery.Codigo, subquery.Presentacion, subquery.Stock, subquery.Fecha, subquery.FechaVto, subquery.Precio, subquery.Tipo, subquery.AceptaPreguntas";
            string fromYSubquery = " FROM ( SELECT  Publicacion.Codigo, Publicacion.Presentacion, Publicacion.Stock,  Visibilidad.Precio,Publicacion.Fecha, Publicacion.FechaVto, Publicacion.Tipo, Publicacion.AceptaPreguntas, ROW_NUMBER() OVER (ORDER BY Visibilidad.Precio) AS numero_row FROM    DIRTYDEEDS.Publicacion join DIRTYDEEDS.Visibilidad on Publicacion.IdVisibilidad = Visibilidad.Id join DIRTYDEEDS.Estado on Publicacion.IdEstado = Estado.Id  ";
            string whereSubQuery = " where Publicacion.IdEstado = 1 and Publicacion.Stock > 0  and EXISTS (SELECT 1 FROM   #matTemp01 WHERE  #matTemp01.CodPublicacion = Publicacion.Codigo)";
            whereSubQuery = addWhereDescripcion(whereDescripcion, whereSubQuery);
            string finSubquery = " ) subquery ";
            string where = String.Format(" where numero_row between {0} and {1}", nroFilaInicio, nroFilaFin);
            return StaticDataAccess.executeQuery(String.Format("{0}{1}{2}{3}{4}{5}", armaTablaTemporal,camposFinales, fromYSubquery, whereSubQuery, finSubquery, where));
        }


        public static int getCantidadPublicacionesSegunFiltro(string whereRubros, string whereDescripcion)
        {
            string armaTablaTemporal = "";
            // Obtenemos la tabla temporal necesaria para validar los rubros.
            armaTablaTemporal = getTablaTemporalRubros(whereRubros, armaTablaTemporal);
            string select = "select COUNT(*) FROM DIRTYDEEDS.Publicacion ";
            string joins = " join DIRTYDEEDS.Visibilidad on Publicacion.IdVisibilidad = Visibilidad.Id join DIRTYDEEDS.Estado on Publicacion.IdEstado = Estado.Id ";
            string where = " where Publicacion.IdEstado = 1 and Publicacion.Stock > 0 and EXISTS (SELECT 1 FROM   #matTemp01 WHERE  #matTemp01.CodPublicacion = Publicacion.Codigo) ";
            where = addWhereDescripcion(whereDescripcion, where);
            DataTable dtConteo = StaticDataAccess.executeQuery(String.Format("{0}{1}{2}{3}", armaTablaTemporal, select, joins, where));

            if ((dtConteo == null) || (dtConteo.Rows.Count != 1) || (dtConteo.Rows[0][0].GetType() == typeof(DBNull)))
                return 0;

            return Convert.ToInt32(dtConteo.Rows[0][0]);

        }

        // Metodos privados para evitar logica repetida.
        private static string addWhereDescripcion(string whereDescripcion, string whereSubQuery)
        {
            if (whereDescripcion.Trim() != "")
                // Agregamos el where filtros quitandole el and del final.
                whereSubQuery += String.Format(" and {0}", whereDescripcion);
            return whereSubQuery;
        }

        private static string getTablaTemporalRubros(string whereRubros, string armaTablaTemporal)
        {
            armaTablaTemporal = "IF EXISTS(SELECT * FROM tempdb.dbo.sysobjects WHERE ID = OBJECT_ID(N'tempdb..#matTemp01')) BEGIN DROP TABLE #matTemp01 END select distinct CodPublicacion into #matTemp01 from DIRTYDEEDS.Publicacion_Rubro ";
            string whereTablaTemporal = "";
            if (whereRubros.Trim() != "")
                whereTablaTemporal += String.Format(" where {0} ", whereRubros);
            armaTablaTemporal += whereTablaTemporal;
            return armaTablaTemporal;
        }
    }
}
