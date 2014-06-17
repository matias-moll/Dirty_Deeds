using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Factura
    {
        private DataAccessObject<Factura> daoFactura;

        public int campoNumero { get; set; }
        public DateTime campoFecha { get; set; }
        public decimal campoTotal { get; set; }
        public int campoIdFormaPago { get; set; }

        #region Constructores

        public Factura() { daoFactura = new DataAccessObject<Factura>(); }

        public Factura(DateTime fecha, int idFormaPago) : this()
        {
            campoFecha = fecha;
            campoIdFormaPago = idFormaPago;
        }
        #endregion

        //Metodos publicos
        public void save()
        {
            daoFactura.insert(this);
        }

        public static int getCodigoSiguienteFactura()
        {
            int numero = StaticDataAccess.executeIntFunction("GetSiguienteCodigoFactura");
            if (numero == 0)
                throw new Exception("Error al intentar obtener el siguiente código de publicacion");
            return numero;
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<Factura>.delete(idClavePrimaria);
        }

        public static List<Factura> upFull()
        {
            return DataAccessObject<Factura>.upFull();
        }

        public void update()
        {
            daoFactura.update(this);
        }

        public DataTable upFullByPrototype()
        {
            return DataAccessObject<Factura>.upFullOnTableByPrototype(this);
        }

        public static Factura get(int idClavePrimaria)
        {
            return DataAccessObject<Factura>.get(idClavePrimaria);
        }
    }
}
