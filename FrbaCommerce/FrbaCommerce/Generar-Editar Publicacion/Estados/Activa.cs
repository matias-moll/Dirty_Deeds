using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    public class Activa : Estado
    {
        public override void habilitaControlesCorrespondientes(Publicacion formPublicacion)
        {
            // Activamos todo
            formPublicacion.imgPublicacion.Enabled = true;

            // Deshabilitamos los controles que no puede modificar y el estado de borrador que es invalido.
            formPublicacion.dcePrecio.Enabled = false;
            formPublicacion.rbAceptaPreguntas.Enabled = false;
            formPublicacion.cbTipos.Enabled = false;
            formPublicacion.cbVisibilidades.Enabled = false;
            formPublicacion.neStock.Enabled = true;
            formPublicacion.teDescripcion.Enabled = true;
            formPublicacion.cbRubros.Enabled = false;
            formPublicacion.gbAgregarRubro.Enabled = false;
            formPublicacion.lbRubrosElegidos.Enabled = false;

            formPublicacion.gbBorrador.Enabled = false;
            formPublicacion.gbActiva.Enabled = false;
            formPublicacion.gbPausar.Enabled = true;
            formPublicacion.gbFinalizar.Enabled = true;

            formPublicacion.gbAceptar.Enabled = true;

            formPublicacion.lblEstado.Text = "Activa";
        }

        public override int id { get { return 1; } }

    }
}
