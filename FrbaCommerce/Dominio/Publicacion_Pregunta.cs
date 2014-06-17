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

        public static List<Publicacion_Pregunta> upFull()
        {
            return DataAccessObject<Publicacion_Pregunta>.upFull();
        }

        public void update()
        {
            daoPublicacion_Pregunta.update(this);
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
