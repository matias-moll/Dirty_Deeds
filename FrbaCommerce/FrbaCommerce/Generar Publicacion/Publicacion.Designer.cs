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
            this.gbNuevaPublicacion = new TNGS.NetControls.GlassButton();
            this.gbEditarPublicacion = new TNGS.NetControls.GlassButton();
            this.imgPublicacion = new TNGS.NetControls.ImgGroup();
            this.imgModo = new TNGS.NetControls.ImgGroup();
            this.neStock = new TNGS.NetControls.NumberEdit();
            this.dcePrecio = new TNGS.NetControls.DecimalEdit();
            this.cbTipos = new System.Windows.Forms.ComboBox();
            this.rbAceptaPreguntas = new System.Windows.Forms.RadioButton();
            this.cbVisibilidades = new System.Windows.Forms.ComboBox();
            this.teDescripcion = new TNGS.NetControls.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbConfirmar = new TNGS.NetControls.GlassButton();
            this.gbCancelar = new TNGS.NetControls.GlassButton();
            this.xPanel1.SuspendLayout();
            this.imgPublicacion.SuspendLayout();
            this.imgModo.SuspendLayout();
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
            this.xPanel1.Size = new System.Drawing.Size(619, 554);
            this.xPanel1.SkinFixed = true;
            this.xPanel1.TabIndex = 1;
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
            // gbEditarPublicacion
            // 
            this.gbEditarPublicacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEditarPublicacion.FixedImage = TNGS.NetControls.FixedGlassButtons.Modify;
            this.gbEditarPublicacion.Location = new System.Drawing.Point(364, 23);
            this.gbEditarPublicacion.Name = "gbEditarPublicacion";
            this.gbEditarPublicacion.Size = new System.Drawing.Size(149, 26);
            this.gbEditarPublicacion.TabIndex = 1;
            this.gbEditarPublicacion.Text = "Modificar Publicación";
            this.gbEditarPublicacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbEditarPublicacion.Click += new System.EventHandler(this.gbEditarPublicacion_Click);
            // 
            // imgPublicacion
            // 
            this.imgPublicacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgPublicacion.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.imgPublicacion.BackgroundGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.imgPublicacion.BackgroundGradientMode = TNGS.NetControls.ImgGroup.GroupBoxGradientMode.ForwardDiagonal;
            this.imgPublicacion.BorderColor = System.Drawing.Color.Black;
            this.imgPublicacion.BorderThickness = 1F;
            this.imgPublicacion.Controls.Add(this.gbConfirmar);
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
            this.imgPublicacion.Size = new System.Drawing.Size(595, 476);
            this.imgPublicacion.SkinFixed = true;
            this.imgPublicacion.TabIndex = 1;
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
            this.imgModo.Size = new System.Drawing.Size(595, 60);
            this.imgModo.SkinFixed = true;
            this.imgModo.TabIndex = 0;
            // 
            // neStock
            // 
            this.neStock.BackColor = System.Drawing.SystemColors.Window;
            this.neStock.Location = new System.Drawing.Point(100, 39);
            this.neStock.Name = "neStock";
            this.neStock.Size = new System.Drawing.Size(100, 20);
            this.neStock.TabIndex = 0;
            this.neStock.Text = "0";
            // 
            // dcePrecio
            // 
            this.dcePrecio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dcePrecio.BackColor = System.Drawing.SystemColors.Window;
            this.dcePrecio.Location = new System.Drawing.Point(287, 39);
            this.dcePrecio.MaxLength = 13;
            this.dcePrecio.Name = "dcePrecio";
            this.dcePrecio.Size = new System.Drawing.Size(100, 20);
            this.dcePrecio.TabIndex = 1;
            this.dcePrecio.Text = "0.00";
            // 
            // cbTipos
            // 
            this.cbTipos.FormattingEnabled = true;
            this.cbTipos.Location = new System.Drawing.Point(82, 90);
            this.cbTipos.Name = "cbTipos";
            this.cbTipos.Size = new System.Drawing.Size(168, 21);
            this.cbTipos.TabIndex = 3;
            // 
            // rbAceptaPreguntas
            // 
            this.rbAceptaPreguntas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbAceptaPreguntas.AutoSize = true;
            this.rbAceptaPreguntas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAceptaPreguntas.Location = new System.Drawing.Point(428, 38);
            this.rbAceptaPreguntas.Name = "rbAceptaPreguntas";
            this.rbAceptaPreguntas.Size = new System.Drawing.Size(133, 20);
            this.rbAceptaPreguntas.TabIndex = 2;
            this.rbAceptaPreguntas.TabStop = true;
            this.rbAceptaPreguntas.Text = "Acepta Preguntas";
            this.rbAceptaPreguntas.UseVisualStyleBackColor = true;
            // 
            // cbVisibilidades
            // 
            this.cbVisibilidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVisibilidades.FormattingEnabled = true;
            this.cbVisibilidades.Location = new System.Drawing.Point(384, 90);
            this.cbVisibilidades.Name = "cbVisibilidades";
            this.cbVisibilidades.Size = new System.Drawing.Size(177, 21);
            this.cbVisibilidades.TabIndex = 4;
            // 
            // teDescripcion
            // 
            this.teDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.teDescripcion.BackColor = System.Drawing.SystemColors.Window;
            this.teDescripcion.Location = new System.Drawing.Point(23, 179);
            this.teDescripcion.MaxLength = 250;
            this.teDescripcion.Multiline = true;
            this.teDescripcion.Name = "teDescripcion";
            this.teDescripcion.Size = new System.Drawing.Size(549, 249);
            this.teDescripcion.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cantidad:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Precio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tipo:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(302, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Visibilidad:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(242, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Descripción";
            // 
            // gbConfirmar
            // 
            this.gbConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConfirmar.FixedImage = TNGS.NetControls.FixedGlassButtons.Accept;
            this.gbConfirmar.Location = new System.Drawing.Point(428, 442);
            this.gbConfirmar.Name = "gbConfirmar";
            this.gbConfirmar.Size = new System.Drawing.Size(104, 26);
            this.gbConfirmar.TabIndex = 12;
            this.gbConfirmar.Text = "Confirmar";
            this.gbConfirmar.Click += new System.EventHandler(this.gbConfirmar_Click);
            // 
            // gbCancelar
            // 
            this.gbCancelar.FixedImage = TNGS.NetControls.FixedGlassButtons.Cancel;
            this.gbCancelar.Location = new System.Drawing.Point(63, 442);
            this.gbCancelar.Name = "gbCancelar";
            this.gbCancelar.Size = new System.Drawing.Size(104, 26);
            this.gbCancelar.TabIndex = 11;
            this.gbCancelar.Text = "Cancelar";
            this.gbCancelar.Click += new System.EventHandler(this.gbCancelar_Click);
            // 
            // Publicacion
            // 
            this.AllowEndUserDocking = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 554);
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
            this.imgPublicacion.ResumeLayout(false);
            this.imgPublicacion.PerformLayout();
            this.imgModo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TNGS.NetControls.XPanel xPanel1;
        private TNGS.NetControls.ImgGroup imgPublicacion;
        private TNGS.NetControls.GlassButton gbEditarPublicacion;
        private TNGS.NetControls.GlassButton gbNuevaPublicacion;
        private TNGS.NetControls.ImgGroup imgModo;
        private TNGS.NetControls.NumberEdit neStock;
        private TNGS.NetControls.TextEdit teDescripcion;
        private System.Windows.Forms.ComboBox cbVisibilidades;
        private System.Windows.Forms.RadioButton rbAceptaPreguntas;
        private System.Windows.Forms.ComboBox cbTipos;
        private TNGS.NetControls.DecimalEdit dcePrecio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private TNGS.NetControls.GlassButton gbConfirmar;
        private TNGS.NetControls.GlassButton gbCancelar;
    }
}