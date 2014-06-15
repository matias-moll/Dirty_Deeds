using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Publicacion
    {
        //Miembros
        private DataAccessObject<Publicacion> daoPublicacion;

        // Properties con la convencion del DataAccessObject
        public int campoCodigo { get; set; }
        public string campoDescripcion { get; set; }
        public int campoStock { get; set; }
        public DateTime campoFecha { get; set; }
        public DateTime campoFechaVto { get; set; }
        public decimal campoPrecio { get; set; }
        public string campoTipo { get; set; }
        public bool campoAceptaPreguntas { get; set; }

        public int foraneaIdEstado { get; set; }
        public int foraneaIdVisibilidad { get; set; }
        public int foraneaIdUsuario { get; set; }


        public Visibilidad prototipoVisibilidad { get; set; }
        public Publicacion_Estado prototipoEstado { get; set; }
        public Usuario prototipoUsuario { get; set; }


        #region Constructores
        public Publicacion() { daoPublicacion = new DataAccessObject<Publicacion>(); }

        public Publicacion(int codigo, string descripcion, int stock, DateTime fecha, DateTime fechaVto, decimal precio,
                           char tipo, bool aceptaPreguntas) : this()
        {
            campoCodigo = codigo;
            campoDescripcion = descripcion;
            campoStock = stock;
            campoFecha = fecha;
            campoFechaVto = fechaVto;
            campoPrecio = precio;
            campoTipo = tipo.ToString();
            campoAceptaPreguntas = aceptaPreguntas;
        }


        public Publicacion(int codigo, string descripcion, int stock, DateTime fecha, decimal precio, char tipo, bool preguntas)
            : this(codigo, descripcion, stock, fecha, new DateTime(1900, 1, 1), precio, tipo, preguntas) { }



        #endregion


        //Metodos publicos
        public static Publicacion get(int idClavePrimaria)
        {
            return DataAccessObject<Publicacion>.get(idClavePrimaria);
        }

        public void save()
        {
            daoPublicacion.insert(this);
        }

        public void update()
        {
            daoPublicacion.update(this);
        }

        public DataTable upFullByPrototype()
        {
            return DataAccessObject<Publicacion>.upFullOnTableByPrototype(this);
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<Publicacion>.delete(idClavePrimaria);
        }
    }
}
