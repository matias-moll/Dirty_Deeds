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

        // Property que mantiene actualizado los lbls de pantalla.
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
            cantidadRegistrosPorPagina = 10;
        }

        private void ComprarOfertar_Load(object sender, EventArgs e)
        {
            /* TODO: Decidir si vamos a cargar al comienzo o tiene que tocar un boton.
            cantidadPaginas = obtenerCantidadPaginas();
            cargarPublicaciones();
             */
        }

        #region Operaciones (eventos click)

        // Eventos de compra, oferta y pregunta

        private void gbComprar_Click(object sender, EventArgs e)
        {
            // Validamos
            if ((!validacionRegistroSeleccionado()) || (!validacionNoElegirseAUnoMismo()))
                return;
            if (dgvPublicaciones.SelectedRows[0].Cells["Tipo"].Value.ToString().Trim() == "Subasta")
            {
                MessageBox.Show("La opcion de compra es solo para publicaciones de tipo Compra Inmediata, y la publicacion elegida es de tipo Subasta.");
                return;
            }

            OfertaCompra compra = new OfertaCompra();
            compra.campoCodPublicacion = (int)dgvPublicaciones.SelectedRows[0].Cells["Codigo"].Value;
            compra.campoFecha = DateTime.Now;
            compra.campoDiscriminante = "C";
            compra.campoIdUsuario = DatosGlobales.usuarioLoggeado.autoId;
            compra.campoMonto = 0;
            compra.campoCantidad = 1;
            compra.save();

            // Actualizamos el stock de la publicacion vendida.
            Dominio.Publicacion publicacionVendida = Dominio.Publicacion.get(compra.campoCodPublicacion);
            publicacionVendida.campoStockActual -= 1;
            // Si no queda mas stock, la publicacion se vendio y esta finalizada.
            if (publicacionVendida.campoStockActual == 0)
            {
                publicacionVendida.foraneaIdEstado = 4;
                publicacionVendida.campoVendida = "S";
            }
            publicacionVendida.update();

            Usuario usuarioVendedor = Usuario.get(compra.campoIdUsuario);

            MessageBox.Show("Su compra fue realizada exitosamente! Ahora dispondra de los datos del vendedor para poder contactarse. Deberá volver a ejecutar la busqueda para poder ver los datos actualizados.");
            string discriminante = dgvPublicaciones.SelectedRows[0].Cells["Vendedor"].Value.ToString();
            ABMs.AltaGenerico vendedor;
            // Obtenemos el form a mostrar correspondiente para el tipo de usuario vendedor y lo mostramos.
            if (discriminante == "Empresa")
                vendedor = new ABMs.AltaGenerico(new ABMs.Empresas(), usuarioVendedor.campoIdReferencia, true);
            else
                vendedor = new ABMs.AltaGenerico(new ABMs.Clientes(), usuarioVendedor.campoIdReferencia, true);

            vendedor.ShowDialog(this);
        }

        private void gbPreguntar_Click(object sender, EventArgs e)
        {
            if ((!validacionRegistroSeleccionado()) || (!validacionNoElegirseAUnoMismo()))
                return;

            bool aceptaPreguntas = ((string)dgvPublicaciones.SelectedRows[0].Cells["Acepta_Preguntas"].Value) == "Si";

            if (!aceptaPreguntas)
            {
                MessageBox.Show("No puede realizar una pregunta sobre una publicacion que no las acepta.");
                return;
            }

            RealizarPregunta preguntar = new RealizarPregunta((int)dgvPublicaciones.SelectedRows[0].Cells["Codigo"].Value);
            preguntar.ShowDialog(this);

        }

        private void gbOfertar_Click(object sender, EventArgs e)
        {
            // Validamos
            if ((!validacionRegistroSeleccionado()) || (!validacionNoElegirseAUnoMismo()))
                return;
            if (dgvPublicaciones.SelectedRows[0].Cells["Tipo"].Value.ToString().Trim() != "Subasta")
            {
                MessageBox.Show("La opcion de oferta es solo para publicaciones de tipo Subasta, y la publicacion elegida es de tipo Compra Inmediata.");
                return;
            }

            RealizarOferta ofertar = new RealizarOferta((decimal)dgvPublicaciones.SelectedRows[0].Cells["Precio"].Value);
            ofertar.ShowDialog(this);

            if (ofertar.DialogResult == DialogResult.Cancel)
                return;

            OfertaCompra compra = new OfertaCompra();
            compra.campoCodPublicacion = (int)dgvPublicaciones.SelectedRows[0].Cells["Codigo"].Value;
            compra.campoFecha = DateTime.Now;
            compra.campoDiscriminante = "S";
            compra.campoIdUsuario = DatosGlobales.usuarioLoggeado.autoId;
            compra.campoMonto = ofertar.ofertaRealizada;
            compra.campoCantidad = 0;
            compra.save();

            // Actualizamos a la ultima oferta en la subasta.
            Dominio.Publicacion publicacionOfertada = Dominio.Publicacion.get(compra.campoCodPublicacion);
            publicacionOfertada.campoPrecio = compra.campoMonto;
            publicacionOfertada.update();

            MessageBox.Show("Su oferta fue realizada exitosamente! Suerte con la subasta!. Deberá volver a ejecutar la busqueda para poder ver los datos actualizados");
        }

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

        private void gbAgregarFiltro_Click(object sender, EventArgs e)
        {
            // Armamos la string de where de filtros.
            List<Rubro> rubros = new List<Rubro>();
            foreach (object unRubro in lbRubrosElegidos.Items)
                rubros.Add((Rubro)unRubro);
            whereRubros = Dominio.Publicacion.armaWhereRubros(rubros);

            whereDescripcion = Dominio.Publicacion.armaWhereDescripcion(teDescripcion.Text);

            cantidadPaginas = obtenerCantidadPaginas();
            numeroPagina = 1;
            cargarPublicaciones();
        }

        private void gbQuitarFiltro_Click(object sender, EventArgs e)
        {
            whereRubros = whereDescripcion = "";
            lbRubrosElegidos.Items.Clear();
            teDescripcion.Text = "";
            cantidadPaginas = obtenerCantidadPaginas();
            numeroPagina = 1;
            cargarPublicaciones();
        }

        #endregion

        #region Metodos soporte (privados)


        private bool validacionNoElegirseAUnoMismo()
        {
            if (((int)dgvPublicaciones.SelectedRows[0].Cells["Id_Usuario"].Value) == DatosGlobales.usuarioLoggeado.autoId)
            {
                MessageBox.Show("No se pueden realizar acciones sobre publicaciones propias.");
                return false;
            }
            return true;
        }

        private bool validacionRegistroSeleccionado()
        {
            if (dgvPublicaciones.SelectedRows.Count != 1)
            {
                MessageBox.Show("Debe seleccionar solo una entidad (clickeando en la fila correspondiente) para poder seleccionarla");
                return false;
            }
            return true;
        }

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
            return numeroPagina * cantidadRegistrosPorPagina;
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

    }
}
