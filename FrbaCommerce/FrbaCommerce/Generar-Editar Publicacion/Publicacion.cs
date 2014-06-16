﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Dominio;
using ABMs;

namespace FrbaCommerce
{
    public partial class Publicacion : DockContent
    {
        PublicacionEnPantalla publicacionEnEdicion;
        Visibilidad visibilidadVacia;

        public Publicacion()
        {
            InitializeComponent();

            // Inicializacion estado.
            visibilidadVacia = new Visibilidad();
            visibilidadVacia.autoId = 0;
            visibilidadVacia.campoDescripcion = "";

            //Carga de combos
            TipoPublicacion.cargarComboTipos(cbTipos);
            cbVisibilidades.DataSource = Visibilidad.upFull();
            cbVisibilidades.DisplayMember = "campoDescripcion";
            cbVisibilidades.ValueMember = "autoId";
        }

        #region Operaciones (eventos de click)

        private void gbNuevaPublicacion_Click(object sender, EventArgs e)
        {
            publicacionEnEdicion = new PublicacionEnPantalla(new Dominio.Publicacion(), new Nueva(), 
                                                             PublicacionEnPantalla.modoPublicacion.nueva);

            habilitarCargaPublicacion();
        }

        private void gbEditarPublicacion_Click(object sender, EventArgs e)
        {
            // Disparamos la seleccion de publicacion.
            ABMGenerico seleccionPublicacion = new ABMGenerico(new Publicaciones(DatosGlobales.usuarioLoggeado), 
                                                               ABMGenerico.modoPantalla.seleccion);
            seleccionPublicacion.ShowDialog(this);

            if (seleccionPublicacion.DialogResult != DialogResult.OK)
                return;

            // Obtenemos la publicacion seleccionada.
            Dominio.Publicacion publicacionAEditar = Dominio.Publicacion.get(seleccionPublicacion.idClavePrimariaObjetoSeleccionado);

            publicacionEnEdicion = new PublicacionEnPantalla(publicacionAEditar, 
                                                             Estado.getEstadoFromId(publicacionAEditar.foraneaIdEstado), 
                                                             PublicacionEnPantalla.modoPublicacion.existente); 
            cargarAPantalla(publicacionEnEdicion.objeto);
            habilitarCargaPublicacion();
        }

