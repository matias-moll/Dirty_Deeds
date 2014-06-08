using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Visibilidad
    {
        private bool deleted;
        private DataAccessObject<Visibilidad> daoVisibilidad;

        public int autoId { get; set; }
        public string campoDescripcion { get; set; }
        public decimal campoPrecio { get; set; }
        public decimal campoPorcentaje { get; set; }
        public byte campoDeleted { get { if (deleted) return 1; else return 0; } }

        public Visibilidad(string descripcion, decimal precio, decimal porcentaje, bool p_deleted)
        {
            campoDescripcion = descripcion;
            campoPrecio = precio;
            campoPorcentaje = porcentaje;
            deleted = p_deleted;
            daoVisibilidad = new DataAccessObject<Visibilidad>();
        }

        public Visibilidad(string descripcion, decimal precio, decimal porcentaje) :
            this(descripcion, precio, porcentaje, false) { }

        // Metodos publicos
        public void save()
        {
            daoVisibilidad.insert(this);
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<Visibilidad>.delete(idClavePrimaria, typeof(Visibilidad));
        }

        public void update()
        {

        }

        public DataTable upFullByPrototype()
        {
            return daoVisibilidad.upFullOnTableByPrototype(this);
        }
    }
}
