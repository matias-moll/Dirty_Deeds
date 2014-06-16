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
        // Miembros
        private DockPanel dockManager = null;
        private bool debeCerrarse;
        private int idRolUsuarioLoggeado;
        private Usuario usuarioLoggeado;

        ComprarOfertar dockComprarOfertar = new ComprarOfertar();

        // Constructor y load de la pantalla.
        public Mainframe()
        {
            InitializeComponent();
            debeCerrarse = false;
            // Esta rutina es recursiva hasta que logre hacer un login satisfactorio
            iniciarLogin();
        }

        private void Mainframe_Load(object sender, EventArgs e)
        {
            // Si el usuario cancelo el login debemos cerrar la aplicacion.
            if (debeCerrarse)
                this.Close();

            CreateDockManager();

            // En este punto el usuario ya esta loggeado.
            DatosGlobales.seLoggeoElUsuario(usuarioLoggeado);

            abrirDockeablesSegunFuncionalidadesHabilitadas();

            abrirDockeablesSegunTipoUsuario();
        }

        #region Metodos Privados

        private void iniciarLogin()
        {
            try
            {
                Login logeo = new Login();
                logeo.ShowDialog(this);

                if (logeo.DialogResult == DialogResult.OK)
                {
                    idRolUsuarioLoggeado = logeo.idRolUsuario;
                    usuarioLoggeado = logeo.usuarioLoggeado;
                }
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
            dockManager.Location = new Point(0, 0);
            dockManager.Name = "dockManagerControl";
            dockManager.Size = this.Size;
            dockManager.TabIndex = 10;
            dockManager.BackgroundImageLayout = BackgroundImageLayout;
            dockManager.BackgroundImage = BackgroundImage;
            dockManager.SimAppWorkspace = false;
            dockManager.DocumentStyle = DocumentStyle.DockingMdi;
            BackgroundImage = null;
            dockManager.AllowEndUserDocking = false;
            dockManager.AllowDrop = false;
            dockManager.AllowEndUserNestedDocking = false;

            // Lo agregamos a la ventana
            Controls.Add(dockManager);
            Refresh();
        }


        #region Metodos de apertura de dockeables

        private void abrirDockeablesSegunTipoUsuario()
        {
            if (usuarioLoggeado.campoDiscriminante == "C")
                abrirDockeablesCliente();
            else if (usuarioLoggeado.campoDiscriminante == "E")
                abrirDockeablesEmpresa();
        }

        private void abrirDockeablesEmpresa()
        {
            
        }

        private void abrirDockeablesCliente()
        {
            
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
                case 1: dockComprarOfertar.Show(dockManager); break;
                case 2: new Publicacion().Show(dockManager); break;
                case 3: new Facturacion().Show(dockManager); break;
                case 4: new HistorialCliente().Show(dockManager); break;
                case 5: new ListadoEstadistico().Show(dockManager); break;
            }
        }

        #endregion

        #endregion

    }
}
