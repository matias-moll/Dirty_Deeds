namespace FrbaCommerce
{
    partial class HistorialCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialCliente));
            this.xPanel1 = new TNGS.NetControls.XPanel();
            this.imgBotonera = new TNGS.NetControls.ImgGroup();
            this.gbCompras = new TNGS.NetControls.GlassButton();
            this.imgGrillaOperacional = new TNGS.NetControls.ImgGroup();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.gbAceptar = new TNGS.NetControls.GlassButton();
            this.gbOfertas = new TNGS.NetControls.GlassButton();
            this.gbCalificaciones = new TNGS.NetControls.GlassButton();
            this.xPanel1.SuspendLayout();
            this.imgBotonera.SuspendLayout();
            this.imgGrillaOperacional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanel1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.xPanel1.Controls.Add(this.imgBotonera);
            this.xPanel1.Controls.Add(this.imgGrillaOperacional);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(767, 541);
            this.xPanel1.SkinFixed = true;
            this.xPanel1.TabIndex = 1;
            // 
            // imgBotonera
            // 
            this.imgBotonera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgBotonera.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.imgBotonera.BackgroundGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.imgBotonera.BackgroundGradientMode = TNGS.NetControls.ImgGroup.GroupBoxGradientMode.ForwardDiagonal;
            this.imgBotonera.BorderColor = System.Drawing.Color.Black;
            this.imgBotonera.BorderThickness = 1F;
            this.imgBotonera.Controls.Add(this.gbCalificaciones);
            this.imgBotonera.Controls.Add(this.gbOfertas);
            this.imgBotonera.Controls.Add(this.gbCompras);
            this.imgBotonera.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.imgBotonera.FontTitle = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgBotonera.GroupImage = null;
            this.imgBotonera.GroupTitle = "";
            this.imgBotonera.Location = new System.Drawing.Point(12, 10);
            this.imgBotonera.Name = "imgBotonera";
            this.imgBotonera.Padding = new System.Windows.Forms.Padding(20);
            this.imgBotonera.PaintGroupBox = false;
            this.imgBotonera.RoundCorners = 10;
            this.imgBotonera.ShadowColor = System.Drawing.Color.DarkGray;
            this.imgBotonera.ShadowControl = false;
            this.imgBotonera.ShadowThickness = 3;
            this.imgBotonera.Size = new System.Drawing.Size(743, 60);
            this.imgBotonera.SkinFixed = true;
            this.imgBotonera.TabIndex = 4;
            // 
            // gbCompras
            // 
            this.gbCompras.FixedImage = TNGS.NetControls.FixedGlassButtons.Money;
            this.gbCompras.Location = new System.Drawing.Point(126, 23);
            this.gbCompras.Name = "gbCompras";
            this.gbCompras.Size = new System.Drawing.Size(104, 26);
            this.gbCompras.TabIndex = 0;
            this.gbCompras.Text = "Compras";
            this.gbCompras.Click += new System.EventHandler(this.gbCompras_Click);
            // 
            // imgGrillaOperacional
            // 
            this.imgGrillaOperacional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgGrillaOperacional.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.imgGrillaOperacional.BackgroundGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.imgGrillaOperacional.BackgroundGradientMode = TNGS.NetControls.ImgGroup.GroupBoxGradientMode.ForwardDiagonal;
            this.imgGrillaOperacional.BorderColor = System.Drawing.Color.Black;
            this.imgGrillaOperacional.BorderThickness = 1F;
            this.imgGrillaOperacional.Controls.Add(this.dgvHistorial);
            this.imgGrillaOperacional.Controls.Add(this.gbAceptar);
            this.imgGrillaOperacional.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.imgGrillaOperacional.Enabled = false;
            this.imgGrillaOperacional.FontTitle = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgGrillaOperacional.GroupImage = null;
            this.imgGrillaOperacional.GroupTitle = "";
            this.imgGrillaOperacional.Location = new System.Drawing.Point(12, 68);
            this.imgGrillaOperacional.Name = "imgGrillaOperacional";
            this.imgGrillaOperacional.Padding = new System.Windows.Forms.Padding(20);
            this.imgGrillaOperacional.PaintGroupBox = false;
            this.imgGrillaOperacional.RoundCorners = 10;
            this.imgGrillaOperacional.ShadowColor = System.Drawing.Color.DarkGray;
            this.imgGrillaOperacional.ShadowControl = false;
            this.imgGrillaOperacional.ShadowThickness = 3;
            this.imgGrillaOperacional.Size = new System.Drawing.Size(743, 463);
            this.imgGrillaOperacional.SkinFixed = true;
            this.imgGrillaOperacional.TabIndex = 5;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(23, 23);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.Size = new System.Drawing.Size(697, 375);
            this.dgvHistorial.TabIndex = 13;
            // 
            // gbAceptar
            // 
            this.gbAceptar.FixedImage = TNGS.NetControls.FixedGlassButtons.Accept;
            this.gbAceptar.Location = new System.Drawing.Point(616, 417);
            this.gbAceptar.Name = "gbAceptar";
            this.gbAceptar.Size = new System.Drawing.Size(104, 26);
            this.gbAceptar.TabIndex = 12;
            this.gbAceptar.Text = "Aceptar";
            this.gbAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbAceptar.Click += new System.EventHandler(this.gbAceptar_Click);
            // 
            // gbOfertas
            // 
            this.gbOfertas.FixedImage = TNGS.NetControls.FixedGlassButtons.Pay;
            this.gbOfertas.Location = new System.Drawing.Point(321, 23);
            this.gbOfertas.Name = "gbOfertas";
            this.gbOfertas.Size = new System.Drawing.Size(104, 26);
            this.gbOfertas.TabIndex = 2;
            this.gbOfertas.Text = "Ofertas";
            this.gbOfertas.Click += new System.EventHandler(this.gbOfertas_Click);
            // 
            // gbCalificaciones
            // 
            this.gbCalificaciones.FixedImage = TNGS.NetControls.FixedGlassButtons.Audit;
            this.gbCalificaciones.Location = new System.Drawing.Point(523, 23);
            this.gbCalificaciones.Name = "gbCalificaciones";
            this.gbCalificaciones.Size = new System.Drawing.Size(117, 26);
            this.gbCalificaciones.TabIndex = 15;
            this.gbCalificaciones.Text = "Calificaciones";
            this.gbCalificaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbCalificaciones.Click += new System.EventHandler(this.gbCalificaciones_Click);
            // 
            // HistorialCliente
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
            this.Name = "HistorialCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Historial Cliente";
            this.xPanel1.ResumeLayout(false);
            this.imgBotonera.ResumeLayout(false);
            this.imgGrillaOperacional.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TNGS.NetControls.XPanel xPanel1;
        internal TNGS.NetControls.ImgGroup imgBotonera;
        internal TNGS.NetControls.GlassButton gbOfertas;
        internal TNGS.NetControls.GlassButton gbCompras;
        internal TNGS.NetControls.ImgGroup imgGrillaOperacional;
        private System.Windows.Forms.DataGridView dgvHistorial;
        internal TNGS.NetControls.GlassButton gbAceptar;
        internal TNGS.NetControls.GlassButton gbCalificaciones;
    }
}