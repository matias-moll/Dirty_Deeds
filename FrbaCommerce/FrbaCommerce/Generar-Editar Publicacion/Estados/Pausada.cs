using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    public class Pausada : Estado
    {
        public override void habilitaControlesCorrespondientes(Publicacion formPublicacion)
        {
            // Activamos todo
            formPublicacion.imgPublicacion.Enabled = true;

            // Deshabilitamos todos los controles de modificacion y cambio de estados salvo el de activar.
            formPublicacion.dcePrecio.Enabled = false;
            formPublicacion.rbAceptaPreguntas.Enabled = false;
            formPublicacion.cbTipos.Enabled = false;
            formPublicacion.cbVisibilidades.Enabled = false;
            formPublicacion.neStock.Enabled = false;
            formPublicacion.teDescripcion.Enabled = false;

            formPublicacion.gbBorrador.Enabled = false;
            formPublicacion.gbAceptar.Enabled = true;
            formPublicacion.gbFinalizar.Enabled = false;
            formPublicacion.gbPausar.Enabled = false;

            formPublicacion.gbActiva.Enabled = true;

            formPublicacion.lblEstado.Text = "Pausada";
        }

        public override int id { get { return 3; } }

    }
}
