using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FrbaCommerce
{
    abstract class Alignment
    {
        
        internal Size tamañoDisponible { get; set; }
        internal Control ultimoControlAñadido;
        private string nombreDefault = "Default";
        internal int separacionVertical;
        internal int separacionHorizontal;
        internal Point puntoInicio = new Point(10, 10);
        // Cargamos los valores defaults para los sizes, cada alignment peude sobreescribirlos luego.
        public Size sizeLabels = new Size(120, 25);
        public Size sizeEdits = new Size(180, 20);
        public Size sizeNumberEdits = new Size(60, 20);
        public Size sizeDateEdits = new Size(90, 20);

        public Alignment(Size tamaño)
        {
            tamañoDisponible = tamaño;
            ultimoControlAñadido = new Control();
            ultimoControlAñadido.Location = puntoInicio;
            ultimoControlAñadido.Size = new Size(0,0);
            ultimoControlAñadido.Name = nombreDefault;
            // Delegamos en las subclases el cargado de las sepraciones.
            cargaSeparaciones();
        }

        public void addControlWithLabel(Label label, Control edit, Panel panelToBuild)
        {
            // Calculamos las posiciones de los controles a añadir
            label.Location = calculaPosicion(label);
            ultimoControlAñadido = label;
            edit.Location = calculaPosicion(edit);
            ultimoControlAñadido = edit;

            // Los agregamos al panel.
            panelToBuild.Controls.Add(label);
            panelToBuild.Controls.Add(edit);

            // Cada subclase puede elegir cual es el ultimo control, en base a ello calcula la siguiente posicion.
            pickLastControl(label, edit);
        }

        public void addGrouper(GroupBox grouper, Panel panelToBuild)
        {
            acomodarControlesEnAgrupador(grouper);
            grouper.Location = calculaPosicion(grouper);
            ultimoControlAñadido = grouper;

            panelToBuild.Controls.Add(grouper);
        }

        internal abstract void pickLastControl(Label label, Control edit);
        internal abstract Point calculaPosicion(Control control);
        internal abstract Point calculaPosicion(Label control);
        internal abstract void cargaSeparaciones();
        internal virtual void acomodarControlesEnAgrupador(GroupBox grouper) { }


        internal virtual void centrarControlesEnElPanel(Panel panelToBuild) 
        {
            int puntoMaximoEnEjeX = 0;
            int puntoFinalControl = 0;
            // Obtenemos el maximo.
            foreach (Control unControl in panelToBuild.Controls)
            {
                puntoFinalControl = unControl.Location.X + unControl.Size.Width;
                if (puntoFinalControl > puntoMaximoEnEjeX)
                    puntoMaximoEnEjeX = puntoFinalControl;
            }

            int separacionDeUltimoControlABordePanel = this.tamañoDisponible.Width - puntoMaximoEnEjeX;
            // La cantidad de pixeles a mover para centrar es la separacion del ultimo control menos 
            // la separacion actual que se fija como punto de inicio divido 2 ya que la idea es que quede
            // misma cantidad de puntos vacios a ambos lados.
            int cantidadAMoverLosControles = (separacionDeUltimoControlABordePanel - this.puntoInicio.X) / 2;

            if (cantidadAMoverLosControles > 1)
                moverTodosLosControlesEnEjeXDe(panelToBuild, cantidadAMoverLosControles);
        }

        // Si el ultimo control es el default de la clase, permitimos que cambie la posicion inicial.
        private Point posicionInicial 
        {
            set 
            {
                if (esElControlDefault())
                    ultimoControlAñadido.Location = value;
            } 
        }


        private bool esElControlDefault()
        {
            return ultimoControlAñadido.Name == nombreDefault;
        }

        // Metodos soporte que ayudan a que el codigo sea mas claro en las clases derivadas
        internal int posicionYInferiorUltimoControl()
        {
            return ultimoControlAñadido.Location.Y +
                            ultimoControlAñadido.Size.Height;
        }

        internal int posicionXUltimoControl()
        {
            return ultimoControlAñadido.Location.X +
                        ultimoControlAñadido.Size.Width;
        }

        private void moverTodosLosControlesEnEjeXDe(Panel panelToBuild, int cantidadAMoverLosControles)
        {
            foreach (Control unControl in panelToBuild.Controls)
                unControl.Location = new Point(unControl.Location.X + cantidadAMoverLosControles, unControl.Location.Y);
        }

    }
}
