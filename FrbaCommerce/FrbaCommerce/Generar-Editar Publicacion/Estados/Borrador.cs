using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    public class Borrador : Estado
    {
        public override void habilitaControlesCorrespondientes(Publicacion formPublicacion)
        {
            // Activamos todo menos los botones de finalizar y pausar ya que la publicacion es borrador (no visible al publico)
            formPublicacion.imgPublicacion.Enabled = true;

            formPublicacion.dcePrecio.Enabled = true;
            formPublicacion.rbAceptaPreguntas.Enabled = true;
            formPublicacion.cbTipos.Enabled = true;
            formPublicacion.cbVisibilidades.Enabled = true;
            formPublicacion.neStock.Enabled = true;
            formPublicacion.teDescripcion.Enabled = true;
            formPublicacion.cbRubros.Enabled = true;
            formPublicacion.gbAgregarRubro.Enabled = true;
            formPublicacion.lbRubrosElegidos.Enabled = true;

            formPublicacion.gbBorrador.Enabled = false;
            formPublicacion.gbActiva.Enabled = true;
            formPublicacion.gbPausar.Enabled = false;
            formPublicacion.gbFinalizar.Enabled = false;

            formPublicacion.gbAceptar.Enabled = true;

            formPublicacion.lblEstado.Text = "Borrador";
        }

        public override int id { get { return 2; } }
    }
}
