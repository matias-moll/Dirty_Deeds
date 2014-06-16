namespace FrbaCommerce
{
    partial class Publicacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Publicacion));
            this.xPanel1 = new TNGS.NetControls.XPanel();
            this.imgModo = new TNGS.NetControls.ImgGroup();
            this.gbEditarPublicacion = new TNGS.NetControls.GlassButton();
            this.gbNuevaPublicacion = new TNGS.NetControls.GlassButton();
            this.imgPublicacion = new TNGS.NetControls.ImgGroup();
            this.label7 = new System.Windows.Forms.Label();
            this.gbActiva = new TNGS.NetControls.GlassButton();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbPausar = new TNGS.NetControls.GlassButton();
            this.gbFinalizar = new TNGS.NetControls.GlassButton();
            this.gbBorrador = new TNGS.NetControls.GlassButton();
            this.gbAceptar = new TNGS.NetControls.GlassButton();
            this.gbCancelar = new TNGS.NetControls.GlassButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.teDescripcion = new TNGS.NetControls.TextEdit();
            this.cbVisibilidades = new System.Windows.Forms.ComboBox();
            this.rbAceptaPreguntas = new System.Windows.Forms.RadioButton();
            this.cbTipos = new System.Windows.Forms.ComboBox();
            this.dcePrecio = new TNGS.NetControls.DecimalEdit();
            this.neStock = new TNGS.NetControls.NumberEdit();
            this.xPanel1.SuspendLayout();
            this.imgModo.SuspendLayout();
            this.imgPublicacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanel1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.xPanel1.Controls.Add(this.imgModo);
            this.xPanel1.Controls.Add(this.imgPublicacion);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(767, 541);
            this.xPanel1.SkinFixed = true;
            this.xPanel1.TabIndex = 1;
            // 
            // imgModo
            // 
            this.imgModo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgModo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.imgModo.BackgroundGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.imgModo.BackgroundGradientMode = TNGS.NetControls.ImgGroup.GroupBoxGradientMode.ForwardDiagonal;
            this.imgModo.BorderColor = System.Drawing.Color.Black;
            this.imgModo.BorderThickness = 1F;
            this.imgModo.Controls.Add(this.gbEditarPublicacion);
            this.imgModo.Controls.Add(this.gbNuevaPublicacion);
            this.imgModo.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.imgModo.FontTitle = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgModo.GroupImage = null;
            this.imgModo.GroupTitle = "";
            this.imgModo.Location = new System.Drawing.Point(12, 8);
            this.imgModo.Name = "imgModo";
            this.imgModo.Padding = new System.Windows.Forms.Padding(20);
            this.imgModo.PaintGroupBox = false;
            this.imgModo.RoundCorners = 10;
            this.imgModo.ShadowColor = System.Drawing.Color.DarkGray;
            this.imgModo.ShadowControl = false;
            this.imgModo.ShadowThickness = 3;
            this.imgModo.Size = new System.Drawing.Size(743, 60);
            this.imgModo.SkinFixed = true;
            this.imgModo.TabIndex = 0;
            // 
            // gbEditarPublicacion
            // 
            this.gbEditarPublicacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEditarPublicacion.FixedImage = TNGS.NetControls.FixedGlassButtons.Modify;
            this.gbEditarPublicacion.Location = new System.Drawing.Point(512, 23);
            this.gbEditarPublicacion.Name = "gbEditarPublicacion";
            this.gbEditarPublicacion.Size = new System.Drawing.Size(149, 26);
            this.gbEditarPublicacion.TabIndex = 1;
            this.gbEditarPublicacion.Text = "Modificar Publicación";
            this.gbEditarPublicacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbEditarPublicacion.Click += new System.EventHandler(this.gbEditarPublicacion_Click);
            // 
            // gbNuevaPublicacion
            // 
            this.gbNuevaPublicacion.FixedImage = TNGS.NetControls.FixedGlassButtons.New;
            this.gbNuevaPublicacion.Location = new System.Drawing.Point(113, 23);
            this.gbNuevaPublicacion.Name = "gbNuevaPublicacion";
            this.gbNuevaPublicacion.Size = new System.Drawing.Size(137, 26);
            this.gbNuevaPublicacion.TabIndex = 0;
            this.gbNuevaPublicacion.Text = "Nueva Publicación";
            this.gbNuevaPublicacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbNuevaPublicacion.Click += new System.EventHandler(this.gbNuevaPublicacion_Click);
            // 
            // imgPublicacion
            // 
            this.imgPublicacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgPublicacion.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.imgPublicacion.BackgroundGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.imgPublicacion.BackgroundGradientMode = TNGS.NetControls.ImgGroup.GroupBoxGradientMode.ForwardDiagonal;
            this.imgPublicacion.BorderColor = System.Drawing.Color.Black;
            this.imgPublicacion.BorderThickness = 1F;
            this.imgPublicacion.Controls.Add(this.label7);
            this.imgPublicacion.Controls.Add(this.gbActiva);
            this.imgPublicacion.Controls.Add(this.lblEstado);
            this.imgPublicacion.Controls.Add(this.label6);
            this.imgPublicacion.Controls.Add(this.gbPausar);
            this.imgPublicacion.Controls.Add(this.gbFinalizar);
            this.imgPublicacion.Controls.Add(this.gbBorrador);
            this.imgPublicacion.Controls.Add(this.gbAceptar);
            this.imgPublicacion.Controls.Add(this.gbCancelar);
            this.imgPublicacion.Controls.Add(this.label5);
            this.imgPublicacion.Controls.Add(this.label4);
            this.imgPublicacion.Controls.Add(this.label3);
            this.imgPublicacion.Controls.Add(this.label2);
            this.imgPublicacion.Controls.Add(this.label1);
            this.imgPublicacion.Controls.Add(this.teDescripcion);
            this.imgPublicacion.Controls.Add(this.cbVisibilidades);
            this.imgPublicacion.Controls.Add(this.rbAceptaPreguntas);
            this.imgPublicacion.Controls.Add(this.cbTipos);
            this.imgPublicacion.Controls.Add(this.dcePrecio);
            this.imgPublicacion.Controls.Add(this.neStock);
            this.imgPublicacion.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.imgPublicacion.Enabled = false;
            this.imgPublicacion.FontTitle = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgPublicacion.GroupImage = null;
            this.imgPublicacion.GroupTitle = "";
            this.imgPublicacion.Location = new System.Drawing.Point(12, 66);
            this.imgPublicacion.Name = "imgPublicacion";
            this.imgPublicacion.Padding = new System.Windows.Forms.Padding(20);
            this.imgPublicacion.PaintGroupBox = false;
            this.imgPublicacion.RoundCorners = 10;
            this.imgPublicacion.ShadowColor = System.Drawing.Color.DarkGray;
            this.imgPublicacion.ShadowControl = false;
            this.imgPublicacion.ShadowThickness = 3;
            this.imgPublicacion.Size = new System.Drawing.Size(743, 463);
            this.imgPublicacion.SkinFixed = true;
            this.imgPublicacion.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Cambiar Estado:";
            // 
            // gbActiva
            // 
            this.gbActiva.FixedImage = TNGS.NetControls.FixedGlassButtons.End;
            this.gbActiva.Location = new System.Drawing.Point(333, 350);
            this.gbActiva.Name = "gbActiva";
            this.gbActiva.Size = new System.Drawing.Size(104, 26);
            this.gbActiva.TabIndex = 18;
            this.gbActiva.Text = "Activa";
            this.gbActiva.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbActiva.ToolTipCheckedText = "Activa la publicación";
            this.gbActiva.Click += new System.EventHandler(this.gbActiva_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(420, 21);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 20);
            this.lblEstado.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(237, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Estado de la publicación:";
            // 
            // gbPausar
            // 
            this.gbPausar.FixedImage = TNGS.NetControls.FixedGlassButtons.Subs;
            this.gbPausar.Location = new System.Drawing.Point(472, 350);
            this.gbPausar.Name = "gbPausar";
            this.gbPausar.Size = new System.Drawing.Size(104, 26);
            this.gbPausar.TabIndex = 15;
            this.gbPausar.Text = "Pausada";
            this.gbPausar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbPausar.Click += new System.EventHandler(this.gbPausar_Click);
            // 
            // gbFinalizar
            // 
            this.gbFinalizar.FixedImage = TNGS.NetControls.FixedGlassButtons.Pay;
            this.gbFinalizar.Location = new System.Drawing.Point(600, 350);
            this.gbFinalizar.Name = "gbFinalizar";
            this.gbFinalizar.Size = new System.Drawing.Size(104, 26);
            this.gbFinalizar.TabIndex = 14;
            this.gbFinalizar.Text = "Finalizada";
            this.gbFinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbFinalizar.Click += new System.EventHandler(this.gbFinalizar_Click);
            // 
            // gbBorrador
            // 
            this.gbBorrador.FixedImage = TNGS.NetControls.FixedGlassButtons.Notepad;
            this.gbBorrador.Location = new System.Drawing.Point(194, 350);
            this.gbBorrador.Name = "gbBorrador";
            this.gbBorrador.Size = new System.Drawing.Size(104, 26);
            this.gbBorrador.TabIndex = 13;
            this.gbBorrador.Text = "Borrador";
            this.gbBorrador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbBorrador.Click += new System.EventHandler(this.gbBorrador_Click);
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
            this.gbAceptar.ToolTipCheckedText = "Activa la publicación";
            this.gbAceptar.Click += new System.EventHandler(this.gbConfirmar_Click);
            // 
            // gbCancelar
            // 
            this.gbCancelar.FixedImage = TNGS.NetControls.FixedGlassButtons.Cancel;
            this.gbCancelar.Location = new System.Drawing.Point(23, 417);
            this.gbCancelar.Name = "gbCancelar";
            this.gbCancelar.Size = new System.Drawing.Size(104, 26);
            this.gbCancelar.TabIndex = 11;
            this.gbCancelar.Text = "Cancelar";
            this.gbCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbCancelar.Click += new System.EventHandler(this.gbCancelar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(315, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Descripción";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(421, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Visibilidad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tipo:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(289, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Precio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cantidad:";
            // 
            // teDescripcion
            // 
            this.teDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.teDescripcion.BackColor = System.Drawing.SystemColors.Window;
            this.teDescripcion.Location = new System.Drawing.Point(23, 166);
            this.teDescripcion.MaxLength = 250;
            this.teDescripcion.Multiline = true;
            this.teDescripcion.Name = "teDescripcion";
            this.teDescripcion.Size = new System.Drawing.Size(697, 168);
            this.teDescripcion.TabIndex = 5;
            // 
            // cbVisibilidades
            // 
            this.cbVisibilidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVisibilidades.FormattingEnabled = true;
            this.cbVisibilidades.Location = new System.Drawing.Point(503, 105);
            this.cbVisibilidades.Name = "cbVisibilidades";
            this.cbVisibilidades.Size = new System.Drawing.Size(217, 21);
            this.cbVisibilidades.TabIndex = 4;
            // 
            // rbAceptaPreguntas
            // 
            this.rbAceptaPreguntas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbAceptaPreguntas.AutoSize = true;
            this.rbAceptaPreguntas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAceptaPreguntas.Location = new System.Drawing.Point(547, 55);
            this.rbAceptaPreguntas.Name = "rbAceptaPreguntas";
            this.rbAceptaPreguntas.Size = new System.Drawing.Size(133, 20);
            this.rbAceptaPreguntas.TabIndex = 2;
            this.rbAceptaPreguntas.TabStop = true;
            this.rbAceptaPreguntas.Text = "Acepta Preguntas";
            this.rbAceptaPreguntas.UseVisualStyleBackColor = true;
            // 
            // cbTipos
            // 
            this.cbTipos.FormattingEnabled = true;
            this.cbTipos.Location = new System.Drawing.Point(82, 105);
            this.cbTipos.Name = "cbTipos";
            this.cbTipos.Size = new System.Drawing.Size(202, 21);
            this.cbTipos.TabIndex = 3;
            // 
            // dcePrecio
            // 
            this.dcePrecio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dcePrecio.BackColor = System.Drawing.SystemColors.Window;
            this.dcePrecio.Location = new System.Drawing.Point(350, 55);
            this.dcePrecio.MaxLength = 13;
            this.dcePrecio.Name = "dcePrecio";
            this.dcePrecio.Size = new System.Drawing.Size(100, 20);
            this.dcePrecio.TabIndex = 1;
            this.dcePrecio.Text = "0.00";
            // 
            // neStock
            // 
            this.neStock.BackColor = System.Drawing.SystemColors.Window;
            this.neStock.Location = new System.Drawing.Point(100, 54);
            this.neStock.Name = "neStock";
            this.neStock.Size = new System.Drawing.Size(100, 20);
            this.neStock.TabIndex = 0;
            this.neStock.Text = "0";
            // 
            // Publicacion
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
            this.Name = "Publicacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Publicacion";
            this.xPanel1.ResumeLayout(false);
            this.imgModo.ResumeLayout(false);
            this.imgPublicacion.ResumeLayout(false);
            this.imgPublicacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal TNGS.NetControls.XPanel xPanel1;
        internal TNGS.NetControls.ImgGroup imgPublicacion;
        internal TNGS.NetControls.GlassButton gbEditarPublicacion;
        internal TNGS.NetControls.GlassButton gbNuevaPublicacion;
        internal TNGS.NetControls.ImgGroup imgModo;
        internal TNGS.NetControls.NumberEdit neStock;
        internal TNGS.NetControls.TextEdit teDescripcion;
        internal System.Windows.Forms.ComboBox cbVisibilidades;
        internal System.Windows.Forms.RadioButton rbAceptaPreguntas;
        internal System.Windows.Forms.ComboBox cbTipos;
        internal TNGS.NetControls.DecimalEdit dcePrecio;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal TNGS.NetControls.GlassButton gbAceptar;
        internal TNGS.NetControls.GlassButton gbCancelar;
        internal TNGS.NetControls.GlassButton gbPausar;
        internal TNGS.NetControls.GlassButton gbFinalizar;
        internal TNGS.NetControls.GlassButton gbBorrador;
        internal System.Windows.Forms.Label lblEstado;
        internal System.Windows.Forms.Label label6;
        internal TNGS.NetControls.GlassButton gbActiva;
        internal System.Windows.Forms.Label label7;
    }
}