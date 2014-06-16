using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    public class Finalizada : Estado
    {
        public override void habilitaControlesCorrespondientes(Publicacion formPublicacion)
        {
            // Activamos el imgroup
            formPublicacion.imgPublicacion.Enabled = true;

            // Deshabilitamos todos los controles de modificacion y cambio de estados.
            formPublicacion.dcePrecio.Enabled = false;
            formPublicacion.rbAceptaPreguntas.Enabled = false;
            formPublicacion.cbTipos.Enabled = false;
            formPublicacion.cbVisibilidades.Enabled = false;
            formPublicacion.neStock.Enabled = false;
            formPublicacion.teDescripcion.Enabled = false;
            formPublicacion.cbRubros.Enabled = false;
            formPublicacion.gbAgregarRubro.Enabled = false;
            formPublicacion.lbRubrosElegidos.Enabled = false;

            formPublicacion.gbBorrador.Enabled = false;
            formPublicacion.gbPausar.Enabled = false;
            formPublicacion.gbFinalizar.Enabled = false;
            formPublicacion.gbAceptar.Enabled = true;
            formPublicacion.gbActiva.Enabled = false;

            formPublicacion.lblEstado.Text = "Finalizada";
        }

        public override int id { get { return Finalizada.Id; } }

        public static int Id { get { return 4; } }

    }
}
