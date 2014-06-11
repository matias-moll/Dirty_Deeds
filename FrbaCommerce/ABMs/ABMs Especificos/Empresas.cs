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
    class Empresas : ABMEspecifico
    {
        // Campos para la empresa
        TextEdit teRazonSocial = new TextEdit();
        CuitEdit ceCuit = new CuitEdit();
        DateTimeEdit dteFechaIngreso = new DateTimeEdit();
        TextEdit teMail = new TextEdit();
        TextEdit teNombreContacto = new TextEdit();

        // Campos para la direccion
        TextEdit teDomicilio = new TextEdit();
        NumberEdit neNroCalle = new NumberEdit();
        NumberEdit nePiso = new NumberEdit();
        TextEdit teDepto = new TextEdit();
        ComboBox cbLocalidades = new ComboBox();

        public Empresas()
        {
            // Cargamos la lista de localidades.
            cbLocalidades.DataSource = Localidad.upFull();
            cbLocalidades.DisplayMember = "campoNombre";
            cbLocalidades.ValueMember = "autoId";

            // Solo lectura.
            cbLocalidades.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public override DataTable ejecutarBusqueda()
        {
            // Creamos el Empresa y lo mandamos a buscar.
            Empresa unEmpresa = crearEmpresaFromCamposGUI();
            return unEmpresa.upFullByPrototype();
        }

        public override void cargarTusDatos(int p_idClavePrimaria)
        {
            Empresa unaEmpresa = Empresa.get(p_idClavePrimaria);
            teRazonSocial.Text = unaEmpresa.campoRazonSocial;
            ceCuit.Text = unaEmpresa.campoCuit;
            dteFechaIngreso.FechaHora = unaEmpresa.campoFechaIngreso;
            teMail.Text = unaEmpresa.campoMail;
            teNombreContacto.Text = unaEmpresa.campoNombreContacto;
        }

        protected override void grabarAlta()
        {
            // Creamos el Empresa y lo mandamos a grabar.
            Empresa unEmpresa = crearEmpresaFromCamposGUI();
            unEmpresa.save();
        }

        protected override void grabarModificacion(int idClaveObjetoAModificar)
        {
            // Creamos el Empresa a partir de los datos de la pantalla y el id que tenemos guardado y lo mandamos a actualizar.
            Empresa unEmpresa = crearEmpresaFromCamposGUI();
            unEmpresa.autoId = idClaveObjetoAModificar;
            unEmpresa.update();
        }

        protected override void baja(int idClavePrimaria)
        {
            Empresa.delete(idClavePrimaria);
        }

        protected override void bajaLogica(int idClavePrimaria)
        {
            Empresa unEmpresa = Empresa.get(idClavePrimaria);
            unEmpresa.borradoLogico();
        }

        public override Panel getPanel(Size tamañoPanel)
        {
            PanelBuilder builder = new PanelBuilder(tamañoPanel, PanelBuilder.Alineacion.Horizontal);
            builder.AddControlWithLabel("Razón Social", teRazonSocial)
                   .AddControlWithLabel("Cuit", ceCuit)
                   .AddControlWithLabel("Fecha Ingreso", dteFechaIngreso)
                   .AddControlWithLabel("Mail", teMail)
                   .AddControlWithLabel("Contacto", teNombreContacto)
                   .AddControlWithLabel("Dirección", teDomicilio)
                   .AddControlWithLabel("Nro. Calle", neNroCalle)
                   .AddControlWithLabel("Piso", nePiso)
                   .AddControlWithLabel("Departamento", teDepto)
                   .AddControlWithLabel("Localidad", cbLocalidades)
                   .centrarControlesEnElPanel();

            return builder.getPanel;
        }

        private Empresa crearEmpresaFromCamposGUI()
        {
            return new Empresa(teRazonSocial.Text, ceCuit.Text, dteFechaIngreso.FechaHora,
                                            teMail.Text, teNombreContacto.Text);
        }
    }
}
