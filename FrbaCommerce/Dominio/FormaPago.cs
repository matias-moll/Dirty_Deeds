using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class FormaPago
    {
        private DataAccessObject<FormaPago> daoFormaPago;

        public int autoId { get; set; }
        public string campoDescripcion { get; set; }

        #region Constructores

        public FormaPago() { daoFormaPago = new DataAccessObject<FormaPago>(); }

        public FormaPago(string descripcion) : this()
        {
            campoDescripcion = descripcion;
        }

        #endregion

        //Metodos publicos
        public void save()
        {
            daoFormaPago.insert(this);
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<FormaPago>.delete(idClavePrimaria);
        }


        public static List<FormaPago> upFull()
        {
            return DataAccessObject<FormaPago>.upFull();
        }

        public void update()
        {
            daoFormaPago.update(this);
        }

        public DataTable upFullByPrototype()
        {
            return DataAccessObject<FormaPago>.upFullOnTableByPrototype(this);
        }

        public static FormaPago get(int idClavePrimaria)
        {
            return DataAccessObject<FormaPago>.get(idClavePrimaria);
        }
    }
}
