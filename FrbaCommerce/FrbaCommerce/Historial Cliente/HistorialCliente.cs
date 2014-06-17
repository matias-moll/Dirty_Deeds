using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace FrbaCommerce
{
    public partial class HistorialCliente : DockContent
    {
        public HistorialCliente()
        {
            InitializeComponent();
        }

        #region Operaciones

        private void gbCompras_Click(object sender, EventArgs e)
        {
            // TODO: obtener compras.
            dgvHistorial.DataSource = null;

            estadoGrillaOperacional();
        }

        private void gbOfertas_Click(object sender, EventArgs e)
        {
            // TODO: obtener ofertas.
            dgvHistorial.DataSource = null;

            estadoGrillaOperacional();
        }

        private void gbCalificaciones_Click(object sender, EventArgs e)
        {
            // TODO: obtener Calificaciones.
            dgvHistorial.DataSource = null;

            estadoGrillaOperacional();
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
            dgvHistorial.DataSource = null;
        }

        private bool validacionRegistroSeleccionado()
        {
            if (dgvHistorial.SelectedRows.Count != 1)
            {
                MessageBox.Show("Debe seleccionar solo una entidad (clickeando en la fila correspondiente) para poder seleccionarla");
                return false;
            }
            return true;
        }

        #endregion
    }
}
