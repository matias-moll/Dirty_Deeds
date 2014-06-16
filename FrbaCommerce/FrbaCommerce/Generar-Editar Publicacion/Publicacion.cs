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
using ABMs;

namespace FrbaCommerce
{
    public partial class Publicacion : DockContent
    {
        PublicacionEnPantalla publicacionEnEdicion;
        Visibilidad visibilidadVacia;
        List<Dominio.Rubro> rubros;

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

            rubros = Rubro.upFull();
            cbRubros.DataSource = rubros;
            cbRubros.DisplayMember = "campoDescripcion";
            cbRubros.ValueMember = "autoId";

            lbRubrosElegidos.DisplayMember = "campoDescripcion";
            lbRubrosElegidos.ValueMember = "autoId";
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

        private void gbCancelar_Click(object sender, EventArgs e)
        {
            limpiarControlesGUI();
            habilitarSeleccionOperacion();
        }

        #region Eventos de botones de cambio de estado

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

        #endregion 

        private void gbAgregarRubro_Click(object sender, EventArgs e)
        {
            Dominio.Rubro rubroElegido = (Dominio.Rubro)cbRubros.SelectedItem;
            if (lbRubrosElegidos.Items.Contains(rubroElegido))
            {
                MessageBox.Show("No se puede agregar dos veces el mismo rubro a la publicacion");
                return;
            }

            lbRubrosElegidos.Items.Add(rubroElegido);
        }

        #endregion

        #region Metodos soporte (privados)

        private void grabarPublicacion()
        {
            Dominio.Publicacion publicacionAGrabar;
            int codigoPublicacion;
            if (publicacionEnEdicion.esNueva)
            {
                publicacionAGrabar = crearPublicacionFromControlesGUI();
                codigoPublicacion = publicacionAGrabar.save();
            }
            else
            {
                publicacionAGrabar = actualizarPublicacionFromControlesGUI();
                codigoPublicacion = publicacionAGrabar.campoCodigo;
                publicacionAGrabar.update();
            }

            grabarRubrosAsociados(codigoPublicacion);
        }

        private void grabarRubrosAsociados(int codPublicacion)
        {
            // Borramos las que tuviera.
            Publicacion_Rubro.delete(codPublicacion);

            // Y mandamos a grabar las nuevas.
            Publicacion_Rubro relacionRubro = new Publicacion_Rubro();
            relacionRubro.campoCodPublicacion = codPublicacion;
            Rubro unRubro;

            foreach (object rubro in lbRubrosElegidos.Items)
            {
                unRubro = (Rubro)rubro;
                relacionRubro.campoIdRubro = unRubro.autoId;
                relacionRubro.save();
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

            Visibilidad visibilidadElegida = (Visibilidad)cbVisibilidades.SelectedItem;

            publicacionAGrabar.campoFecha = DateTime.Now;
            publicacionAGrabar.campoFechaVto = publicacionAGrabar.campoFecha.AddDays(visibilidadElegida.campoDiasActiva);

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

            cargarAPantallaLosRubros(publicacionAEditar);
        }

        private void cargarAPantallaLosRubros(Dominio.Publicacion publicacionAEditar)
        {
            Publicacion_Rubro unaRelacionRubro = new Publicacion_Rubro();
            unaRelacionRubro.campoCodPublicacion = publicacionAEditar.campoCodigo;
            List<Publicacion_Rubro> rubros = unaRelacionRubro.getListByPrototype();
            foreach (Publicacion_Rubro rubroElegido in rubros)
            {
                // Simulamos las elecciones del usuario seteando el item y disparando el evento del click del add.
                cbRubros.SelectedValue = rubroElegido.campoIdRubro;
                gbAgregarRubro_Click(this, null);
            }
        }

        private bool comboSinSeleccionar(ComboBox combo)
        {
            return combo.SelectedValue.ToString().Trim() == "";
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
            lbRubrosElegidos.Items.Clear();
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


    }
}
