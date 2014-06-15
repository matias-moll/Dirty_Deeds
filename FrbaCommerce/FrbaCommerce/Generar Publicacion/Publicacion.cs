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
    public partial class Publicacion : DockContent
    {
        Publicacion publicacionEnEdicion;
        Visibilidad visibilidadVacia;

        public Publicacion()
        {
            InitializeComponent();

            // Inicializacion estado.
            publicacionEnEdicion = null;
            visibilidadVacia = new Visibilidad();
            visibilidadVacia.autoId = 0;
            visibilidadVacia.campoDescripcion = "";

            //Carga de combos
            cbTipos.DataSource = TipoPublicacion.tipos;
            cbTipos.DisplayMember = "descripcion";
            cbTipos.ValueMember = "tipo";
            cbVisibilidades.DataSource = Visibilidad.upFull();
            cbVisibilidades.DisplayMember = "campoDescripcion";
            cbVisibilidades.ValueMember = "autoId";
        }

        #region Operaciones (eventos de click)

        private void gbNuevaPublicacion_Click(object sender, EventArgs e)
        {
            habilitarCargaPublicacion();
        }

        private void gbEditarPublicacion_Click(object sender, EventArgs e)
        {
            publicacionEnEdicion = new Publicacion(); // Aca va la pantalla de seleccion de publicacion.
            cargarAPantalla(publicacionEnEdicion);
            habilitarCargaPublicacion();
        }

        private void gbConfirmar_Click(object sender, EventArgs e)
        {
            grabarPublicacion();
            limpiarControlesGUI();
            habilitarSeleccionOperacion();
        }

        private void gbCancelar_Click(object sender, EventArgs e)
        {
            limpiarControlesGUI();
            habilitarSeleccionOperacion();
        }

        #endregion

        #region Metodos soporte (privados)

        private void grabarPublicacion()
        {
            Dominio.Publicacion publicacionAGrabar;
            if (publicacionEnEdicion == null)
            {
                publicacionAGrabar = crearPublicacionFromControlesGUI();
                publicacionAGrabar.save();
            }
            else
            {
                publicacionAGrabar = actualizarPublicacionFromControlesGUI(publicacionEnEdicion);
                publicacionAGrabar.update();
            }
        }

        private Dominio.Publicacion actualizarPublicacionFromControlesGUI(Publicacion publicacionEnEdicion)
        {
            throw new NotImplementedException();
        }

        private Dominio.Publicacion crearPublicacionFromControlesGUI()
        {
            throw new NotImplementedException();
        }

        private void cargarAPantalla(Publicacion publicacionAEditar)
        {
            throw new NotImplementedException();
        }

        private void limpiarControlesGUI()
        {
            neStock.Numero = 0;
            dcePrecio.Decimal = 0.00M;
            rbAceptaPreguntas.Checked = false;
            cbTipos.SelectedItem = TipoPublicacion.tipoVacio;
            cbVisibilidades.SelectedItem = visibilidadVacia;
            teDescripcion.Text = "";
        }

        private void habilitarCargaPublicacion()
        {
            imgModo.Enabled = false;
            imgPublicacion.Enabled = true;
        }

        private void habilitarSeleccionOperacion()
        {
            publicacionEnEdicion = null;
            imgModo.Enabled = true;
            imgPublicacion.Enabled = false;
        }

        #endregion

    }
}
