using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FrbaCommerce
{
    public class PanelBuilder
    {
        private Panel m_pnPanel;
        Alignment alignment;
        public Size tamañoLabels { private get; set; }
        public Size tamañoControles { private get; set; }
        public Size tamañoNumberEdits { private get; set; }
        public Size tamañoDateEdits { private get; set; }
        public Size tamañoGrouper { private get; set; }
        public enum Alineacion { Vertical = 1, Horizontal = 2, Reportes = 3 };
        private int tabOrder = 0;


        public PanelBuilder(Size p_szTamaño, Alineacion p_enumAlineacion)
        {
            // Creamos el panel y le fijamos el tamaño y el skinFixed
            m_pnPanel = new Panel();
            m_pnPanel.BackColor = Color.Transparent;
            m_pnPanel.Size = p_szTamaño;

            // Creamos la alineacion correspondiente
            switch (p_enumAlineacion)
            {
                case Alineacion.Vertical: { this.alignment = new VerticalAlign(m_pnPanel.Size); break; }
                case Alineacion.Horizontal: { this.alignment = new HorizontalAlign(m_pnPanel.Size); break; }
            }

            // Cargamos los tamaños default que nos da el alignment, si el programador quiere puede cambiarlos
            // mediante las properties correspondientes.
            this.tamañoLabels = this.alignment.sizeLabels;
            this.tamañoControles = this.alignment.sizeEdits;
            this.tamañoDateEdits = this.alignment.sizeDateEdits;
            this.tamañoNumberEdits = this.alignment.sizeNumberEdits;
            this.tamañoGrouper = new Size(0, 0);
            m_pnPanel.Location = new Point(40, 20);
        }

        public PanelBuilder AddControlWithLabel(string p_strTexto, Control p_ctrEdit)
        {
            Label l_flLabel = crearLabel(p_strTexto);

            p_ctrEdit.Size = this.getSizeForControl(p_ctrEdit);
            p_ctrEdit.TabIndex = tabOrder++;

            // Delegamos, el añadir los controles creados, en el objeto que maneja la alineacion y las posiciones.
            alignment.addControlWithLabel(l_flLabel, p_ctrEdit, this.getPanel);

            return this;
        }

        public PanelBuilder AddControlWithLabelSizeFixed(string p_strTexto, Control p_ctrEdit)
        {
            Label l_flLabel = crearLabel(p_strTexto);

            p_ctrEdit.TabIndex = tabOrder++;

            // Delegamos, el añadir los controles creados, en el objeto que maneja la alineacion y las posiciones.
            alignment.addControlWithLabel(l_flLabel, p_ctrEdit, this.getPanel);

            return this;
        }

        public PanelBuilder AddGroupOfRadioButtons(string p_strTitulo, RadioButton[] p_arbRadioButtons, string[] p_asTextos)
        {
            GroupBox grouper = new GroupBox();

            // Si no tenemos setteado un tamaño para el grouper, usamos el estandar, sino usamos el setteado.
            grouper.Size = (tamañoGrouper.Height == 0) ? new Size(200, p_arbRadioButtons.Length * 55) : tamañoGrouper;

            // Cargamos los textos a cada radiobutton y los agregamos al agrupador.
            int i = 0;
            foreach (RadioButton radioButton in p_arbRadioButtons)
            {
                radioButton.Text = p_asTextos[i++];
                grouper.Controls.Add(radioButton);
            }

            alignment.addGrouper(grouper, this.getPanel);

            return this;
        }

        public Size getSizeForControl(Control unControl)
        {
            return this.tamañoControles; 
        }

        public void centrarControlesEnElPanel()
        {
            alignment.centrarControlesEnElPanel(m_pnPanel);
        }

        public Panel getPanel
        {
            get { return m_pnPanel; }
        }

        public Point location 
        {
            get { return m_pnPanel.Location; }
            set { m_pnPanel.Location = value; }
        }


        private Label crearLabel(string p_strTexto)
        {
            Label l_flLabel = new Label();
            l_flLabel.Text = p_strTexto;
            l_flLabel.Size = this.tamañoLabels;
            l_flLabel.BackColor = Color.Transparent;

            return l_flLabel;
        }

    }
}
