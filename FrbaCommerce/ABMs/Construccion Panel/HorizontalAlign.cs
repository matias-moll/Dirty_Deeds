using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ABMs
{
    class HorizontalAlign : Alignment
    {
        Control controlMasLargo = new Control();

        public HorizontalAlign( Size tamaño)
                        : base(tamaño)
        {
            this.sizeLabels = new Size(76, 25);
            this.controlMasLargo.Size = new Size(1, 1);
        }

        internal override void pickLastControl(Label label, Control edit)
        {
            // Si el siguiente control va a ser en una nueva columna, necesitamos la posicion del edit.
            if (esUltimaFilaDeLaColumna())
                this.ultimoControlAñadido = edit;
            else
                // Para la alineacion horizontal siempre necesitamos que el ultimo control sea el label
                this.ultimoControlAñadido = label;
        }

        private bool esUltimaFilaDeLaColumna()
        {
            return ((this.posicionYInferiorUltimoControl() +
                   this.separacionVertical +
                   this.ultimoControlAñadido.Size.Height) >= this.tamañoDisponible.Height);
        }

        internal override Point calculaPosicion(Control control)
        {
            // Nos vamos quedando siempre con el control mas largo.
            if (control.Size.Width > this.controlMasLargo.Size.Width)
                controlMasLargo = control;

            return new Point(this.posicionXUltimoControl() + this.separacionHorizontal, this.ultimoControlAñadido.Location.Y);
        }

        internal override Point calculaPosicion(Label control)
        {
            // Si no hay lugar para otra fila de controles, pasamos a una nueva columna
            if (this.posicionYInferiorUltimoControl() + this.separacionVertical + control.Size.Height >
                this.tamañoDisponible.Height)
                return posicionEnOtraColumna(control);
            else
                // Si hay lugar, la posicion es la misma que la del label anterior sumando la separacion vertical.
                return new Point(this.ultimoControlAñadido.Location.X, 
                                 this.posicionYInferiorUltimoControl() + this.separacionVertical);

        }

        private Point posicionEnOtraColumna(Control control)
        {
            if (posicionXUltimoControl() + this.separacionHorizontal + control.Size.Width > this.tamañoDisponible.Width)
                throw new Exception("No hay espacio suficiente para agregar el control en el panel");
            else
            {
                Point posicionControl = new Point();
                posicionControl.X = this.ultimoControlAñadido.Location.X + this.controlMasLargo.Size.Width + this.separacionHorizontal*2;
                posicionControl.Y = this.puntoInicio.Y + this.separacionVertical;
                return posicionControl;
            }
        }


        internal override void cargaSeparaciones()
        {
            this.separacionVertical = 5;
            this.separacionHorizontal = 35;
        }


    }
}
