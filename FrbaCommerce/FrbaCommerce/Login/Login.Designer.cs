namespace FrbaCommerce
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.xPanel1 = new TNGS.NetControls.XPanel();
            this.gbAceptar = new TNGS.NetControls.GlassButton();
            this.gbPrimerIngreso = new TNGS.NetControls.GlassButton();
            this.teContrasenia = new TNGS.NetControls.TextEdit();
            this.teUsuario = new TNGS.NetControls.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.xPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanel1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.xPanel1.Controls.Add(this.gbAceptar);
            this.xPanel1.Controls.Add(this.gbPrimerIngreso);
            this.xPanel1.Controls.Add(this.teContrasenia);
            this.xPanel1.Controls.Add(this.teUsuario);
            this.xPanel1.Controls.Add(this.label2);
            this.xPanel1.Controls.Add(this.label1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(291, 146);
            this.xPanel1.SkinFixed = true;
            this.xPanel1.TabIndex = 0;
            // 
            // gbAceptar
            // 
            this.gbAceptar.FixedImage = TNGS.NetControls.FixedGlassButtons.Accept;
            this.gbAceptar.Location = new System.Drawing.Point(180, 103);
            this.gbAceptar.Name = "gbAceptar";
            this.gbAceptar.Size = new System.Drawing.Size(99, 26);
            this.gbAceptar.TabIndex = 5;
            this.gbAceptar.Text = "Ingresar";
            this.gbAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbAceptar.Click += new System.EventHandler(this.gbAceptar_Click);
            // 
            // gbPrimerIngreso
            // 
            this.gbPrimerIngreso.FixedImage = TNGS.NetControls.FixedGlassButtons.Access;
            this.gbPrimerIngreso.Location = new System.Drawing.Point(26, 103);
            this.gbPrimerIngreso.Name = "gbPrimerIngreso";
            this.gbPrimerIngreso.Size = new System.Drawing.Size(117, 26);
            this.gbPrimerIngreso.TabIndex = 4;
            this.gbPrimerIngreso.Text = "Primer Ingreso";
            this.gbPrimerIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gbPrimerIngreso.Click += new System.EventHandler(this.gbPrimerIngreso_Click);
            // 
            // teContrasenia
            // 
            this.teContrasenia.BackColor = System.Drawing.SystemColors.Window;
            this.teContrasenia.Location = new System.Drawing.Point(118, 57);
            this.teContrasenia.Name = "teContrasenia";
            this.teContrasenia.Size = new System.Drawing.Size(143, 20);
            this.teContrasenia.TabIndex = 3;
            this.teContrasenia.UseSystemPasswordChar = true;
            this.teContrasenia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.teContrasenia_KeyPress);
            // 
            // teUsuario
            // 
            this.teUsuario.BackColor = System.Drawing.SystemColors.Window;
            this.teUsuario.Location = new System.Drawing.Point(118, 21);
            this.teUsuario.Name = "teUsuario";
            this.teUsuario.Size = new System.Drawing.Size(143, 20);
            this.teUsuario.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 146);
            this.Controls.Add(this.xPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TNGS.NetControls.XPanel xPanel1;
        private TNGS.NetControls.TextEdit teContrasenia;
        private TNGS.NetControls.TextEdit teUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private TNGS.NetControls.GlassButton gbAceptar;
        private TNGS.NetControls.GlassButton gbPrimerIngreso;
    }
}