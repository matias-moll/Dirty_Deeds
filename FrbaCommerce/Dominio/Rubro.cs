using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;

namespace Dominio
{
    public class Rubro
    {
        public int autoId { get; set; }
        public string campoDescripcion { get; set; }

        public Rubro(string descripcion)
        {
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
