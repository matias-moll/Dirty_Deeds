namespace FrbaCommerce
{
    partial class Calificar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calificar));
            this.xPanel1 = new TNGS.NetControls.XPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEstrellas = new System.Windows.Forms.ComboBox();
            this.teComentario = new TNGS.NetControls.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.gbAceptar = new TNGS.NetControls.GlassButton();
            this.gbCancelar = new TNGS.NetControls.GlassButton();
            this.xPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanel1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.xPanel1.Controls.Add(this.label1);
            this.xPanel1.Controls.Add(this.cbEstrellas);
            this.xPanel1.Controls.Add(this.teComentario);
            this.xPanel1.Controls.Add(this.label2);
            this.xPanel1.Controls.Add(this.gbAceptar);
            this.xPanel1.Controls.Add(this.gbCancelar);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(292, 307);
            this.xPanel1.SkinFixed = true;
            this.xPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Estrellas:";
            // 
            // cbEstrellas
            // 
            this.cbEstrellas.FormattingEnabled = true;
            this.cbEstrellas.Location = new System.Drawing.Point(90, 12);
            this.cbEstrellas.Name = "cbEstrellas";
            this.cbEstrellas.Size = new System.Drawing.Size(186, 21);
            this.cbEstrellas.TabIndex = 17;
            // 
            // teComentario
            // 
            this.teComentario.BackColor = System.Drawing.SystemColors.Window;
            this.teComentario.Location = new System.Drawing.Point(24, 94);
            this.teComentario.MaxLength = 254;
            this.teComentario.Multiline = true;
            this.teComentario.Name = "teComentario";
            this.teComentario.Size = new System.Drawing.Size(252, 134);
            this.teComentario.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(104, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Comentario:";
            // 
            // gbAceptar
            // 
            this.gbAceptar.FixedImage = TNGS.NetControls.FixedGlassButtons.Accept;
            this.gbAceptar.Location = new System.Drawing.Point(172, 261);
            this.gbAceptar.Name = "gbAceptar";
            this.gbAceptar.Size = new System.Drawing.Size(104, 26);
            this.gbAceptar.TabIndex = 14;
            this.gbAceptar.Text = "Aceptar";
            this.gbAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbAceptar.Click += new System.EventHandler(this.gbAceptar_Click);
            // 
            // gbCancelar
            // 
            this.gbCancelar.FixedImage = TNGS.NetControls.FixedGlassButtons.Cancel;
            this.gbCancelar.Location = new System.Drawing.Point(24, 261);
            this.gbCancelar.Name = "gbCancelar";
            this.gbCancelar.Size = new System.Drawing.Size(104, 26);
            this.gbCancelar.TabIndex = 13;
            this.gbCancelar.Text = "Cancelar";
            this.gbCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbCancelar.Click += new System.EventHandler(this.gbCancelar_Click);
            // 
            // Calificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 307);
            this.Controls.Add(this.xPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Calificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calificar";
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TNGS.NetControls.XPanel xPanel1;
        internal TNGS.NetControls.GlassButton gbAceptar;
        internal TNGS.NetControls.GlassButton gbCancelar;
        private TNGS.NetControls.TextEdit teComentario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEstrellas;
    }
}