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
        protected delegate void SelectorGrabacion();

        // Firmas obligatorias que deben sobreescribir las subclases.
        public abstract DataTable ejecutarBusqueda();
        public abstract Panel getPanel(Size tamañoPanel);
        public abstract void cargarTusDatos(int idClavePrimaria);
        protected abstract void grabarAlta();
        protected abstract void grabarModificacion();
        protected abstract void baja(int idClavePrimaria);
        


        // Metodos con comportamiento default, pueden sobreescribirse
        public virtual void alta(Form parent)
        {
            SelectorGrabacion metodo = () => this.grabarAlta();
            disparaFormularioCarga(parent, metodo, 0, "Se ha realizado exitosamente el alta");
        }

        public virtual void modificacion(Form parent, int idClavePrimaria)
        {
            SelectorGrabacion metodo = () => this.grabarModificacion();
            disparaFormularioCarga(parent, metodo, idClavePrimaria, "Se ha realizado exitosamente la modificación");
        }

        public virtual void baja(Form parent, int idClavePrimaria)
        {
            // Pedimos confirmacion.
            if (MessageBox.Show("¿Está seguro que desea borrar la entidad seleccionada?", "Baja",
                                MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            this.baja(idClavePrimaria);
            MessageBox.Show("Se ha realizado la baja física exitosamente");

        }
        
        public virtual Panel getPanel()
        {
            return this.getPanel(new Size(600, 200));
        }

        public virtual Panel getPanelAlta()
        {
            return this.getPanel(new Size(350, 340));
        }

        protected void disparaFormularioCarga(Form parent, SelectorGrabacion metodoGrabacion, int idClave, string mensajeExitoso)
        {
            // Disparamos el form de alta generico pasandole como resolver a nosotros mismos.
            AltaGenerico frmAlta = new AltaGenerico(this, idClave);
            frmAlta.ShowDialog(parent);

            // Si confirmo el alta
            if (frmAlta.DialogResult == DialogResult.OK)
            {
                metodoGrabacion();
                MessageBox.Show(mensajeExitoso);
            }
        }


    }
}
