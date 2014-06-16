using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    public class Nueva : Estado
    {
        public override void habilitaControlesCorrespondientes(Publicacion formPublicacion)
        {
            formPublicacion.imgPublicacion.Enabled = true;

            // Activamos todo menos los botones de finalizar y pausar ya que la publicacion es nueva.
            formPublicacion.dcePrecio.Enabled = true;
            formPublicacion.rbAceptaPreguntas.Enabled = true;
            formPublicacion.cbTipos.Enabled = true;
            formPublicacion.cbVisibilidades.Enabled = true;
            formPublicacion.neStock.Enabled = true;
            formPublicacion.teDescripcion.Enabled = true;

            formPublicacion.gbBorrador.Enabled = true;
            formPublicacion.gbActiva.Enabled = true;
            formPublicacion.gbPausar.Enabled = false;
            formPublicacion.gbFinalizar.Enabled = false;
            formPublicacion.gbAceptar.Enabled = false;

            formPublicacion.lblEstado.Text = "Nueva";
        }

        public override int id { get { return 0; } }
    }
}
