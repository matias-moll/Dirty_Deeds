using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TNGS.NetControls;

namespace FrbaCommerce
{
    public partial class ABMGenerico : Form
    {
        public enum modoPantalla { abm = 1, seleccion = 2, bajaLogicaYRecupero= 3 };

        ABMEspecifico resolver;
        Panel pnFiltros;

        public int idClavePrimariaObjetoSeleccionado { get; set; }

        public ABMGenerico(ABMEspecifico resolverEspecifico)
        {
            InitializeComponent();
            resolver = resolverEspecifico;

            estadoInicial(modoPantalla.abm);
        }

        public ABMGenerico(ABMEspecifico resolverEspecifico, modoPantalla modo)
        {
            InitializeComponent();
            resolver = resolverEspecifico;

            estadoInicial(modo);
        }

        private void estadoInicial(modoPantalla modo)
        {
            // Si pidio modo de seleccion para la pantalla
            if (modo == modoPantalla.seleccion)
            {
                // Escondemos los botones de funcionalidad ABM y mostramos el de seleccion.
                gbAlta.Visible = false;
                gbBajaRecupero.Visible = false;
                gbBajaFisica.Visible = false;
                gbModificacion.Visible = false;

                gbSeleccionar.Visible = true;
                idClavePrimariaObjetoSeleccionado = 0;
            }
            else if (modo == modoPantalla.bajaLogicaYRecupero)
            {
                // Solo dejamos visible el boton de baja y recupero logico.
                gbAlta.Visible = false;
                gbBajaFisica.Visible = false;
                gbModificacion.Visible = false;
                gbSeleccionar.Visible = false;
            }
        }

        private void ABMGenerico_Load(object sender, EventArgs e)
        {
            // Cargamos el titulo y el panel especificos para completar nuestro form de ABM
            this.Text = resolver.GetType().Name.ToString();
            pnFiltros = resolver.getPanel();
            this.gbFiltros.Controls.Add(pnFiltros);

            // Hay que hacer esto de recargar los controles para evitar unas validaciones boludas que hace
            // los controles decimal y sino les pinta el fondo de rojo.
            limpiarControlesDelPanel();
            resetearControles();
        }


        #region Operaciones

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiamos el texto de todos los textbox del agrupador de filtros. Y luego la grilla.
            foreach (Control unControl in pnFiltros.Controls)
                if (esControlEdit(unControl.GetType()))
                    unControl.Text = "";

            dgvGrilla.DataSource = null;
            pnFiltros.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvGrilla.DataSource = formatToGrid(resolver.ejecutarBusqueda());
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            // Limpiamos los controles (se reutilizan para las dos pantallas, por eso hay que limpiarlos).
            limpiarControlesDelPanel();

            try
            {
                // Delegamos el alta.
                resolver.alta(this);
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
            resetearControles();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.SelectedRows.Count != 1)
            {
                MessageBox.Show("Debe seleccionar solo una entidad (clickeando en la fila correspondiente) para poder modificarla");
                return;
            }
            try
            {
                // Recuperamos la clave primaria que es el primer campo en todas las grillas. Y delegamos la baja.
                int idClavePrimaria = Convert.ToInt32(dgvGrilla.SelectedRows[0].Cells[0].Value);
                resolver.modificacion(this, idClavePrimaria);
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

            resetearControles();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.SelectedRows.Count != 1)
            {
                MessageBox.Show("Debe seleccionar solo una entidad (clickeando en la fila correspondiente) para poder borrarla");
                return;
            }
            try
            {
                // Recuperamos la clave primaria que es el primer campo en todas las grillas. Y delegamos la baja.
                int idClavePrimaria = Convert.ToInt32(dgvGrilla.SelectedRows[0].Cells[0].Value);
                resolver.baja(this, idClavePrimaria);

                // Actualizamos la grilla.
                this.btnBuscar_Click(this, new EventArgs());
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        #endregion


        #region Metodos Privados

        private void resetearControles()
        {
            // Removemos el panel actual y obtenemos uno nuevo para la busqueda (sino no se carga).
            this.gbFiltros.Controls.Remove(pnFiltros);
            pnFiltros = resolver.getPanel();

            // Añadimos el panel nuevamente.
            this.gbFiltros.Controls.Add(pnFiltros);

            // Limpiamos la pantalla porque el alta puede modificar la consulta realizada y no podemos impactarla de vuelta.
            this.btnLimpiar_Click(this, new EventArgs());
        }

        private void limpiarControlesDelPanel()
        {
            foreach (Control unControl in pnFiltros.Controls)
            {
                if (esControlEdit(unControl.GetType())) unControl.Text = "";
                if (esCombo(unControl.GetType())) ((ComboBox)unControl).SelectedValue = 0;
            }
        }

        

        private DataTable formatToGrid(DataTable tablaAMostrar)
        {
            tablaAMostrar.Columns["Deleted"].ReadOnly = true;
            ajustarColumnasEnCasoDeCamposForaneos(tablaAMostrar);
            return tablaAMostrar;
        }

        private void ajustarColumnasEnCasoDeCamposForaneos(DataTable tablaAMostrar)
        {
            // Si hay campos de una tabla foranea
            if (tablaAMostrar.Columns.Contains("Deleted1"))
            {
                // Hacemos que el deleted1 (el del final) sea readonly y borramos el Deleted y el Id1 (foraneo)
                tablaAMostrar.Columns["Deleted1"].ReadOnly = true;
                tablaAMostrar.Columns.Remove(tablaAMostrar.Columns["Deleted"]);
                tablaAMostrar.Columns.Remove(tablaAMostrar.Columns["Id1"]);
            }

            if (tablaAMostrar.Columns.Contains("IdReferencia"))
                tablaAMostrar.Columns.Remove(tablaAMostrar.Columns["IdReferencia"]);
        }

        private bool esControlEdit(Type tipoControl)
        {
            return ((tipoControl == typeof(TextEdit)) || (tipoControl == typeof(NumberEdit)) ||
                (tipoControl == typeof(DecimalEdit)) || (tipoControl == typeof(DateTimeEdit)) ||
                (tipoControl == typeof(CuitEdit)) || (tipoControl == typeof(DateEdit)));
        }

        private bool esCombo(Type type)
        {
            return type == typeof(ComboBox);
        }

        #endregion

        private void btnBajaLogica_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.SelectedRows.Count != 1)
            {
                MessageBox.Show("Debe seleccionar solo una entidad (clickeando en la fila correspondiente) para poder borrarla");
                return;
            }
            try
            {
                // Recuperamos la clave primaria que es el primer campo en todas las grillas. Y delegamos la baja.
                int idClavePrimaria = Convert.ToInt32(dgvGrilla.SelectedRows[0].Cells[0].Value);
                resolver.bajaLogica(this, idClavePrimaria);

                // Actualizamos la grilla.
                this.btnBuscar_Click(this, new EventArgs());
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.SelectedRows.Count != 1)
            {
                MessageBox.Show("Debe seleccionar solo una entidad (clickeando en la fila correspondiente) para poder seleccionarla");
                return;
            }
            try
            {
                // Recuperamos la clave primaria que es el primer campo en todas las grillas. Y delegamos la baja.
                idClavePrimariaObjetoSeleccionado = Convert.ToInt32(dgvGrilla.SelectedRows[0].Cells[0].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
                
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

        }


    }
}
