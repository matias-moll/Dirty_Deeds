using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;

namespace Dominio
{
    public class Visibilidad
    {
        public int claveCodigo { get; set; }
        public string campoDescripcion { get; set; }
        public double campoPrecio { get; set; }
        public double campoPorcentaje { get; set; }

        public Visibilidad(int codigo, string descripcion, double precio, double porcentaje)
        {
            claveCodigo = codigo;
            campoDescripcion = descripcion;
            campoPrecio = precio;
            campoPorcentaje = porcentaje;
        }

        // Metodos publicos
        public void save()
        {
            DataAccessObject<Visibilidad> daoVisibilidad = new DataAccessObject<Visibilidad>();
            daoVisibilidad.insert(this);
        }

        public void update()
        {

        }
    }
}
