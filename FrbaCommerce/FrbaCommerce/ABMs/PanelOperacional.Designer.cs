namespace FrbaCommerce
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
            this.xPanel1 = new TNGS.NetControls.XPanel();
            this.xPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRoles
            // 
            this.btnRoles.BackColor = System.Drawing.Color.Transparent;
            this.btnRoles.Image = ((System.Drawing.Image)(resources.GetObject("btnRoles.Image")));
            this.btnRoles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoles.Location = new System.Drawing.Point(212, 99);
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
            this.btnClientes.Location = new System.Drawing.Point(212, 360);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(117, 34);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnEmpresas
            // 
            this.btnEmpresas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmpresas.BackColor = System.Drawing.Color.Transparent;
            this.btnEmpresas.Image = ((System.Drawing.Image)(resources.GetObject("btnEmpresas.Image")));
            this.btnEmpresas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpresas.Location = new System.Drawing.Point(452, 360);
            this.btnEmpresas.Name = "btnEmpresas";
            this.btnEmpresas.Size = new System.Drawing.Size(117, 34);
            this.btnEmpresas.TabIndex = 3;
            this.btnEmpresas.Text = "Empresas";
            this.btnEmpresas.UseVisualStyleBackColor = false;
            this.btnEmpresas.Click += new System.EventHandler(this.btnEmpresas_Click);
            // 
            // btnVisibilidades
            // 
            this.btnVisibilidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisibilidades.BackColor = System.Drawing.Color.Transparent;
            this.btnVisibilidades.Image = ((System.Drawing.Image)(resources.GetObject("btnVisibilidades.Image")));
            this.btnVisibilidades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisibilidades.Location = new System.Drawing.Point(452, 99);
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
            this.btnLocalidades.Location = new System.Drawing.Point(212, 225);
            this.btnLocalidades.Name = "btnLocalidades";
            this.btnLocalidades.Size = new System.Drawing.Size(117, 34);
            this.btnLocalidades.TabIndex = 6;
            this.btnLocalidades.Text = "Localidades";
            this.btnLocalidades.UseVisualStyleBackColor = false;
            this.btnLocalidades.Click += new System.EventHandler(this.btnLocalidades_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsuarios.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(452, 225);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(117, 34);
            this.btnUsuarios.TabIndex = 7;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // xPanel1
            // 
            this.xPanel1.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanel1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.xPanel1.Controls.Add(this.btnVisibilidades);
            this.xPanel1.Controls.Add(this.btnUsuarios);
            this.xPanel1.Controls.Add(this.btnRoles);
            this.xPanel1.Controls.Add(this.btnLocalidades);
            this.xPanel1.Controls.Add(this.btnClientes);
            this.xPanel1.Controls.Add(this.btnEmpresas);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(769, 543);
            this.xPanel1.SkinFixed = true;
            this.xPanel1.TabIndex = 8;
            // 
            // PanelOperacional
            // 
            this.AllowEndUserDocking = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(769, 543);
            this.Controls.Add(this.xPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PanelOperacional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel Operacional";
            this.xPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnEmpresas;
        private System.Windows.Forms.Button btnVisibilidades;
        private System.Windows.Forms.Button btnLocalidades;
        private System.Windows.Forms.Button btnUsuarios;
        private TNGS.NetControls.XPanel xPanel1;
    }
}