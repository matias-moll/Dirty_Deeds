using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Publicacion_Pregunta
    {
        private DataAccessObject<Publicacion_Pregunta> daoPublicacion_Pregunta;

        public int campoCodPublicacion { get; set; }
        public int campoNumPregunta { get; set; }
        public string campoPregunta { get; set; }
        public string campoRespuesta { get; set; }

        #region Constructores

        public Publicacion_Pregunta() { daoPublicacion_Pregunta = new DataAccessObject<Publicacion_Pregunta>(); }

        public Publicacion_Pregunta( int codPublicacion) : this()
        {
            campoCodPublicacion = codPublicacion;
            campoPregunta = "";
            campoRespuesta = "";
        }

        #endregion

        public static DataTable getPreguntasAResponder(int idUsuario)
        {
            DataTable dtPreguntas = StaticDataAccess.executeSPPreguntas("DIRTYDEEDS.Preguntas", idUsuario);
            DataRow[] drsPreguntas = dtPreguntas.Select("Respuesta = ''");

            if (drsPreguntas.Count() < 1)
                throw new Exception("No tiene preguntas pendientes de respuesta");
            else
                return drsPreguntas.CopyToDataTable();
        }

        public static DataTable getRespuestas(int idUsuario)
        {
            DataTable dtRespuestas = StaticDataAccess.executeSPPreguntas("DIRTYDEEDS.Preguntas", idUsuario);
            DataRow[] drsRespuestas = dtRespuestas.Select("Respuesta <> ''");
            if (drsRespuestas.Count() < 1)
                throw new Exception("No cuenta con ninguna pregunta respondida");
            else
                return drsRespuestas.CopyToDataTable();
        }

        //Para que este metodo retorne como si fuera un get el prototipo debe tener cargados los dos campos de la clave compuesta.
        public Publicacion_Pregunta getByPrototype()
        {
            List<Publicacion_Pregunta> pregunta = getListByPrototype();
            if (pregunta.Count != 1)
                throw new Exception("No fue posible obtener la pregunta que se buscaba");

            return pregunta[0];
        }

        //Metodos publicos
        public void save()
        {
            daoPublicacion_Pregunta.insert(this);
        }

        public int getSiguienteNroPreguntaFromPrototype()
        {
            // Esto funciona asumiendo que tenemos cargado el codigo de publicacion en el prototipo.
            DataTable dtResultado = this.upFullByPrototype();
            if (dtResultado == null)
                return 1;
            else
                return dtResultado.Rows.Count + 1;
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<Publicacion_Pregunta>.delete(idClavePrimaria);
        }

        public List<Publicacion_Pregunta> getListByPrototype()
        {
            return DataAccessObject<Publicacion_Pregunta>.upFullByPrototype(this);
        }

        public static List<Publicacion_Pregunta> upFull()
        {
            return DataAccessObject<Publicacion_Pregunta>.upFull();
        }

        public void update()
        {
            daoPublicacion_Pregunta.update(this, "",
                String.Format("CodPublicacion = {0} and NumPregunta = {1}", this.campoCodPublicacion, this.campoNumPregunta ));
        }

        public DataTable upFullByPrototype()
        {
            return DataAccessObject<Publicacion_Pregunta>.upFullOnTableByPrototype(this);
        }

        public static Publicacion_Pregunta get(int idClavePrimaria)
        {
            return DataAccessObject<Publicacion_Pregunta>.get(idClavePrimaria);
        }
    }
}
