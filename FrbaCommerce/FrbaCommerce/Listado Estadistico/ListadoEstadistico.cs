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
    public partial class ListadoEstadistico : DockContent
    {
        public ListadoEstadistico()
        {
            InitializeComponent();

            // Llenamos las combos
            List<ElementoCombo> trimestres = new List<ElementoCombo>();
            trimestres.Add(new ElementoCombo(1, "Primero (1-3)"));
            trimestres.Add(new ElementoCombo(2, "Segundo (4-6)"));
            trimestres.Add(new ElementoCombo(3, "Tercero (7-9)"));
            trimestres.Add(new ElementoCombo(4, "Cuarto (10-12)"));
            cbTrimestres.DataSource = trimestres;
            cbTrimestres.DisplayMember = "descripcion";
            cbTrimestres.ValueMember = "valor";

            List<ElementoCombo> tipos = new List<ElementoCombo>();
            tipos.Add(new ElementoCombo(1, "Vendedores Mayor Cantidad No Vendidos"));
            tipos.Add(new ElementoCombo(2, "Vendedores Mayor Facturación"));
            tipos.Add(new ElementoCombo(3, "Vendedores Mayores Calificaciones"));
            tipos.Add(new ElementoCombo(4, "Clientes Mayor Cantidad Sin Calif."));
            cbTipos.DataSource = tipos;
            cbTipos.DisplayMember = "descripcion";
            cbTipos.ValueMember = "valor";

        }




        #region Metodos Privados (soporte)

        private void estadoGrillaEstadistica()
        {
            imgGrillaEstadistica.Enabled = true;
            imgParametros.Enabled = false;
        }

        private void estadoParametros()
        {
            imgGrillaEstadistica.Enabled = false;
            imgParametros.Enabled = true;
            dgvEstadistica.DataSource = null;
        }

        #endregion

        private void gbEstadistica_Click(object sender, EventArgs e)
        {
            if ((neAnio.Numero < 2000) || (neAnio.Numero > Soporte.Now().Year))
            {
                MessageBox.Show("No se pueden pedir consultas con año menor al 2000 o mayor al actual");
                return;
            }

            int mesInicio, mesFin, anio;
            mesInicio = ((((int)cbTrimestres.SelectedValue) - 1) * 3) + 1;
            mesFin = ((int)cbTrimestres.SelectedValue) * 3;
            anio = neAnio.Numero;

            try
            {
                switch ((int)cbTipos.SelectedValue)
                {
                    // Vendedores Mayor Cantidad No Vendidos
                    case 1:
                        {
                            GetVisibilidad elegirVisibilidad = new GetVisibilidad();
                            elegirVisibilidad.ShowDialog(this);
                            if (elegirVisibilidad.DialogResult == DialogResult.Cancel)
                                return;

                            dgvEstadistica.DataSource = Factura.getVendedoresConMasProductosNoVendidos(anio, mesInicio,
                                                                                         mesFin, elegirVisibilidad.idVisibilidad);
                            break;
                        }

                    // Vendedores Mayor Facturación
                    case 2: dgvEstadistica.DataSource = Factura.getVendedoresConMayorFacturacion(anio, mesInicio, mesFin); break;

                    // Vendedores Mayores Calificaciones
                    case 3: dgvEstadistica.DataSource = Calificacion.getVendedoresConMayoresCalificaciones(anio, mesInicio, mesFin); break;
                    
                    // Clientes Mayor Cantidad Sin Calif.
                    case 4: dgvEstadistica.DataSource = Cliente.getClientesMayorCantidadSinCalificaciones(anio, mesInicio, mesFin); break;
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                return;
            }
            estadoGrillaEstadistica();

        }

        private void gbAceptar_Click(object sender, EventArgs e)
        {
            estadoParametros();
        }
    }
}
