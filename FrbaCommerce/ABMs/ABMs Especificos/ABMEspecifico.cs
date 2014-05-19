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
        // Firmas obligatorias que deben sobreescribir las subclases.
        public abstract DataTable ejecutarBusqueda();
        public abstract Panel getPanel(Size tamañoPanel);
        public abstract void grabarAlta();


        // Metodos con comportamiento default, pueden sobreescribirse
        public virtual void alta(Form parent)
        {
            // Disparamos el form de alta generico pasandole como resolver a nosotros mismos.
            AltaGenerico frmAltaRol = new AltaGenerico(this);
            frmAltaRol.ShowDialog(parent);

            // Si confirmo el alta
            if (frmAltaRol.DialogResult == DialogResult.OK)
            {
                this.grabarAlta();
                MessageBox.Show("Se ha realizado exitosamente la grabación");
            }
        }
        
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
