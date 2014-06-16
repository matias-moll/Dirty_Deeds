namespace FrbaCommerce
{
    partial class ComprarOfertar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComprarOfertar));
            this.xPanel1 = new TNGS.NetControls.XPanel();
            this.cbRubros = new System.Windows.Forms.ComboBox();
            this.gbAgregarFiltro = new TNGS.NetControls.GlassButton();
            this.imgFiltros = new TNGS.NetControls.ImgGroup();
            this.gbQuitarFiltro = new TNGS.NetControls.GlassButton();
            this.textEdit1 = new TNGS.NetControls.TextEdit();
            this.dgvPublicaciones = new System.Windows.Forms.DataGridView();
            this.gbPrimerPagina = new TNGS.NetControls.GlassButton();
            this.gbAvanzar = new TNGS.NetControls.GlassButton();
            this.gbRetroceder = new TNGS.NetControls.GlassButton();
            this.gbUltimaPagina = new TNGS.NetControls.GlassButton();
            this.gbVerPublicacion = new TNGS.NetControls.GlassButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xPanel1.SuspendLayout();
            this.imgFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublicaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanel1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.xPanel1.Controls.Add(this.gbVerPublicacion);
            this.xPanel1.Controls.Add(this.gbUltimaPagina);
            this.xPanel1.Controls.Add(this.gbAvanzar);
            this.xPanel1.Controls.Add(this.gbRetroceder);
            this.xPanel1.Controls.Add(this.gbPrimerPagina);
            this.xPanel1.Controls.Add(this.dgvPublicaciones);
            this.xPanel1.Controls.Add(this.imgFiltros);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(767, 541);
            this.xPanel1.SkinFixed = true;
            this.xPanel1.TabIndex = 1;
            // 
            // cbRubros
            // 
            this.cbRubros.FormattingEnabled = true;
            this.cbRubros.Location = new System.Drawing.Point(95, 32);
            this.cbRubros.Name = "cbRubros";
            this.cbRubros.Size = new System.Drawing.Size(201, 21);
            this.cbRubros.TabIndex = 0;
            // 
            // gbAgregarFiltro
            // 
            this.gbAgregarFiltro.FixedImage = TNGS.NetControls.FixedGlassButtons.AddFilter;
            this.gbAgregarFiltro.Location = new System.Drawing.Point(192, 72);
            this.gbAgregarFiltro.Name = "gbAgregarFiltro";
            this.gbAgregarFiltro.Size = new System.Drawing.Size(124, 26);
            this.gbAgregarFiltro.TabIndex = 1;
            this.gbAgregarFiltro.Text = "Agregar Filtro";
            this.gbAgregarFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgFiltros
            // 
            this.imgFiltros.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.imgFiltros.BackgroundGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.imgFiltros.BackgroundGradientMode = TNGS.NetControls.ImgGroup.GroupBoxGradientMode.ForwardDiagonal;
            this.imgFiltros.BorderColor = System.Drawing.Color.Black;
            this.imgFiltros.BorderThickness = 1F;
            this.imgFiltros.Controls.Add(this.label2);
            this.imgFiltros.Controls.Add(this.label1);
            this.imgFiltros.Controls.Add(this.textEdit1);
            this.imgFiltros.Controls.Add(this.gbQuitarFiltro);
            this.imgFiltros.Controls.Add(this.cbRubros);
            this.imgFiltros.Controls.Add(this.gbAgregarFiltro);
            this.imgFiltros.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.imgFiltros.FontTitle = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgFiltros.GroupImage = null;
            this.imgFiltros.GroupTitle = "Filtros";
            this.imgFiltros.Location = new System.Drawing.Point(12, 12);
            this.imgFiltros.Name = "imgFiltros";
            this.imgFiltros.Padding = new System.Windows.Forms.Padding(20);
            this.imgFiltros.PaintGroupBox = false;
            this.imgFiltros.RoundCorners = 10;
            this.imgFiltros.ShadowColor = System.Drawing.Color.DarkGray;
            this.imgFiltros.ShadowControl = false;
            this.imgFiltros.ShadowThickness = 3;
            this.imgFiltros.Size = new System.Drawing.Size(743, 118);
            this.imgFiltros.SkinFixed = true;
            this.imgFiltros.TabIndex = 2;
            // 
            // gbQuitarFiltro
            // 
            this.gbQuitarFiltro.FixedImage = TNGS.NetControls.FixedGlassButtons.RemFilter;
            this.gbQuitarFiltro.Location = new System.Drawing.Point(393, 72);
            this.gbQuitarFiltro.Name = "gbQuitarFiltro";
            this.gbQuitarFiltro.Size = new System.Drawing.Size(104, 26);
            this.gbQuitarFiltro.TabIndex = 2;
            this.gbQuitarFiltro.Text = "Quitar Filtro";
            this.gbQuitarFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textEdit1
            // 
            this.textEdit1.BackColor = System.Drawing.SystemColors.Window;
            this.textEdit1.Location = new System.Drawing.Point(393, 35);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(327, 20);
            this.textEdit1.TabIndex = 3;
            // 
            // dgvPublicaciones
            // 
            this.dgvPublicaciones.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvPublicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPublicaciones.Location = new System.Drawing.Point(12, 184);
            this.dgvPublicaciones.Name = "dgvPublicaciones";
            this.dgvPublicaciones.ReadOnly = true;
            this.dgvPublicaciones.Size = new System.Drawing.Size(743, 291);
            this.dgvPublicaciones.TabIndex = 7;
            // 
            // gbPrimerPagina
            // 
            this.gbPrimerPagina.FixedImage = TNGS.NetControls.FixedGlassButtons.RemoveAll;
            this.gbPrimerPagina.Location = new System.Drawing.Point(12, 155);
            this.gbPrimerPagina.Name = "gbPrimerPagina";
            this.gbPrimerPagina.Size = new System.Drawing.Size(113, 26);
            this.gbPrimerPagina.TabIndex = 8;
            this.gbPrimerPagina.Text = "Primer Pagina";
            this.gbPrimerPagina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbAvanzar
            // 
            this.gbAvanzar.FixedImage = TNGS.NetControls.FixedGlassButtons.PassOne;
            this.gbAvanzar.Location = new System.Drawing.Point(405, 155);
            this.gbAvanzar.Name = "gbAvanzar";
            this.gbAvanzar.Size = new System.Drawing.Size(104, 26);
            this.gbAvanzar.TabIndex = 10;
            this.gbAvanzar.Text = "Avanzar";
            this.gbAvanzar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbRetroceder
            // 
            this.gbRetroceder.FixedImage = TNGS.NetControls.FixedGlassButtons.RemoveOne;
            this.gbRetroceder.Location = new System.Drawing.Point(295, 155);
            this.gbRetroceder.Name = "gbRetroceder";
            this.gbRetroceder.Size = new System.Drawing.Size(104, 26);
            this.gbRetroceder.TabIndex = 9;
            this.gbRetroceder.Text = "Retroceder";
            this.gbRetroceder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbUltimaPagina
            // 
            this.gbUltimaPagina.FixedImage = TNGS.NetControls.FixedGlassButtons.PassAll;
            this.gbUltimaPagina.Location = new System.Drawing.Point(644, 155);
            this.gbUltimaPagina.Name = "gbUltimaPagina";
            this.gbUltimaPagina.Size = new System.Drawing.Size(111, 26);
            this.gbUltimaPagina.TabIndex = 11;
            this.gbUltimaPagina.Text = "Última Página";
            this.gbUltimaPagina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbVerPublicacion
            // 
            this.gbVerPublicacion.FixedImage = TNGS.NetControls.FixedGlassButtons.Zoom;
            this.gbVerPublicacion.Location = new System.Drawing.Point(330, 493);
            this.gbVerPublicacion.Name = "gbVerPublicacion";
            this.gbVerPublicacion.Size = new System.Drawing.Size(129, 26);
            this.gbVerPublicacion.TabIndex = 12;
            this.gbVerPublicacion.Text = "Ver Publicación";
            this.gbVerPublicacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rubro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Descripción";
            // 
            // ComprarOfertar
            // 
            this.AllowEndUserDocking = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 541);
            this.Controls.Add(this.xPanel1);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComprarOfertar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Comprar / Ofertar";
            this.xPanel1.ResumeLayout(false);
            this.imgFiltros.ResumeLayout(false);
            this.imgFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublicaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TNGS.NetControls.XPanel xPanel1;
        private TNGS.NetControls.ImgGroup imgFiltros;
        private TNGS.NetControls.TextEdit textEdit1;
        private TNGS.NetControls.GlassButton gbQuitarFiltro;
        private System.Windows.Forms.ComboBox cbRubros;
        private TNGS.NetControls.GlassButton gbAgregarFiltro;
        private System.Windows.Forms.DataGridView dgvPublicaciones;
        private TNGS.NetControls.GlassButton gbVerPublicacion;
        private TNGS.NetControls.GlassButton gbUltimaPagina;
        private TNGS.NetControls.GlassButton gbAvanzar;
        private TNGS.NetControls.GlassButton gbRetroceder;
        private TNGS.NetControls.GlassButton gbPrimerPagina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}