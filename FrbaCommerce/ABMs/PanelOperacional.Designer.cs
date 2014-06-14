namespace ABMs
{
    partial class PanelOperacional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelOperacional));
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnEmpresas = new System.Windows.Forms.Button();
            this.btnVisibilidades = new System.Windows.Forms.Button();
            this.btnLocalidades = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRoles
            // 
            this.btnRoles.BackColor = System.Drawing.Color.Transparent;
            this.btnRoles.Image = ((System.Drawing.Image)(resources.GetObject("btnRoles.Image")));
            this.btnRoles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoles.Location = new System.Drawing.Point(86, 65);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(117, 34);
            this.btnRoles.TabIndex = 1;
            this.btnRoles.Text = "Roles";
            this.btnRoles.UseVisualStyleBackColor = false;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.Transparent;
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(86, 157);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(117, 34);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnEmpresas
            // 
            this.btnEmpresas.BackColor = System.Drawing.Color.Transparent;
            this.btnEmpresas.Image = ((System.Drawing.Image)(resources.GetObject("btnEmpresas.Image")));
            this.btnEmpresas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpresas.Location = new System.Drawing.Point(326, 157);
            this.btnEmpresas.Name = "btnEmpresas";
            this.btnEmpresas.Size = new System.Drawing.Size(117, 34);
            this.btnEmpresas.TabIndex = 3;
            this.btnEmpresas.Text = "Empresas";
            this.btnEmpresas.UseVisualStyleBackColor = false;
            this.btnEmpresas.Click += new System.EventHandler(this.btnEmpresas_Click);
            // 
            // btnVisibilidades
            // 
            this.btnVisibilidades.BackColor = System.Drawing.Color.Transparent;
            this.btnVisibilidades.Image = ((System.Drawing.Image)(resources.GetObject("btnVisibilidades.Image")));
            this.btnVisibilidades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisibilidades.Location = new System.Drawing.Point(326, 65);
            this.btnVisibilidades.Name = "btnVisibilidades";
            this.btnVisibilidades.Size = new System.Drawing.Size(117, 34);
            this.btnVisibilidades.TabIndex = 5;
            this.btnVisibilidades.Text = "Visibilidades";
            this.btnVisibilidades.UseVisualStyleBackColor = false;
            this.btnVisibilidades.Click += new System.EventHandler(this.btnVisibilidades_Click);
            // 
            // btnLocalidades
            // 
            this.btnLocalidades.BackColor = System.Drawing.Color.Transparent;
            this.btnLocalidades.Image = ((System.Drawing.Image)(resources.GetObject("btnLocalidades.Image")));
            this.btnLocalidades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocalidades.Location = new System.Drawing.Point(326, 250);
            this.btnLocalidades.Name = "btnLocalidades";
            this.btnLocalidades.Size = new System.Drawing.Size(117, 34);
            this.btnLocalidades.TabIndex = 6;
            this.btnLocalidades.Text = "Localidades";
            this.btnLocalidades.UseVisualStyleBackColor = false;
            this.btnLocalidades.Click += new System.EventHandler(this.btnLocalidades_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(86, 250);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(117, 34);
            this.btnUsuarios.TabIndex = 7;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            // 
            // PanelOperacional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(537, 363);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.btnLocalidades);
            this.Controls.Add(this.btnVisibilidades);
            this.Controls.Add(this.btnEmpresas);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnRoles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PanelOperacional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel Operacional";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnEmpresas;
        private System.Windows.Forms.Button btnVisibilidades;
        private System.Windows.Forms.Button btnLocalidades;
        private System.Windows.Forms.Button btnUsuarios;
    }
}