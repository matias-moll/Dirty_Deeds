using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Dominio;

namespace FrbaCommerce
{
    public partial class Mainframe : Form
    {
        private DockPanel dockManager = null;
        private bool debeCerrarse;
        private int idRolUsuarioLoggeado;

        public Mainframe()
        {
            InitializeComponent();
            CreateDockManager();
            debeCerrarse = false;
            // Esta rutina es recursiva hasta que logre hacer un login satisfactorio
            iniciarLogin();
        }

        private void iniciarLogin()
        {
            try
            {
                Login logeo = new Login();
                logeo.ShowDialog(this);

                if (logeo.DialogResult == DialogResult.OK)
                    idRolUsuarioLoggeado = logeo.idRolUsuario;
                else
                    debeCerrarse = true;

            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                iniciarLogin();
            }
        }

        private void CreateDockManager()
        {
            // Creamos el DockManager
            dockManager = new DockPanel();
            dockManager.ActiveAutoHideContent = null;
            dockManager.Location = new Point(0,0);
            dockManager.Name = "dockManagerControl";
            dockManager.Size = this.Size;
            dockManager.TabIndex = 10;
            dockManager.BackgroundImageLayout = BackgroundImageLayout;
            dockManager.BackgroundImage = BackgroundImage;
            dockManager.SimAppWorkspace = false;
            dockManager.DocumentStyle = DocumentStyle.DockingMdi;
            BackgroundImage = null;


            // Lo agregamos a la ventana
            Controls.Add(dockManager);
        }

        private void Mainframe_Load(object sender, EventArgs e)
        {
            if (debeCerrarse)
                this.Close();

            // En este punto el usuario ya esta loggeado.
            abrirDockeablesSegunFuncionalidadesHabilitadas();

            abrirDockeablesSegunTipoUsuario();
        }

        private void abrirDockeablesSegunTipoUsuario()
        {
            throw new NotImplementedException();
        }

        private void abrirDockeablesSegunFuncionalidadesHabilitadas()
        {
            Rol_Funcionalidad unPrototipo = new Rol_Funcionalidad();
            unPrototipo.campoIdRol = idRolUsuarioLoggeado;
            List<Rol_Funcionalidad> funcionalidadesPermitidas = unPrototipo.getListByPrototype();
            foreach (Rol_Funcionalidad unaFuncionalidad in funcionalidadesPermitidas)
                agregarDockeableCorrespondiente(unaFuncionalidad);
        }

        private void agregarDockeableCorrespondiente(Rol_Funcionalidad unaFuncionalidad)
        {
            switch (unaFuncionalidad.campoIdFuncionalidad)
            {
                case 1: this.addCon.Checked = true; break;
                case 2: cbGenEditPublicacion.Checked = true; break;
                case 3: cbFactPublicaciones.Checked = true; break;
                case 4: cbHistorialCliente.Checked = true; break;
                case 5: cbEstadisticas.Checked = true; break;
            }
        }
    }
}
