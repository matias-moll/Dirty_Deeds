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
    public partial class Facturacion : DockContent
    {
        public Facturacion()
        {
            InitializeComponent();
        }

        #region Operaciones

        private void gbCargarPublicacionesARendir_Click(object sender, EventArgs e)
        {
            try
            {
                dgvVentas.DataSource = Item.getItemsAunNoRendidos(DatosGlobales.usuarioLoggeado.autoId);
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                estadoBotonera();
                return;
            }
            estadoGrillaOperacional();
        }

        private void gbFacturar_Click(object sender, EventArgs e)
        {
            DatosParaFactura getDatos = new DatosParaFactura();
            getDatos.ShowDialog(this);

            if (getDatos.DialogResult == DialogResult.Cancel)
                return;

            if (getDatos.cantidadPublicaciones < 1)
            {
                MessageBox.Show("No se puede rendir menos de un item");
                return;
            }

            if (getDatos.cantidadPublicaciones >= dgvVentas.Rows.Count)
            {
                MessageBox.Show("No se puede rendir mas items de la cantidad que se muestra en la grilla");
                return;
            }

            // Creamos la factura con todos los datos menos el monto total que sale de la suma de los items.
            Factura facturaARendir = new Factura(Soporte.Now(), getDatos.idFormaDePago);
            facturaARendir.campoNumero = Factura.getCodigoSiguienteFactura();
            // Grabamos la factura para que no conflictue la validacion de foreign key de los items.
            facturaARendir.save();
            int cantidadPublicacionesARendir = getDatos.cantidadPublicaciones;
            decimal montoTotal = 0;

            Item itemFactura = new Item();
            itemFactura.campoNumFactura = facturaARendir.campoNumero;
            for (int indicePublicacion = 1; indicePublicacion <= cantidadPublicacionesARendir; indicePublicacion++)
            {
                // Llenamos los datos de cada publicacion a rendir en un item de la factura y lo mandamos a grabar.
                itemFactura.campoNumItem = indicePublicacion;
                itemFactura.campoCodigoPublicacion = (int)dgvVentas.Rows[indicePublicacion - 1].Cells["Codigo"].Value;
                itemFactura.campoMonto = (decimal)dgvVentas.Rows[indicePublicacion - 1].Cells["Costo"].Value;
                itemFactura.campoDescripcion = dgvVentas.Rows[indicePublicacion - 1].Cells["Presentacion"].Value.ToString();
                itemFactura.campoCantidad = (int)dgvVentas.Rows[indicePublicacion - 1].Cells["Cantidad"].Value;
                montoTotal += itemFactura.campoMonto;
                itemFactura.save();
            }
            // Completamos la factura y la mandamos a grabar.
            facturaARendir.campoTotal = montoTotal;
            facturaARendir.update();

            // Avisamos al usuario y recargamos la grilla.
            MessageBox.Show("Su factura con las publicaciones elegidas fue rendida exitosamente!");
            gbCargarPublicacionesARendir_Click(this, null);
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
            dgvVentas.DataSource = null;
        }

        #endregion


    }
}
