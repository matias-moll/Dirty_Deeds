namespace FrbaCommerce
{
    partial class ABMGenerico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABMGenerico));
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.xPanel1 = new TNGS.NetControls.XPanel();
            this.gbAlta = new TNGS.NetControls.GlassButton();
            this.gbModificacion = new TNGS.NetControls.GlassButton();
            this.gbBajaFisica = new TNGS.NetControls.GlassButton();
            this.gbBajaRecupero = new TNGS.NetControls.GlassButton();
            this.gbBuscar = new TNGS.NetControls.GlassButton();
            this.gbLimpiar = new TNGS.NetControls.GlassButton();
            this.gbSeleccionar = new TNGS.NetControls.GlassButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.BackColor = System.Drawing.Color.Transparent;
            this.gbFiltros.Location = new System.Drawing.Point(12, 3);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(770, 253);
            this.gbFiltros.TabIndex = 0;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(14, 329);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.Size = new System.Drawing.Size(771, 207);
            this.dgvGrilla.TabIndex = 6;
            // 
            // xPanel1
            // 
            this.xPanel1.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanel1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.xPanel1.Controls.Add(this.gbSeleccionar);
            this.xPanel1.Controls.Add(this.gbLimpiar);
            this.xPanel1.Controls.Add(this.gbBuscar);
            this.xPanel1.Controls.Add(this.gbBajaRecupero);
            this.xPanel1.Controls.Add(this.gbBajaFisica);
            this.xPanel1.Controls.Add(this.gbModificacion);
            this.xPanel1.Controls.Add(this.gbAlta);
            this.xPanel1.Controls.Add(this.dgvGrilla);
            this.xPanel1.Controls.Add(this.gbFiltros);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(804, 548);
            this.xPanel1.SkinFixed = true;
            this.xPanel1.TabIndex = 9;
            // 
            // gbAlta
            // 
            this.gbAlta.FixedImage = TNGS.NetControls.FixedGlassButtons.New;
            this.gbAlta.Location = new System.Drawing.Point(359, 290);
            this.gbAlta.Name = "gbAlta";
            this.gbAlta.Size = new System.Drawing.Size(92, 26);
            this.gbAlta.TabIndex = 9;
            this.gbAlta.Text = "Alta";
            this.gbAlta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // gbModificacion
            // 
            this.gbModificacion.FixedImage = TNGS.NetControls.FixedGlassButtons.Modify;
            this.gbModificacion.Location = new System.Drawing.Point(457, 290);
            this.gbModificacion.Name = "gbModificacion";
            this.gbModificacion.Size = new System.Drawing.Size(104, 26);
            this.gbModificacion.TabIndex = 10;
            this.gbModificacion.Text = "Modificación";
            this.gbModificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbModificacion.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // gbBajaFisica
            // 
            this.gbBajaFisica.FixedImage = TNGS.NetControls.FixedGlassButtons.Delete;
            this.gbBajaFisica.Location = new System.Drawing.Point(567, 290);
            this.gbBajaFisica.Name = "gbBajaFisica";
            this.gbBajaFisica.Size = new System.Drawing.Size(96, 26);
            this.gbBajaFisica.TabIndex = 11;
            this.gbBajaFisica.Text = "Baja Física";
            this.gbBajaFisica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbBajaFisica.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // gbBajaRecupero
            // 
            this.gbBajaRecupero.FixedImage = TNGS.NetControls.FixedGlassButtons.Unify;
            this.gbBajaRecupero.Location = new System.Drawing.Point(669, 287);
            this.gbBajaRecupero.Name = "gbBajaRecupero";
            this.gbBajaRecupero.Size = new System.Drawing.Size(113, 33);
            this.gbBajaRecupero.TabIndex = 12;
            this.gbBajaRecupero.Text = "Baja Lógica / Recupero";
            this.gbBajaRecupero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbBajaRecupero.Click += new System.EventHandler(this.btnBajaLogica_Click);
            // 
            // gbBuscar
            // 
            this.gbBuscar.FixedImage = TNGS.NetControls.FixedGlassButtons.Find;
            this.gbBuscar.Location = new System.Drawing.Point(14, 260);
            this.gbBuscar.Name = "gbBuscar";
            this.gbBuscar.Size = new System.Drawing.Size(99, 26);
            this.gbBuscar.TabIndex = 13;
            this.gbBuscar.Text = "Buscar";
            this.gbBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gbLimpiar
            // 
            this.gbLimpiar.FixedImage = TNGS.NetControls.FixedGlassButtons.Clean;
            this.gbLimpiar.Location = new System.Drawing.Point(125, 260);
            this.gbLimpiar.Name = "gbLimpiar";
            this.gbLimpiar.Size = new System.Drawing.Size(91, 26);
            this.gbLimpiar.TabIndex = 14;
            this.gbLimpiar.Text = "Limpiar";
            this.gbLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // gbSeleccionar
            // 
            this.gbSeleccionar.FixedImage = TNGS.NetControls.FixedGlassButtons.End;
            this.gbSeleccionar.Location = new System.Drawing.Point(14, 297);
            this.gbSeleccionar.Name = "gbSeleccionar";
            this.gbSeleccionar.Size = new System.Drawing.Size(99, 26);
            this.gbSeleccionar.TabIndex = 15;
            this.gbSeleccionar.Text = "Seleccionar";
            this.gbSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // ABMGenerico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(804, 548);
            this.Controls.Add(this.xPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ABMGenerico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM";
            this.Load += new System.EventHandler(this.ABMGenerico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.DataGridView dgvGrilla;
        private TNGS.NetControls.XPanel xPanel1;
        private TNGS.NetControls.GlassButton gbModificacion;
        private TNGS.NetControls.GlassButton gbAlta;
        private TNGS.NetControls.GlassButton gbLimpiar;
        private TNGS.NetControls.GlassButton gbBuscar;
        private TNGS.NetControls.GlassButton gbBajaRecupero;
        private TNGS.NetControls.GlassButton gbBajaFisica;
        private TNGS.NetControls.GlassButton gbSeleccionar;
    }
}