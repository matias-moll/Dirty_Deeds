using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;

namespace Dominio
{
    public class Rubro
    {
        public int claveId { get; set; }
        public string campoDescripcion { get; set; }

        public Rubro(int id, string descripcion)
        {
            claveId = id;
            campoDescripcion = descripcion;
        }


        //Metodos publicos
        public void save()
        {
            DataAccessObject<Rubro> daoRol = new DataAccessObject<Rubro>();
            daoRol.insert(this);
        }

        public void update()
        {

        }
    }
}
