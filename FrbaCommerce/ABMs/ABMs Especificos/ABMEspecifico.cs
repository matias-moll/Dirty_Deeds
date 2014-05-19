using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace ABMs
{
    public abstract class ABMEspecifico
    {
        public abstract DataTable ejecutarBusqueda();
        public abstract  void alta(Form parent);
        public abstract Panel getPanel(Size tamañoPanel);

        public virtual Panel getPanel()
        {
            return this.getPanel(new Size(600, 200));
        }

        public virtual Panel getPanelAlta()
        {
            return this.getPanel(new Size(350, 340));
        }

    }
}
