using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Dominio;

namespace FrbaCommerce
{
    public partial class CalificarVendedor : DockContent
    {
        public CalificarVendedor()
        {
            InitializeComponent();
            estadoBotonera();
        }

        #region Operaciones


        private void gbCalificar_Click(object sender, EventArgs e)
        {
            if (!validacionRegistroSeleccionado())
                return;

            Calificar calificar = new Calificar();
            calificar.ShowDialog(this);

            if (calificar.DialogResult == DialogResult.Cancel)
                return;

            Calificacion calificacionObtenida = new Calificacion();
            // TODO: aca tengo que obtener los datos de la grilla para completar la calificacion.
            calificacionObtenida.campoCantidadEstrellas = calificar.estrellasObtenidas;
            calificacionObtenida.campoDescripcion = calificar.comentarioObtenido;
            calificacionObtenida.save();

            MessageBox.Show("Su calificación fue guardada exitosamente!");

            // Actualizamos la grilla.
            gbCargarCompras_Click(this, null);
        }

        private void gbCargarCompras_Click(object sender, EventArgs e)
        {

        }

        private void gbAceptar_Click(object sender, EventArgs e)
        {
            estadoBotonera();
        }

        #endregion

        #region Metodos Privados (soporte)

        private void estadoGrillaOperacional()
        {
            imgGrillaOperacional.Enabled = true;
            imgBotonera.Enabled = false;
        }

        private void estadoBotonera()
        {
            imgGrillaOperacional.Enabled = false;
            imgBotonera.Enabled = true;
            dgvCompras.DataSource = null;
        }

        private bool validacionRegistroSeleccionado()
        {
            if (dgvCompras.SelectedRows.Count != 1)
            {
                MessageBox.Show("Debe seleccionar solo una entidad (clickeando en la fila correspondiente) para poder seleccionarla");
                return false;
            }
            return true;
        }

        #endregion

    }
}
