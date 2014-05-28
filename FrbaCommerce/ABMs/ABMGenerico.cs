using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TNGS.NetControls;

namespace ABMs
{
    public partial class ABMGenerico : Form
    {
        ABMEspecifico resolver;
        Panel pnFiltros;

        public ABMGenerico(ABMEspecifico resolverEspecifico)
        {
            InitializeComponent();
            resolver = resolverEspecifico;
        }

        private void ABMGenerico_Load(object sender, EventArgs e)
        {
            // Cargamos el titulo y el panel especificos para completar nuestro form de ABM
            this.Text = resolver.GetType().Name.ToString();
            pnFiltros = resolver.getPanel();
            this.gbFiltros.Controls.Add(pnFiltros);
        }

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
            // Codigo para agregar columna con boton.
            /*DataGridView pepe = new DataGridView();
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.UseColumnTextForButtonValue = true;
            col.Text = "modificar";
            col.Name = "botonModif";
            pepe.Columns.Add(col);
             */
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
             
            // Removemos el panel actual y obtenemos uno nuevo para la busqueda (sino no se carga).
            this.gbFiltros.Controls.Remove(pnFiltros);
            pnFiltros = resolver.getPanel();

            // Limpiamos los controles (se reutilizan para las dos pantallas, por eso hay que limpiarlos).
            limpiarControlesDelPanel();

            // Añadimos el panel nuevamente.
            this.gbFiltros.Controls.Add(pnFiltros);
        }


        private void limpiarControlesDelPanel()
        {
            foreach (Control unControl in pnFiltros.Controls)
                if (esControlEdit(unControl.GetType())) unControl.Text = "";
        }

        private DataTable formatToGrid(DataTable tablaAMostrar)
        {
            tablaAMostrar.Columns["Deleted"].ReadOnly = true;
            return tablaAMostrar;
        }

        private bool esControlEdit(Type tipoControl)
        {
            return ((tipoControl == typeof(TextEdit)) || (tipoControl == typeof(NumberEdit)) ||
                (tipoControl == typeof(DecimalEdit)) || (tipoControl == typeof(DateTimeEdit)));
        }
    }
}
