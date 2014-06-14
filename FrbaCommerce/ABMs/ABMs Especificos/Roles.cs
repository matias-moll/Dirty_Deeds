using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Dominio;
using System.Drawing;
using TNGS.NetControls;

namespace ABMs
{
    class Roles : ABMEspecifico
    {

        TextEdit teNombre = new TextEdit();
        CheckBox cbComprarOfertar = new CheckBox();
        CheckBox cbGenEditPublicacion = new CheckBox();
        CheckBox cbFactPublicaciones = new CheckBox();
        CheckBox cbHistorialCliente = new CheckBox();
        CheckBox cbEstadisticas = new CheckBox();

        public override DataTable ejecutarBusqueda()
        {
            // Creamos el rol y lo mandamos a buscar.
            Rol unRol = new Rol(teNombre.Text);
            return unRol.upFullByPrototype();
        }

        public override void cargarTusDatos(int p_idClavePrimaria)
        {
            Rol unRol = Rol.get(p_idClavePrimaria);
            teNombre.Text = unRol.campoNombre;

            Rol_Funcionalidad relacionRolFunc = new Rol_Funcionalidad();
            relacionRolFunc.campoIdRol = p_idClavePrimaria;
            cargarCheckedCorrespondientes(relacionRolFunc.getListByPrototype());
        }
        protected override void grabarAlta()
        {
            // Creamos el rol y lo mandamos a grabar.
            Rol unRol = new Rol(teNombre.Text);
            int idRol = unRol.save();

            // Grabamos las funcionalidades correspondientes segun haya elegido el usuario en pantalla.
            grabarFuncionalidades(idRol);
        }

        private void grabarFuncionalidades(int idRol)
        {
            grabarRelacionRolFuncionalidad(idRol, cbComprarOfertar, "ComprarOfertar");
            grabarRelacionRolFuncionalidad(idRol, cbEstadisticas, "Estadisticas");
            grabarRelacionRolFuncionalidad(idRol, cbFactPublicaciones, "Facturacion");
            grabarRelacionRolFuncionalidad(idRol, cbGenEditPublicacion, "GenEditPublicacion");
            grabarRelacionRolFuncionalidad(idRol, cbHistorialCliente, "HistorialCliente");
        }

        private void grabarRelacionRolFuncionalidad(int idRol, CheckBox cbFuncionalidad, string nombreFuncionalidad)
        {
            Rol_Funcionalidad relacionRolFunc = new Rol_Funcionalidad();
            relacionRolFunc.campoIdRol = idRol;
            if (cbFuncionalidad.Checked)
            {
                relacionRolFunc.campoIdFuncionalidad = Funcionalidad.funcionalidades[nombreFuncionalidad];
                relacionRolFunc.save();
            }
        }

        protected override void grabarModificacion(int idClaveObjetoAModificar)
        {
            // Creamos el rol a partir de los datos de la pantalla y el id que tenemos guardado y lo mandamos a actualizar.
            Rol unRol = new Rol(teNombre.Text);
            unRol.autoId = idClaveObjetoAModificar;
            unRol.update();

            // Actualizamos la nueva seleccion.
            Rol_Funcionalidad.delete(idClaveObjetoAModificar);
            grabarFuncionalidades(idClaveObjetoAModificar);
        }

        protected override void baja(int idClavePrimaria)
        {
            Rol_Funcionalidad.delete(idClavePrimaria);
            Rol.delete(idClavePrimaria);
        }

        private void cargarCheckedCorrespondientes(List<Rol_Funcionalidad> list)
        {
            foreach (Rol_Funcionalidad unaFuncionalidad in list)
            {
                switch (unaFuncionalidad.campoIdFuncionalidad)
                {
                    case 1: cbComprarOfertar.Checked = true; break;
                    case 2: cbGenEditPublicacion.Checked = true; break;
                    case 3: cbFactPublicaciones.Checked = true; break;
                    case 4: cbHistorialCliente.Checked = true; break;
                    case 5: cbEstadisticas.Checked = true; break;
                }
            }
        }

        protected override void bajaLogica(int idClavePrimaria)
        {
            Rol unRol = Rol.get(idClavePrimaria);
            unRol.borradoLogico();
        }

        public override Panel getPanel(Size tamañoPanel)
        {
            PanelBuilder builder = new PanelBuilder(tamañoPanel, PanelBuilder.Alineacion.Horizontal);
            builder.AddControlWithLabel("Nombre", teNombre)
                   .centrarControlesEnElPanel();

            return builder.getPanel;
        }

        public override Panel getPanelAlta()
        {
            limpiarCheckBoxes(new List<CheckBox>(){cbComprarOfertar, cbEstadisticas, cbFactPublicaciones, cbGenEditPublicacion, cbHistorialCliente});
            PanelBuilder builder = new PanelBuilder(new Size(350, 400), PanelBuilder.Alineacion.Horizontal);
            builder.AddControlWithLabel("Nombre", teNombre)
                   .AddControlWithLabel("Comprar/Ofertar", cbComprarOfertar)
                   .AddControlWithLabel("Estadísticas", cbEstadisticas)
                   .AddControlWithLabel("Facturación", cbFactPublicaciones)
                   .AddControlWithLabel("Publicaciones", cbGenEditPublicacion)
                   .AddControlWithLabel("Historial Cliente", cbHistorialCliente)
                   .centrarControlesEnElPanel();

            return builder.getPanel;
        }

        private void limpiarCheckBoxes(List<CheckBox> list)
        {
            foreach (CheckBox cb in list)
                cb.Checked = false;
        }

    }
}
