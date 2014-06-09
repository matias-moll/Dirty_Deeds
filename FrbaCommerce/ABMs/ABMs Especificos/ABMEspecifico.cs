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
        protected enum modoForm { alta = 1, modificacion = 2 };

        // Firmas obligatorias que deben sobreescribir las subclases.
        public abstract DataTable ejecutarBusqueda();
        public abstract Panel getPanel(Size tamañoPanel);
        public abstract void cargarTusDatos(int idClavePrimaria);
        protected abstract void grabarAlta();
        protected abstract void grabarModificacion(int idClaveObjeto);
        protected abstract void baja(int idClavePrimaria);
        protected abstract void bajaLogica(int idClavePrimaria);


        // Metodos con comportamiento comun a todos los ABMs especificos.
        public virtual void alta(Form parent)
        {
            disparaFormularioCarga(parent, modoForm.alta, 0, "Se ha realizado exitosamente el alta");
        }

        public virtual void modificacion(Form parent, int idClavePrimaria)
        {
            disparaFormularioCarga(parent, modoForm.modificacion, idClavePrimaria, "Se ha realizado exitosamente la modificación");
        }

        public virtual void baja(Form parent, int idClavePrimaria)
        {
            // Pedimos confirmacion.
            if (MessageBox.Show(parent, "¿Está seguro que desea borrar la entidad seleccionada?", "Baja",
                                MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            this.baja(idClavePrimaria);
            MessageBox.Show(parent,"Se ha realizado la baja física exitosamente");
        }

        public virtual void bajaLogica(Form parent, int idClavePrimaria)
        {
            this.bajaLogica(idClavePrimaria);
            MessageBox.Show(parent, "Se ha realizado el cambio de estado lógico exitosamente");
        }
        
        public virtual Panel getPanel()
        {
            return this.getPanel(new Size(600, 200));
        }

        public virtual Panel getPanelAlta()
        {
            return this.getPanel(new Size(350, 340));
        }

        protected void disparaFormularioCarga(Form parent, modoForm modoForm, int idClave, string mensajeExitoso)
        {
            // Disparamos el form de alta generico pasandole como resolver a nosotros mismos.
            AltaGenerico frmAlta = new AltaGenerico(this, idClave);
            frmAlta.ShowDialog(parent);

            // Si confirmo el alta
            if (frmAlta.DialogResult == DialogResult.OK)
            {
                if (modoForm == modoForm.alta)
                    this.grabarAlta();
                else
                    this.grabarModificacion(idClave);
                MessageBox.Show(mensajeExitoso);
            }
        }


    }
}
