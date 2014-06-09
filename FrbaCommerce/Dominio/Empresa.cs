using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Empresa
    {
        //Miembros
        private DataAccessObject<Empresa> daoEmpresa;
        private DateTime fechaIngreso;

        // Properties con la convencion del DataAccessObject
        public int autoId { get; set; }
        public string campoRazonSocial { get; set; }
        public string campoCuit { get; set; }
        public string campoMail { get; set; }
        public string campoNombreContacto { get; set; }
        public bool campoDeleted { get; set; }
        public DateTime campoFechaIngreso { get; set; }


        #region Constructores
        public Empresa() { daoEmpresa = new DataAccessObject<Empresa>(); }

        public Empresa(string razonSocial, string cuit, DateTime fechaIngreso, string mail, 
                       string nombreContacto, bool p_deleted) : this()
        {
            campoRazonSocial = razonSocial;
            campoCuit = cuit;
            campoFechaIngreso = fechaIngreso;
            campoMail = mail;
            campoNombreContacto = nombreContacto;
            campoDeleted = p_deleted;
        }

        public Empresa(string razonSocial, string cuit, DateTime fechaIngreso, string mail, string nombreContacto)
            : this(razonSocial,cuit, fechaIngreso, mail, nombreContacto, false) { }

        #endregion


        //Metodos publicos
        public static Empresa get(int idClavePrimaria)
        {
            return DataAccessObject<Empresa>.get(idClavePrimaria);
        }

        public void save()
        {
            daoEmpresa.insert(this);
        }

        public void update()
        {
            daoEmpresa.update(this);
        }

        public DataTable upFullByPrototype()
        {
            return daoEmpresa.upFullOnTableByPrototype(this);
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<Empresa>.delete(idClavePrimaria);
        }

        public void borradoLogico()
        {
            campoDeleted = !campoDeleted;
            update();
        }
}
}
