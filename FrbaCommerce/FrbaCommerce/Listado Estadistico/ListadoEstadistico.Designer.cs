namespace FrbaCommerce
{
    partial class ListadoEstadistico
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoEstadistico));
            this.xPanel1 = new TNGS.NetControls.XPanel();
            this.imgParametros = new TNGS.NetControls.ImgGroup();
            this.gbEstadistica = new TNGS.NetControls.GlassButton();
            this.imgGrillaEstadistica = new TNGS.NetControls.ImgGroup();
            this.dgvEstadistica = new System.Windows.Forms.DataGridView();
            this.gbAceptar = new TNGS.NetControls.GlassButton();
            this.cbTrimestres = new System.Windows.Forms.ComboBox();
            this.cbTipos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.neAnio = new TNGS.NetControls.NumberEdit();
            this.xPanel1.SuspendLayout();
            this.imgParametros.SuspendLayout();
            this.imgGrillaEstadistica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadistica)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanel1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.xPanel1.Controls.Add(this.imgParametros);
            this.xPanel1.Controls.Add(this.imgGrillaEstadistica);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(767, 541);
            this.xPanel1.SkinFixed = true;
            this.xPanel1.TabIndex = 1;
            // 
            // imgParametros
            // 
            this.imgParametros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgParametros.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.imgParametros.BackgroundGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.imgParametros.BackgroundGradientMode = TNGS.NetControls.ImgGroup.GroupBoxGradientMode.ForwardDiagonal;
            this.imgParametros.BorderColor = System.Drawing.Color.Black;
            this.imgParametros.BorderThickness = 1F;
            this.imgParametros.Controls.Add(this.neAnio);
            this.imgParametros.Controls.Add(this.label3);
            this.imgParametros.Controls.Add(this.label2);
            this.imgParametros.Controls.Add(this.label1);
            this.imgParametros.Controls.Add(this.cbTipos);
            this.imgParametros.Controls.Add(this.cbTrimestres);
            this.imgParametros.Controls.Add(this.gbEstadistica);
            this.imgParametros.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.imgParametros.FontTitle = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgParametros.GroupImage = null;
            this.imgParametros.GroupTitle = "Parámetros";
            this.imgParametros.Location = new System.Drawing.Point(12, 10);
            this.imgParametros.Name = "imgParametros";
            this.imgParametros.Padding = new System.Windows.Forms.Padding(20);
            this.imgParametros.PaintGroupBox = false;
            this.imgParametros.RoundCorners = 10;
            this.imgParametros.ShadowColor = System.Drawing.Color.DarkGray;
            this.imgParametros.ShadowControl = false;
            this.imgParametros.ShadowThickness = 3;
            this.imgParametros.Size = new System.Drawing.Size(743, 154);
            this.imgParametros.SkinFixed = true;
            this.imgParametros.TabIndex = 6;
            // 
            // gbEstadistica
            // 
            this.gbEstadistica.FixedImage = TNGS.NetControls.FixedGlassButtons.Chart1;
            this.gbEstadistica.Location = new System.Drawing.Point(306, 105);
            this.gbEstadistica.Name = "gbEstadistica";
            this.gbEstadistica.Size = new System.Drawing.Size(104, 26);
            this.gbEstadistica.TabIndex = 15;
            this.gbEstadistica.Text = "Estadística";
            this.gbEstadistica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbEstadistica.Click += new System.EventHandler(this.gbEstadistica_Click);
            // 
            // imgGrillaEstadistica
            // 
            this.imgGrillaEstadistica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgGrillaEstadistica.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.imgGrillaEstadistica.BackgroundGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.imgGrillaEstadistica.BackgroundGradientMode = TNGS.NetControls.ImgGroup.GroupBoxGradientMode.ForwardDiagonal;
            this.imgGrillaEstadistica.BorderColor = System.Drawing.Color.Black;
            this.imgGrillaEstadistica.BorderThickness = 1F;
            this.imgGrillaEstadistica.Controls.Add(this.dgvEstadistica);
            this.imgGrillaEstadistica.Controls.Add(this.gbAceptar);
            this.imgGrillaEstadistica.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.imgGrillaEstadistica.Enabled = false;
            this.imgGrillaEstadistica.FontTitle = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgGrillaEstadistica.GroupImage = null;
            this.imgGrillaEstadistica.GroupTitle = "";
            this.imgGrillaEstadistica.Location = new System.Drawing.Point(12, 170);
            this.imgGrillaEstadistica.Name = "imgGrillaEstadistica";
            this.imgGrillaEstadistica.Padding = new System.Windows.Forms.Padding(20);
            this.imgGrillaEstadistica.PaintGroupBox = false;
            this.imgGrillaEstadistica.RoundCorners = 10;
            this.imgGrillaEstadistica.ShadowColor = System.Drawing.Color.DarkGray;
            this.imgGrillaEstadistica.ShadowControl = false;
            this.imgGrillaEstadistica.ShadowThickness = 3;
            this.imgGrillaEstadistica.Size = new System.Drawing.Size(743, 361);
            this.imgGrillaEstadistica.SkinFixed = true;
            this.imgGrillaEstadistica.TabIndex = 7;
            // 
            // dgvEstadistica
            // 
            this.dgvEstadistica.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvEstadistica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstadistica.Location = new System.Drawing.Point(23, 23);
            this.dgvEstadistica.Name = "dgvEstadistica";
            this.dgvEstadistica.ReadOnly = true;
            this.dgvEstadistica.Size = new System.Drawing.Size(697, 269);
            this.dgvEstadistica.TabIndex = 13;
            // 
            // gbAceptar
            // 
            this.gbAceptar.FixedImage = TNGS.NetControls.FixedGlassButtons.Accept;
            this.gbAceptar.Location = new System.Drawing.Point(616, 311);
            this.gbAceptar.Name = "gbAceptar";
            this.gbAceptar.Size = new System.Drawing.Size(104, 26);
            this.gbAceptar.TabIndex = 12;
            this.gbAceptar.Text = "Aceptar";
            this.gbAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbAceptar.Click += new System.EventHandler(this.gbAceptar_Click);
            // 
            // cbTrimestres
            // 
            this.cbTrimestres.FormattingEnabled = true;
            this.cbTrimestres.Location = new System.Drawing.Point(280, 66);
            this.cbTrimestres.Name = "cbTrimestres";
            this.cbTrimestres.Size = new System.Drawing.Size(162, 21);
            this.cbTrimestres.TabIndex = 17;
            // 
            // cbTipos
            // 
            this.cbTipos.FormattingEnabled = true;
            this.cbTipos.Location = new System.Drawing.Point(492, 67);
            this.cbTipos.Name = "cbTipos";
            this.cbTipos.Size = new System.Drawing.Size(238, 21);
            this.cbTipos.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(144, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(324, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "Trimestre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(587, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "Tipo";
            // 
            // neAnio
            // 
            this.neAnio.BackColor = System.Drawing.SystemColors.Window;
            this.neAnio.Location = new System.Drawing.Point(114, 67);
            this.neAnio.Name = "neAnio";
            this.neAnio.Size = new System.Drawing.Size(100, 20);
            this.neAnio.TabIndex = 22;
            this.neAnio.Text = "0";
            // 
            // ListadoEstadistico
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
            this.Name = "ListadoEstadistico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado Estadístico";
            this.xPanel1.ResumeLayout(false);
            this.imgParametros.ResumeLayout(false);
            this.imgParametros.PerformLayout();
            this.imgGrillaEstadistica.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadistica)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TNGS.NetControls.XPanel xPanel1;
        internal TNGS.NetControls.ImgGroup imgParametros;
        internal TNGS.NetControls.GlassButton gbEstadistica;
        internal TNGS.NetControls.ImgGroup imgGrillaEstadistica;
        private System.Windows.Forms.DataGridView dgvEstadistica;
        internal TNGS.NetControls.GlassButton gbAceptar;
        private TNGS.NetControls.NumberEdit neAnio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTipos;
        private System.Windows.Forms.ComboBox cbTrimestres;
    }
}