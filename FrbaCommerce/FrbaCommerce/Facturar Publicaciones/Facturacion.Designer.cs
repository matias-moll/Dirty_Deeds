﻿namespace FrbaCommerce
{
    partial class Facturacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Facturacion));
            this.xPanel1 = new TNGS.NetControls.XPanel();
            this.imgBotonera = new TNGS.NetControls.ImgGroup();
            this.gbCargarPublicacionesARendir = new TNGS.NetControls.GlassButton();
            this.imgGrillaOperacional = new TNGS.NetControls.ImgGroup();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFacturar = new TNGS.NetControls.GlassButton();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.gbAceptar = new TNGS.NetControls.GlassButton();
            this.xPanel1.SuspendLayout();
            this.imgBotonera.SuspendLayout();
            this.imgGrillaOperacional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
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
            this.imgBotonera.Controls.Add(this.gbCargarPublicacionesARendir);
            this.imgBotonera.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.imgBotonera.FontTitle = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgBotonera.GroupImage = null;
            this.imgBotonera.GroupTitle = "";
            this.imgBotonera.Location = new System.Drawing.Point(12, 7);
            this.imgBotonera.Name = "imgBotonera";
            this.imgBotonera.Padding = new System.Windows.Forms.Padding(20);
            this.imgBotonera.PaintGroupBox = false;
            this.imgBotonera.RoundCorners = 10;
            this.imgBotonera.ShadowColor = System.Drawing.Color.DarkGray;
            this.imgBotonera.ShadowControl = false;
            this.imgBotonera.ShadowThickness = 3;
            this.imgBotonera.Size = new System.Drawing.Size(743, 60);
            this.imgBotonera.SkinFixed = true;
            this.imgBotonera.TabIndex = 7;
            // 
            // gbCargarPublicacionesARendir
            // 
            this.gbCargarPublicacionesARendir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCargarPublicacionesARendir.FixedImage = TNGS.NetControls.FixedGlassButtons.Grid;
            this.gbCargarPublicacionesARendir.Location = new System.Drawing.Point(254, 23);
            this.gbCargarPublicacionesARendir.Name = "gbCargarPublicacionesARendir";
            this.gbCargarPublicacionesARendir.Size = new System.Drawing.Size(204, 26);
            this.gbCargarPublicacionesARendir.TabIndex = 1;
            this.gbCargarPublicacionesARendir.Text = "Cargar Publicaciones A Rendir";
            this.gbCargarPublicacionesARendir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbCargarPublicacionesARendir.Click += new System.EventHandler(this.gbCargarPublicacionesARendir_Click);
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
            this.imgGrillaOperacional.Controls.Add(this.label1);
            this.imgGrillaOperacional.Controls.Add(this.gbFacturar);
            this.imgGrillaOperacional.Controls.Add(this.dgvVentas);
            this.imgGrillaOperacional.Controls.Add(this.gbAceptar);
            this.imgGrillaOperacional.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.imgGrillaOperacional.Enabled = false;
            this.imgGrillaOperacional.FontTitle = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgGrillaOperacional.GroupImage = null;
            this.imgGrillaOperacional.GroupTitle = "";
            this.imgGrillaOperacional.Location = new System.Drawing.Point(12, 70);
            this.imgGrillaOperacional.Name = "imgGrillaOperacional";
            this.imgGrillaOperacional.Padding = new System.Windows.Forms.Padding(20);
            this.imgGrillaOperacional.PaintGroupBox = false;
            this.imgGrillaOperacional.RoundCorners = 10;
            this.imgGrillaOperacional.ShadowColor = System.Drawing.Color.DarkGray;
            this.imgGrillaOperacional.ShadowControl = false;
            this.imgGrillaOperacional.ShadowThickness = 3;
            this.imgGrillaOperacional.Size = new System.Drawing.Size(743, 463);
            this.imgGrillaOperacional.SkinFixed = true;
            this.imgGrillaOperacional.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(238, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Ventas Pendientes de Rendimiento";
            // 
            // gbFacturar
            // 
            this.gbFacturar.FixedImage = TNGS.NetControls.FixedGlassButtons.Pay;
            this.gbFacturar.Location = new System.Drawing.Point(23, 414);
            this.gbFacturar.Name = "gbFacturar";
            this.gbFacturar.Size = new System.Drawing.Size(144, 26);
            this.gbFacturar.TabIndex = 14;
            this.gbFacturar.Text = "Rendir Facturación";
            this.gbFacturar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbFacturar.Click += new System.EventHandler(this.gbFacturar_Click);
            // 
            // dgvVentas
            // 
            this.dgvVentas.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(23, 68);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.Size = new System.Drawing.Size(697, 330);
            this.dgvVentas.TabIndex = 13;
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
            // Facturacion
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
            this.Name = "Facturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Facturación";
            this.xPanel1.ResumeLayout(false);
            this.imgBotonera.ResumeLayout(false);
            this.imgGrillaOperacional.ResumeLayout(false);
            this.imgGrillaOperacional.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TNGS.NetControls.XPanel xPanel1;
        internal TNGS.NetControls.ImgGroup imgBotonera;
        internal TNGS.NetControls.GlassButton gbCargarPublicacionesARendir;
        internal TNGS.NetControls.ImgGroup imgGrillaOperacional;
        private System.Windows.Forms.Label label1;
        internal TNGS.NetControls.GlassButton gbFacturar;
        private System.Windows.Forms.DataGridView dgvVentas;
        internal TNGS.NetControls.GlassButton gbAceptar;
    }
}