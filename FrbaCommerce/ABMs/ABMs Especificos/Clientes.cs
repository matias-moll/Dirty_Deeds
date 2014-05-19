using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Dominio;

namespace ABMs
{
    class Clientes : ABMEspecifico
    {
        public DataTable ejecutarBusqueda()
        {
            return null;
        }

        public void alta()
        {
            Dal.DataAccessObject<Localidad> daoLocalidad = new Dal.DataAccessObject<Localidad>();
            Localidad unaLocalidad = new Localidad("2737", "Marcos Paz");
            daoLocalidad.insert(unaLocalidad);

        }
        public Panel getPanel()
        {
            return null;
        }
    }
}