        private void gbConfirmar_Click(object sender, EventArgs e)
        {
            // Validamos.
            if (lblEstado.Text.Trim() == "Nueva")
            {
                MessageBox.Show("No se puede grabar una Publicación con estado Nueva, elija si quiere activarla o guardarla como borrador.");
                return;
            }
            if (comboSinSeleccionar(cbTipos))
            {
                MessageBox.Show("No se puede grabar una Publicación sin elegirle un tipo.");
                return;
            }
            if(comboSinSeleccionar(cbVisibilidades))
            {
                MessageBox.Show("No se puede grabar una Publicación sin elegirle una visibilidad.");
                return;
            }

            // Pasadas las validaciones grabamos y volvemos a estado de seleccion de operacion.
            try
            {
                grabarPublicacion();
                limpiarControlesGUI();
                habilitarSeleccionOperacion();
                MessageBox.Show("La publicación fue guardada exitosamente");
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private bool comboSinSeleccionar(ComboBox combo)
        {
            return combo.SelectedValue.ToString().Trim() == "";
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
            if (publicacionEnEdicion.esNueva)
            {
                publicacionAGrabar = crearPublicacionFromControlesGUI();
                publicacionAGrabar.save();
            }
            else
            {
                publicacionAGrabar = actualizarPublicacionFromControlesGUI();
                publicacionAGrabar.update();
            }
        }

        private Dominio.Publicacion actualizarPublicacionFromControlesGUI()
        {
            Dominio.Publicacion publicacionAGrabar = publicacionEnEdicion.objeto;
            actualizarCamposComunesAAmbosModos(publicacionAGrabar);

            if (Estado.esEstadoFinalizada(publicacionEnEdicion.estado))
                publicacionAGrabar.campoFechaVto = DateTime.Now;

            return publicacionAGrabar;
        }

        private Dominio.Publicacion crearPublicacionFromControlesGUI()
        {
            Dominio.Publicacion publicacionAGrabar = publicacionEnEdicion.objeto;
            actualizarCamposComunesAAmbosModos(publicacionAGrabar);

            publicacionAGrabar.campoFecha = DateTime.Now;
            publicacionAGrabar.campoFechaVto = new DateTime(1900, 1, 1);

            return publicacionAGrabar;
        }

        private void actualizarCamposComunesAAmbosModos(Dominio.Publicacion publicacionAGrabar)
        {
            publicacionAGrabar.campoTipo = cbTipos.SelectedValue.ToString();
            publicacionAGrabar.campoStock = neStock.Numero;
            publicacionAGrabar.campoPrecio = dcePrecio.Decimal;
            publicacionAGrabar.campoPresentacion = teDescripcion.Text;
            publicacionAGrabar.campoAceptaPreguntas = rbAceptaPreguntas.Checked;

            publicacionAGrabar.foraneaIdUsuario = DatosGlobales.usuarioLoggeado.autoId;
            publicacionAGrabar.foraneaIdEstado = publicacionEnEdicion.estado.id;
            publicacionAGrabar.foraneaIdVisibilidad = (int)cbVisibilidades.SelectedValue;
        }

        private void cargarAPantalla(Dominio.Publicacion publicacionAEditar)
        {
            neStock.Numero = publicacionAEditar.campoStock;
            dcePrecio.Decimal = publicacionAEditar.campoPrecio;
            rbAceptaPreguntas.Checked = publicacionAEditar.campoAceptaPreguntas;
            cbTipos.SelectedValue = Convert.ToChar(publicacionAEditar.campoTipo);
            cbVisibilidades.SelectedValue = publicacionAEditar.foraneaIdVisibilidad;
            teDescripcion.Text = publicacionAEditar.campoPresentacion;
        }

        private void limpiarControlesGUI()
        {
            neStock.Numero = 0;
            dcePrecio.Decimal = 0.00M;
            rbAceptaPreguntas.Checked = false;
            cbTipos.SelectedItem = TipoPublicacion.tipoVacio;
            cbVisibilidades.SelectedItem = visibilidadVacia;
            teDescripcion.Text = "";
            lblEstado.Text = "";
        }

        private void habilitarCargaPublicacion()
        {
            imgModo.Enabled = false;
            imgPublicacion.Enabled = true;

            publicacionEnEdicion.estado.habilitaControlesCorrespondientes(this);

            Refresh();
        }

        private void habilitarSeleccionOperacion()
        {
            publicacionEnEdicion = null;
            imgModo.Enabled = true;
            imgPublicacion.Enabled = false;

            Refresh();
        }

        #endregion

        private void gbBorrador_Click(object sender, EventArgs e)
        {
            publicacionEnEdicion.estado = Estado.estados["Borrador"];
            publicacionEnEdicion.estado.habilitaControlesCorrespondientes(this);
            lblEstado.Text = "Borrador";
        }

        private void gbActiva_Click(object sender, EventArgs e)
        {
            publicacionEnEdicion.estado = Estado.estados["Activa"];
            publicacionEnEdicion.estado.habilitaControlesCorrespondientes(this);
            lblEstado.Text = "Activa";
        }

        private void gbPausar_Click(object sender, EventArgs e)
        {
            publicacionEnEdicion.estado = Estado.estados["Pausada"];
            publicacionEnEdicion.estado.habilitaControlesCorrespondientes(this);
            lblEstado.Text = "Pausada";
        }

        private void gbFinalizar_Click(object sender, EventArgs e)
        {
            publicacionEnEdicion.estado = Estado.estados["Finalizada"];
            publicacionEnEdicion.estado.habilitaControlesCorrespondientes(this);
            lblEstado.Text = "Finalizada";
        }


    }
}
