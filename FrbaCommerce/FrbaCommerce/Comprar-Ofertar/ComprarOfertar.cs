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
    public partial class ComprarOfertar : DockContent
    {
        private int nroPagina;
        private int cantPaginas;
        private int cantidadRegistrosPorPagina;
        private string whereDescripcion;
        private string whereRubros;
        // Property que mantiene actualizado el lbl de pantalla.
        private int numeroPagina 
        { 
            get{ return nroPagina;} 
            set { nroPagina = value; lblPaginaActual.Text = nroPagina.ToString();}
        }
        private int cantidadPaginas
        {
            get { return cantPaginas; }
            set { cantPaginas = value; lblCantidadPaginas.Text = cantPaginas.ToString(); }
        }
        

        public ComprarOfertar()
        {
            InitializeComponent();

            cbRubros.DataSource = Rubro.upFull();
            cbRubros.DisplayMember = "campoDescripcion";
            cbRubros.ValueMember = "autoId";

            lbRubrosElegidos.DisplayMember = "campoDescripcion";
            lbRubrosElegidos.ValueMember = "autoId";

            numeroPagina = 1;
            whereDescripcion = whereRubros = "";
            cantidadRegistrosPorPagina = 20;
        }

        private void ComprarOfertar_Load(object sender, EventArgs e)
        {
            cantidadPaginas = obtenerCantidadPaginas();
            cargarPublicaciones();
        }

        #region Operaciones (eventos click)

        // Eventos para modificacion en grilla paginada
        private void gbAvanzar_Click(object sender, EventArgs e)
        {
            // Validamos
            if (numeroPagina == cantidadPaginas)
            {
                MessageBox.Show("Ya se encuentra viendo la última página, no puede avanzar mas");
                return;
            }
            // Actualizamos el indice y cargamos a pantalla.
            numeroPagina++;
            cargarPublicaciones();
        }

        private void gbRetroceder_Click(object sender, EventArgs e)
        {
            // Validamos
            if (numeroPagina == 1)
            {
                MessageBox.Show("Ya se encuentra viendo la primera página, no puede retroceder mas");
                return;
            }
            // Actualizamos el indice y cargamos a pantalla.
            numeroPagina--;
            cargarPublicaciones();
        }

        private void gbPrimerPagina_Click(object sender, EventArgs e)
        {
            numeroPagina = 1;
            cargarPublicaciones();
        }

        private void gbUltimaPagina_Click(object sender, EventArgs e)
        {
            numeroPagina = cantidadPaginas;
            if (numeroPagina == 0)
                return;
            cargarPublicaciones();
        }

        // Eventos de los filtros.
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

        private void gbQuitarRubro_Click(object sender, EventArgs e)
        {
            lbRubrosElegidos.Items.Remove(lbRubrosElegidos.SelectedItem);
        }

        #endregion

        #region Metodos soporte (privados)

        private void cargarPublicaciones()
        {
            dgvPublicaciones.DataSource = Dominio.Publicacion.getPrimerasNPublicaciones(getFilaInicio(), getFilaFin(), 
                                                                                        whereRubros, whereDescripcion);
            if (dgvPublicaciones.Rows.Count == 0)
            {
                MessageBox.Show("No hay mas publicaciones para mostrar con esos filtros elegidos");
                return;
            }
        }

        private int getFilaFin()
        {
            return numeroPagina * 20;
        }

        private int getFilaInicio()
        {
            return (numeroPagina - 1) * cantidadRegistrosPorPagina;
        }

        private void cargarPublicaciones(int numeroPagina)
        {
            throw new NotImplementedException();
        }

        private int obtenerCantidadPaginas()
        {
            try
            {
                int cantidadPublicaciones = Dominio.Publicacion.getCantidadPublicacionesSegunFiltro(whereRubros, whereDescripcion);
                return (cantidadPublicaciones / cantidadRegistrosPorPagina) + 1;
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                return 0;
            }
        }

        #endregion

        private void gbAgregarFiltro_Click(object sender, EventArgs e)
        {
            // Armamos la string de where de filtros.
            List<Rubro> rubros = new List<Rubro>();
            foreach(object unRubro in lbRubrosElegidos.Items)
                rubros.Add((Rubro)unRubro);
            whereRubros = Dominio.Publicacion.armaWhereRubros(rubros);

            whereDescripcion = Dominio.Publicacion.armaWhereDescripcion(teDescripcion.Text);

            cantidadPaginas = obtenerCantidadPaginas();
            cargarPublicaciones();
        }

        private void gbQuitarFiltro_Click(object sender, EventArgs e)
        {
            whereRubros = whereDescripcion = "";
            lbRubrosElegidos.Items.Clear();
            teDescripcion.Text = "";
            cantidadPaginas = obtenerCantidadPaginas();
            cargarPublicaciones();
        }
    }
}
