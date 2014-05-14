using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace ABMs
{
    public interface ABMEspecifico
    {
        DataTable ejecutarBusqueda();
        void alta();
        Panel getPanel();

    }
}
