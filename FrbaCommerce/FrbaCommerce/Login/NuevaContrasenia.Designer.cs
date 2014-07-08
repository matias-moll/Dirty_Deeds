namespace FrbaCommerce
{
    partial class NuevaContrasenia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevaContrasenia));
            this.xPanel1 = new TNGS.NetControls.XPanel();
            this.gbAceptar = new TNGS.NetControls.GlassButton();
            this.gbCancelar = new TNGS.NetControls.GlassButton();
            this.teContrasenia = new TNGS.NetControls.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.xPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanel1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.xPanel1.Controls.Add(this.gbAceptar);
            this.xPanel1.Controls.Add(this.gbCancelar);
            this.xPanel1.Controls.Add(this.teContrasenia);
            this.xPanel1.Controls.Add(this.label2);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(292, 121);
            this.xPanel1.SkinFixed = true;
            this.xPanel1.TabIndex = 0;
            // 
            // gbAceptar
            // 
            this.gbAceptar.FixedImage = TNGS.NetControls.FixedGlassButtons.Accept;
            this.gbAceptar.Location = new System.Drawing.Point(178, 75);
            this.gbAceptar.Name = "gbAceptar";
            this.gbAceptar.Size = new System.Drawing.Size(99, 26);
            this.gbAceptar.TabIndex = 9;
            this.gbAceptar.Text = "Ingresar";
            this.gbAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbAceptar.Click += new System.EventHandler(this.gbAceptar_Click);
            // 
            // gbCancelar
            // 
            this.gbCancelar.FixedImage = TNGS.NetControls.FixedGlassButtons.Cancel;
            this.gbCancelar.Location = new System.Drawing.Point(24, 75);
            this.gbCancelar.Name = "gbCancelar";
            this.gbCancelar.Size = new System.Drawing.Size(104, 26);
            this.gbCancelar.TabIndex = 8;
            this.gbCancelar.Text = "Cancelar";
            this.gbCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbCancelar.Click += new System.EventHandler(this.gbCancelar_Click);
            // 
            // teContrasenia
            // 
            this.teContrasenia.BackColor = System.Drawing.SystemColors.Window;
            this.teContrasenia.Location = new System.Drawing.Point(116, 29);
            this.teContrasenia.Name = "teContrasenia";
            this.teContrasenia.Size = new System.Drawing.Size(143, 20);
            this.teContrasenia.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Contraseña:";
            // 
            // NuevaContrasenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 121);
            this.Controls.Add(this.xPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NuevaContrasenia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Contraseña";
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TNGS.NetControls.XPanel xPanel1;
        private TNGS.NetControls.GlassButton gbAceptar;
        private TNGS.NetControls.GlassButton gbCancelar;
        private TNGS.NetControls.TextEdit teContrasenia;
        private System.Windows.Forms.Label label2;
    }
}