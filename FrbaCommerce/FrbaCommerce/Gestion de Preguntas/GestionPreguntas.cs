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
    public partial class GestionPreguntas : DockContent
    {
        public GestionPreguntas()
        {
            InitializeComponent();
            estadoBotonera();
        }

        #region Operaciones

        private void gbResponder_Click(object sender, EventArgs e)
        {
            if (!validacionRegistroSeleccionado())
                return;

            ResponderPregunta responder = new ResponderPregunta(dgvPreguntas.SelectedRows[0].Cells["Pregunta"].Value.ToString());
            responder.ShowDialog(this);

            if (responder.DialogResult == DialogResult.Cancel)
                return;

            // Llenamos el objeto y lo mandamos a actualizar.
            Publicacion_Pregunta preguntaRespondida = new Publicacion_Pregunta();
            preguntaRespondida.campoCodPublicacion = (int)dgvPreguntas.SelectedRows[0].Cells["Codigo_Publicacion"].Value;
            preguntaRespondida.campoNumPregunta = (int)dgvPreguntas.SelectedRows[0].Cells["Numero_Pregunta"].Value;
            preguntaRespondida.campoPregunta = dgvPreguntas.SelectedRows[0].Cells["Pregunta"].Value.ToString();
            preguntaRespondida.campoRespuesta = responder.respuestaObtenida;
            preguntaRespondida.update();

            MessageBox.Show("Su respuesta fue grabada exitosamente!");

            // Actualizamos la grilla.
            gbResponderPreguntas_Click(this, null);
        }

        private void gbResponderPreguntas_Click(object sender, EventArgs e)
        {
            // Cambiamos el estado del form y mostramos las preguntas correspondientes.
            estadoGrillaOperacional(true);
            try
            {
                dgvPreguntas.DataSource = Publicacion_Pregunta.getPreguntasAResponder(DatosGlobales.usuarioLoggeado.autoId);
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                return;
            }
        }

        private void gbVerRespuestas_Click(object sender, EventArgs e)
        {
            try
            {
                dgvPreguntas.DataSource = Publicacion_Pregunta.getRespuestas(DatosGlobales.usuarioLoggeado.autoId);
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                return;
            }
            estadoGrillaOperacional(false);
        }

        private void gbAceptar_Click(object sender, EventArgs e)
        {
            estadoBotonera();
        }

        #endregion

        #region Metodos Privados (soporte)

        private void estadoGrillaOperacional(bool habilitarBotonResponderPreguntas)
        {
            imgGrillaOperacional.Enabled = true;
            imgBotonera.Enabled = false;
            gbResponder.Enabled = habilitarBotonResponderPreguntas;
        }

        private void estadoBotonera()
        {
            imgGrillaOperacional.Enabled = false;
            imgBotonera.Enabled = true;
            dgvPreguntas.DataSource = null;
        }

        private bool validacionRegistroSeleccionado()
        {
            if (dgvPreguntas.SelectedRows.Count != 1)
            {
                MessageBox.Show("Debe seleccionar solo una entidad (clickeando en la fila correspondiente) para poder seleccionarla");
                return false;
            }
            return true;
        }

        #endregion

    }
}
