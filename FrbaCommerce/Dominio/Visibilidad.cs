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

        public int autoCodigo { get; set; }
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
        }

        public Visibilidad(string descripcion, decimal precio, decimal porcentaje) :
            this(descripcion, precio, porcentaje, false) { }

        // Metodos publicos
        public void save()
        {
            DataAccessObject<Visibilidad> daoVisibilidad = new DataAccessObject<Visibilidad>();
            daoVisibilidad.insert(this);
        }

        public void update()
        {

        }

        public static DataTable upFullByCondition()
        {
            return DataAccessObject<Visibilidad>.upFullOnTable();
        }
    }
}
