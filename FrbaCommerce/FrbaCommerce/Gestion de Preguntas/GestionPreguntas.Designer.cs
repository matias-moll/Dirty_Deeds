namespace FrbaCommerce
{
    partial class GestionPreguntas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionPreguntas));
            this.xPanel1 = new TNGS.NetControls.XPanel();
            this.imgBotonera = new TNGS.NetControls.ImgGroup();
            this.gbVerRespuestas = new TNGS.NetControls.GlassButton();
            this.gbResponderPreguntas = new TNGS.NetControls.GlassButton();
            this.imgGrillaOperacional = new TNGS.NetControls.ImgGroup();
            this.gbAceptar = new TNGS.NetControls.GlassButton();
            this.dgvPreguntas = new System.Windows.Forms.DataGridView();
            this.gbResponder = new TNGS.NetControls.GlassButton();
            this.xPanel1.SuspendLayout();
            this.imgBotonera.SuspendLayout();
            this.imgGrillaOperacional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreguntas)).BeginInit();
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
            this.imgBotonera.Controls.Add(this.gbVerRespuestas);
            this.imgBotonera.Controls.Add(this.gbResponderPreguntas);
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
            this.imgBotonera.TabIndex = 2;
            // 
            // gbVerRespuestas
            // 
            this.gbVerRespuestas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbVerRespuestas.FixedImage = TNGS.NetControls.FixedGlassButtons.Grid;
            this.gbVerRespuestas.Location = new System.Drawing.Point(512, 23);
            this.gbVerRespuestas.Name = "gbVerRespuestas";
            this.gbVerRespuestas.Size = new System.Drawing.Size(130, 26);
            this.gbVerRespuestas.TabIndex = 1;
            this.gbVerRespuestas.Text = "Ver Respuestas";
            this.gbVerRespuestas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbVerRespuestas.Click += new System.EventHandler(this.gbVerRespuestas_Click);
            // 
            // gbResponderPreguntas
            // 
            this.gbResponderPreguntas.FixedImage = TNGS.NetControls.FixedGlassButtons.Help;
            this.gbResponderPreguntas.Location = new System.Drawing.Point(113, 23);
            this.gbResponderPreguntas.Name = "gbResponderPreguntas";
            this.gbResponderPreguntas.Size = new System.Drawing.Size(153, 26);
            this.gbResponderPreguntas.TabIndex = 0;
            this.gbResponderPreguntas.Text = "Responder Preguntas";
            this.gbResponderPreguntas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbResponderPreguntas.Click += new System.EventHandler(this.gbResponderPreguntas_Click);
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
            this.imgGrillaOperacional.Controls.Add(this.gbResponder);
            this.imgGrillaOperacional.Controls.Add(this.dgvPreguntas);
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
            this.imgGrillaOperacional.TabIndex = 3;
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
            // dgvPreguntas
            // 
            this.dgvPreguntas.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreguntas.Location = new System.Drawing.Point(23, 23);
            this.dgvPreguntas.Name = "dgvPreguntas";
            this.dgvPreguntas.ReadOnly = true;
            this.dgvPreguntas.Size = new System.Drawing.Size(697, 375);
            this.dgvPreguntas.TabIndex = 13;
            // 
            // gbResponder
            // 
            this.gbResponder.FixedImage = TNGS.NetControls.FixedGlassButtons.Note;
            this.gbResponder.Location = new System.Drawing.Point(23, 414);
            this.gbResponder.Name = "gbResponder";
            this.gbResponder.Size = new System.Drawing.Size(147, 26);
            this.gbResponder.TabIndex = 14;
            this.gbResponder.Text = "Responder Pregunta";
            this.gbResponder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbResponder.Click += new System.EventHandler(this.gbResponder_Click);
            // 
            // GestionPreguntas
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
            this.Name = "GestionPreguntas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion de Preguntas";
            this.xPanel1.ResumeLayout(false);
            this.imgBotonera.ResumeLayout(false);
            this.imgGrillaOperacional.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreguntas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TNGS.NetControls.XPanel xPanel1;
        internal TNGS.NetControls.ImgGroup imgBotonera;
        internal TNGS.NetControls.GlassButton gbVerRespuestas;
        internal TNGS.NetControls.GlassButton gbResponderPreguntas;
        internal TNGS.NetControls.ImgGroup imgGrillaOperacional;
        internal TNGS.NetControls.GlassButton gbAceptar;
        internal TNGS.NetControls.GlassButton gbResponder;
        private System.Windows.Forms.DataGridView dgvPreguntas;
    }
}