﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce
{
    public partial class AltaGenerico : Form
    {
        ABMEspecifico resolver;
        private int idClaveObjeto;
        bool controlesSoloLectura = false;
        public int idObtenido { get; private set; }

        public AltaGenerico(ABMEspecifico p_resolver, int idClaveObjetoModificacion)
        {
            InitializeComponent();
            resolver = p_resolver;
            idClaveObjeto = idClaveObjetoModificacion;
        }

        public AltaGenerico(ABMEspecifico p_resolver, int idClaveObjetoModificacion, bool soloLectura) : this(p_resolver, idClaveObjetoModificacion)
        {
            controlesSoloLectura = soloLectura;
        }

        private void AltaGenerico_Load(object sender, EventArgs e)
        {
            this.Text = resolver.GetType().Name.ToString();
            gbDatos.Controls.Add(resolver.getPanelAlta());
            if (idClaveObjeto != 0)
                resolver.cargarTusDatos(idClaveObjeto);

            if (controlesSoloLectura)
                gbDatos.Enabled = false;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            idObtenido = resolver.getIdParaDevolver();

            // Si no es solo lectura, validamos el alta. Si es solo lectura no se debe validar nada.
            if (!controlesSoloLectura)
            {
                if (!resolver.pasaValidacion())
                {
                    MessageBox.Show(resolver.mensajeErrorValidacion());
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
