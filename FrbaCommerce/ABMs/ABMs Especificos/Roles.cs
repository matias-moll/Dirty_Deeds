using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Dominio;

namespace ABMs
{
    class Roles : ABMEspecifico
    {
        public DataTable ejecutarBusqueda()
        {
            return null;
        }

        public void alta()
        {
            // todo el codigo que dispare la ventana y me devuelva el objeto construido
            Rol unRol = new Rol(1, "Administrativo");
            unRol.save();
        }
        public Panel getPanel()
        {
            return null;
        }
    }
}
